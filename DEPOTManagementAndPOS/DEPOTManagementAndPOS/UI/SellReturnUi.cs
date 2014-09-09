using DEPOTManagementAndPOS.BLL;
using DEPOTManagementAndPOS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities.Collections;

namespace DEPOTManagementAndPOS.UI
{
    public partial class SellReturnUi : Form
    {
        public SellReturnUi()
        {
            InitializeComponent();
            AddButtonColumnEdit();
            AddButtonColumnDelete();
        }
        double totalPrice = 0;
        private string id;


        private List<SellProduct> _aSellProductsForMatching;

        private void searchByOrderNoButton_Click(object sender, EventArgs e)
        {
            payableTotalTextBox.Text = 0.ToString();
            sellReturnDataGridView.Rows.Clear();
            id = searchOrderNoTextBox.Text;

            totalPrice = 0;
            totaItemTakenCounter = 0;
            CustomerManager aCustomerManager = new CustomerManager();

            Customer aCustomer = aCustomerManager.GetCustomerInfoUsingId(id);

            customerNameTextBox.Text = aCustomer.Name;

            phoneTextBox.Text = aCustomer.Phone;
            shopNameTextBox.Text = aCustomer.ShopName;


            SellProductManeger aSellProductManeger = new SellProductManeger();
            List<SellProduct> _aSellProducts = aSellProductManeger.GetSoldProductInfoUsingOrderNo(id);

            int searchTrack = _aSellProducts.Count;

            if (searchTrack == 0)
            {
                MessageBox.Show("No Item Found");
                doneButton.Enabled = false;
                addToUpdateSellReturnButton.Enabled = false;

            }
            else
            {
                doneButton.Enabled = true;
            addToUpdateSellReturnButton.Enabled = true;
        }

        _aSellProductsForMatching = new List<SellProduct>();
            _aSellProductsForMatching = _aSellProducts;

            foreach (var aSellProduct in _aSellProducts)
            {
                sellReturnDataGridView.Rows.Add(aSellProduct.ItemName, aSellProduct.Quantity, aSellProduct.UnitPrice,
                    aSellProduct.TotalPrice);
                totalPrice += aSellProduct.TotalPrice;
                totaItemTakenCounter++;
                totalItemTakenLabel.Text = totaItemTakenCounter.ToString();

            }
            grandTotalTextBox.Text = totalPrice.ToString();

            SellInvoice _aSellInvoice = new SellInvoice();
            SellInvoiceManager _aSellInvoiceManager = new SellInvoiceManager();
            _aSellInvoice = _aSellInvoiceManager.GetSellReportUsingOrderNo(id);
            paidTextBox.Text = _aSellInvoice.Paid.ToString();
            dueTextBox.Text = _aSellInvoice.Due.ToString();


        }

        private void AddButtonColumnEdit()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Edit";
                buttons.Text = "Edit";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 4;

            }

            sellReturnDataGridView.Columns.Add(buttons);

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

