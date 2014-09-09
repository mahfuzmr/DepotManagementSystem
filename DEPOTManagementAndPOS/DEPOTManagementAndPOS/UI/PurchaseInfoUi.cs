using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEPOTManagementAndPOS.BLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.UI
{
    public partial class PurchaseInfoUi : Form
    {
        public PurchaseInfoUi()
        {
            InitializeComponent();
            LoadPurchaseInformation();
        }

        private void LoadPurchaseInformation()
        {
           PurchaseManager aPurchaseManager=new PurchaseManager();
            List<Purchase> aPurchasesList=new List<Purchase>();
            aPurchasesList = aPurchaseManager.GetPurchaseInfo();
            foreach (var purchaseList in aPurchasesList)
            {
                purchaseInformationGridView.Rows.Add(purchaseList.ProductName,
                    purchaseList.Quantity,purchaseList.Price,purchaseList.DateTime);
                
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
