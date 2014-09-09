using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOTManagementAndPOS.Model
{
    class Customer
    {
        public Int64 CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string AddressOfCustomer { get; set; }
        public string ShopName { get; set; }
        public string AddressOfShop { get; set; }

    }
}
