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
            btnSaveAssessment = new OrganizationProfile.CustomButton();
            btnChangePatient = new OrganizationProfile.CustomButton();
            panelPatientInformation = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnBack = new OrganizationProfile.CustomButton();
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
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnSaveAssessment);
            flowLayoutPanel1.Controls.Add(btnChangePatient);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(89, 132);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1410, 58);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // btnSaveAssessment
            // 
            btnSaveAssessment.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveAssessment.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnSaveAssessment.BackgroundColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnSaveAssessment.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveAssessment.BorderRadius = 10;
            btnSaveAssessment.BorderSize = 1;
            btnSaveAssessment.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSaveAssessment.FlatAppearance.BorderSize = 0;
            btnSaveAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveAssessment.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSaveAssessment.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveAssessment.Image = (System.Drawing.Image)resources.GetObject("btnSaveAssessment.Image");
            btnSaveAssessment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSaveAssessment.Location = new System.Drawing.Point(1204, 3);
            btnSaveAssessment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveAssessment.Name = "btnSaveAssessment";
            btnSaveAssessment.Padding = new System.Windows.Forms.Padding(12, 5, 23, 0);
            btnSaveAssessment.Size = new System.Drawing.Size(202, 51);
            btnSaveAssessment.TabIndex = 13;
            btnSaveAssessment.Text = "Save Assessment";
            btnSaveAssessment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSaveAssessment.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveAssessment.UseVisualStyleBackColor = false;
            btnSaveAssessment.Click += btnSaveAssessment_Click;
            // 
            // btnChangePatient
            // 
            btnChangePatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChangePatient.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnChangePatient.BackgroundColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnChangePatient.BorderColor = System.Drawing.Color.White;
            btnChangePatient.BorderRadius = 10;
            btnChangePatient.BorderSize = 0;
            btnChangePatient.Cursor = System.Windows.Forms.Cursors.Hand;
            btnChangePatient.FlatAppearance.BorderSize = 0;
            btnChangePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangePatient.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnChangePatient.ForeColor = System.Drawing.Color.White;
            btnChangePatient.Image = Properties.Resources.newReselect;
            btnChangePatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnChangePatient.Location = new System.Drawing.Point(997, 3);
            btnChangePatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnChangePatient.Name = "btnChangePatient";
            btnChangePatient.Padding = new System.Windows.Forms.Padding(10, 3, 30, 0);
            btnChangePatient.Size = new System.Drawing.Size(199, 51);
            btnChangePatient.TabIndex = 11;
            btnChangePatient.Text = "Change Patient";
            btnChangePatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnChangePatient.TextColor = System.Drawing.Color.White;
            btnChangePatient.UseVisualStyleBackColor = false;
            btnChangePatient.Click += btnChangePatient_Click;
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
            panelPatientInformation.Size = new System.Drawing.Size(1423, 404);
            panelPatientInformation.TabIndex = 35;
            // 
            // btnBack
            // 
            btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnBack.BackColor = System.Drawing.Color.White;
            btnBack.BackgroundColor = System.Drawing.Color.White;
            btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnBack.BorderRadius = 10;
            btnBack.BorderSize = 0;
            btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnBack.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.Image = Properties.Resources.back_button_icon;
            btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnBack.Location = new System.Drawing.Point(1350, 19);
            btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Padding = new System.Windows.Forms.Padding(0, 3, 35, 0);
            btnBack.Size = new System.Drawing.Size(145, 46);
            btnBack.TabIndex = 36;
            btnBack.Text = "Back";
            btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnBack.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // AddAssessment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            Controls.Add(btnBack);
            Controls.Add(panelPatientInformation);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblSelectedUser);
            Controls.Add(titleNav);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddAssessment";
            Size = new System.Drawing.Size(1541, 671);
            Load += AddAssessment_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label titleNav;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private OrganizationProfile.CustomButton btnChangePatient;
        private OrganizationProfile.CustomButton btnSaveAssessment;
        private WindowsFormsApp2.CustomButton.PanelBorder panelPatientInformation;
        private OrganizationProfile.CustomButton btnBack;
    }
}
