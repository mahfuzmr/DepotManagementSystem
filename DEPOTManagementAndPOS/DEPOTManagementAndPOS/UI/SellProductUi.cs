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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;


namespace DEPOTManagementAndPOS.UI
{
    public partial class SellProductUi : Form
    {
        public SellProductUi()
        {
            InitializeComponent();

            customerInfoGroupBox.Enabled = false;
            donePanel.Enabled = false;

            AddButtonColumnEdit();

            addItemsButton.Enabled = false;


        }

        private void SellProductUi_Load(object sender, EventArgs e)
        {
            PurchaseManager _aPurchaseManager = new PurchaseManager();

            string[] productNameFromJoinedDatabase = _aPurchaseManager.GetProductNameWithCategoryAndBrandName().Select(x => string.Format("{0} {1} {2}", x.CategoryEntry.Name, x.BrandEntry.Name, x.Product.ProductNameExtention)).ToArray();


            itemNameForSellTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            itemNameForSellTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(productNameFromJoinedDatabase);
            itemNameForSellTextBox.AutoCompleteCustomSource = autoComplete;
        }


        int totaItemTakenCounter = 0;
        private double grandTotal=0;
        SellProduct _aSellProduct = new SellProduct();
        private void addItemsButton_Click(object sender, EventArgs e)
        {

            
            customerInfoGroupBox.Enabled = true;
            donePanel.Enabled = true;


            SellProduct _aSellProduct = new SellProduct();
            String itemName = itemNameForSellTextBox.Text;
            int quantity;
            double unitPrice;
            if (!string.IsNullOrEmpty(quantityTextBox.Text) && !string.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                quantity = Convert.ToInt32(quantityTextBox.Text);
                unitPrice = Convert.ToDouble(unitPriceTextBox.Text);
            }
            else
            {
                quantity = 0;
                unitPrice = 0;
            }
            
            double totalPrice = _aSellProduct.GetTotalPrice(quantity,unitPrice);

            if (quantity > 0 && unitPrice >= 0.01)
            {
                selectedItemDataGridView.Rows.Add(itemName, quantity, unitPrice, totalPrice);    
            }
            else
            {
                MessageBox.Show("Please enter quantity > 0 and unit price >= 0.01");
            }
            

            itemNameForSellTextBox.Clear();
            quantityTextBox.Clear();
            unitPriceTextBox.Clear();
            totalPricePerProductTextBox.Clear();
            totaItemTakenCounter++;
            totalItemTakenLabel.Text = totaItemTakenCounter.ToString();

            // grandTotal view

            
            grandTotal=_aSellProduct.GetGrandTotal(grandTotal,totalPrice);
            grandTotalTextBox.Text = grandTotal.ToString();

            //this.Enabled = false;





        }


        
        private void doneButton_Click(object sender, EventArgs e)
        {
            SellInvoice _aSellInvoice = new SellInvoice();
            SellInvoiceManager _aInvoiceManager = new SellInvoiceManager();

            if (!string.IsNullOrEmpty(customerNameTextBox.Text) && !string.IsNullOrEmpty(phoneTextBox.Text) && !string.IsNullOrEmpty(addressOfCustomeRichTextBox.Text) && !string.IsNullOrEmpty(shopNameTextBox.Text) && !string.IsNullOrEmpty(addressOfShopRichTextBox.Text))
            {
                Customer _aCustomer = new Customer();
                _aCustomer.Name = customerNameTextBox.Text;
                _aCustomer.Phone = phoneTextBox.Text;
                _aCustomer.AddressOfCustomer = addressOfCustomeRichTextBox.Text;
                _aCustomer.ShopName = shopNameTextBox.Text;
                _aCustomer.AddressOfShop = addressOfShopRichTextBox.Text;

                bool saveCustomerSuccess = false;
                CustomerManager _aCustomerManager = new CustomerManager();

                saveCustomerSuccess = _aCustomerManager.SaveAllCustomerInfo(_aCustomer);
                if (saveCustomerSuccess)
                {
                    MessageBox.Show("Customer info saved successfully");

                }
                else
                {
                    MessageBox.Show("Error saving Customer info");
                }


                if (!string.IsNullOrEmpty(grandTotalTextBox.Text) && !string.IsNullOrEmpty(paidTextBox.Text))
                {


                    string today = DateTime.Today.ToShortDateString();
                    _aSellInvoice.GrandTotal = Convert.ToDouble(grandTotalTextBox.Text);
                    if (!string.IsNullOrEmpty(paidTextBox.Text))
                    {
                        _aSellInvoice.Paid = Convert.ToDouble(paidTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter paid amount");
                    }
                    _aSellInvoice.Due = Convert.ToDouble(dueTextBox.Text);
                    _aSellInvoice.OrderNo = _aInvoiceManager.GetInvoiceOrderNo();

                    _aSellInvoice.SellDate = today;
                    _aSellInvoice.TotalItemSold = Convert.ToInt32(totalItemTakenLabel.Text);
                    _aSellInvoice.Customer.CustomerId = CustomerManager.GetCustomerId();
                    String statusOfCashIn = null;
                    if (cashCheckBox.Checked)
                    {
                        statusOfCashIn = "Cash";
                        //chequeCheckBox.Enabled = false;
                    }
                    else if (chequeCheckBox.Checked)
                    {
                        //cashCheckBox.Enabled = false;
                        statusOfCashIn = "Bank Cheque";
                    }
                    else if (!cashCheckBox.Checked && !chequeCheckBox.Checked)
                    {
                        MessageBox.Show("Please specify payment method whether it's cash or cheque");
                    }
                    _aSellInvoice.CashStatus = statusOfCashIn;

                    bool saveSellInvoiceSuccess = false;

                    saveSellInvoiceSuccess = _aInvoiceManager.SaveSellInvoiceInfo(_aSellInvoice);
                    if (saveSellInvoiceSuccess)
                    {
                        MessageBox.Show("Item Sold Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error, Saving Sell Invoice Info");
                    }
                }


                List<SellProduct> _aSellProductList = new List<SellProduct>();
                List<Stock> _aStockList = new List<Stock>();
                StockManager _aStockManager = new StockManager();


                for (int i = 0; i < selectedItemDataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        SellProduct aSellProduct = new SellProduct();
                        Stock _aStock = new Stock();

                        string productName = Convert.ToString(selectedItemDataGridView.Rows[i].Cells[j].Value);
                        Int32 quantity = Convert.ToInt32(selectedItemDataGridView.Rows[i].Cells[j + 1].Value);
                        aSellProduct.UnitPrice = Convert.ToDouble(selectedItemDataGridView.Rows[i].Cells[j + 2].Value);
                        aSellProduct.TotalPrice = Convert.ToDouble(selectedItemDataGridView.Rows[i].Cells[j + 3].Value);
                        aSellProduct.SellInvoice.SellInvoiceId = _aInvoiceManager.GetSellInvoiceId();
                        aSellProduct.ItemName = productName;
                        aSellProduct.Quantity = quantity;


                        _aStock = _aStockManager.GetCurrentStockInfo(productName);
                        string productNameFromDatabase = _aStock.ProductName;

                        if (productNameFromDatabase == productName)
                        {
                            int quantityPrevious = _aStock.QuantityInStock;
                            int quantityNew = quantity;
                            int quantityInStockAfterSell = quantityPrevious - quantityNew;

                            _aStock.QuantityInStock = quantityInStockAfterSell;
                            _aStock.ProductName = productName;

                            bool updateStockSuccess = false;
                            updateStockSuccess = _aStockManager.UpdateAllStockInfo(_aStock);
                            if (updateStockSuccess)
                            {
                                MessageBox.Show("update stock Stock info");
                                _aStockList.Add(_aStock);
                            }
                            else
                            {
                                MessageBox.Show("Error updating stock info");
                            }
                        }


                        _aSellProductList.Add(aSellProduct);
                    }
                }



                bool saveSellProductStatus = false;

                SellProductManeger aProductManeger = new SellProductManeger();
                saveSellProductStatus = aProductManeger.saveAllSellProductInfo(_aSellProductList);
                if (saveSellProductStatus)
                {
                    MessageBox.Show("Sell product info saved successfully");
                }
                else
                {
                    MessageBox.Show("Error saving sell info product");
                }
            }
            else
            {
                MessageBox.Show("Please enter customer info and other info accurately");
            }
            



            
            customerNameTextBox.Clear();
            phoneTextBox.Clear();
            addressOfCustomeRichTextBox.Clear();
            addressOfShopRichTextBox.Clear();
            shopNameTextBox.Clear();
            grandTotalTextBox.Clear();
            paidTextBox.Clear();
            dueTextBox.Clear();
            totalPricePerProductTextBox.Clear();
            totalItemTakenLabel.Text = "0";
            selectedItemDataGridView.Rows.Clear();
            inStockTextBox.Clear();
            



        }

