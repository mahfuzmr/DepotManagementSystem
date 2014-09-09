using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class ProductEntryManager
    {
        ProductEntryGetway _aProductEntryGetway = new ProductEntryGetway();
        
        public bool SaveProductNameExtention(Product aProduct)
        {
           _aProductEntryGetway = new ProductEntryGetway();
           return _aProductEntryGetway.SaveProductNameExtention(aProduct);
        }
    }
}
