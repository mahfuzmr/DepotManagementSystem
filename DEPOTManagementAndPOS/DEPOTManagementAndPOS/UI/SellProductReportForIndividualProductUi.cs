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
    public partial class SellProductReportForIndividualProductUi : Form
    {
        public SellProductReportForIndividualProductUi()
        {
            InitializeComponent();
            ShowGridViewForSellReport();
        }

        private void ShowGridViewForSellReport()
        {
            SellProductManeger aSellProductManeger = new SellProductManeger();
            List<SellProduct> aSellProductList = new List<SellProduct>();

            aSellProductList = aSellProductManeger.GetSellReportForIndividualProduct();
            foreach (SellProduct sellProduct in aSellProductList)
            {
                sellReportForIndividualProductDataGridView.Rows.Add(sellProduct.ItemName, sellProduct.Quantity,
                    sellProduct.UnitPrice, sellProduct.TotalPrice);
            }
        }
    }
}
