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
            addToUpdateSellReturnButton.Enabled = false;
        }
        double totalPrice = 0;
        private string OrderNo;
        private List<SellProduct> _aSellProductsForMatching;
        private List<SellProduct> productsToBeDeleted;


        
        List<SellProduct> _aSellProductList = new List<SellProduct>(); //old quantity found
        private void searchByOrderNoButton_Click(object sender, EventArgs e)
        {
            productsToBeDeleted = new List<SellProduct>();
            payableTotalTextBox.Text = 0.ToString();
            sellReturnDataGridView.Rows.Clear();
            OrderNo = searchOrderNoTextBox.Text;

            totalPrice = 0;
            totaItemTakenCounter = 0;
            CustomerManager aCustomerManager = new CustomerManager();

            Customer aCustomer = aCustomerManager.GetCustomerInfoUsingId(OrderNo);

            customerNameTextBox.Text = aCustomer.Name;

            phoneTextBox.Text = aCustomer.Phone;
            shopNameTextBox.Text = aCustomer.ShopName;


            SellProductManeger aSellProductManeger = new SellProductManeger();
            _aSellProductList = aSellProductManeger.GetSoldProductInfoUsingOrderNo(OrderNo);

            int searchTrack = _aSellProductList.Count;

            if (searchTrack == 0)
            {
                MessageBox.Show("No Item Found");

            }

            doneButton.Enabled = false;
            addToUpdateSellReturnButton.Enabled = false;

        
              _aSellProductsForMatching = new List<SellProduct>();
            _aSellProductsForMatching = _aSellProductList;

            foreach (var aSellProduct in _aSellProductList)
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
            _aSellInvoice = _aSellInvoiceManager.GetSellReportUsingOrderNo(OrderNo);
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
        private List<Stock> _aStockList = new List<Stock>(); 
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

                addToUpdateSellReturnButton.Enabled = true;
                doneButton.Enabled = true;

            }

            if (e.ColumnIndex == 5)
            {

                SellProduct aSellProductToDelete = new SellProduct();
                int selectedRow = e.RowIndex;
                aSellProductToDelete.ItemName = sellReturnDataGridView.Rows[selectedRow].Cells[0].Value.ToString();
                aSellProductToDelete.Quantity = (int) sellReturnDataGridView.Rows[selectedRow].Cells[1].Value;
             
                
                string itemNameToBeDelete = sellReturnDataGridView.Rows[selectedRow].Cells[0].Value.ToString();
                double aProductTotalPrice = (double) sellReturnDataGridView.Rows[selectedRow].Cells[3].Value;

                int quantityToBeDeletedItem = (int) sellReturnDataGridView.Rows[selectedRow].Cells[1].Value;


                SellProductManeger aSellProductManager = new SellProductManeger();
                SellInvoiceManager aSellInvoiceManager = new SellInvoiceManager();

                




                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);

               

                if (confirmResult == DialogResult.Yes)
                {
                    productsToBeDeleted.Add(aSellProductToDelete);
                    sellReturnDataGridView.Rows.Remove(sellReturnDataGridView.Rows[e.RowIndex]);

                  //  double aProductTotalPrice = Convert.ToDouble(sellReturnDataGridView.CurrentRow.Cells[3].Value);

                    totaItemTakenCounter--;
                    totalPrice = _aSellProduct.GetGrandTotalMinus(totalPrice, aProductTotalPrice);
                    grandTotalTextBox.Text = totalPrice.ToString();
                    dueAdjustedTextBox.Text = (totalPrice - (Convert.ToDouble(paidTextBox.Text))).ToString();
                    totalItemTakenLabel.Text = totaItemTakenCounter.ToString();

                    addToUpdateSellReturnButton.Enabled = true;
                    doneButton.Enabled = true;

                      
                }
                else
                {
                    MessageBox.Show("Item not deleted");
                }
               
                //Adhustimg paid,due and total from sellInvoiceTable

               // SellInvoiceManager _aSellInvoiceManager= new SellInvoiceManager();
               // _aSellInvoiceManager.UpdateSellInvoiceAmpuntWhileDeleting();


                 

                Stock _aStock = new Stock();
                StockManager _aStockManager = new StockManager();

                _aStock = _aStockManager.GetCurrentStockInfo(itemNameToBeDelete);
                string productNameFromDatabase = _aStock.ProductName;
                

                if (productNameFromDatabase == itemNameToBeDelete)
                {
                    int quantityPrevious = _aStock.QuantityInStock;
                    int quantityNew = quantityToBeDeletedItem;
                    int quantityInStockAfterSellReturn = quantityPrevious + quantityNew;
                    _aStock.QuantityInStock = quantityInStockAfterSellReturn;

                    _aStockList.Add(_aStock);
                    
                }
               
                //itemToBeDeleteList.Add(itemNameToBeDelete);
                //double aProductTotalPrice = Convert.ToDouble(sellReturnDataGridView.CurrentRow.Cells[3].Value);
                
                //totalPrice = totalPrice - aProductTotalPrice;
                //grandTotalTextBox.Text = totalPrice.ToString();
                //totaItemTakenCounter--;
                //totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
                //dueAdjustedTextBox.Text = (totalPrice - (Convert.ToDouble(paidTextBox.Text))).ToString();
                //dueAdjustedFromDeleteButton = totalPrice - (Convert.ToDouble(paidTextBox.Text));
                //payableTotalTextBox.Text=0.ToString();

                //doneButton.Enabled = true;

            }
        }

        int totaItemTakenCounter = 0;
       
        SellProduct _aSellProduct = new SellProduct();
        List<Stock> _aStockListFromGridViewAfterEditingProduct = new List<Stock>();

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

            
              
            


            for (int i = 0; i < sellReturnDataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Stock aStock = new Stock();

                    string productName = Convert.ToString(sellReturnDataGridView.Rows[i].Cells[j].Value);
                    Int32 quantityUpdatedFromGridView = Convert.ToInt32(sellReturnDataGridView.Rows[i].Cells[j + 1].Value);

                    aStock.ProductName = productName;
                    aStock.QuantityInStock = quantityUpdatedFromGridView;

                    _aStockListFromGridViewAfterEditingProduct.Add(aStock); // new quantity found

                }
            }

            totalPrice += totalPricePerProduct;

            itemNameForSellReturnTextBox.Clear();
            quantityReturnTextBox.Clear();
            unitPriceSellReturnTextBox.Clear();

            totaItemTakenCounter++;
            totalItemTakenLabel.Text = totaItemTakenCounter.ToString();
            double paidPrevious = Convert.ToDouble(paidTextBox.Text);

            grandTotalTextBox.Text = totalPrice.ToString();
            paymentIsPlusOrMinus = totalPrice - paidPrevious;



            dueAdjustedTextBox.Text = paymentIsPlusOrMinus.ToString();
            dueAdjustedFromAddButton = paymentIsPlusOrMinus;

            addToUpdateSellReturnButton.Enabled = false;

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
                MessageBox.Show("Successfully updated sell return info in SellInvoiceTable");
            }
            else
            {
                MessageBox.Show("Error updating sell return info in SellInvoiceTable");
            }


            //Sell ProductTable during edit save

            SellInvoiceManager _aInvoiceManager = new SellInvoiceManager();
            Int64 invoiceIdOfCurrentOrderNo = _aInvoiceManager.GetSellInvoiceIdUsingOrderNo(orderNo);

            SellProductManeger _aSellProductManeger = new SellProductManeger();
            

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

                    status2 = _aSellProductManeger.UpdateAllSellProductUsingOrderNo(aSellProduct,
                        invoiceIdOfCurrentOrderNo);
                    // _aInvoiceManager.UpdateAllSellProductUsingOrderNo(aSellProduct,OrderNo);
                    if (status2)
                    {
                        MessageBox.Show("SellProductTable Updated succeessfully");

                    }
                    else
                    {
                        MessageBox.Show("Error in Updating SellProductTable");
                    }


                    //Updating stock start

                    foreach (SellProduct aProduct in _aSellProductsForMatching)
                    {
                        if (aProduct.ItemName == aSellProduct.ItemName)
                        {
                            int statusStockcount = 1;
                            if (aProduct.Quantity != aSellProduct.Quantity)
                            {
                                StockManager _stockManager = new StockManager();
                                bool statusStock = false;

                                statusStock = _stockManager.SellReturnStockUpdate(aProduct, aSellProduct);

                                if (statusStock)
                                {
                                    MessageBox.Show(statusStockcount + "Sell Return Stock Updated");
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


            //Deleting item
            if(productsToBeDeleted !=null){
            foreach (SellProduct itemToDelete in productsToBeDeleted)
            {

                SellProductManeger aSellProductManager = new SellProductManeger();
                StockManager aStockManager = new StockManager();
                Int64 sellInvoiceId = aSellInvoiceManager.GetSellInvoiceIdUsingOrderNo(Convert.ToInt64(OrderNo));


                bool deleteItemFromSellProductTableSuccess =
                    aSellProductManager.DeleteSelectedItemUsingItemName(itemToDelete.ItemName, sellInvoiceId);
                bool updateStockDeletedItem = aStockManager.UpdateStockWhenDeletingIteM(itemToDelete);


                if (updateStockDeletedItem)
                {
                    MessageBox.Show("deleted Item Added To Stock Successfully");

                }
                else
                {
                    MessageBox.Show("Error to Adding deleted Item Added To Stock");
                }


                if (deleteItemFromSellProductTableSuccess)
                {
                    MessageBox.Show("Item successfully deleted from Sell Product table");

                }
                else
                {
                    MessageBox.Show("Error, Item can not be deleted from Sell Product table");
                }




            }



        }

            


            
          

            ProductInfoClear();
            CustomerInfoClear();

            productsToBeDeleted.Clear();

            
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
