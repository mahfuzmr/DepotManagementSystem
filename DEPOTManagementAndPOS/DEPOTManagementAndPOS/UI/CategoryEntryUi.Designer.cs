namespace DEPOTManagementAndPOS.UI
{
    partial class CategoryEntryUi
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
            this.saveCatagoryButton = new System.Windows.Forms.Button();
            this.categoryEntryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeCategoryEntryButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 178);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeCategoryEntryButton);
            this.groupBox1.Controls.Add(this.saveCatagoryButton);
            this.groupBox1.Controls.Add(this.categoryEntryTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Category";
            // 
            // saveCatagoryButton
            // 
            this.saveCatagoryButton.Location = new System.Drawing.Point(343, 85);
            this.saveCatagoryButton.Name = "saveCatagoryButton";
            this.saveCatagoryButton.Size = new System.Drawing.Size(110, 35);
            this.saveCatagoryButton.TabIndex = 2;
            this.saveCatagoryButton.Text = "Save";
            this.saveCatagoryButton.UseVisualStyleBackColor = true;
            this.saveCatagoryButton.Click += new System.EventHandler(this.saveCatagoryButton_Click);
            // 
            // categoryEntryTextBox
            // 
            this.categoryEntryTextBox.Location = new System.Drawing.Point(197, 48);
            this.categoryEntryTextBox.Name = "categoryEntryTextBox";
            this.categoryEntryTextBox.Size = new System.Drawing.Size(259, 23);
            this.categoryEntryTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Category Name : ";
            // 
            // closeCategoryEntryButton
            // 
            this.closeCategoryEntryButton.Location = new System.Drawing.Point(225, 85);
            this.closeCategoryEntryButton.Name = "closeCategoryEntryButton";
            this.closeCategoryEntryButton.Size = new System.Drawing.Size(110, 35);
            this.closeCategoryEntryButton.TabIndex = 3;
            this.closeCategoryEntryButton.Text = "Close";
            this.closeCategoryEntryButton.UseVisualStyleBackColor = true;
            this.closeCategoryEntryButton.Click += new System.EventHandler(this.closeCategoryEntryButton_Click);
            // 
            // CategoryEntryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(633, 205);
            this.Controls.Add(this.panel1);
            this.Name = "CategoryEntryUi";
            this.Text = "Add New Category";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveCatagoryButton;
        private System.Windows.Forms.TextBox categoryEntryTextBox;
        private System.Windows.Forms.Button closeCategoryEntryButton;
    }
}