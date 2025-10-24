namespace Kinesia.Assessment
{
    partial class SelectTool
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
            btnAstraProCamera = new OrganizationProfile.CustomButton();
            btnGoniometer = new OrganizationProfile.CustomButton();
            label2 = new System.Windows.Forms.Label();
            btnClose = new OrganizationProfile.CustomButton();
            SuspendLayout();
            // 
            // btnAstraProCamera
            // 
            btnAstraProCamera.BackColor = System.Drawing.Color.Transparent;
            btnAstraProCamera.BackgroundColor = System.Drawing.Color.Transparent;
            btnAstraProCamera.BorderColor = System.Drawing.Color.Black;
            btnAstraProCamera.BorderRadius = 20;
            btnAstraProCamera.BorderSize = 1;
            btnAstraProCamera.FlatAppearance.BorderSize = 0;
            btnAstraProCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAstraProCamera.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnAstraProCamera.ForeColor = System.Drawing.Color.Black;
            btnAstraProCamera.Image = Properties.Resources.newSmallOrbbec;
            btnAstraProCamera.Location = new System.Drawing.Point(39, 122);
            btnAstraProCamera.Name = "btnAstraProCamera";
            btnAstraProCamera.Size = new System.Drawing.Size(192, 198);
            btnAstraProCamera.TabIndex = 0;
            btnAstraProCamera.Text = "Astra Pro Plus";
            btnAstraProCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAstraProCamera.TextColor = System.Drawing.Color.Black;
            btnAstraProCamera.UseVisualStyleBackColor = false;
            btnAstraProCamera.Click += btnAstraProCamera_Click;
            // 
            // btnGoniometer
            // 
            btnGoniometer.BackColor = System.Drawing.Color.Transparent;
            btnGoniometer.BackgroundColor = System.Drawing.Color.Transparent;
            btnGoniometer.BorderColor = System.Drawing.Color.Black;
            btnGoniometer.BorderRadius = 20;
            btnGoniometer.BorderSize = 1;
            btnGoniometer.FlatAppearance.BorderSize = 0;
            btnGoniometer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGoniometer.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnGoniometer.ForeColor = System.Drawing.Color.Black;
            btnGoniometer.Image = Properties.Resources.goniometerLogo;
            btnGoniometer.Location = new System.Drawing.Point(288, 122);
            btnGoniometer.Name = "btnGoniometer";
            btnGoniometer.Size = new System.Drawing.Size(199, 198);
            btnGoniometer.TabIndex = 1;
            btnGoniometer.Text = "Goniometer";
            btnGoniometer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnGoniometer.TextColor = System.Drawing.Color.Black;
            btnGoniometer.UseVisualStyleBackColor = false;
            btnGoniometer.Click += btnGoniometer_Click;
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
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.newSmallClose;
            btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnClose.BorderRadius = 15;
            btnClose.BorderSize = 0;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.Transparent;
            btnClose.Location = new System.Drawing.Point(476, 29);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(39, 30);
            btnClose.TabIndex = 23;
            btnClose.TextColor = System.Drawing.Color.Transparent;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // SelectTool
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(539, 450);
            Controls.Add(btnClose);
            Controls.Add(label2);
            Controls.Add(btnGoniometer);
            Controls.Add(btnAstraProCamera);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SelectTool";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AddROMPopup";
            ResumeLayout(false);
        }

        #endregion

        private OrganizationProfile.CustomButton btnAstraProCamera;
        private OrganizationProfile.CustomButton btnGoniometer;
        private System.Windows.Forms.Label label2;
        private OrganizationProfile.CustomButton btnClose;
    }
}