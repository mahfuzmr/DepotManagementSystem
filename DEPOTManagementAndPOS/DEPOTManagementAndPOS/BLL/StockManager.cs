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

        public bool UpdateAllStockInfoUsingList(Stock aStock)
        {
            _aStockGateway = new StockGateway();
            return _aStockGateway.UpdateAllStockInfoUsingList(aStock);
        }

        public bool UpdateStockWhenDeletingIteM(SellProduct itemToDelete)
        {
            _aStockGateway= new StockGateway();
            long currentQuantity = _aStockGateway.GetCurrentQuantityOfaProduct(itemToDelete.ItemName);

            long newQuantityOfStockAfterAddingDeletedItem = currentQuantity + itemToDelete.Quantity;

            return _aStockGateway.SellReturnStockUpdate(itemToDelete,newQuantityOfStockAfterAddingDeletedItem);



        }

        public List<Stock> ViewAllDepo()
        {
            StockGateway _aStockGateway = new StockGateway();

            return _aStockGateway.ViewAllDepo();
        }

        public bool DeleleStock(Stock aStock)
        {
            StockGateway _aStockGateway = new StockGateway();

           return  _aStockGateway.DeleleStock(aStock);
        }
    }
}
