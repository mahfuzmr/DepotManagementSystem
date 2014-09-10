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
    class StockGateway
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        private Stock _aStock;
        public StockGateway()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DepotDB"].ConnectionString;

        }

        public Stock GetCurrentStockInfo(string productNameFromTextBox)
        {
            _connection.Open();
            _aStock = new Stock();
            string query = string.Format("SELECT StockId, ProductName, QuantityInStock FROM StockTable WHERE ProductName='{0}'", productNameFromTextBox);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    _aStock.StockId = Convert.ToInt64(aReader[0]);
                    _aStock.ProductName = (aReader[1]).ToString();
                    _aStock.QuantityInStock = Convert.ToInt32(aReader[2]);



                }
            }
            _connection.Close();
            return _aStock;
        }

        public bool SaveNewStockInfo(Stock aStock)
        {
            _connection.Open();
            string query = string.Format("INSERT INTO StockTable VALUES ('{0}', {1})", aStock.ProductName,
                aStock.QuantityInStock);

            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateAllStockInfo(Stock aStock)
        {
            _connection.Open();

            string query = string.Format("UPDATE StockTable SET QuantityInStock={0} WHERE ProductName='{1}'",
                aStock.QuantityInStock, aStock.ProductName);
            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool SellReturnStockUpdate(SellProduct aProduct, long newQuantityInStock)
        {
            _connection.Open();

            string query = string.Format("UPDATE StockTable SET QuantityInStock={0} WHERE ProductName='{1}'",
                newQuantityInStock,aProduct.ItemName);
            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public long GetCurrentQuantityOfaProduct(string itemName)
        {
            _connection.Open();
            long currentQuantity=0;
            string query = string.Format("SELECT QuantityInStock FROM StockTable WHERE ProductName='{0}'", itemName);
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    currentQuantity = Convert.ToInt64(aReader[0]);
                  



                }
            }
            _connection.Close();
            return currentQuantity;
        }

        public bool UpdateAllStockInfoUsingList(Stock aStock)
        {
            _connection.Open();

            string query = string.Format("UPDATE StockTable SET QuantityInStock={0} WHERE ProductName='{1}'",
                aStock.QuantityInStock, aStock.ProductName);
            _command = new SqlCommand(query, _connection);
            int affectedRows = _command.ExecuteNonQuery();
            _connection.Close();
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public List<Stock> ViewAllDepo()
        {
            _connection.Open();
           

            List<Stock> allStockList = new List<Stock>();
            string query = string.Format("SELECT * From StockTable");
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();



            while (aReader.Read())
            {
                _aStock = new Stock();
                _aStock.ProductName = (string) (aReader[1]);
                _aStock.QuantityInStock= (int) aReader[2];
                allStockList.Add(_aStock);
            }


            _connection.Close();
            return allStockList;

        }

        public bool DeleleStock(Stock aStock)
        {

            _connection.Open();
            string query =
                string.Format("DELETE FROM StockTable " +
                              "WHERE ProductName= '{0}'",aStock.ProductName);


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
