using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class PurchaseManager
    {
        private PurchaseGateway _aPurchaseGateway;
        public List<Purchase> GetProductNameWithCategoryAndBrandName()
        {
            _aPurchaseGateway = new PurchaseGateway();
            return _aPurchaseGateway.GetProductNameWithCategoryAndBrandName();
        }

        public bool SaveAllPurchaseInfo(Purchase aPurchase)
        {
            _aPurchaseGateway = new PurchaseGateway();
            return _aPurchaseGateway.SaveAllPurchaseInfo(aPurchase);
        }

        public Purchase GetCurrentStockInfo(string name)
        {
            _aPurchaseGateway=new PurchaseGateway();
            return _aPurchaseGateway.GetCurrentStockInfo(name);
        }

        public bool UpdateAllPurchaseInfo(Purchase aPurchase)
        {
            _aPurchaseGateway = new PurchaseGateway();
            return _aPurchaseGateway.UpdateAllPurchaseInfo(aPurchase);
        }
    }
}
