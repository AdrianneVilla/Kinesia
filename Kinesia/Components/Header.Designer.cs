namespace Kinesia.Components
{
    partial class Header
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            pictureBox2 = new System.Windows.Forms.PictureBox();
            btnExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.small_logo;
            pictureBox2.Location = new System.Drawing.Point(7, 14);
            pictureBox2.Margin = new System.Windows.Forms.Padding(14, 14, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(97, 52);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExit.Image = (System.Drawing.Image)resources.GetObject("btnExit.Image");
            btnExit.Location = new System.Drawing.Point(1077, 10);
            btnExit.Margin = new System.Windows.Forms.Padding(933, 17, 14, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(43, 55);
            btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            btnExit.TabIndex = 4;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // Header
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImage = Properties.Resources.Header;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(pictureBox2);
            Controls.Add(btnExit);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Header";
            Size = new System.Drawing.Size(1134, 80);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnExit;
    }
}
