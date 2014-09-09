using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.BLL
{
    class CategoryEntryManager
    {
        private CategoryEntryGateway _aCategoryEntryGateway;
        public bool SaveCategory(CategoryEntry aCategoryEntry)
        {
            _aCategoryEntryGateway = new CategoryEntryGateway();

            return _aCategoryEntryGateway.SaveCategory(aCategoryEntry);
        }

        public List<CategoryEntry> GetAllCategory()
        {
            _aCategoryEntryGateway = new CategoryEntryGateway();
            return _aCategoryEntryGateway.GetAllCategory();
        }
    }
}
