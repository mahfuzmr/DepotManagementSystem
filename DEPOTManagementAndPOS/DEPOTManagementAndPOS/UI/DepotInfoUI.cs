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
using DEPOTManagementAndPOS.DLL;
using DEPOTManagementAndPOS.Model;

namespace DEPOTManagementAndPOS.UI
{
    public partial class DepotInfoUI : Form
    {
        public DepotInfoUI()
        {
            InitializeComponent();
            AddButtonColumnDelete();
            StockManager aManager = new StockManager();
            List<Stock> viewStocks = aManager.ViewAllDepo();

            foreach (var aStock in viewStocks)
            {

                productInfodataGridView.Rows.Add(aStock.ProductName, aStock.QuantityInStock);

            }



            //  productInfodataGridView.DataSource = viewStocks;

        }

        private void AddButtonColumnDelete()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Delete";
                buttons.Text = "Delete";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 5;

            }

            productInfodataGridView.Columns.Add(buttons);

        }

        private void productInfodataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) //Assuming the button column as second column, if not can change the index
            {
                
                
                     var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);



                if (confirmResult == DialogResult.Yes)
                {

                    Stock _aStock = new Stock();
                    _aStock.ProductName = productInfodataGridView.CurrentRow.Cells[0].Value.ToString();


                    StockManager aStockManager = new StockManager();
                    bool status = aStockManager.DeleleStock(_aStock);

                    if (status)
                    {
                        MessageBox.Show("Successfully Deleted All Stock");
                        productInfodataGridView.Rows.Remove(productInfodataGridView.Rows[e.RowIndex]);
                    }
                    else
                    {
                        MessageBox.Show("Error deleting Stock");
                    }

                }

                //var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                //        "Confirm Delete!!",
                //        MessageBoxButtons.YesNo);



                //if (confirmResult == DialogResult.Yes)
                //{
                //    productsToBeDeleted.Add(aSellProductToDelete);
                //    sellReturnDataGridView.Rows.Remove(sellReturnDataGridView.Rows[e.RowIndex]);

                //    //  double aProductTotalPrice = Convert.ToDouble(sellReturnDataGridView.CurrentRow.Cells[3].Value);

                //    totaItemTakenCounter--;
                //    totalPrice = _aSellProduct.GetGrandTotalMinus(totalPrice, aProductTotalPrice);
                //    grandTotalTextBox.Text = totalPrice.ToString();
                //    dueAdjustedTextBox.Text = (totalPrice - (Convert.ToDouble(paidTextBox.Text))).ToString();
                //    totalItemTakenLabel.Text = totaItemTakenCounter.ToString();

                //    addToUpdateSellReturnButton.Enabled = true;
                //    doneButton.Enabled = true;


                //}
                //else
                //{
                //    MessageBox.Show("Item not deleted");
                //}

            }
        }

       
    }
}