            sellReturnDataGridView.Columns.Add(buttons);

        }

        private double dueAdjustedFromDeleteButton = 0;
        List<String> itemToBeDeleteList = new List<string>();
        private void sellReturnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //Assuming the button column as second column, if not can change the index
            {

                itemNameForSellReturnTextBox.Text = sellReturnDataGridView.CurrentRow.Cells[0].Value.ToString();
                quantityReturnTextBox.Text = sellReturnDataGridView.CurrentRow.Cells[1].Value.ToString();
                unitPriceSellReturnTextBox.Text = sellReturnDataGridView.CurrentRow.Cells[2].Value.ToString();

                




                double aProductTotalPrice = Convert.ToDouble(sellReturnDataGridView.CurrentRow.Cells[3].Value);


                totalPriceSellReturnPerProductTextBox.Text = Convert.ToString(aProductTotalPrice);

                sellReturnDataGridView.Rows.Remove(sellReturnDataGridView.Rows[e.RowIndex]);

                totaItemTakenCounter--;
                totalPrice = _aSellProduct.GetGrandTotalMinus(totalPrice, aProductTotalPrice);
                grandTotalTextBox.Text = totalPrice.ToString();
                dueAdjustedTextBox.Text = (totalPrice - (Convert.ToDouble(paidTextBox.Text))).ToString();
                totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
                

            }

            if (e.ColumnIndex == 5)
            {
                int selectedRow = e.RowIndex;
                string itemToBeDelete = sellReturnDataGridView.Rows[selectedRow].Cells[0].Value.ToString();
                //(string) sellReturnDataGridView.Rows[selectedRow].Cells[1].Value;


                
                itemToBeDeleteList.Add(itemToBeDelete);
                double aProductTotalPrice = Convert.ToDouble(sellReturnDataGridView.CurrentRow.Cells[3].Value);
                sellReturnDataGridView.Rows.Remove(sellReturnDataGridView.Rows[e.RowIndex]);
                totalPrice = totalPrice - aProductTotalPrice;
                grandTotalTextBox.Text = totalPrice.ToString();
                totaItemTakenCounter--;
                totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
                dueAdjustedTextBox.Text = (totalPrice - (Convert.ToDouble(paidTextBox.Text))).ToString();
                dueAdjustedFromDeleteButton = totalPrice - (Convert.ToDouble(paidTextBox.Text));
                payableTotalTextBox.Clear();

                
                SellProduct _aSellProduct = new SellProduct();





            }
        }
        int totaItemTakenCounter = 0;
       
        SellProduct _aSellProduct = new SellProduct();
        private double paymentIsPlusOrMinus;
        private double dueAdjustedFromAddButton ;
        private void addToUpdateSellReturnButton_Click(object sender, EventArgs e)
        {
            customerInfoGroupBox.Enabled = true;
            donePanel.Enabled = true;


            SellProduct _aSellProduct = new SellProduct();
            String itemName = itemNameForSellReturnTextBox.Text;
            int quantity;
            double unitPrice;
            if (!string.IsNullOrEmpty(quantityReturnTextBox.Text))
            {
                quantity = Convert.ToInt32(quantityReturnTextBox.Text);
                unitPrice = Convert.ToDouble(unitPriceSellReturnTextBox.Text);
            }
            else
            {
                quantity = 0;
                unitPrice = 0;
            }

            double totalPricePerProduct = _aSellProduct.GetTotalPrice(quantity, unitPrice);

            sellReturnDataGridView.Rows.Add(itemName, quantity, unitPrice, totalPricePerProduct);
            totalPrice += totalPricePerProduct;

            itemNameForSellReturnTextBox.Clear();
            quantityReturnTextBox.Clear();
            unitPriceSellReturnTextBox.Clear();

            totaItemTakenCounter++;
            totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
            double paidPrevious = Convert.ToDouble(paidTextBox.Text);

            // grandTotal view
            grandTotalTextBox.Text = totalPrice.ToString();
            paymentIsPlusOrMinus = totalPrice - paidPrevious;
            //if (paymentIsPlusOrMinus < 0)
            //{
            //    statusLabel.ForeColor=Color.Red;
            //    statusLabel.Text = "Payable to Customer";
            //    dueStatusLabel.ForeColor = Color.Red;
            //    dueStatusLabel.Text="Payable To Customer";
            //    payableTotalTextBox.ReadOnly = true;
            //}


            dueAdjustedTextBox.Text = paymentIsPlusOrMinus.ToString();
            dueAdjustedFromAddButton = paymentIsPlusOrMinus;

        }


        private void quantityReturnTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SellProduct aSellProduct = new SellProduct();

            if (unitPriceSellReturnTextBox.Text != "" && quantityReturnTextBox.Text != "")
            {

                aSellProduct.Quantity = Convert.ToInt32(quantityReturnTextBox.Text);
                aSellProduct.UnitPrice = Convert.ToDouble(unitPriceSellReturnTextBox.Text);

                double totalPrice = aSellProduct.GetTotalPrice(aSellProduct.Quantity, aSellProduct.UnitPrice);
                totalPriceSellReturnPerProductTextBox.Text = totalPrice.ToString();


            }
            else
            {
                aSellProduct.UnitPrice = 0;
                totalPriceSellReturnPerProductTextBox.Clear();
            }
        }

        private void unitPriceSellReturnTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SellProduct aSellProduct = new SellProduct();

            if (unitPriceSellReturnTextBox.Text != "" && quantityReturnTextBox.Text != "")
            {

                aSellProduct.Quantity = Convert.ToInt32(quantityReturnTextBox.Text);
                aSellProduct.UnitPrice = Convert.ToDouble(unitPriceSellReturnTextBox.Text);

                double totalPrice = aSellProduct.GetTotalPrice(aSellProduct.Quantity, aSellProduct.UnitPrice);
                totalPriceSellReturnPerProductTextBox.Text = totalPrice.ToString();


            }
            else
            {
                aSellProduct.UnitPrice = 0;
                totalPriceSellReturnPerProductTextBox.Clear();
            }
        }

        private void payableTotalTextBox_KeyUp(object sender, KeyEventArgs e)
        {
           
            double paymentNew;
            double paidPrevious=0;
            double dueAdjusted=0;

            if (paymentIsPlusOrMinus >= 0 && payableTotalTextBox.Text !="")
            {
                paidPrevious = Convert.ToDouble(paidTextBox.Text);
                paymentNew = Convert.ToDouble(payableTotalTextBox.Text);
                dueAdjusted = (totalPrice - (paymentNew + paidPrevious));
                dueAdjustedTextBox.Text = dueAdjusted.ToString();
                
            }
            else if (payableTotalTextBox.Text == "")
            {
                
                if (payableTotalTextBox.Text == String.Empty)
                {
                    
                    dueAdjusted = dueAdjustedFromDeleteButton;
                    dueAdjustedTextBox.Text = dueAdjusted.ToString();
                }
            }

            
            


        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            // NOTE: Need to update Three tables=> SellProduct and SellInvoice, StockInfo
            double grandTotal = Convert.ToDouble(grandTotalTextBox.Text);
            double paid = Convert.ToDouble(paidTextBox.Text) + Convert.ToDouble(payableTotalTextBox.Text);
            double due;
            if (!string.IsNullOrEmpty(dueAdjustedTextBox.Text))
            {
                due = Convert.ToDouble(dueAdjustedTextBox.Text);
            }
            else
            {
                due = 0;
            }

            int totalItemSoldUpdateInfo = totaItemTakenCounter;


            Int32 orderNo = Convert.ToInt32(searchOrderNoTextBox.Text);

            SellInvoice aSellInvoice = new SellInvoice();
            aSellInvoice.OrderNo = orderNo;
            aSellInvoice.GrandTotal = grandTotal;
            aSellInvoice.Paid = paid;
            aSellInvoice.Due = due;
            aSellInvoice.TotalItemSold = totalItemSoldUpdateInfo;

            SellInvoiceManager aSellInvoiceManager = new SellInvoiceManager();
            Boolean status = false;
            status = aSellInvoiceManager.UpdateAllSellVoiceUsingOrderNo(aSellInvoice);
            if (status)
            {
                MessageBox.Show("Successfully updated sell return info");
            }
            else
            {
                MessageBox.Show("Error updating sell return info");
            }


            SellInvoiceManager _aInvoiceManager = new SellInvoiceManager();
            int statusFlag = 0;

            for (int i = 0; i < sellReturnDataGridView.Rows.Count - 1; i++)
            {

                bool status2 = false;
                for (int j = 0; j < 1; j++)
                {
                    SellProduct aSellProduct = new SellProduct();

                    aSellProduct.Quantity = Convert.ToInt32(sellReturnDataGridView.Rows[i].Cells[j + 1].Value);
                    aSellProduct.UnitPrice = Convert.ToDouble(sellReturnDataGridView.Rows[i].Cells[j + 2].Value);
                    aSellProduct.TotalPrice = Convert.ToDouble(sellReturnDataGridView.Rows[i].Cells[j + 3].Value);
                    aSellProduct.ItemName = (string) sellReturnDataGridView.Rows[i].Cells[j].Value;


                    status2 = _aInvoiceManager.UpdateAllSellProductUsingOrderNo(aSellProduct, id);
                    if (status2)
                    {
                        statusFlag++;
                    }


                    //Updating stock start

                    foreach (SellProduct aProduct in _aSellProductsForMatching)
                    {
                        if (aProduct.ItemName == aSellProduct.ItemName)
                        {
                            int statusStockcount = 1;
                            if (aProduct.Quantity != aSellProduct.Quantity)
                            {StockManager _stockManager = new StockManager();
                                bool statusStock = false;

                              statusStock =   _stockManager.SellReturnStockUpdate(aProduct, aSellProduct);

                                if (statusStock)
                                {
                                    MessageBox.Show(statusStockcount+"Sell Return Stock Updated");
                                    statusStockcount++;
                                }
                                else
                                {
                                    MessageBox.Show(" Error stock updating");
                                }

                            }
                        }

                    }


                }
            }


            if (statusFlag == sellReturnDataGridView.Rows.Count - 1)
                {
                    MessageBox.Show("Item Update successfuly");
                }
                else
                {
                    MessageBox.Show("Error updating sell return");
                }



                SellProductManeger _aProductManeger = new SellProductManeger();

                foreach (string selectedItemToDelete in itemToBeDeleteList)
                {
                    bool deleteSuccess = _aProductManeger.DeleteSelectRow(selectedItemToDelete, id);

                }






            

            ProductInfoClear();

                CustomerInfoClear();

            
        }

        private void CustomerInfoClear()
        {
            customerNameTextBox.Clear();
            phoneTextBox.Clear();
            shopNameTextBox.Clear();
            grandTotalTextBox.Clear();
            payableTotalTextBox.Clear();
            dueAdjustedTextBox.Clear();
        }

        private void ProductInfoClear()
        {
            searchOrderNoTextBox.Clear();
            itemNameForSellReturnTextBox.Clear();
            quantityReturnTextBox.Clear();
            unitPriceSellReturnTextBox.Clear();
            totalPriceSellReturnPerProductTextBox.Clear();
            paidTextBox.Clear();
            dueTextBox.Clear();
            sellReturnDataGridView.Rows.Clear();
        }

        
    }
}
