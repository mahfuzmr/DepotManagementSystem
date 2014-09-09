using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.DLL
{
    class SellInvoiceGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SellInvoice _aSellInvoice;

        public SellInvoiceGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;
        }
        public Int64 GetInvoiceOrderNo()
        {
            _connection.Open();
            _aSellInvoice = new SellInvoice();

            String query = String.Format("SELECT SellOrderNo From SellInvoiceTable WHERE SellOrderNo = ( SELECT MAX(SellOrderNo) FROM SellInvoiceTable)");
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aSellInvoice.OrderNo = Convert.ToInt64(aReader[0]);    
                }
                
                _aSellInvoice.OrderNo++;

            }
            _connection.Close();
            return _aSellInvoice.OrderNo;
        }

        public bool SaveSellInvoiceInfo(SellInvoice aSellInvoice)
        {

            _connection.Open();
            string query = string.Format("INSERT INTO SellInvoiceTable VALUES ({0},{1},{2},{3},'{4}','{5}',{6},{7})", 
                aSellInvoice.OrderNo,aSellInvoice.GrandTotal,aSellInvoice.Paid,aSellInvoice.Due,
                aSellInvoice.SellDate,aSellInvoice.CashStatus, aSellInvoice.TotalItemSold, aSellInvoice.Customer.CustomerId);

            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public long GetSellInvoiceId()
        {
            _connection.Open();
            _aSellInvoice = new SellInvoice();

            String query = String.Format("SELECT SellInvoiceId FROM SellInvoiceTable");
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aSellInvoice.SellInvoiceId = Convert.ToInt64(aReader[0]);
                }

            }
            _connection.Close();
            return _aSellInvoice.SellInvoiceId;
        }

        public List<SellInvoice> GetSellReportUsingDate(string selectedDate)
        {
            List<SellInvoice> _aSellInvoiceList = new List<SellInvoice>();
            _connection.Open();
            
            string query =
                string.Format(
                    "SELECT SellOrderNo, CustomerTable.Name, GrandTotalPrice, Paid, Due, SellDate, CashStatus, TotalItemSold " +
                    "FROM SellInvoiceTable " +
                    "JOIN CustomerTable " +
                    "ON SellInvoiceTable.CustomerId = CustomerTable.CustomerId " +
                    "WHERE SellDate = '{0}'", selectedDate);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aSellInvoice = new SellInvoice();

                    _aSellInvoice.OrderNo = Convert.ToInt64(aReader[0]);
                    _aSellInvoice.Customer.Name = aReader[1].ToString();
                    _aSellInvoice.GrandTotal = Convert.ToDouble(aReader[2]);
                    _aSellInvoice.Paid = Convert.ToDouble(aReader[3]);
                    _aSellInvoice.Due = Convert.ToDouble(aReader[4]);
                    _aSellInvoice.SellDate = aReader[5].ToString();
                    _aSellInvoice.CashStatus = aReader[6].ToString();
                    _aSellInvoice.TotalItemSold = Convert.ToInt32(aReader[7]);

                    _aSellInvoiceList.Add(_aSellInvoice);
                }
            }
            _connection.Close();
            return _aSellInvoiceList;
        }

        public SellInvoice GetSellReportUsingOrderNo(string id)
        {
            _connection.Open();
            _aSellInvoice = new SellInvoice();

            String query = String.Format("SELECT Paid, Due FROM SellInvoiceTable WHERE SellOrderNo = {0}", id);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aSellInvoice.Paid = Convert.ToDouble(aReader[0]);
                    _aSellInvoice.Due = Convert.ToDouble(aReader[1]);
                }

            }
            _connection.Close();
            return _aSellInvoice;
        }

        public bool UpdateAllSellVoiceUsingOrderNo(SellInvoice aSellInvoice)
        {
            _connection.Open();

            string query = string.Format("UPDATE SellInvoiceTable SET GrandTotalPrice={0},Paid={1},Due={2}, TotalItemSold={3} WHERE SellOrderNo='{4}'", aSellInvoice.GrandTotal,
                aSellInvoice.Paid, aSellInvoice.Due, aSellInvoice.TotalItemSold, aSellInvoice.OrderNo);
            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }
    }
}
