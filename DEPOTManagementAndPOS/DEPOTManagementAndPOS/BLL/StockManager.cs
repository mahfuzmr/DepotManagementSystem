using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class StockManager
    {
        private StockGateway _aStockGateway;
        public Stock GetCurrentStockInfo(string productNameFromTextBox)
        {
           _aStockGateway = new StockGateway();
            return _aStockGateway.GetCurrentStockInfo(productNameFromTextBox);
        }

        public bool SaveNewStockInfo(Stock aStock)
        {
            _aStockGateway = new StockGateway();
            return _aStockGateway.SaveNewStockInfo(aStock);
        }

        public bool UpdateAllStockInfo(Stock aStock)
        {
            _aStockGateway = new StockGateway();
            return _aStockGateway.UpdateAllStockInfo(aStock);
        }

        public bool SellReturnStockUpdate(SellProduct aProduct, SellProduct aSellProduct)
        {
            _aStockGateway= new StockGateway();

            long currentQuantity = _aStockGateway.GetCurrentQuantityOfaProduct(aProduct.ItemName);

            int returnedQuantity = aProduct.Quantity - aSellProduct.Quantity;


            long newQuantityInStock = currentQuantity + returnedQuantity;

            return _aStockGateway.SellReturnStockUpdate(aProduct, newQuantityInStock);

        }

        public List<Stock> GetTotalStockInfo()
        {
            _aStockGateway = new StockGateway();
            return _aStockGateway.GetTotalStockInfo();
        }
    }
}
