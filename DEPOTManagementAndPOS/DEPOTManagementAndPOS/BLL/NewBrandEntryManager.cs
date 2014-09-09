using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class NewBrandEntryManager
    {
        private NewBrandEntryGateway _aNewBrandEntryGateway;
        public bool SaveNewBrand(BrandEntry aBrandEntry)
        {
            _aNewBrandEntryGateway = new NewBrandEntryGateway();
            return _aNewBrandEntryGateway.SaveNewBrand(aBrandEntry);
        }

        public List<BrandEntry> GetAllBrand()
        {
            _aNewBrandEntryGateway = new NewBrandEntryGateway();
            return _aNewBrandEntryGateway.GetAllBrand();
        }

        public List<BrandEntry> GetAllBrandUsingCategoryId(int CategoryId)
        {

            _aNewBrandEntryGateway = new NewBrandEntryGateway();
            return _aNewBrandEntryGateway.GetAllBrandUsingCategoryId(CategoryId);

        }
    }
}
