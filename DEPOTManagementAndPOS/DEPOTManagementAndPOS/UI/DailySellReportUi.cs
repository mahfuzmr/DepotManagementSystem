using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEPOTManagementAndPOS.BLL;
using DEPOTManagementAndPOS.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;

namespace DEPOTManagementAndPOS.UI
{
    public partial class DailySellReportUi : Form
    {
        public DailySellReportUi()
        {
            InitializeComponent();
        }

        private void showDailyReportButton_Click(object sender, EventArgs e)
        {
            dailySellReportDataGridView.Rows.Clear();
            string selectedDate = sellReportDateTimePicker.Value.ToShortDateString();

            List<SellInvoice> _sellInvoiceList = new List<SellInvoice>();
            SellInvoiceManager _aSellInvoiceManager = new SellInvoiceManager();
            _sellInvoiceList = _aSellInvoiceManager.GetSellReportUsingDate(selectedDate);

            foreach (var sellInvoice in _sellInvoiceList)
            {
                dailySellReportDataGridView.Rows.Add(sellInvoice.OrderNo, sellInvoice.SellDate, sellInvoice.Customer.Name,
                    sellInvoice.GrandTotal, sellInvoice.Paid, sellInvoice.Due,
                    sellInvoice.TotalItemSold, sellInvoice.CashStatus);
            }
        }

        private void showPDFReportButton_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Rectangle rec2 = new iTextSharp.text.Rectangle(PageSize.A4);

            rec2.BackgroundColor = new CMYKColor(0, 0, 0, 0);

            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            try
            {
                using (FileStream fs = new FileStream(appRootDir + "/PDFs/" + "DailyReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                
                using (Document doc = new Document(rec2))
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    
                    doc.Open();

                    PdfPTable reportTable = new PdfPTable(dailySellReportDataGridView.Columns.Count);

                    for (int i = 0; i < dailySellReportDataGridView.Columns.Count; i++)
                    {
                        reportTable.AddCell(new Phrase(dailySellReportDataGridView.Columns[i].HeaderText));
                    }

                    reportTable.HeaderRows = 1;

                    for (int j = 0; j < dailySellReportDataGridView.Rows.Count; j++)
                    {
                        for (int k = 0; k < dailySellReportDataGridView.Columns.Count; k++)
                        {
                            if (dailySellReportDataGridView[k, j].Value != null)
                            {
                                reportTable.AddCell(new Phrase(dailySellReportDataGridView[k, j].Value.ToString()));
                            }
                        }
                    }

                    doc.Add(reportTable);
                    doc.Close();

                    System.Diagnostics.Process.Start(appRootDir + "/PDFs/" + "DailyReport.pdf");

                }
            }
            
            catch (DocumentException de)
            {
                throw de;
            }
            
            catch (IOException ioe)
            {
                throw ioe;
            }
        }
    }
}
