namespace Kinesia.Assessment
{
    partial class DisplayAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayAssessment));
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            txtPatientID = new System.Windows.Forms.Label();
            btnArchive = new OrganizationProfile.CustomButton();
            btnEdit = new OrganizationProfile.CustomButton();
            txtStatus = new System.Windows.Forms.Label();
            txtContact = new System.Windows.Forms.Label();
            txtGender = new System.Windows.Forms.Label();
            txtPatientName = new System.Windows.Forms.Label();
            panelBorder1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BorderRadius = 20;
            panelBorder1.Color = System.Drawing.Color.White;
            panelBorder1.Controls.Add(txtPatientID);
            panelBorder1.Controls.Add(btnArchive);
            panelBorder1.Controls.Add(btnEdit);
            panelBorder1.Controls.Add(txtStatus);
            panelBorder1.Controls.Add(txtContact);
            panelBorder1.Controls.Add(txtGender);
            panelBorder1.Controls.Add(txtPatientName);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(4, 3);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(1754, 111);
            panelBorder1.TabIndex = 1;
            // 
            // txtPatientID
            // 
            txtPatientID.AutoSize = true;
            txtPatientID.Font = new System.Drawing.Font("Poppins", 9F);
            txtPatientID.ForeColor = System.Drawing.Color.Black;
            txtPatientID.Location = new System.Drawing.Point(20, 39);
            txtPatientID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.Size = new System.Drawing.Size(94, 22);
            txtPatientID.TabIndex = 8;
            txtPatientID.Text = "Assessment ID";
            // 
            // btnArchive
            // 
            btnArchive.BackColor = System.Drawing.Color.White;
            btnArchive.BackgroundColor = System.Drawing.Color.White;
            btnArchive.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnArchive.BackgroundImage");
            btnArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnArchive.BorderColor = System.Drawing.Color.White;
            btnArchive.BorderRadius = 40;
            btnArchive.BorderSize = 0;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnArchive.ForeColor = System.Drawing.Color.Transparent;
            btnArchive.Location = new System.Drawing.Point(1657, 28);
            btnArchive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new System.Drawing.Size(46, 46);
            btnArchive.TabIndex = 7;
            btnArchive.TextColor = System.Drawing.Color.Transparent;
            btnArchive.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.White;
            btnEdit.BackgroundColor = System.Drawing.Color.White;
            btnEdit.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnEdit.BackgroundImage");
            btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnEdit.BorderColor = System.Drawing.Color.White;
            btnEdit.BorderRadius = 40;
            btnEdit.BorderSize = 0;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.ForeColor = System.Drawing.Color.Transparent;
            btnEdit.Location = new System.Drawing.Point(1582, 28);
            btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(46, 46);
            btnEdit.TabIndex = 6;
            btnEdit.TextColor = System.Drawing.Color.Transparent;
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // txtStatus
            // 
            txtStatus.AutoSize = true;
            txtStatus.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtStatus.Location = new System.Drawing.Point(1272, 39);
            txtStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new System.Drawing.Size(37, 22);
            txtStatus.TabIndex = 4;
            txtStatus.Text = "Date";
            // 
            // txtContact
            // 
            txtContact.AutoSize = true;
            txtContact.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtContact.Location = new System.Drawing.Point(1001, 39);
            txtContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            txtContact.Name = "txtContact";
            txtContact.Size = new System.Drawing.Size(80, 22);
            txtContact.TabIndex = 3;
            txtContact.Text = "Body Group";
            // 
            // txtGender
            // 
            txtGender.AutoSize = true;
            txtGender.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtGender.Location = new System.Drawing.Point(729, 39);
            txtGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            txtGender.Name = "txtGender";
            txtGender.Size = new System.Drawing.Size(116, 22);
            txtGender.TabIndex = 2;
            txtGender.Text = "Physical Therapist";
            // 
            // txtPatientName
            // 
            txtPatientName.AutoSize = true;
            txtPatientName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtPatientName.Location = new System.Drawing.Point(267, 39);
            txtPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new System.Drawing.Size(94, 22);
            txtPatientName.TabIndex = 0;
            txtPatientName.Text = "Patient Name";
            // 
            // DisplayAssessment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            Controls.Add(panelBorder1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DisplayAssessment";
            Size = new System.Drawing.Size(1762, 117);
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label txtPatientID;
        private OrganizationProfile.CustomButton btnArchive;
        private OrganizationProfile.CustomButton btnEdit;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label txtContact;
        private System.Windows.Forms.Label txtGender;
        private System.Windows.Forms.Label txtPatientName;
    }
}
