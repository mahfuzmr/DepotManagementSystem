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
    public partial class CategoryEntryUi : Form
    {
        public CategoryEntryUi()
        {
            InitializeComponent();
        }

        private void saveCatagoryButton_Click(object sender, EventArgs e)
        {
            CategoryEntry _aCategoryEntry = new CategoryEntry();
            _aCategoryEntry.Name = categoryEntryTextBox.Text;

            CategoryEntryManager _aCategoryEntryManager = new CategoryEntryManager();

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

        private void closeCategoryEntryButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
