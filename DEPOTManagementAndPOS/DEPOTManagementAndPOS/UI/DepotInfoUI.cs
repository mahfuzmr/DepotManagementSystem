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
    public partial class DepotInfoUI : Form
    {
        public DepotInfoUI()
        {
            InitializeComponent();
            LoadStockInfo();
        }

        private void LoadStockInfo()
        {
           StockManager aStockManager=new StockManager();
            List<Stock> aStockList =new List<Stock>();
            aStockList=aStockManager.GetTotalStockInfo();
            foreach (var stockList in aStockList)
            {
                productInfodataGridView.Rows.Add(stockList.ProductName, stockList.QuantityInStock);

            }
            
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
