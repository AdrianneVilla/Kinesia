namespace Kinesia.Users
{
    partial class DisplayUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayUsers));
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnEdit = new OrganizationProfile.CustomButton();
            this.btnArchive = new OrganizationProfile.CustomButton();
            this.btnView = new OrganizationProfile.CustomButton();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panelBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorder1
            // 
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BorderRadius = 20;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.btnEdit);
            this.panelBorder1.Controls.Add(this.btnArchive);
            this.panelBorder1.Controls.Add(this.btnView);
            this.panelBorder1.Controls.Add(this.lblRole);
            this.panelBorder1.Controls.Add(this.lblUserID);
            this.panelBorder1.Controls.Add(this.lblName);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(3, 3);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1497, 91);
            this.panelBorder1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundColor = System.Drawing.Color.White;
            this.btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.BorderRadius = 34;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Transparent;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(1284, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 40);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.TextColor = System.Drawing.Color.Transparent;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundColor = System.Drawing.Color.White;
            this.btnArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArchive.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnArchive.BorderRadius = 40;
            this.btnArchive.BorderSize = 0;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.ForeColor = System.Drawing.Color.Transparent;
            this.btnArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnArchive.Image")));
            this.btnArchive.Location = new System.Drawing.Point(1385, 25);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(39, 40);
            this.btnArchive.TabIndex = 9;
            this.btnArchive.TextColor = System.Drawing.Color.Transparent;
            this.btnArchive.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.BackgroundColor = System.Drawing.Color.White;
            this.btnView.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnView.BorderRadius = 33;
            this.btnView.BorderSize = 0;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.Transparent;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(1175, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(39, 40);
            this.btnView.TabIndex = 8;
            this.btnView.TextColor = System.Drawing.Color.Transparent;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblRole.Location = new System.Drawing.Point(837, 35);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 25);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "Role";
            // 
            // lblUserID
            // 
            this.lblUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblUserID.Location = new System.Drawing.Point(19, 35);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 25);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "UserID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(279, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // DisplayUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panelBorder1);
            this.Name = "DisplayUsers";
            this.Size = new System.Drawing.Size(1510, 99);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUserID;
        private OrganizationProfile.CustomButton btnView;
        private OrganizationProfile.CustomButton btnArchive;
        private OrganizationProfile.CustomButton btnEdit;
    }
}
