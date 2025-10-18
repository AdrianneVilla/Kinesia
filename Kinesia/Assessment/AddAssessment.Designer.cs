namespace Kinesia.Assessment
{
    partial class AddAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAssessment));
            label1 = new System.Windows.Forms.Label();
            lblSelectedUser = new System.Windows.Forms.Label();
            titleNav = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            customButton1 = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            panelPatientInformation = new WindowsFormsApp2.CustomButton.PanelBorder();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(76, 83);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(228, 23);
            label1.TabIndex = 19;
            label1.Text = "Select patient to add assessment";
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSelectedUser.AutoSize = true;
            lblSelectedUser.BackColor = System.Drawing.Color.Transparent;
            lblSelectedUser.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            lblSelectedUser.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblSelectedUser.Location = new System.Drawing.Point(240, 35);
            lblSelectedUser.Margin = new System.Windows.Forms.Padding(0);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new System.Drawing.Size(254, 48);
            lblSelectedUser.TabIndex = 32;
            lblSelectedUser.Text = "Add Assessment";
            lblSelectedUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleNav
            // 
            titleNav.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            titleNav.AutoSize = true;
            titleNav.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleNav.ForeColor = System.Drawing.Color.DarkGray;
            titleNav.Location = new System.Drawing.Point(71, 44);
            titleNav.Margin = new System.Windows.Forms.Padding(0);
            titleNav.Name = "titleNav";
            titleNav.Size = new System.Drawing.Size(155, 36);
            titleNav.TabIndex = 31;
            titleNav.Text = "Assessment >";
            titleNav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(customButton1);
            flowLayoutPanel1.Controls.Add(customButton2);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(89, 132);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1291, 58);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // customButton1
            // 
            customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButton1.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            customButton1.BackgroundColor = System.Drawing.Color.FromArgb(200, 220, 255);
            customButton1.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.BorderRadius = 10;
            customButton1.BorderSize = 1;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.Image = (System.Drawing.Image)resources.GetObject("customButton1.Image");
            customButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButton1.Location = new System.Drawing.Point(1085, 3);
            customButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton1.Name = "customButton1";
            customButton1.Padding = new System.Windows.Forms.Padding(12, 5, 23, 0);
            customButton1.Size = new System.Drawing.Size(202, 51);
            customButton1.TabIndex = 13;
            customButton1.Text = "Save Assessment";
            customButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            customButton1.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            customButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            customButton2.BackgroundColor = System.Drawing.Color.FromArgb(64, 64, 64);
            customButton2.BorderColor = System.Drawing.Color.White;
            customButton2.BorderRadius = 10;
            customButton2.BorderSize = 0;
            customButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton2.ForeColor = System.Drawing.Color.White;
            customButton2.Image = Properties.Resources.newReselect;
            customButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButton2.Location = new System.Drawing.Point(878, 3);
            customButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton2.Name = "customButton2";
            customButton2.Padding = new System.Windows.Forms.Padding(10, 3, 30, 0);
            customButton2.Size = new System.Drawing.Size(199, 51);
            customButton2.TabIndex = 11;
            customButton2.Text = "Change Patient";
            customButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            customButton2.TextColor = System.Drawing.Color.White;
            customButton2.UseVisualStyleBackColor = false;
            // 
            // panelPatientInformation
            // 
            panelPatientInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelPatientInformation.BackColor = System.Drawing.Color.White;
            panelPatientInformation.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelPatientInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelPatientInformation.BorderRadius = 30;
            panelPatientInformation.Color = System.Drawing.Color.BurlyWood;
            panelPatientInformation.ForeColor = System.Drawing.Color.Black;
            panelPatientInformation.Location = new System.Drawing.Point(76, 239);
            panelPatientInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelPatientInformation.Name = "panelPatientInformation";
            panelPatientInformation.Size = new System.Drawing.Size(1457, 404);
            panelPatientInformation.TabIndex = 35;
            panelPatientInformation.Visible = false;
            // 
            // AddAssessment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(panelPatientInformation);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblSelectedUser);
            Controls.Add(titleNav);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddAssessment";
            Size = new System.Drawing.Size(1541, 875);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label titleNav;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private OrganizationProfile.CustomButton customButton2;
        private OrganizationProfile.CustomButton customButton1;
        private WindowsFormsApp2.CustomButton.PanelBorder panelPatientInformation;
    }
}
