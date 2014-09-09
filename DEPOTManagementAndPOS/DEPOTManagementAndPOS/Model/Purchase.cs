using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;

namespace DEPOTManagementAndPOS.Model
{
    class Purchase
    {
        public Int64 PurchaseId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPurchasePrice { get; set; }
        public string DateTime { get; set; }

        public CategoryEntry CategoryEntry { get; set; }
        public BrandEntry BrandEntry { get; set; }
        public Product Product { get; set; }
        public Purchase()
        {
            CategoryEntry = new CategoryEntry();
            BrandEntry = new BrandEntry();
            Product = new Product();
        }

        public double GetTotalPurchasePrice()
        {
            return Quantity*Price;
        }

       
    }
}
