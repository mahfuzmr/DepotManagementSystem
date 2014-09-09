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
    class CategoryEntryGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public CategoryEntryGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;

        }
        public bool SaveCategory(CategoryEntry aCategoryEntry)
        {
            _connection.Open();
            string query = string.Format("INSERT INTO CategoryEntryTable VALUES ('{0}')", aCategoryEntry.Name);

           _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }
            
            return false;
             
        }

        public List<CategoryEntry> GetAllCategory()
        {
            string query = "SELECT * FROM CategoryEntryTable";
            SqlConnection sqlConnection = new SqlConnection(_connection.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<CategoryEntry> _aCategoryEntryList = new List<CategoryEntry>();
            while (sqlDataReader.Read())
            {
                CategoryEntry _aCategoryEntry = new CategoryEntry();
                _aCategoryEntry.CategoryEntryId = Convert.ToInt32(sqlDataReader[0]);
                _aCategoryEntry.Name = sqlDataReader[1].ToString();
                _aCategoryEntryList.Add(_aCategoryEntry);
            }
            sqlConnection.Close();
            return _aCategoryEntryList;
        }
    }
}
