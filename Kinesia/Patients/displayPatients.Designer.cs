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
            this.txtPatientID = new System.Windows.Forms.Label();
            this.btnArchive = new OrganizationProfile.CustomButton();
            this.btnEdit = new OrganizationProfile.CustomButton();
            this.btnView = new OrganizationProfile.CustomButton();
            this.txtStatus = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.Label();
            this.panelBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BorderRadius = 20;
            this.panelBorder1.Color = System.Drawing.Color.White;
            this.panelBorder1.Controls.Add(this.txtPatientID);
            this.panelBorder1.Controls.Add(this.btnArchive);
            this.panelBorder1.Controls.Add(this.btnEdit);
            this.panelBorder1.Controls.Add(this.btnView);
            this.panelBorder1.Controls.Add(this.txtStatus);
            this.panelBorder1.Controls.Add(this.txtContact);
            this.panelBorder1.Controls.Add(this.txtGender);
            this.panelBorder1.Controls.Add(this.txtAge);
            this.panelBorder1.Controls.Add(this.txtPatientName);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(3, 3);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1497, 91);
            this.panelBorder1.TabIndex = 0;
            // 
            // txtPatientID
            // 
            this.txtPatientID.AutoSize = true;
            this.txtPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPatientID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPatientID.Location = new System.Drawing.Point(14, 55);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(54, 13);
            this.txtPatientID.TabIndex = 8;
            this.txtPatientID.Text = "Patient ID";
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnArchive.BackgroundImage")));
            this.btnArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArchive.BorderColor = System.Drawing.Color.White;
            this.btnArchive.BorderRadius = 40;
            this.btnArchive.BorderSize = 0;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.ForeColor = System.Drawing.Color.Transparent;
            this.btnArchive.Location = new System.Drawing.Point(1415, 24);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(39, 40);
            this.btnArchive.TabIndex = 7;
            this.btnArchive.TextColor = System.Drawing.Color.Transparent;
            this.btnArchive.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.BorderColor = System.Drawing.Color.White;
            this.btnEdit.BorderRadius = 40;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Transparent;
            this.btnEdit.Location = new System.Drawing.Point(1344, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.TextColor = System.Drawing.Color.Transparent;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.BackgroundColor = System.Drawing.Color.White;
            this.btnView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnView.BackgroundImage")));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnView.BorderColor = System.Drawing.Color.White;
            this.btnView.BorderRadius = 40;
            this.btnView.BorderSize = 0;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.Transparent;
            this.btnView.Location = new System.Drawing.Point(1267, 24);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(39, 40);
            this.btnView.TabIndex = 5;
            this.btnView.TextColor = System.Drawing.Color.Transparent;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(1057, 35);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(47, 22);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "Status";
            // 
            // txtContact
            // 
            this.txtContact.AutoSize = true;
            this.txtContact.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(843, 35);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(108, 22);
            this.txtContact.TabIndex = 3;
            this.txtContact.Text = "Contact Number";
            // 
            // txtGender
            // 
            this.txtGender.AutoSize = true;
            this.txtGender.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.Location = new System.Drawing.Point(635, 35);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(53, 22);
            this.txtGender.TabIndex = 2;
            this.txtGender.Text = "Gender";
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAge.AutoSize = true;
            this.txtAge.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(421, 35);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(33, 22);
            this.txtAge.TabIndex = 1;
            this.txtAge.Text = "Age";
            // 
            // txtPatientName
            // 
            this.txtPatientName.AutoSize = true;
            this.txtPatientName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(14, 35);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(94, 22);
            this.txtPatientName.TabIndex = 0;
            this.txtPatientName.Text = "Patient Name";
            // 
            // DisplayPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panelBorder1);
            this.Name = "DisplayPatients";
            this.Size = new System.Drawing.Size(1510, 97);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
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
    }
}
