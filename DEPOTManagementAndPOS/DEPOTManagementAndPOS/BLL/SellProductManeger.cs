using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    internal class SellProductManeger
    {
        private SellProductGateway _aSellProductGateway;

        public bool saveAllSellProductInfo(List<SellProduct> aSellProductList)
        {
            _aSellProductGateway = new SellProductGateway();
            return _aSellProductGateway.saveAllSellProductInfo(aSellProductList);
        }


        public List<SellProduct> GetSoldProductInfoUsingOrderNo(string id)
        {
            _aSellProductGateway = new SellProductGateway();
            return _aSellProductGateway.GetSoldProductInfoUsingOrderNo(id);
        }

        public bool UpdateAllSellVoiceUsingOrderNo(SellInvoice aSellInvoice)
        {
            _aSellProductGateway = new SellProductGateway();
            return _aSellProductGateway.UpdateAllSellVoiceUsingOrderNo(aSellInvoice);
        }

        public bool DeleteSelectRow(string selectedItemToDelete, string id)
        {
            _aSellProductGateway =new SellProductGateway();
            return _aSellProductGateway.DeleteSelectRow(selectedItemToDelete, id);
        }
    }
}
