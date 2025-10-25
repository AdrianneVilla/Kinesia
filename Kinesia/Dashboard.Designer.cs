namespace Kinesia
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            ContentsPanel = new System.Windows.Forms.Panel();
            header1 = new Kinesia.Components.Header();
            sidebar1 = new Kinesia.Components.Sidebar();
            SuspendLayout();
            // 
            // ContentsPanel
            // 
            ContentsPanel.AutoSize = true;
            ContentsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ContentsPanel.Location = new System.Drawing.Point(314, 80);
            ContentsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ContentsPanel.Name = "ContentsPanel";
            ContentsPanel.Size = new System.Drawing.Size(1128, 958);
            ContentsPanel.TabIndex = 2;
            // 
            // header1
            // 
            header1.BackColor = System.Drawing.Color.White;
            header1.BackgroundImage = (System.Drawing.Image)resources.GetObject("header1.BackgroundImage");
            header1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            header1.Dock = System.Windows.Forms.DockStyle.Top;
            header1.Location = new System.Drawing.Point(0, 0);
            header1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            header1.Name = "header1";
            header1.Size = new System.Drawing.Size(1442, 80);
            header1.TabIndex = 0;
            header1.Load += header1_Load;
            // 
            // sidebar1
            // 
            sidebar1.BackColor = System.Drawing.Color.White;
            sidebar1.BackgroundImage = Properties.Resources.sidepanel;
            sidebar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            sidebar1.Dock = System.Windows.Forms.DockStyle.Left;
            sidebar1.Location = new System.Drawing.Point(0, 80);
            sidebar1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            sidebar1.Name = "sidebar1";
            sidebar1.Size = new System.Drawing.Size(314, 958);
            sidebar1.TabIndex = 1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1442, 1038);
            Controls.Add(ContentsPanel);
            Controls.Add(sidebar1);
            Controls.Add(header1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Dashboard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " ";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Components.Header header1;
        public System.Windows.Forms.Panel ContentsPanel;
        private Components.Sidebar sidebar1;
    }
}