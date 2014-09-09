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
    class CustomerGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private Customer _aCustomer;

        public CustomerGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;
        }
        public bool SaveAllCustomerInfo(Customer newCustomer)
        {
            _connection.Open();
            string query = string.Format("INSERT INTO CustomerTable VALUES ('{0}','{1}','{2}','{3}','{4}')", 
                newCustomer.Name, newCustomer.Phone, newCustomer.AddressOfCustomer, newCustomer.ShopName, 
                newCustomer.AddressOfShop);

            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public Customer GetCustomerInfoUsingId(string id)
        {

            Customer aCustomer = new Customer();
            _connection.Open();
            string query = string.Format("SELECT * FROM CustomerTable " +
                                         "JOIN SellInvoiceTable " +
                                         "ON SellInvoiceTable.CustomerId = CustomerTable.CustomerId " +
                                         "WHERE SellOrderNo = '{0}'", id);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aCustomer.CustomerId = (long)aReader[0];
                    aCustomer.Name = (string)aReader[1];
                    aCustomer.Phone = (string)aReader[2];
                    aCustomer.ShopName = (string)aReader[4];
                    
                    
                }
            }
            _connection.Close();
            return aCustomer;
        }

        public long GetCustomerId()
        {
            _connection.Open();
            _aCustomer = new Customer();

            String query = String.Format("SELECT CustomerId FROM CustomerTable");
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aCustomer.CustomerId = Convert.ToInt64(aReader[0]);
                }

            }
            _connection.Close();
            return _aCustomer.CustomerId;
        }
    }
}
