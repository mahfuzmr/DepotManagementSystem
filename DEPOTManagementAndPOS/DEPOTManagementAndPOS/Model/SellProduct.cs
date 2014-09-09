using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOTManagementAndPOS.Model
{
    class SellProduct
    {

        public Int64 SellProductId { get; set; }
        public String ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        
        

        public SellInvoice SellInvoice { get; set; }

        public SellProduct()
        {
            SellInvoice = new SellInvoice();
        }
       

        public double GetTotalPrice( int Quantity,Double UnitPrice)
        {
            return Quantity*UnitPrice;
        }


        public double GetGrandTotal(double grandTotal ,double totalPrice)
        {
            return grandTotal += totalPrice;
        }

        public double GetGrandTotalMinus(double grandTotal, double aProductTotalPrice)
        {
            return grandTotal -= aProductTotalPrice;
        }
    }
}
