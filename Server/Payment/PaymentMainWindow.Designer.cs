namespace Server.Payment
{
    partial class PaymentMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMainWindow));
            this.buttonsContainer = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.TablesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsContainer
            // 
            this.buttonsContainer.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonsContainer.Controls.Add(this.exitButton);
            this.buttonsContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonsContainer.Location = new System.Drawing.Point(429, 0);
            this.buttonsContainer.MaximumSize = new System.Drawing.Size(120, 0);
            this.buttonsContainer.MinimumSize = new System.Drawing.Size(120, 0);
            this.buttonsContainer.Name = "buttonsContainer";
            this.buttonsContainer.Size = new System.Drawing.Size(120, 293);
            this.buttonsContainer.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(6, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(109, 35);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.Exit);
            // 
            // TablesContainer
            // 
            this.TablesContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.TablesContainer.Location = new System.Drawing.Point(0, 0);
            this.TablesContainer.Name = "TablesContainer";
            this.TablesContainer.Size = new System.Drawing.Size(431, 293);
            this.TablesContainer.TabIndex = 1;
            // 
            // PaymentMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 293);
            this.Controls.Add(this.TablesContainer);
            this.Controls.Add(this.buttonsContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(565, 332);
            this.MinimumSize = new System.Drawing.Size(565, 332);
            this.Name = "PaymentMainWindow";
            this.Text = "Payment";
            this.buttonsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsContainer;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.FlowLayoutPanel TablesContainer;
    }
}