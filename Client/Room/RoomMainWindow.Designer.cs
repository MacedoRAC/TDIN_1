﻿namespace Client.Room
{
    partial class RoomMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomMainWindow));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TablesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.TablesContainerTitle = new System.Windows.Forms.Label();
            this.openTableButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.TablesContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.AccessibleName = "MainContainer";
            this.mainSplitContainer.Panel1.Controls.Add(this.TablesContainer);
            this.mainSplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.AccessibleName = "ButtonsContainer";
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.mainSplitContainer.Panel2.Controls.Add(this.exitButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.openTableButton);
            this.mainSplitContainer.Panel2.ForeColor = System.Drawing.Color.White;
            this.mainSplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.mainSplitContainer.Size = new System.Drawing.Size(565, 332);
            this.mainSplitContainer.SplitterDistance = 422;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // TablesContainer
            // 
            this.TablesContainer.Controls.Add(this.TablesContainerTitle);
            this.TablesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesContainer.Location = new System.Drawing.Point(0, 0);
            this.TablesContainer.Name = "TablesContainer";
            this.TablesContainer.Size = new System.Drawing.Size(422, 332);
            this.TablesContainer.TabIndex = 0;
            this.AutoScroll = true;
            // 
            // TablesContainerTitle
            // 
            this.TablesContainerTitle.AutoSize = true;
            this.TablesContainer.SetFlowBreak(this.TablesContainerTitle, true);
            this.TablesContainerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TablesContainerTitle.Location = new System.Drawing.Point(3, 0);
            this.TablesContainerTitle.Name = "TablesContainerTitle";
            this.TablesContainerTitle.Size = new System.Drawing.Size(187, 20);
            this.TablesContainerTitle.TabIndex = 0;
            this.TablesContainerTitle.Text = "Currently Open Tables";
            // 
            // openTableButton
            // 
            this.openTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openTableButton.ForeColor = System.Drawing.Color.White;
            this.openTableButton.Location = new System.Drawing.Point(4, 13);
            this.openTableButton.Name = "openTableButton";
            this.openTableButton.Size = new System.Drawing.Size(130, 35);
            this.openTableButton.TabIndex = 0;
            this.openTableButton.Text = "Open Table";
            this.openTableButton.UseVisualStyleBackColor = true;
            this.openTableButton.Click += new System.EventHandler(this.OpenNewTable);
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(4, 54);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 35);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exit);
            // 
            // RoomMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(565, 332);
            this.Controls.Add(this.mainSplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Load += new System.EventHandler(this.RoomMainWindow_Load);
            this.Name = "RoomMainWindow";
            this.Text = "Room";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.TablesContainer.ResumeLayout(false);
            this.TablesContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel TablesContainer;
        private System.Windows.Forms.Label TablesContainerTitle;
        private System.Windows.Forms.Button openTableButton;
        private System.Windows.Forms.Button exitButton;
    }
}