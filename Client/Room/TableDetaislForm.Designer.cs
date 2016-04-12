namespace Client.Room
{
    partial class TableDetaislForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDetaislForm));
            this.ListViewOrders = new System.Windows.Forms.ListView();
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewOrders
            // 
            this.ListViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnQuantity,
            this.columnDescription,
            this.columnState});
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
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantity";
            this.columnQuantity.Width = 63;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Product";
            this.columnDescription.Width = 275;
            // 
            // columnState
            // 
            this.columnState.Text = "State";
            this.columnState.Width = 92;
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.BackColor = System.Drawing.Color.Transparent;
            this.addOrderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.addOrderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.addOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addOrderBtn.ForeColor = System.Drawing.Color.White;
            this.addOrderBtn.Location = new System.Drawing.Point(438, 13);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(96, 37);
            this.addOrderBtn.TabIndex = 1;
            this.addOrderBtn.Text = "Add Order";
            this.addOrderBtn.UseVisualStyleBackColor = false;
            this.addOrderBtn.Click += new System.EventHandler(this.OpenNewOrderDialog);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(438, 56);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(96, 37);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseWindow);
            // 
            // TableDetaislForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(546, 308);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.addOrderBtn);
            this.Controls.Add(this.ListViewOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableDetaislForm";
            this.Text = "Meal Number ";
            this.Load += new System.EventHandler(this.TableDetailsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewOrders;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnState;
        private System.Windows.Forms.Button addOrderBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}