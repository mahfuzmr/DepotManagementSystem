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
    }
}
