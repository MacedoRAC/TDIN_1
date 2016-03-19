namespace Room
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitMainContainer = new System.Windows.Forms.SplitContainer();
            this.tablesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.addTableBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainContainer)).BeginInit();
            this.splitMainContainer.Panel1.SuspendLayout();
            this.splitMainContainer.Panel2.SuspendLayout();
            this.splitMainContainer.SuspendLayout();
            this.buttonsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMainContainer
            // 
            this.splitMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainContainer.Location = new System.Drawing.Point(0, 0);
            this.splitMainContainer.Name = "splitMainContainer";
            // 
            // splitMainContainer.Panel1
            // 
            this.splitMainContainer.Panel1.Controls.Add(this.tablesContainer);
            // 
            // splitMainContainer.Panel2
            // 
            this.splitMainContainer.Panel2.Controls.Add(this.buttonsContainer);
            this.splitMainContainer.Size = new System.Drawing.Size(512, 326);
            this.splitMainContainer.SplitterDistance = 397;
            this.splitMainContainer.TabIndex = 0;
            // 
            // tablesContainer
            // 
            this.tablesContainer.Location = new System.Drawing.Point(0, 0);
            this.tablesContainer.Name = "tablesContainer";
            this.tablesContainer.Size = new System.Drawing.Size(394, 326);
            this.tablesContainer.TabIndex = 0;
            // 
            // buttonsContainer
            // 
            this.buttonsContainer.BackColor = System.Drawing.Color.Teal;
            this.buttonsContainer.Controls.Add(this.addTableBtn);
            this.buttonsContainer.Location = new System.Drawing.Point(-1, 0);
            this.buttonsContainer.Name = "buttonsContainer";
            this.buttonsContainer.Size = new System.Drawing.Size(112, 331);
            this.buttonsContainer.TabIndex = 0;
            // 
            // addTableBtn
            // 
            this.addTableBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.addTableBtn.FlatAppearance.BorderSize = 0;
            this.addTableBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTableBtn.ForeColor = System.Drawing.Color.White;
            this.addTableBtn.Location = new System.Drawing.Point(2, 3);
            this.addTableBtn.Margin = new System.Windows.Forms.Padding(2, 3, 3, 0);
            this.addTableBtn.Name = "addTableBtn";
            this.addTableBtn.Size = new System.Drawing.Size(107, 39);
            this.addTableBtn.TabIndex = 0;
            this.addTableBtn.Text = "Open Table";
            this.addTableBtn.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(512, 326);
            this.Controls.Add(this.splitMainContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Room";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitMainContainer.Panel1.ResumeLayout(false);
            this.splitMainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMainContainer)).EndInit();
            this.splitMainContainer.ResumeLayout(false);
            this.buttonsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMainContainer;
        private System.Windows.Forms.FlowLayoutPanel tablesContainer;
        private System.Windows.Forms.FlowLayoutPanel buttonsContainer;
        private System.Windows.Forms.Button addTableBtn;
    }
}

