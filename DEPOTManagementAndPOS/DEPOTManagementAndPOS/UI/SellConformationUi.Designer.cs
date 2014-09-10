namespace DEPOTManagementAndPOS.UI
{
    partial class SellConformationUi
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
            System.Windows.Forms.DataGridView itemDataGridView;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sellOrderNoextBox = new System.Windows.Forms.TextBox();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.shopeNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneNoTextBox = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grandTotalTextBox = new System.Windows.Forms.TextBox();
            this.paidTextBox = new System.Windows.Forms.TextBox();
            this.dueTextBox = new System.Windows.Forms.TextBox();
            this.pdfButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            itemDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(itemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(itemDataGridView);
            this.panel1.Controls.Add(this.dueTextBox);
            this.panel1.Controls.Add(this.paidTextBox);
            this.panel1.Controls.Add(this.grandTotalTextBox);
            this.panel1.Controls.Add(this.phoneNoTextBox);
            this.panel1.Controls.Add(this.shopeNameTextBox);
            this.panel1.Controls.Add(this.CustomerNameTextBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 584);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sell Order No. : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Name : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Shop Name : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Phone Number : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Magenta;
            this.panel2.Controls.Add(this.sellOrderNoextBox);
            this.panel2.Location = new System.Drawing.Point(189, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 43);
            this.panel2.TabIndex = 2;
            // 
            // sellOrderNoextBox
            // 
            this.sellOrderNoextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sellOrderNoextBox.ForeColor = System.Drawing.Color.Red;
            this.sellOrderNoextBox.Location = new System.Drawing.Point(4, 8);
            this.sellOrderNoextBox.Name = "sellOrderNoextBox";
            this.sellOrderNoextBox.ReadOnly = true;
            this.sellOrderNoextBox.Size = new System.Drawing.Size(154, 26);
            this.sellOrderNoextBox.TabIndex = 0;
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Location = new System.Drawing.Point(193, 58);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.ReadOnly = true;
            this.CustomerNameTextBox.Size = new System.Drawing.Size(154, 26);
            this.CustomerNameTextBox.TabIndex = 0;
            // 
            // shopeNameTextBox
            // 
            this.shopeNameTextBox.Location = new System.Drawing.Point(193, 99);
            this.shopeNameTextBox.Name = "shopeNameTextBox";
            this.shopeNameTextBox.ReadOnly = true;
            this.shopeNameTextBox.Size = new System.Drawing.Size(154, 26);
            this.shopeNameTextBox.TabIndex = 0;
            // 
            // phoneNoTextBox
            // 
            this.phoneNoTextBox.Location = new System.Drawing.Point(193, 136);
            this.phoneNoTextBox.Name = "phoneNoTextBox";
            this.phoneNoTextBox.ReadOnly = true;
            this.phoneNoTextBox.Size = new System.Drawing.Size(154, 26);
            this.phoneNoTextBox.TabIndex = 0;
            // 
            // itemDataGridView
            // 
            itemDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            itemDataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            itemDataGridView.GridColor = System.Drawing.Color.PaleGreen;
            itemDataGridView.Location = new System.Drawing.Point(3, 196);
            itemDataGridView.Name = "itemDataGridView";
            itemDataGridView.ReadOnly = true;
            itemDataGridView.Size = new System.Drawing.Size(622, 348);
            itemDataGridView.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grand Total : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Paid : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 551);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Due : ";
            // 
            // grandTotalTextBox
            // 
            this.grandTotalTextBox.Location = new System.Drawing.Point(105, 548);
            this.grandTotalTextBox.Name = "grandTotalTextBox";
            this.grandTotalTextBox.ReadOnly = true;
            this.grandTotalTextBox.Size = new System.Drawing.Size(130, 26);
            this.grandTotalTextBox.TabIndex = 0;
            // 
            // paidTextBox
            // 
            this.paidTextBox.Location = new System.Drawing.Point(284, 548);
            this.paidTextBox.Name = "paidTextBox";
            this.paidTextBox.ReadOnly = true;
            this.paidTextBox.Size = new System.Drawing.Size(137, 26);
            this.paidTextBox.TabIndex = 0;
            // 
            // dueTextBox
            // 
            this.dueTextBox.Location = new System.Drawing.Point(491, 548);
            this.dueTextBox.Name = "dueTextBox";
            this.dueTextBox.ReadOnly = true;
            this.dueTextBox.Size = new System.Drawing.Size(134, 26);
            this.dueTextBox.TabIndex = 0;
            // 
            // pdfButton
            // 
            this.pdfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfButton.Location = new System.Drawing.Point(231, 602);
            this.pdfButton.Name = "pdfButton";
            this.pdfButton.Size = new System.Drawing.Size(128, 51);
            this.pdfButton.TabIndex = 1;
            this.pdfButton.Text = "PDF";
            this.pdfButton.UseVisualStyleBackColor = true;
            // 
            // ContinueButton
            // 
            this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueButton.Location = new System.Drawing.Point(431, 603);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(121, 50);
            this.ContinueButton.TabIndex = 1;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            // 
            // SellConformationUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 665);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.pdfButton);
            this.Controls.Add(this.panel1);
            this.Name = "SellConformationUi";
            this.Text = "Sell Conformation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(itemDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox dueTextBox;
        private System.Windows.Forms.TextBox paidTextBox;
        private System.Windows.Forms.TextBox grandTotalTextBox;
        private System.Windows.Forms.TextBox phoneNoTextBox;
        private System.Windows.Forms.TextBox shopeNameTextBox;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox sellOrderNoextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pdfButton;
        private System.Windows.Forms.Button ContinueButton;
    }
}