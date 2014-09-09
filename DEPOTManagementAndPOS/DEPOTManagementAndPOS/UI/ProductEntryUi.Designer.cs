namespace DEPOTManagementAndPOS.UI
{
    partial class ProductEntryUi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productExtensionEntryTextBox = new System.Windows.Forms.TextBox();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.addNewBrandButton = new System.Windows.Forms.Button();
            this.addNewCategoryButton = new System.Windows.Forms.Button();
            this.brandComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.closeProductEntryButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 245);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeProductEntryButton);
            this.groupBox1.Controls.Add(this.productExtensionEntryTextBox);
            this.groupBox1.Controls.Add(this.saveProductButton);
            this.groupBox1.Controls.Add(this.addNewBrandButton);
            this.groupBox1.Controls.Add(this.addNewCategoryButton);
            this.groupBox1.Controls.Add(this.brandComboBox);
            this.groupBox1.Controls.Add(this.categoryComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Product";
            // 
            // productExtensionEntryTextBox
            // 
            this.productExtensionEntryTextBox.Location = new System.Drawing.Point(181, 129);
            this.productExtensionEntryTextBox.Name = "productExtensionEntryTextBox";
            this.productExtensionEntryTextBox.Size = new System.Drawing.Size(240, 23);
            this.productExtensionEntryTextBox.TabIndex = 0;
            // 
            // saveProductButton
            // 
            this.saveProductButton.Location = new System.Drawing.Point(317, 163);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(110, 35);
            this.saveProductButton.TabIndex = 14;
            this.saveProductButton.Text = "Save";
            this.saveProductButton.UseVisualStyleBackColor = true;
            this.saveProductButton.Click += new System.EventHandler(this.saveProductButton_Click);
            // 
            // addNewBrandButton
            // 
            this.addNewBrandButton.Location = new System.Drawing.Point(427, 78);
            this.addNewBrandButton.Name = "addNewBrandButton";
            this.addNewBrandButton.Size = new System.Drawing.Size(154, 35);
            this.addNewBrandButton.TabIndex = 14;
            this.addNewBrandButton.Text = "Add New Brand";
            this.addNewBrandButton.UseVisualStyleBackColor = true;
            this.addNewBrandButton.Click += new System.EventHandler(this.addNewBrandButton_Click);
            // 
            // addNewCategoryButton
            // 
            this.addNewCategoryButton.Location = new System.Drawing.Point(426, 34);
            this.addNewCategoryButton.Name = "addNewCategoryButton";
            this.addNewCategoryButton.Size = new System.Drawing.Size(154, 35);
            this.addNewCategoryButton.TabIndex = 15;
            this.addNewCategoryButton.Text = "Add New Category";
            this.addNewCategoryButton.UseVisualStyleBackColor = true;
            this.addNewCategoryButton.Click += new System.EventHandler(this.addNewCategoryButton_Click);
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(181, 83);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(240, 24);
            this.brandComboBox.TabIndex = 13;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(181, 39);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(240, 24);
            this.categoryComboBox.TabIndex = 12;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Product Extension : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Brand : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Category : ";
            // 
            // closeProductEntryButton
            // 
            this.closeProductEntryButton.Location = new System.Drawing.Point(201, 163);
            this.closeProductEntryButton.Name = "closeProductEntryButton";
            this.closeProductEntryButton.Size = new System.Drawing.Size(110, 35);
            this.closeProductEntryButton.TabIndex = 16;
            this.closeProductEntryButton.Text = "Close";
            this.closeProductEntryButton.UseVisualStyleBackColor = true;
            this.closeProductEntryButton.Click += new System.EventHandler(this.closeProductEntryButton_Click);
            // 
            // ProductEntryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(696, 269);
            this.Controls.Add(this.panel1);
            this.Name = "ProductEntryUi";
            this.Text = "New Product Entry";
            this.Load += new System.EventHandler(this.ProductEntryUi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox productExtensionEntryTextBox;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.Button addNewBrandButton;
        private System.Windows.Forms.Button addNewCategoryButton;
        private System.Windows.Forms.ComboBox brandComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button closeProductEntryButton;
    }
}