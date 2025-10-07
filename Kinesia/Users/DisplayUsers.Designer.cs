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
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnEdit = new OrganizationProfile.CustomButton();
            btnArchive = new OrganizationProfile.CustomButton();
            btnView = new OrganizationProfile.CustomButton();
            lblRole = new System.Windows.Forms.Label();
            lblUserID = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            panelBorder1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorder1
            // 
            panelBorder1.AutoSize = true;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BorderRadius = 20;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(btnEdit);
            panelBorder1.Controls.Add(btnArchive);
            panelBorder1.Controls.Add(btnView);
            panelBorder1.Controls.Add(lblRole);
            panelBorder1.Controls.Add(lblUserID);
            panelBorder1.Controls.Add(lblName);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(0, 0);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(1746, 118);
            panelBorder1.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.White;
            btnEdit.BackgroundColor = System.Drawing.Color.White;
            btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnEdit.BorderRadius = 34;
            btnEdit.BorderSize = 0;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.ForeColor = System.Drawing.Color.Transparent;
            btnEdit.Image = (System.Drawing.Image)resources.GetObject("btnEdit.Image");
            btnEdit.Location = new System.Drawing.Point(1498, 29);
            btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(46, 46);
            btnEdit.TabIndex = 10;
            btnEdit.TextColor = System.Drawing.Color.Transparent;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnArchive
            // 
            btnArchive.BackColor = System.Drawing.Color.White;
            btnArchive.BackgroundColor = System.Drawing.Color.White;
            btnArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnArchive.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnArchive.BorderRadius = 40;
            btnArchive.BorderSize = 0;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnArchive.ForeColor = System.Drawing.Color.Transparent;
            btnArchive.Image = (System.Drawing.Image)resources.GetObject("btnArchive.Image");
            btnArchive.Location = new System.Drawing.Point(1616, 29);
            btnArchive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new System.Drawing.Size(46, 46);
            btnArchive.TabIndex = 9;
            btnArchive.TextColor = System.Drawing.Color.Transparent;
            btnArchive.UseVisualStyleBackColor = false;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnView
            // 
            btnView.BackColor = System.Drawing.Color.White;
            btnView.BackgroundColor = System.Drawing.Color.White;
            btnView.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnView.BorderRadius = 33;
            btnView.BorderSize = 0;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnView.ForeColor = System.Drawing.Color.Transparent;
            btnView.Image = (System.Drawing.Image)resources.GetObject("btnView.Image");
            btnView.Location = new System.Drawing.Point(1371, 29);
            btnView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnView.Name = "btnView";
            btnView.Size = new System.Drawing.Size(46, 46);
            btnView.TabIndex = 8;
            btnView.TextColor = System.Drawing.Color.Transparent;
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // lblRole
            // 
            lblRole.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Poppins", 10F);
            lblRole.Location = new System.Drawing.Point(976, 40);
            lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(42, 25);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role";
            // 
            // lblUserID
            // 
            lblUserID.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblUserID.AutoSize = true;
            lblUserID.Font = new System.Drawing.Font("Poppins", 10F);
            lblUserID.Location = new System.Drawing.Point(22, 40);
            lblUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new System.Drawing.Size(55, 25);
            lblUserID.TabIndex = 2;
            lblUserID.Text = "UserID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            lblName.Location = new System.Drawing.Point(326, 40);
            lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(57, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // DisplayUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            Controls.Add(panelBorder1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DisplayUsers";
            Size = new System.Drawing.Size(1750, 121);
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
