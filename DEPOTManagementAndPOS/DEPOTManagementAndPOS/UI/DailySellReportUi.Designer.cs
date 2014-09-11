namespace DEPOTManagementAndPOS.UI
{
    partial class DailySellReportUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sellReportDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dailySellReportPanel = new System.Windows.Forms.Panel();
            this.dailySellReportGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.showPDFReportButton = new System.Windows.Forms.Button();
            this.showDailyReportButton = new System.Windows.Forms.Button();
            this.dailySellReportDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSoldItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dailySellReportPanel.SuspendLayout();
            this.dailySellReportGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailySellReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sellReportDateTimePicker
            // 
            this.sellReportDateTimePicker.Location = new System.Drawing.Point(413, 22);
            this.sellReportDateTimePicker.Name = "sellReportDateTimePicker";
            this.sellReportDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.sellReportDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Date";
            // 
            // dailySellReportPanel
            // 
            this.dailySellReportPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dailySellReportPanel.Controls.Add(this.dailySellReportGroupBox);
            this.dailySellReportPanel.Location = new System.Drawing.Point(7, 2);
            this.dailySellReportPanel.Name = "dailySellReportPanel";
            this.dailySellReportPanel.Size = new System.Drawing.Size(1320, 698);
            this.dailySellReportPanel.TabIndex = 0;
            // 
            // dailySellReportGroupBox
            // 
            this.dailySellReportGroupBox.Controls.Add(this.label11);
            this.dailySellReportGroupBox.Controls.Add(this.showPDFReportButton);
            this.dailySellReportGroupBox.Controls.Add(this.showDailyReportButton);
            this.dailySellReportGroupBox.Controls.Add(this.dailySellReportDataGridView);
            this.dailySellReportGroupBox.Controls.Add(this.sellReportDateTimePicker);
            this.dailySellReportGroupBox.Controls.Add(this.label1);
            this.dailySellReportGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailySellReportGroupBox.Location = new System.Drawing.Point(13, 11);
            this.dailySellReportGroupBox.Name = "dailySellReportGroupBox";
            this.dailySellReportGroupBox.Size = new System.Drawing.Size(1297, 676);
            this.dailySellReportGroupBox.TabIndex = 0;
            this.dailySellReportGroupBox.TabStop = false;
            this.dailySellReportGroupBox.Text = "Daily Sell Report ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 657);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(466, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Developed And Powerd By TarfTech  Email:contact@tarftech.com Phone: 01738823238";
            // 
            // showPDFReportButton
            // 
            this.showPDFReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPDFReportButton.Location = new System.Drawing.Point(747, 16);
            this.showPDFReportButton.Name = "showPDFReportButton";
            this.showPDFReportButton.Size = new System.Drawing.Size(120, 35);
            this.showPDFReportButton.TabIndex = 3;
            this.showPDFReportButton.Text = "Show PDF Report";
            this.showPDFReportButton.UseVisualStyleBackColor = true;
            this.showPDFReportButton.Click += new System.EventHandler(this.showPDFReportButton_Click);
            // 
            // showDailyReportButton
            // 
            this.showDailyReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDailyReportButton.Location = new System.Drawing.Point(620, 16);
            this.showDailyReportButton.Name = "showDailyReportButton";
            this.showDailyReportButton.Size = new System.Drawing.Size(120, 35);
            this.showDailyReportButton.TabIndex = 2;
            this.showDailyReportButton.Text = "Show Report";
            this.showDailyReportButton.UseVisualStyleBackColor = true;
            this.showDailyReportButton.Click += new System.EventHandler(this.showDailyReportButton_Click);
            // 
            // dailySellReportDataGridView
            // 
            this.dailySellReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dailySellReportDataGridView.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dailySellReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailySellReportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.OrderDate,
            this.CustomerName,
            this.TotalPrice,
            this.Paid,
            this.Due,
            this.TotalSoldItem,
            this.PaymentMethod});
            this.dailySellReportDataGridView.Location = new System.Drawing.Point(6, 64);
            this.dailySellReportDataGridView.Name = "dailySellReportDataGridView";
            this.dailySellReportDataGridView.ReadOnly = true;
            this.dailySellReportDataGridView.Size = new System.Drawing.Size(1285, 590);
            this.dailySellReportDataGridView.TabIndex = 2;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // Paid
            // 
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // Due
            // 
            this.Due.HeaderText = "Due";
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // TotalSoldItem
            // 
            this.TotalSoldItem.HeaderText = "Total Item Sold";
            this.TotalSoldItem.Name = "TotalSoldItem";
            this.TotalSoldItem.ReadOnly = true;
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.HeaderText = "Payment Method";
            this.PaymentMethod.Name = "PaymentMethod";
            this.PaymentMethod.ReadOnly = true;
            // 
            // DailySellReportUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1334, 701);
            this.Controls.Add(this.dailySellReportPanel);
            this.Name = "DailySellReportUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailySellReportUi";
            this.dailySellReportPanel.ResumeLayout(false);
            this.dailySellReportGroupBox.ResumeLayout(false);
            this.dailySellReportGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailySellReportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker sellReportDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dailySellReportPanel;
        private System.Windows.Forms.GroupBox dailySellReportGroupBox;
        private System.Windows.Forms.DataGridView dailySellReportDataGridView;
        private System.Windows.Forms.Button showPDFReportButton;
        private System.Windows.Forms.Button showDailyReportButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSoldItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethod;
        private System.Windows.Forms.Label label11;
    }
}