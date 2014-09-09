using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.Model;
using iTextSharp.text;

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

        public List<Stock> GetTotalStockInfo()
        {
            _connection.Open();
            Stock aStock;
            List<Stock>aStockList=new List<Stock>();
            
            string query = string.Format("SELECT  ProductName,QuantityInStock FROM StockTable");
            _command = new SqlCommand(query, _connection);
            SqlDataReader aReader = _command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aStock=new Stock();
                    aStock.QuantityInStock = Convert.ToInt32(aReader[1]);
                    aStock.ProductName = aReader[0].ToString();
                    aStockList.Add(aStock);






                }
            }
            _connection.Close();
            return aStockList;
        }
    }
}
