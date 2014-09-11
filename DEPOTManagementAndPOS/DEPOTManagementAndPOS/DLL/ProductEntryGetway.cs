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
    class ProductEntryGetway
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        private Product _aProduct;
        public ProductEntryGetway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;

        }

       

        public bool SaveProductNameExtention(Product aProduct)
        {
            _connection.Open();
            string query = string.Format("INSERT INTO ProductNameExtentionEntryTable values ('{0}',{1},{2})",
                aProduct.ProductNameExtention, aProduct.CategoryEntry.CategoryEntryId, aProduct.BrandEntry.BrandEnteyId);

            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
                        
        }

        public string DoesProductNameAlreadyExist(string productExtentionName)
        {
            _aProduct = new Product();
            _connection.Open();
            string query = string.Format("SELECT ProductNameExtention FROM ProductNameExtentionEntryTable WHERE ProductNameExtention='{0}'", productExtentionName);

            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();
            
            
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aProduct.ProductNameExtention = (aReader[0]).ToString();
                }
            }
            _connection.Close();
            return _aProduct.ProductNameExtention;

        }
    }
}
