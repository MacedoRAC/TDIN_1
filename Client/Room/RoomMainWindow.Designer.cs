namespace Client.Room
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
            this.MealsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.MealsContainerTitle = new System.Windows.Forms.Label();
            this.openMealButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.MealsContainer.SuspendLayout();
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
            this.mainSplitContainer.Panel1.Controls.Add(this.MealsContainer);
            this.mainSplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.AccessibleName = "ButtonsContainer";
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.mainSplitContainer.Panel2.Controls.Add(this.exitButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.openMealButton);
            this.mainSplitContainer.Panel2.ForeColor = System.Drawing.Color.White;
            this.mainSplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.mainSplitContainer.Size = new System.Drawing.Size(565, 332);
            this.mainSplitContainer.SplitterDistance = 422;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // MealsContainer
            // 
            this.MealsContainer.Controls.Add(this.MealsContainerTitle);
            this.MealsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MealsContainer.Location = new System.Drawing.Point(0, 0);
            this.MealsContainer.Name = "MealsContainer";
            this.MealsContainer.Size = new System.Drawing.Size(422, 332);
            this.MealsContainer.TabIndex = 0;
            this.AutoScroll = true;
            // 
            // MealsContainerTitle
            // 
            this.MealsContainerTitle.AutoSize = true;
            this.MealsContainer.SetFlowBreak(this.MealsContainerTitle, true);
            this.MealsContainerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MealsContainerTitle.Location = new System.Drawing.Point(3, 0);
            this.MealsContainerTitle.Name = "MealsContainerTitle";
            this.MealsContainerTitle.Size = new System.Drawing.Size(187, 20);
            this.MealsContainerTitle.TabIndex = 0;
            this.MealsContainerTitle.Text = "Currently Open Meals";
            // 
            // openTableButton
            // 
            this.openMealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openMealButton.ForeColor = System.Drawing.Color.White;
            this.openMealButton.Location = new System.Drawing.Point(4, 13);
            this.openMealButton.Name = "openMealButton";
            this.openMealButton.Size = new System.Drawing.Size(130, 35);
            this.openMealButton.TabIndex = 0;
            this.openMealButton.Text = "Open Meal";
            this.openMealButton.UseVisualStyleBackColor = true;
            this.openMealButton.Click += new System.EventHandler(this.OpenNewMeal);
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
            this.MealsContainer.ResumeLayout(false);
            this.MealsContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel MealsContainer;
        private System.Windows.Forms.Label MealsContainerTitle;
        private System.Windows.Forms.Button openMealButton;
        private System.Windows.Forms.Button exitButton;
    }
}