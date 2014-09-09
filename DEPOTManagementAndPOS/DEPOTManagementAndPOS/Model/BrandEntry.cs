using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOTManagementAndPOS.Model
{
    class BrandEntry
    {
        public int BrandEnteyId { get; set; }
        public string Name { get; set; }
        public CategoryEntry CategoryEntry { get; set; }

        public BrandEntry()
        {
            CategoryEntry = new CategoryEntry();
        }
    }
}
