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
    class NewBrandEntryGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private BrandEntry _aBrandEntry;

        public NewBrandEntryGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;
        }
        public bool SaveNewBrand(Model.BrandEntry aBrandEntry)
        {
            _connection.Open();
            string query = string.Format("INSERT INTO BrandEntryTable VALUES ('{0}', {1})", aBrandEntry.Name, aBrandEntry.CategoryEntry.CategoryEntryId);

            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public List<BrandEntry> GetAllBrand()
        {

            string query = "SELECT * FROM BrandEntryTable";
            SqlConnection sqlConnection = new SqlConnection(_connection.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<BrandEntry> _aneNewBrandEntryList = new List<BrandEntry>();
            while (sqlDataReader.Read())
            {
                BrandEntry aBrandEntry = new BrandEntry();
                aBrandEntry.BrandEnteyId = Convert.ToInt32(sqlDataReader[0]);
                aBrandEntry.Name = sqlDataReader[1].ToString();
                _aneNewBrandEntryList.Add(aBrandEntry);
            }
            sqlConnection.Close();
            return _aneNewBrandEntryList;
        }

        public List<BrandEntry> GetAllBrandUsingCategoryId(int categoryId)
        {
            string query = String.Format("SELECT * FROM BrandEntryTable WHERE CategoryId='{0}'",categoryId);
            SqlConnection sqlConnection = new SqlConnection(_connection.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<BrandEntry> _aneNewBrandEntryList = new List<BrandEntry>();
            while (sqlDataReader.Read())
            {
                BrandEntry aBrandEntry = new BrandEntry();
                aBrandEntry.BrandEnteyId = Convert.ToInt32(sqlDataReader[0]);
                aBrandEntry.Name = sqlDataReader[1].ToString();
                _aneNewBrandEntryList.Add(aBrandEntry);
            }
            sqlConnection.Close();
            return _aneNewBrandEntryList;
            
        }

        public string IsBrandNameAlreadyExists(string brandName)
        {
            //_connection.Open();
            //string query = string.Format("SELECT Name FROM BrandEntryTable WHERE Name = '{0}'", brandName);

            //_command = new SqlCommand(query, _connection);
            //int affectedRows = _command.ExecuteNonQuery();
            //_connection.Close();
            //if (affectedRows > 0)
            //{
            //    return true;
            //}

            //return false;
            _aBrandEntry = new BrandEntry();
            _connection.Open();
            string query = string.Format("SELECT Name FROM BrandEntryTable WHERE Name = '{0}'", brandName);

            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aBrandEntry.Name = (aReader[0]).ToString();
                }
            }
            _connection.Close();
            return _aBrandEntry.Name;
        }
    }
}
