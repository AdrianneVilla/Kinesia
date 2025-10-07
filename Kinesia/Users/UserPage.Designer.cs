namespace Kinesia.Users
{
    partial class UserPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPage));
            dataGridUsers = new System.Windows.Forms.DataGridView();
            UserIDHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EmpPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            editHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            cbSort = new CustomControls.RJControls.RJComboBox();
            btnInactive = new OrganizationProfile.CustomButton();
            btnActive = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            btnAddPatient = new OrganizationProfile.CustomButton();
            UserHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            lblHiddenForFocus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).BeginInit();
            panelBorder2.SuspendLayout();
            UserHolder.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridUsers
            // 
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;
            dataGridUsers.AllowUserToResizeColumns = false;
            dataGridUsers.AllowUserToResizeRows = false;
            dataGridUsers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridUsers.BackgroundColor = System.Drawing.Color.White;
            dataGridUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridUsers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { UserIDHeader, nameHeader, EmpPosition, editHeader, Column1, Column2 });
            dataGridUsers.Enabled = false;
            dataGridUsers.GridColor = System.Drawing.Color.White;
            dataGridUsers.Location = new System.Drawing.Point(2, 9);
            dataGridUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridUsers.Name = "dataGridUsers";
            dataGridUsers.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridUsers.ShowCellErrors = false;
            dataGridUsers.ShowCellToolTips = false;
            dataGridUsers.ShowEditingIcon = false;
            dataGridUsers.ShowRowErrors = false;
            dataGridUsers.Size = new System.Drawing.Size(1307, 517);
            dataGridUsers.TabIndex = 14;
            // 
            // UserIDHeader
            // 
            UserIDHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            UserIDHeader.FillWeight = 50F;
            UserIDHeader.HeaderText = "User ID";
            UserIDHeader.Name = "UserIDHeader";
            UserIDHeader.ReadOnly = true;
            // 
            // nameHeader
            // 
            nameHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            nameHeader.DefaultCellStyle = dataGridViewCellStyle2;
            nameHeader.HeaderText = "Name";
            nameHeader.Name = "nameHeader";
            nameHeader.ReadOnly = true;
            nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // EmpPosition
            // 
            EmpPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            EmpPosition.FillWeight = 60F;
            EmpPosition.HeaderText = "Position";
            EmpPosition.Name = "EmpPosition";
            EmpPosition.ReadOnly = true;
            // 
            // editHeader
            // 
            editHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            editHeader.DefaultCellStyle = dataGridViewCellStyle3;
            editHeader.FillWeight = 20F;
            editHeader.HeaderText = "Select";
            editHeader.Name = "editHeader";
            editHeader.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column1.FillWeight = 20F;
            Column1.HeaderText = "Edit";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column2.FillWeight = 40F;
            Column2.HeaderText = "Archive / Unarchive";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(74, 82);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(255, 23);
            label1.TabIndex = 10;
            label1.Text = " Helps you move better and feel better";
            // 
            // nameHolder
            // 
            nameHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            nameHolder.AutoSize = true;
            nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            nameHolder.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            nameHolder.Location = new System.Drawing.Point(69, 36);
            nameHolder.Margin = new System.Windows.Forms.Padding(0);
            nameHolder.Name = "nameHolder";
            nameHolder.Size = new System.Drawing.Size(98, 48);
            nameHolder.TabIndex = 9;
            nameHolder.Text = "Users";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.Controls.Add(btnInactive);
            panelBorder2.Controls.Add(btnActive);
            panelBorder2.Controls.Add(btnAll);
            panelBorder2.Controls.Add(btnAddPatient);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(1317, 67);
            panelBorder2.TabIndex = 15;
            // 
            // cbSort
            // 
            cbSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbSort.BackColor = System.Drawing.Color.White;
            cbSort.BorderColor = System.Drawing.Color.Gray;
            cbSort.BorderSize = 1;
            cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbSort.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbSort.ForeColor = System.Drawing.Color.DimGray;
            cbSort.IconColor = System.Drawing.Color.FromArgb(24, 90, 211);
            cbSort.Items.AddRange(new object[] { "Default", "Alphabetical (Name)", "Earliest (Date Added)", "Latest (Date Added)" });
            cbSort.ListBackColor = System.Drawing.Color.White;
            cbSort.ListTextColor = System.Drawing.Color.Black;
            cbSort.Location = new System.Drawing.Point(839, 6);
            cbSort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSort.MinimumSize = new System.Drawing.Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new System.Windows.Forms.Padding(1);
            cbSort.Size = new System.Drawing.Size(284, 55);
            cbSort.TabIndex = 16;
            cbSort.Texts = "Default";
            cbSort.OnSelectedIndexChanged += cbSort_OnSelectedIndexChanged;
            // 
            // btnInactive
            // 
            btnInactive.BackColor = System.Drawing.Color.Gainsboro;
            btnInactive.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnInactive.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnInactive.BorderRadius = 5;
            btnInactive.BorderSize = 0;
            btnInactive.FlatAppearance.BorderSize = 0;
            btnInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInactive.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnInactive.ForeColor = System.Drawing.Color.Gray;
            btnInactive.Location = new System.Drawing.Point(210, 10);
            btnInactive.Margin = new System.Windows.Forms.Padding(1);
            btnInactive.Name = "btnInactive";
            btnInactive.Size = new System.Drawing.Size(93, 46);
            btnInactive.TabIndex = 12;
            btnInactive.Text = "Inactive";
            btnInactive.TextColor = System.Drawing.Color.Gray;
            btnInactive.UseVisualStyleBackColor = false;
            btnInactive.Click += btnInactive_Click;
            // 
            // btnActive
            // 
            btnActive.BackColor = System.Drawing.Color.Gainsboro;
            btnActive.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnActive.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnActive.BorderRadius = 5;
            btnActive.BorderSize = 0;
            btnActive.FlatAppearance.BorderSize = 0;
            btnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnActive.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnActive.ForeColor = System.Drawing.Color.Gray;
            btnActive.Location = new System.Drawing.Point(112, 10);
            btnActive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnActive.Name = "btnActive";
            btnActive.Size = new System.Drawing.Size(93, 46);
            btnActive.TabIndex = 11;
            btnActive.Text = "Active";
            btnActive.TextColor = System.Drawing.Color.Gray;
            btnActive.UseVisualStyleBackColor = false;
            btnActive.Click += btnActive_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAll.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAll.BorderRadius = 5;
            btnAll.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAll.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAll.ForeColor = System.Drawing.Color.White;
            btnAll.Location = new System.Drawing.Point(14, 10);
            btnAll.Margin = new System.Windows.Forms.Padding(1);
            btnAll.Name = "btnAll";
            btnAll.Size = new System.Drawing.Size(93, 46);
            btnAll.TabIndex = 10;
            btnAll.Text = "All";
            btnAll.TextColor = System.Drawing.Color.White;
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddPatient.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.BorderColor = System.Drawing.Color.White;
            btnAddPatient.BorderRadius = 10;
            btnAddPatient.BorderSize = 0;
            btnAddPatient.FlatAppearance.BorderSize = 0;
            btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            btnAddPatient.ForeColor = System.Drawing.Color.Transparent;
            btnAddPatient.Image = (System.Drawing.Image)resources.GetObject("btnAddPatient.Image");
            btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnAddPatient.Location = new System.Drawing.Point(1134, 6);
            btnAddPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Padding = new System.Windows.Forms.Padding(6, 6, 23, 0);
            btnAddPatient.Size = new System.Drawing.Size(175, 55);
            btnAddPatient.TabIndex = 12;
            btnAddPatient.Text = "Add Users";
            btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnAddPatient.TextColor = System.Drawing.Color.Transparent;
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // UserHolder
            // 
            UserHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            UserHolder.BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            UserHolder.BorderRadius = 10;
            UserHolder.Color = System.Drawing.Color.White;
            UserHolder.Controls.Add(dataGridUsers);
            UserHolder.ForeColor = System.Drawing.Color.Black;
            UserHolder.Location = new System.Drawing.Point(72, 286);
            UserHolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UserHolder.Name = "UserHolder";
            UserHolder.Padding = new System.Windows.Forms.Padding(6);
            UserHolder.Size = new System.Drawing.Size(1317, 535);
            UserHolder.TabIndex = 13;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(btnSearch);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(txtSearchBar);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(807, 51);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(582, 59);
            panelBorder1.TabIndex = 11;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(453, 8);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            btnSearch.Size = new System.Drawing.Size(118, 40);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search_icon;
            pictureBox1.Location = new System.Drawing.Point(16, 17);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(33, 28);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BackColor = System.Drawing.Color.White;
            txtSearchBar.BorderColor = System.Drawing.Color.White;
            txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(56, 9);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.Size = new System.Drawing.Size(388, 35);
            txtSearchBar.TabIndex = 4;
            txtSearchBar.Texts = "";
            txtSearchBar.UnderlinedStyle = false;
            txtSearchBar._TextChanged += txtSearchBar__TextChanged;
            txtSearchBar.Enter += txtSearchBar_Enter;
            txtSearchBar.Leave += txtSearchBar_Leave;
            // 
            // lblHiddenForFocus
            // 
            lblHiddenForFocus.AutoSize = true;
            lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            lblHiddenForFocus.Location = new System.Drawing.Point(433, 84);
            lblHiddenForFocus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new System.Drawing.Size(135, 15);
            lblHiddenForFocus.TabIndex = 16;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // UserPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder2);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Controls.Add(UserHolder);
            Controls.Add(panelBorder1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UserPage";
            Size = new System.Drawing.Size(1457, 875);
            Load += UserPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).EndInit();
            panelBorder2.ResumeLayout(false);
            UserHolder.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private WindowsFormsApp2.CustomButton.PanelBorder UserHolder;
        private OrganizationProfile.CustomButton btnAddPatient;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private OrganizationProfile.CustomButton btnInactive;
        private OrganizationProfile.CustomButton btnActive;
        private OrganizationProfile.CustomButton btnAll;
        private OrganizationProfile.CustomButton btnSearch;
        private CustomControls.RJControls.RJComboBox cbSort;
        private System.Windows.Forms.Label lblHiddenForFocus;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn editHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
