using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEPOTManagementAndPOS.UI
{
    public partial class ViewProductInfoUI : Form
    {
        public ViewProductInfoUI()
        {
            InitializeComponent();
        }

        private void showFullDepotButton_Click(object sender, EventArgs e)
        {
            DepotInfoUI aDepotInfoUi=new DepotInfoUI();
            aDepotInfoUi.ShowDialog();

        }
    }
}
