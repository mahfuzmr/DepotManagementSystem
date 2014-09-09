using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEPOTManagementAndPOS.UI;

namespace DEPOTManagementAndPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CategoryEntryUi());
            //Application.Run(new BrandEntryUi());
            //Application.Run(new ProductEntryUi());
            //Application.Run(new PurchaseEntryUi());
            Application.Run(new SellProductUi());
           // Application.Run(new PurchaseInfoUi());
        }
    }
}