        private void unitPriceTextBox_KeyUp(object sender, KeyEventArgs e)
        {



            SellProduct aSellProduct = new SellProduct();

            if (unitPriceTextBox.Text != "" && quantityTextBox.Text != "")
            {
               
                aSellProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
                aSellProduct.UnitPrice = Convert.ToDouble(unitPriceTextBox.Text);
                
                double totalPrice = aSellProduct.GetTotalPrice(aSellProduct.Quantity, aSellProduct.UnitPrice);
                totalPricePerProductTextBox.Text = totalPrice.ToString();
                


            }
            else
            {
                aSellProduct.UnitPrice = 0;
                totalPricePerProductTextBox.Clear();
                
            }


        }

        private void paidTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SellInvoice _aSellInvoice = new SellInvoice();

            _aSellInvoice.GrandTotal = Convert.ToDouble(grandTotalTextBox.Text);

            if (paidTextBox.Text != "")
            {

                _aSellInvoice.Paid = Convert.ToDouble(paidTextBox.Text);
                dueTextBox.Text = _aSellInvoice.GetDue(_aSellInvoice.Paid).ToString();
            }
            else
            {
                paidTextBox.Clear();
                dueTextBox.Clear();
                if (paidTextBox.Text == String.Empty)
                {
                    dueTextBox.Text = _aSellInvoice.GrandTotal.ToString();
                }

            }
        }

