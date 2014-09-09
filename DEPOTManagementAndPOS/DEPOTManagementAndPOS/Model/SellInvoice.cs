using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOTManagementAndPOS.Model
{
    class SellInvoice
    {
        public Int64 SellInvoiceId { get; set; }
        public Double GrandTotal { get; set; }
        public Double Paid { get; set; }
        public Double Due { get; set; }

        public Int64 OrderNo { get; set; }

        public string SellDate { get; set; }
        public String CashStatus { get; set; }
        public int TotalItemSold { get; set; }

        public Customer Customer { get; set; }

        public SellInvoice()
        {
            Customer = new Customer();
        }
        public double GetDue(double paid)
        {
            return GrandTotal - paid;
        }

        
    }
}
