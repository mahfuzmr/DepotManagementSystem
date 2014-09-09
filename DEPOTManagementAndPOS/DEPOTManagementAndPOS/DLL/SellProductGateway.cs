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
    class SellProductGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SellProduct _aSellProduct;
        
        public SellProductGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;
        }
        public bool saveAllSellProductInfo(List<SellProduct> aSellProductList)
        {
            _connection.Open();
            int affectedRows = 0;
            
            foreach (var sellProduct in aSellProductList)
            {
                
                string query = string.Format("INSERT INTO SellProductTable VALUES ('{0}',{1},{2},{3},{4})", sellProduct.ItemName,
                    sellProduct.Quantity, sellProduct.UnitPrice,sellProduct.TotalPrice, sellProduct.SellInvoice.SellInvoiceId);

                _command = new SqlCommand(query, _connection);
                affectedRows = _command.ExecuteNonQuery();    
                
            }
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public List<SellProduct> GetSoldProductInfoUsingOrderNo(string id)
        {
            List<SellProduct> sellInvoiceList = new List<SellProduct>();

            _connection.Open();
            string query =
                string.Format(
                    "SELECT ItemName, Quantity, UnitPrice, TotalPrice " +
                    "FROM SellProductTable " +
                    "JOIN SellInvoiceTable " +
                    "ON SellInvoiceTable.SellInvoiceId = SellProductTable.SellInvoiceId " +
                    "WHERE SellInvoiceTable.SellOrderNo ='{0}'", id);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aSellProduct = new SellProduct();
                    _aSellProduct.ItemName = (aReader[0]).ToString();
                    _aSellProduct.Quantity = Convert.ToInt32(aReader[1]);
                    _aSellProduct.UnitPrice = Convert.ToDouble(aReader[2]);
                    _aSellProduct.TotalPrice = Convert.ToDouble(aReader[3]);


                    sellInvoiceList.Add(_aSellProduct);
                }
            }
            _connection.Close();
            return sellInvoiceList;
        }

        public bool UpdateAllSellVoiceUsingOrderNo(SellInvoice aSellInvoice)
        {
            _connection.Open();

            string query = string.Format("UPDATE SellInvoiceTable SET GrandTotalPrice={0},Paid={1},Due={2} WHERE SellOrderNo='{3}'", aSellInvoice.GrandTotal,
                aSellInvoice.Paid, aSellInvoice.Due, aSellInvoice.OrderNo);
            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }
        int matchedSellInvoiceIdwithSellOrderNo;
        public bool UpdateAllSellProductUsingOrderNo(SellProduct aSellProduct, string id)
        {
            _connection.Open();
            string queryMatchingSellInvoiceId =
                string.Format(
                    "SELECT SellInvoiceId " +
                    "FROM SellInvoiceTable " +
                    
                    "WHERE SellInvoiceTable.SellOrderNo ='{0}'", id);
            _command = new SqlCommand(queryMatchingSellInvoiceId, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    //int matchedSellInvoiceIdwithSellOrderNo;
                   matchedSellInvoiceIdwithSellOrderNo = Convert.ToInt32(aReader[0]);
                    

                    
                }
            }
            _connection.Close();







            // END of Parsing SellInvoiceID from SellInvoiceTable using SellOrderNo
            _connection.Open();

            string query =
                string.Format(
                    "UPDATE SellProductTable SET TotalPrice={0},quantity={1},UnitPrice={2} " +
                    "WHERE (SellInvoiceId={3}) AND (ItemName='{4}');",
                    aSellProduct.TotalPrice, aSellProduct.Quantity, aSellProduct.UnitPrice, matchedSellInvoiceIdwithSellOrderNo, aSellProduct.ItemName);



            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSelectRow(string selectedItemToDelete, string id)
        {
            _connection.Open();

            string query =
                string.Format("DELETE FROM SellProductTable " +
                              "WHERE (SellProductTable.ItemName= '{0}') " +
                              "AND(SellProductTable.SellInvoiceId = '{1}')", selectedItemToDelete, id);


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
