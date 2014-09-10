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
    public partial class BrandEntryUi : Form
    {
        public BrandEntryUi()
        {
            InitializeComponent();
            categoryComboBox.ValueMember = "CategoryEntryId";
            categoryComboBox.DisplayMember = "Name";
            

        }

       

        private void saveNewBrandButton_Click(object sender, EventArgs e)
        {
            BrandEntry aBrandEntry = new BrandEntry();
            CategoryEntry selectedCategory = (CategoryEntry) categoryComboBox.SelectedItem;
            
            aBrandEntry.Name = brandNameTextBox.Text;
            aBrandEntry.CategoryEntry = selectedCategory;

            NewBrandEntryManager aNewBrandEntryManager = new NewBrandEntryManager();
            bool saveNewBrandEntry = false;

            if (!string.IsNullOrEmpty(aBrandEntry.Name))
            {
                saveNewBrandEntry = aNewBrandEntryManager.SaveNewBrand(aBrandEntry);

                if (selectedCategory != null)
                {
                    if (saveNewBrandEntry)
                    {
                        MessageBox.Show("New Brand saved successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error saving new brand");
                    }
                }    
            }
            else
            {
                MessageBox.Show("Please enter a brand name");
            }
            
            
            
        }

        private void CreateNewBrand_Load(object sender, EventArgs e)
        {
            CategoryEntryManager _aCategoryEntryManager = new CategoryEntryManager();
            categoryComboBox.DataSource = _aCategoryEntryManager.GetAllCategory();
        }

        private void createNewCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryEntryUi aCategoryEntryUi = new CategoryEntryUi();
            aCategoryEntryUi.ShowDialog();
        }

        private void closeNewBrandButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            CategoryEntryManager _aCategoryEntryManager = new CategoryEntryManager();
            categoryComboBox.DataSource = _aCategoryEntryManager.GetAllCategory();
        }

        

       
    }
}
