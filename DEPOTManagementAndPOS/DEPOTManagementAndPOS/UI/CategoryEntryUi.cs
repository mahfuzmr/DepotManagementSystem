using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEPOTManagementAndPOS.BLL;
using DEPOTManagementAndPOS.Model;
using iTextSharp.text.pdf.codec;

namespace DEPOTManagementAndPOS.UI
{
    public partial class CategoryEntryUi : Form
    {
        public CategoryEntryUi()
        {
            InitializeComponent();
        }

        private void saveCatagoryButton_Click(object sender, EventArgs e)
        {
            CategoryEntry _aCategoryEntry = new CategoryEntry();

            string categoryName = categoryEntryTextBox.Text;
            _aCategoryEntry.Name = categoryName;
            CategoryEntryManager _aCategoryEntryManager = new CategoryEntryManager();

            
            string categoryNameFromDatabase = _aCategoryEntryManager.HasThisCategoryAlreadyExist(categoryName);

            categoryNameFromDatabase.ToUpper();
            categoryName.ToUpper();
            if (categoryNameFromDatabase != categoryName)
            {
                bool saveCategory = false;

                if (!string.IsNullOrEmpty(_aCategoryEntry.Name))
                {
                    saveCategory = _aCategoryEntryManager.SaveCategory(_aCategoryEntry);
                    if (saveCategory)
                    {
                        MessageBox.Show("Category saved succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Error saving new category");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a name for the Category");
                }    
            }
            else
            {
                MessageBox.Show("Category Name already exists");
            }
            
            


        }

        private void closeCategoryEntryButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
