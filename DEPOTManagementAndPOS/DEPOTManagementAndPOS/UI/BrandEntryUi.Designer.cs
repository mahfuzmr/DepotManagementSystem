namespace DEPOTManagementAndPOS.UI
{
    partial class BrandEntryUi
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
            this.closeNewBrandButton = new System.Windows.Forms.Button();
            this.createNewCategoryButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.saveNewBrandButton = new System.Windows.Forms.Button();
            this.brandNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 222);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshbutton);
            this.groupBox1.Controls.Add(this.closeNewBrandButton);
            this.groupBox1.Controls.Add(this.createNewCategoryButton);
            this.groupBox1.Controls.Add(this.categoryComboBox);
            this.groupBox1.Controls.Add(this.saveNewBrandButton);
            this.groupBox1.Controls.Add(this.brandNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Brand";
            // 
            // closeNewBrandButton
            // 
            this.closeNewBrandButton.Location = new System.Drawing.Point(156, 127);
            this.closeNewBrandButton.Name = "closeNewBrandButton";
            this.closeNewBrandButton.Size = new System.Drawing.Size(110, 35);
            this.closeNewBrandButton.TabIndex = 5;
            this.closeNewBrandButton.Text = "Close";
            this.closeNewBrandButton.UseVisualStyleBackColor = true;
            this.closeNewBrandButton.Click += new System.EventHandler(this.closeNewBrandButton_Click);
            // 
            // createNewCategoryButton
            // 
            this.createNewCategoryButton.Location = new System.Drawing.Point(389, 39);
            this.createNewCategoryButton.Name = "createNewCategoryButton";
            this.createNewCategoryButton.Size = new System.Drawing.Size(138, 32);
            this.createNewCategoryButton.TabIndex = 4;
            this.createNewCategoryButton.Text = "New Category";
            this.createNewCategoryButton.UseVisualStyleBackColor = true;
            this.createNewCategoryButton.Click += new System.EventHandler(this.createNewCategoryButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(164, 43);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(219, 24);
            this.categoryComboBox.TabIndex = 3;
            // 
            // saveNewBrandButton
            // 
            this.saveNewBrandButton.Location = new System.Drawing.Point(273, 127);
            this.saveNewBrandButton.Name = "saveNewBrandButton";
            this.saveNewBrandButton.Size = new System.Drawing.Size(110, 35);
            this.saveNewBrandButton.TabIndex = 2;
            this.saveNewBrandButton.Text = "Save";
            this.saveNewBrandButton.UseVisualStyleBackColor = true;
            this.saveNewBrandButton.Click += new System.EventHandler(this.saveNewBrandButton_Click);
            // 
            // brandNameTextBox
            // 
            this.brandNameTextBox.Location = new System.Drawing.Point(164, 90);
            this.brandNameTextBox.Name = "brandNameTextBox";
            this.brandNameTextBox.Size = new System.Drawing.Size(219, 23);
            this.brandNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category Name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Brand Name : ";
            // 
            // refreshbutton
            // 
            this.refreshbutton.Location = new System.Drawing.Point(390, 90);
            this.refreshbutton.Name = "refreshbutton";
            this.refreshbutton.Size = new System.Drawing.Size(138, 32);
            this.refreshbutton.TabIndex = 6;
            this.refreshbutton.Text = "Refresh";
            this.refreshbutton.UseVisualStyleBackColor = true;
            this.refreshbutton.Click += new System.EventHandler(this.refreshbutton_Click);
            // 
            // BrandEntryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(611, 240);
            this.Controls.Add(this.panel1);
            this.Name = "BrandEntryUi";
            this.Text = "Create New Brand";
            this.Load += new System.EventHandler(this.CreateNewBrand_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveNewBrandButton;
        private System.Windows.Forms.TextBox brandNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createNewCategoryButton;
        private System.Windows.Forms.Button closeNewBrandButton;
        private System.Windows.Forms.Button refreshbutton;
    }
}