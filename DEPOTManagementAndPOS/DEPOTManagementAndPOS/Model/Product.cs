using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOTManagementAndPOS.Model
{
    class Product
    {
        public Int64 ProductId { get; set; }
        public String ProductNameExtention { get; set; }

        public CategoryEntry CategoryEntry { get; set; }
        public BrandEntry BrandEntry { get; set; }

        public Product()
        {
            CategoryEntry = new CategoryEntry();
            BrandEntry = new BrandEntry();
        }





    }
}
