namespace Server.Payment
{
    partial class ServerTableDetaislForm
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
            System.Windows.Forms.Label totalTable;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerTableDetaislForm));
            this.ListViewOrders = new System.Windows.Forms.ListView();
            this.columnUnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.closeBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            totalTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListViewOrders
            // 
            this.ListViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnQuantity,
            this.columnDescription,
            this.columnUnitPrice,
            this.columnTotalPrice});
            this.ListViewOrders.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListViewOrders.FullRowSelect = true;
            this.ListViewOrders.HoverSelection = true;
            this.ListViewOrders.Location = new System.Drawing.Point(0, 0);
            this.ListViewOrders.MultiSelect = false;
            this.ListViewOrders.Name = "ListViewOrders";
            this.ListViewOrders.Size = new System.Drawing.Size(435, 308);
            this.ListViewOrders.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewOrders.TabIndex = 1;
            this.ListViewOrders.UseCompatibleStateImageBehavior = false;
            this.ListViewOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnUnitPrice
            // 
            this.columnUnitPrice.Text = "Unit Price";
            this.columnUnitPrice.Width = 83;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantity";
            this.columnQuantity.Width = 52;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Product";
            this.columnDescription.Width = 179;
            // 
            // columnTotalPrice
            // 
            this.columnTotalPrice.Text = "Total Price";
            this.columnTotalPrice.Width = 112;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(441, 55);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(101, 37);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Back";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseWindow);
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.Color.Transparent;
            this.printBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.printBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.ForeColor = System.Drawing.Color.White;
            this.printBtn.Location = new System.Drawing.Point(441, 12);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(101, 37);
            this.printBtn.TabIndex = 4;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.PrintReceipt);
            // 
            // totalTable
            // 
            totalTable.AutoSize = true;
            totalTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            totalTable.ForeColor = System.Drawing.Color.White;
            totalTable.Location = new System.Drawing.Point(438, 284);
            totalTable.Name = "totalTable";
            totalTable.Size = new System.Drawing.Size(47, 15);
            totalTable.TabIndex = 5;
            totalTable.Text = "Total: ";
            // 
            // TableDetaislForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(546, 308);
            this.Controls.Add(totalTable);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.ListViewOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(562, 347);
            this.MinimumSize = new System.Drawing.Size(562, 347);
            this.Name = "TableDetaislForm";
            this.Text = "Table Number ";
            this.Load += new System.EventHandler(this.TableDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewOrders;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnTotalPrice;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader columnUnitPrice;
        private System.Windows.Forms.Button printBtn;
    }
}