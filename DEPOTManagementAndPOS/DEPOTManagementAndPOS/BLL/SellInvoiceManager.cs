using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class SellInvoiceManager
    {
        private SellInvoiceGateway _aSellInvoiceGateway;
        public Int64 GetInvoiceOrderNo()
        {
           _aSellInvoiceGateway = new SellInvoiceGateway();
           return _aSellInvoiceGateway.GetInvoiceOrderNo();
        }

        public bool SaveSellInvoiceInfo(SellInvoice aSellInvoice)
        {
            _aSellInvoiceGateway = new SellInvoiceGateway();

            return _aSellInvoiceGateway.SaveSellInvoiceInfo(aSellInvoice);
        }

        public long GetSellInvoiceId()
        {
            _aSellInvoiceGateway = new SellInvoiceGateway();
            return _aSellInvoiceGateway.GetSellInvoiceId();
        }

        public List<SellInvoice> GetSellReportUsingDate(string selectedDate)
        {
            _aSellInvoiceGateway = new SellInvoiceGateway();
            return _aSellInvoiceGateway.GetSellReportUsingDate(selectedDate);
        }

        public SellInvoice GetSellReportUsingOrderNo(string id)
        {
            _aSellInvoiceGateway = new SellInvoiceGateway();
            return _aSellInvoiceGateway.GetSellReportUsingOrderNo(id);
        }

        public bool UpdateAllSellVoiceUsingOrderNo(SellInvoice aSellInvoice)
        {
            _aSellInvoiceGateway = new SellInvoiceGateway();
            return _aSellInvoiceGateway.UpdateAllSellVoiceUsingOrderNo(aSellInvoice);
        }

        private SellProductGateway _aSellProductGateway;
        public bool UpdateAllSellProductUsingOrderNo(SellProduct aSellProduct,string id)
        {
            _aSellProductGateway = new SellProductGateway();
            return _aSellProductGateway.UpdateAllSellProductUsingOrderNo(aSellProduct,id);
        }
    }
}
