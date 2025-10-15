namespace Kinesia.Assessment
{
    partial class AddROMPopup
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
            customButton1 = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            label2 = new System.Windows.Forms.Label();
            customButton3 = new OrganizationProfile.CustomButton();
            SuspendLayout();
            // 
            // customButton1
            // 
            customButton1.BackColor = System.Drawing.Color.Transparent;
            customButton1.BackgroundColor = System.Drawing.Color.Transparent;
            customButton1.BorderColor = System.Drawing.Color.Black;
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 1;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton1.ForeColor = System.Drawing.Color.Black;
            customButton1.Image = Properties.Resources.newSmallOrbbec;
            customButton1.Location = new System.Drawing.Point(39, 122);
            customButton1.Name = "customButton1";
            customButton1.Size = new System.Drawing.Size(192, 198);
            customButton1.TabIndex = 0;
            customButton1.Text = "Astra Pro Plus";
            customButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            customButton1.TextColor = System.Drawing.Color.Black;
            customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            customButton2.BackColor = System.Drawing.Color.Transparent;
            customButton2.BackgroundColor = System.Drawing.Color.Transparent;
            customButton2.BorderColor = System.Drawing.Color.Black;
            customButton2.BorderRadius = 20;
            customButton2.BorderSize = 1;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton2.ForeColor = System.Drawing.Color.Black;
            customButton2.Image = Properties.Resources.goniometerLogo;
            customButton2.Location = new System.Drawing.Point(288, 122);
            customButton2.Name = "customButton2";
            customButton2.Size = new System.Drawing.Size(199, 198);
            customButton2.TabIndex = 1;
            customButton2.Text = "Goniometer";
            customButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            customButton2.TextColor = System.Drawing.Color.Black;
            customButton2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            label2.Location = new System.Drawing.Point(12, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(271, 49);
            label2.TabIndex = 22;
            label2.Text = "Select Instrument";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customButton3
            // 
            customButton3.BackColor = System.Drawing.Color.Transparent;
            customButton3.BackgroundColor = System.Drawing.Color.Transparent;
            customButton3.BackgroundImage = Properties.Resources.newSmallClose;
            customButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            customButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton3.BorderRadius = 15;
            customButton3.BorderSize = 0;
            customButton3.FlatAppearance.BorderSize = 0;
            customButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton3.ForeColor = System.Drawing.Color.Transparent;
            customButton3.Location = new System.Drawing.Point(476, 29);
            customButton3.Name = "customButton3";
            customButton3.Size = new System.Drawing.Size(39, 30);
            customButton3.TabIndex = 23;
            customButton3.TextColor = System.Drawing.Color.Transparent;
            customButton3.UseVisualStyleBackColor = false;
            // 
            // AddROMPopup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(539, 450);
            Controls.Add(customButton3);
            Controls.Add(label2);
            Controls.Add(customButton2);
            Controls.Add(customButton1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "AddROMPopup";
            Text = "AddROMPopup";
            ResumeLayout(false);
        }

        #endregion

        private OrganizationProfile.CustomButton customButton1;
        private OrganizationProfile.CustomButton customButton2;
        private System.Windows.Forms.Label label2;
        private OrganizationProfile.CustomButton customButton3;
    }
}