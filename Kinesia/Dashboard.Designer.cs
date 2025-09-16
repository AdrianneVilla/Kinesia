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
            this.ContentsPanel = new System.Windows.Forms.Panel();
            this.sidebar1 = new Kinesia.Components.Sidebar();
            this.header1 = new Kinesia.Components.Header();
            this.SuspendLayout();
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.AutoSize = true;
            this.ContentsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.Location = new System.Drawing.Point(269, 69);
            this.ContentsPanel.Name = "ContentsPanel";
            this.ContentsPanel.Size = new System.Drawing.Size(967, 831);
            this.ContentsPanel.TabIndex = 2;
            // 
            // sidebar1
            // 
            this.sidebar1.BackColor = System.Drawing.Color.White;
            this.sidebar1.BackgroundImage = global::Kinesia.Properties.Resources.sidepanel;
            this.sidebar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sidebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar1.Location = new System.Drawing.Point(0, 69);
            this.sidebar1.Name = "sidebar1";
            this.sidebar1.Size = new System.Drawing.Size(269, 831);
            this.sidebar1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.White;
            this.header1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header1.BackgroundImage")));
            this.header1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1236, 69);
            this.header1.TabIndex = 0;
            this.header1.Load += new System.EventHandler(this.header1_Load);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1236, 900);
            this.Controls.Add(this.ContentsPanel);
            this.Controls.Add(this.sidebar1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Header header1;
        private Components.Sidebar sidebar1;
        public System.Windows.Forms.Panel ContentsPanel;
    }
}