namespace Kinesia.Patients
{
    partial class DisplayPatients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayPatients));
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPatientID = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnView = new OrganizationProfile.CustomButton();
            this.btnEdit = new OrganizationProfile.CustomButton();
            this.btnArchive = new OrganizationProfile.CustomButton();
            this.panelBorder1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BorderRadius = 20;
            this.panelBorder1.Color = System.Drawing.Color.White;
            this.panelBorder1.Controls.Add(this.flowLayoutPanel1);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(3, 3);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1497, 91);
            this.panelBorder1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1414, 52);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.txtPatientID);
            this.flowLayoutPanel3.Controls.Add(this.txtStatus);
            this.flowLayoutPanel3.Controls.Add(this.txtPatientName);
            this.flowLayoutPanel3.Controls.Add(this.txtGender);
            this.flowLayoutPanel3.Controls.Add(this.txtAge);
            this.flowLayoutPanel3.Controls.Add(this.txtContact);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1273, 46);
            this.flowLayoutPanel3.TabIndex = 10;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPatientID.AutoSize = true;
            this.txtPatientID.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPatientID.Location = new System.Drawing.Point(0, 0);
            this.txtPatientID.Margin = new System.Windows.Forms.Padding(0);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Padding = new System.Windows.Forms.Padding(0, 10, 50, 0);
            this.txtPatientID.Size = new System.Drawing.Size(111, 32);
            this.txtPatientID.TabIndex = 8;
            this.txtPatientID.Text = "Patient ID";
            this.txtPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(111, 0);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(0);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtStatus.Size = new System.Drawing.Size(179, 32);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "Status";
            this.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(290, 0);
            this.txtPatientName.Margin = new System.Windows.Forms.Padding(0);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtPatientName.Size = new System.Drawing.Size(375, 32);
            this.txtPatientName.TabIndex = 0;
            this.txtPatientName.Text = "Patient Name";
            this.txtPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGender
            // 
            this.txtGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGender.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(665, 0);
            this.txtGender.Margin = new System.Windows.Forms.Padding(0);
            this.txtGender.Name = "txtGender";
            this.txtGender.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtGender.Size = new System.Drawing.Size(173, 32);
            this.txtGender.TabIndex = 2;
            this.txtGender.Text = "Gender";
            this.txtGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAge.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(838, 0);
            this.txtAge.Margin = new System.Windows.Forms.Padding(0);
            this.txtAge.Name = "txtAge";
            this.txtAge.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtAge.Size = new System.Drawing.Size(149, 32);
            this.txtAge.TabIndex = 1;
            this.txtAge.Text = "Age";
            this.txtAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtContact.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(987, 0);
            this.txtContact.Margin = new System.Windows.Forms.Padding(0);
            this.txtContact.Name = "txtContact";
            this.txtContact.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.txtContact.Size = new System.Drawing.Size(286, 32);
            this.txtContact.TabIndex = 3;
            this.txtContact.Text = "Contact Number";
            this.txtContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnView);
            this.flowLayoutPanel2.Controls.Add(this.btnEdit);
            this.flowLayoutPanel2.Controls.Add(this.btnArchive);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1276, 3);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(135, 46);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.BackgroundColor = System.Drawing.Color.White;
            this.btnView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnView.BackgroundImage")));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnView.BorderColor = System.Drawing.Color.White;
            this.btnView.BorderRadius = 0;
            this.btnView.BorderSize = 0;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.Transparent;
            this.btnView.Location = new System.Drawing.Point(3, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(39, 40);
            this.btnView.TabIndex = 5;
            this.btnView.TextColor = System.Drawing.Color.Transparent;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.BorderColor = System.Drawing.Color.White;
            this.btnEdit.BorderRadius = 0;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Transparent;
            this.btnEdit.Location = new System.Drawing.Point(48, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.TextColor = System.Drawing.Color.Transparent;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundImage = global::Kinesia.Properties.Resources.archive_icon;
            this.btnArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArchive.BorderColor = System.Drawing.Color.White;
            this.btnArchive.BorderRadius = 0;
            this.btnArchive.BorderSize = 0;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.ForeColor = System.Drawing.Color.Transparent;
            this.btnArchive.Location = new System.Drawing.Point(93, 3);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(39, 40);
            this.btnArchive.TabIndex = 7;
            this.btnArchive.TextColor = System.Drawing.Color.Transparent;
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // DisplayPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panelBorder1);
            this.Name = "DisplayPatients";
            this.Size = new System.Drawing.Size(1503, 97);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label txtPatientName;
        private System.Windows.Forms.Label txtAge;
        private System.Windows.Forms.Label txtGender;
        private System.Windows.Forms.Label txtContact;
        private System.Windows.Forms.Label txtStatus;
        private OrganizationProfile.CustomButton btnView;
        private OrganizationProfile.CustomButton btnEdit;
        private OrganizationProfile.CustomButton btnArchive;
        private System.Windows.Forms.Label txtPatientID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}