        //private void selectedItemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        ////    itemNameForSellTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[0].Value.ToString();
        ////    quantityTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[1].Value.ToString();
        ////    unitPriceTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[2].Value.ToString();
        ////    double totalPrice = Convert.ToDouble(selectedItemDataGridView.CurrentRow.Cells[3].Value);

        ////    //selectedItemDataGridView.Rows.RemoveAt(selectedItemDataGridView.SelectedRows[0].Index);
        ////    totaItemTakenCounter--;
        ////    grandTotal = _aSellProduct.GetGrandTotalMinus(grandTotal, totalPrice);
        ////    grandTotalTextBox.Text = grandTotal.ToString();

        ////    totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
        //}

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

            selectedItemDataGridView.Columns.Add(buttons);

        }
        //private void AddButtonColumnDelete()
        //{
        //    DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
        //    {
        //        buttons.HeaderText = "Delete";
        //        buttons.Text = "Delete";
        //        buttons.UseColumnTextForButtonValue = true;
        //        buttons.AutoSizeMode =
        //            DataGridViewAutoSizeColumnMode.AllCells;
        //        buttons.FlatStyle = FlatStyle.Standard;
        //        buttons.CellTemplate.Style.BackColor = Color.Honeydew;
        //        buttons.DisplayIndex = 1;
        //    }

        //    selectedItemDataGridView.Columns.Add(buttons);

        //}

        private void selectedItemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //Assuming the button column as 4th column, if not can change the index
            {
                
                itemNameForSellTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[0].Value.ToString();
                quantityTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[1].Value.ToString();
                unitPriceTextBox.Text = selectedItemDataGridView.CurrentRow.Cells[2].Value.ToString();
                double totalPrice = Convert.ToDouble(selectedItemDataGridView.CurrentRow.Cells[3].Value);


                selectedItemDataGridView.Rows.Remove(selectedItemDataGridView.Rows[e.RowIndex]);

                totaItemTakenCounter--;
                grandTotal = _aSellProduct.GetGrandTotalMinus(grandTotal, totalPrice);
                grandTotalTextBox.Text = grandTotal.ToString();

                totalItemTakenLabel.Text = totaItemTakenCounter.ToString();

            }
        
            
        }

        private void pdfCreateButton_Click(object sender, EventArgs e)
        {
            

        }

        private void sellReturnUiLoadButton_Click(object sender, EventArgs e)
        {
            SellReturnUi aSellReturnUi = new SellReturnUi();
            aSellReturnUi.ShowDialog();
        }

        private void dailySellReportUiLoadButton_Click(object sender, EventArgs e)
        {
            DailySellReportUi _aDailySellReportUi = new DailySellReportUi();
            _aDailySellReportUi.Show();
        }


        private void itemNameForSellTextBox_Leave(object sender, EventArgs e)
        {
            String name = null;
            name = itemNameForSellTextBox.Text;

            StockManager _aStockManager = new StockManager();
            Stock _aStock = new Stock();

            _aStock = _aStockManager.GetCurrentStockInfo(name);
            int quantityStock = _aStock.QuantityInStock;

            if (quantityStock == 0 && !string.IsNullOrEmpty(_aStock.ProductName))
            {
                addItemsButton.Enabled = false;
                MessageBox.Show("Product not availabe for sell");
            }
            else if (quantityStock > 0 && quantityStock <= 100)
            {
                inStockTextBox.BackColor = Color.Red;
                addItemsButton.Enabled = true;
                inStockTextBox.Text = quantityStock.ToString();
            }
            else if (quantityStock > 100)
            {
                inStockTextBox.BackColor = Color.Plum;
                addItemsButton.Enabled = true;
                inStockTextBox.Text = quantityStock.ToString();
            }

            if (string.IsNullOrEmpty(quantityTextBox.Text))
            {
                addItemsButton.Enabled = false;
            }
            else if (!string.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                addItemsButton.Enabled = false;
            }
            else
            {
                addItemsButton.Enabled = true;
            }
        }

        private void purchaseNewButton_Click(object sender, EventArgs e)
        {
            PurchaseEntryUi _aPurchaseEntryUi = new PurchaseEntryUi();
            _aPurchaseEntryUi.ShowDialog();
        }

        private void addNewItemButton_Click(object sender, EventArgs e)
        {
            ProductEntryUi _aProductEntryUi = new ProductEntryUi();
            _aProductEntryUi.ShowDialog();
        }

        private void stockInfoUiLoadButton_Click(object sender, EventArgs e)
        {
            DepotInfoUI _aDepotInfoUi = new DepotInfoUI();
            _aDepotInfoUi.ShowDialog();
        }

        private void quantityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            String name = null;
            name = itemNameForSellTextBox.Text;
            int quantityForSell;
            if (!string.IsNullOrEmpty(quantityTextBox.Text))
            {
                quantityForSell = Convert.ToInt32(quantityTextBox.Text);    
            }
            else
            {
                quantityForSell = 0;
            }

            StockManager _aStockManager = new StockManager();
            Stock _aStock = new Stock();

            _aStock = _aStockManager.GetCurrentStockInfo(name);
            int quantityStock = _aStock.QuantityInStock;
            if (quantityForSell > quantityStock)
            {
                addItemsButton.Enabled = false;
                MessageBox.Show("Low stock than quantity");
                quantityTextBox.Clear();
            }
            else if (quantityForSell <= quantityStock)
            {
                addItemsButton.Enabled = true;
            }

            SellProduct aSellProduct = new SellProduct();

            if (unitPriceTextBox.Text != "" && quantityTextBox.Text != "")
            {

                aSellProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
                aSellProduct.UnitPrice = Convert.ToDouble(unitPriceTextBox.Text);

                double totalPrice = aSellProduct.GetTotalPrice(aSellProduct.Quantity, aSellProduct.UnitPrice);
                totalPricePerProductTextBox.Text = totalPrice.ToString();



            }
            else
            {
                aSellProduct.UnitPrice = 0;
                totalPricePerProductTextBox.Clear();

            }
        }

        private void cashCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cashCheckBox.Checked)
            {
                chequeCheckBox.Enabled = false;
            }
            else if (!cashCheckBox.Checked)
            {
                chequeCheckBox.Enabled = true;
                
            }
            
            
        }

        private void chequeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chequeCheckBox.Checked)
            {
                cashCheckBox.Enabled = false;
            }
            else if (!chequeCheckBox.Checked)
            {
                cashCheckBox.Enabled = true;
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            PurchaseManager _aPurchaseManager = new PurchaseManager();

            string[] productNameFromJoinedDatabase = _aPurchaseManager.GetProductNameWithCategoryAndBrandName().Select(x => string.Format("{0} {1} {2}", x.CategoryEntry.Name, x.BrandEntry.Name, x.Product.ProductNameExtention)).ToArray();


            itemNameForSellTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            itemNameForSellTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(productNameFromJoinedDatabase);
            itemNameForSellTextBox.AutoCompleteCustomSource = autoComplete;
        }

        private void purchaseReportButton_Click(object sender, EventArgs e)
        {
            PurchaseInfoUi aPurchaseInfoUi=new PurchaseInfoUi();
            aPurchaseInfoUi.ShowDialog();


        }

        private void sellReportForIndividualProductUiLoadButton_Click(object sender, EventArgs e)
        {
            SellProductReportForIndividualProductUi aSellProductReportForIndividualProductUi = new SellProductReportForIndividualProductUi();
            aSellProductReportForIndividualProductUi.ShowDialog();
        }
        
      
    }
}
