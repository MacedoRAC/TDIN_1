using System.Windows.Forms;

namespace Client.Room
{
    partial class AddOrderDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrderDialog));
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantitySelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelector)).BeginInit();
            this.SuspendLayout();
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.AccessibleName = "";
            this.addOrderBtn.BackColor = System.Drawing.Color.Transparent;
            this.addOrderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.addOrderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.addOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addOrderBtn.ForeColor = System.Drawing.Color.White;
            this.addOrderBtn.Location = new System.Drawing.Point(89, 93);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(92, 33);
            this.addOrderBtn.TabIndex = 0;
            this.addOrderBtn.Text = "OK";
            this.addOrderBtn.UseVisualStyleBackColor = false;
            this.addOrderBtn.Click += new System.EventHandler(this.Add);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(207, 93);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 33);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.Cancel);
            // 
            // productsComboBox
            // 
            this.productsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.productsComboBox.BackColor = System.Drawing.Color.White;
            this.productsComboBox.DisplayMember = "Value";
            this.productsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(89, 12);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(250, 21);
            this.productsComboBox.Sorted = true;
            this.productsComboBox.TabIndex = 2;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.ForeColor = System.Drawing.Color.White;
            this.productLabel.Location = new System.Drawing.Point(12, 15);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(44, 13);
            this.productLabel.TabIndex = 3;
            this.productLabel.Text = "Product";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.ForeColor = System.Drawing.Color.White;
            this.quantityLabel.Location = new System.Drawing.Point(12, 53);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 4;
            this.quantityLabel.Text = "Quantity";
            // 
            // quantitySelector
            // 
            this.quantitySelector.BackColor = System.Drawing.Color.White;
            this.quantitySelector.Location = new System.Drawing.Point(89, 51);
            this.quantitySelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantitySelector.Name = "quantitySelector";
            this.quantitySelector.Size = new System.Drawing.Size(120, 20);
            this.quantitySelector.TabIndex = 5;
            this.quantitySelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddOrderDialog
            // 
            this.AcceptButton = this.addOrderBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(382, 138);
            this.Controls.Add(this.quantitySelector);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.productsComboBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addOrderBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddOrderDialog";
            this.Text = "New Order";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.quantitySelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addOrderBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantitySelector;
    }
}