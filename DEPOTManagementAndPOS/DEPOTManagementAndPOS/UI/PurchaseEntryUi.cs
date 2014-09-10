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
    public partial class PurchaseEntryUi : Form
    {
        public PurchaseEntryUi()
        {
            InitializeComponent();
        }

       

        private void PurchaseEntryUi_Load(object sender, EventArgs e)
        {
            PurchaseManager _aPurchaseManager = new PurchaseManager();
            
            string[] productNameFromJoinedDatabase = _aPurchaseManager.GetProductNameWithCategoryAndBrandName().Select(x => string.Format("{0} {1} {2}", x.CategoryEntry.Name, x.BrandEntry.Name, x.Product.ProductNameExtention)).ToArray();

            
            productNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(productNameFromJoinedDatabase);
            productNameTextBox.AutoCompleteCustomSource = autoComplete;

        }






       
        private void closePurchaseEntryUiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savePurchaseButton_Click(object sender, EventArgs e)
        {
            Purchase _aPurchase = new Purchase();
            PurchaseManager _aPurchaseManager = new PurchaseManager();

            Stock _aStock = new Stock();
            StockManager _aStockManager = new StockManager();


            bool savePurchaseSuccess = false;
            bool saveStockSuccess = false;

            String productNameFromTextBox = null;
            productNameFromTextBox = productNameTextBox.Text;



            _aStock = _aStockManager.GetCurrentStockInfo(productNameFromTextBox);
            string productNameFromDatabase = _aStock.ProductName;

            // Update Stock
            if (productNameFromTextBox == productNameFromDatabase)
            {

                int quantityPrevious = _aStock.QuantityInStock;
                int newQuantity = Convert.ToInt32(quantityTextBox.Text);
                int totalQuantity = quantityPrevious + newQuantity;
                
                _aStock.QuantityInStock = totalQuantity;
                _aStock.ProductName = productNameFromTextBox;


                saveStockSuccess = _aStockManager.UpdateAllStockInfo(_aStock);
                if (saveStockSuccess)
                {
                    MessageBox.Show("Stock info updated Successfully");
                }
                else
                {
                    MessageBox.Show("Error while updating stock info");
                }

            }

            else if (productNameFromTextBox != productNameFromDatabase)
            {
                _aStock.QuantityInStock = Convert.ToInt32(quantityTextBox.Text);
                _aStock.ProductName = productNameFromTextBox;
                saveStockSuccess = _aStockManager.SaveNewStockInfo(_aStock);

                if (saveStockSuccess)
                {
                    MessageBox.Show("New stock info saved successfully");
                }
                else
                {
                    MessageBox.Show("Error saving new stock info");
                }
            }

            _aPurchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
            _aPurchase.ProductName = productNameFromTextBox;
            _aPurchase.Price = Convert.ToDouble(unitPriceTextBox.Text);
            totalPriceTextBox.Text = _aPurchase.GetTotalPurchasePrice().ToString();
            _aPurchase.TotalPurchasePrice = Convert.ToDouble(totalPriceTextBox.Text);
            _aPurchase.DateTime = dateTimePicker.Value.ToShortDateString();

            savePurchaseSuccess = _aPurchaseManager.SaveAllPurchaseInfo(_aPurchase);
            if (savePurchaseSuccess)
            {
                MessageBox.Show("Product Purchase info saved Successfully");
            }
            else
            {
                MessageBox.Show("Error saving Purchase info");
            }

        }

        private void addNewItemButton_Click(object sender, EventArgs e)
        {
            ProductEntryUi _aProductEntryUi = new ProductEntryUi();
            _aProductEntryUi.ShowDialog();
        }
        
        private void quantityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Purchase _aPurchase = new Purchase();    
            
            if (unitPriceTextBox.Text != "" && quantityTextBox.Text!= "")
            {
                _aPurchase.Price = Convert.ToDouble(unitPriceTextBox.Text);
                _aPurchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
                totalPriceTextBox.Text = _aPurchase.GetTotalPurchasePrice().ToString();
                    
            }
            else
            {
                _aPurchase.Quantity = 0;
                totalPriceTextBox.Clear();
            }
            
        }

        private void viewProductInfoButton_Click(object sender, EventArgs e)
        {
            ViewProductInfoUI aViewProductInfoUi = new ViewProductInfoUI();
            aViewProductInfoUi.ShowDialog();

        }

       

       
    }
}
