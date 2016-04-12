namespace Client.Room
{
    partial class KitchenMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenMainWindow));
            this.ListViewOrders = new System.Windows.Forms.ListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attendOrderBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.finishOrderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewOrders
            // 
            this.ListViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnQuantity,
            this.columnDescription,
            this.columnTable,
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
            // columnId
            // 
            this.columnId.Text = "Order Number";
            this.columnId.Width = 78;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantity";
            this.columnQuantity.Width = 54;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Product";
            this.columnDescription.Width = 166;
            // 
            // columnTable
            // 
            this.columnTable.Text = "Table";
            this.columnTable.Width = 39;
            // 
            // columnState
            // 
            this.columnState.Text = "State";
            this.columnState.Width = 92;
            // 
            // attendOrderBtn
            // 
            this.attendOrderBtn.BackColor = System.Drawing.Color.Transparent;
            this.attendOrderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.attendOrderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.attendOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendOrderBtn.ForeColor = System.Drawing.Color.White;
            this.attendOrderBtn.Location = new System.Drawing.Point(441, 12);
            this.attendOrderBtn.Name = "attendOrderBtn";
            this.attendOrderBtn.Size = new System.Drawing.Size(96, 37);
            this.attendOrderBtn.TabIndex = 2;
            this.attendOrderBtn.Text = "Attend Order";
            this.attendOrderBtn.UseVisualStyleBackColor = false;
            this.attendOrderBtn.Click += new System.EventHandler(this.AttendOrder);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(441, 98);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(96, 37);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Exit";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.Exit);
            // 
            // finishOrderBtn
            // 
            this.finishOrderBtn.BackColor = System.Drawing.Color.Transparent;
            this.finishOrderBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.finishOrderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.finishOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishOrderBtn.ForeColor = System.Drawing.Color.White;
            this.finishOrderBtn.Location = new System.Drawing.Point(441, 55);
            this.finishOrderBtn.Name = "finishOrderBtn";
            this.finishOrderBtn.Size = new System.Drawing.Size(96, 37);
            this.finishOrderBtn.TabIndex = 4;
            this.finishOrderBtn.Text = "Finish Order";
            this.finishOrderBtn.UseVisualStyleBackColor = false;
            this.finishOrderBtn.Click += new System.EventHandler(this.FinishOrder);
            // 
            // KitchenMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(546, 308);
            this.Controls.Add(this.finishOrderBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.attendOrderBtn);
            this.Controls.Add(this.ListViewOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitchenMainWindow";
            this.Text = "Kitchen";
            this.Load += new System.EventHandler(this.KitchenMainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewOrders;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnState;
        private System.Windows.Forms.Button attendOrderBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColumnHeader columnTable;
        private System.Windows.Forms.Button finishOrderBtn;
        private System.Windows.Forms.ColumnHeader columnId;
    }
}