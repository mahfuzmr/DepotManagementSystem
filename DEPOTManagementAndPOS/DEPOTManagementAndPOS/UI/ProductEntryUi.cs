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
    public partial class ProductEntryUi : Form
    {
        public ProductEntryUi()
        {
            InitializeComponent();
            categoryComboBox.ValueMember = "CategoryEntryId";
            categoryComboBox.DisplayMember = "Name";

            brandComboBox.ValueMember = "BrandEnteyId";
            brandComboBox.DisplayMember = "Name";
            
            
        }

        private void saveProductButton_Click(object sender, EventArgs e)
        {
            Product _aProduct = new Product();
            ProductEntryManager _aProductEntryManager = new ProductEntryManager();
            bool saveNewProduct = false;

            CategoryEntry selectedCategory = (CategoryEntry) categoryComboBox.SelectedItem;
            BrandEntry selectedBrand = (BrandEntry) brandComboBox.SelectedItem;

            _aProduct.ProductNameExtention = productExtensionEntryTextBox.Text;
            _aProduct.CategoryEntry = selectedCategory;
            _aProduct.BrandEntry = selectedBrand;

            saveNewProduct = _aProductEntryManager.SaveProductNameExtention(_aProduct);
            if (saveNewProduct)
            {
                MessageBox.Show("Product name extention saved successful");
            }
            else
            {
                MessageBox.Show("Error saving product name extention");
            }

        }

        private void ProductEntryUi_Load(object sender, EventArgs e)
        {
            CategoryEntryManager _aCategoryEntryManager = new CategoryEntryManager();
            categoryComboBox.DataSource = _aCategoryEntryManager.GetAllCategory();
           
            
           
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           CategoryEntry selectedCategory = (CategoryEntry)categoryComboBox.SelectedItem;
            
           NewBrandEntryManager _aNewBrandEntryManager = new NewBrandEntryManager();
           if (_aNewBrandEntryManager.GetAllBrandUsingCategoryId(selectedCategory.CategoryEntryId).Count!=0)
           {
                brandComboBox.DataSource = _aNewBrandEntryManager.GetAllBrandUsingCategoryId(selectedCategory.CategoryEntryId);
           }
           else
           {
                List<BrandEntry> _aNewBrandEntryList = new List<BrandEntry>();
                BrandEntry _aBrandEntry = new BrandEntry();
                _aBrandEntry.BrandEnteyId = -1;
                _aBrandEntry.Name = " ";
                _aNewBrandEntryList.Add(_aBrandEntry);
                brandComboBox.DataSource = _aNewBrandEntryList;

            }
                  
  
        
            
            
        }

        private void addNewCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryEntryUi aCategoryEntryUi = new CategoryEntryUi();
            aCategoryEntryUi.ShowDialog();
        }

        private void addNewBrandButton_Click(object sender, EventArgs e)
        {
            BrandEntryUi _aBrandEntryUi = new BrandEntryUi();
            _aBrandEntryUi.ShowDialog();
        }

        private void closeProductEntryButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
       

        
    }
}
