namespace Kinesia.Logs
{
    partial class LogsPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            nameHolder = new Label();
            dataGridPatients = new DataGridView();
            LogID = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            nameHeader = new DataGridViewTextBoxColumn();
            genderHeader = new DataGridViewTextBoxColumn();
            contactNumHeader = new DataGridViewTextBoxColumn();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnPatients = new OrganizationProfile.CustomButton();
            btnUsers = new OrganizationProfile.CustomButton();
            btnSessions = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            cbSort = new CustomControls.RJControls.RJComboBox();
            LogHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            pictureBox1 = new PictureBox();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            lblHiddenForFocus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridPatients).BeginInit();
            panelBorder2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(76, 83);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(208, 23);
            label1.TabIndex = 5;
            label1.Text = "Keep track on system's activity";
            // 
            // nameHolder
            // 
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            nameHolder.AutoSize = true;
            nameHolder.Font = new Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameHolder.ForeColor = Color.FromArgb(18, 90, 211);
            nameHolder.Location = new Point(71, 37);
            nameHolder.Margin = new Padding(0);
            nameHolder.Name = "nameHolder";
            nameHolder.Size = new Size(83, 48);
            nameHolder.TabIndex = 4;
            nameHolder.Text = "Logs";
            nameHolder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridPatients
            // 
            dataGridPatients.AllowUserToAddRows = false;
            dataGridPatients.AllowUserToDeleteRows = false;
            dataGridPatients.AllowUserToResizeColumns = false;
            dataGridPatients.AllowUserToResizeRows = false;
            dataGridPatients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPatients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridPatients.BackgroundColor = Color.White;
            dataGridPatients.BorderStyle = BorderStyle.None;
            dataGridPatients.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridPatients.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPatients.Columns.AddRange(new DataGridViewColumn[] { LogID, Column1, nameHeader, genderHeader, contactNumHeader });
            dataGridPatients.GridColor = Color.White;
            dataGridPatients.Location = new Point(82, 238);
            dataGridPatients.Margin = new Padding(4, 3, 4, 3);
            dataGridPatients.Name = "dataGridPatients";
            dataGridPatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Transparent;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridPatients.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridPatients.ShowCellErrors = false;
            dataGridPatients.ShowCellToolTips = false;
            dataGridPatients.ShowEditingIcon = false;
            dataGridPatients.ShowRowErrors = false;
            dataGridPatients.Size = new Size(773, 31);
            dataGridPatients.TabIndex = 9;
            // 
            // LogID
            // 
            LogID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LogID.FillWeight = 50F;
            LogID.HeaderText = "Log ID";
            LogID.Name = "LogID";
            LogID.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.FillWeight = 50F;
            Column1.HeaderText = "Log Type";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // nameHeader
            // 
            nameHeader.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(18, 90, 211);
            nameHeader.DefaultCellStyle = dataGridViewCellStyle2;
            nameHeader.HeaderText = "Name of User";
            nameHeader.Name = "nameHeader";
            nameHeader.ReadOnly = true;
            nameHeader.Resizable = DataGridViewTriState.False;
            // 
            // genderHeader
            // 
            genderHeader.FillWeight = 50F;
            genderHeader.HeaderText = "Log Description";
            genderHeader.Name = "genderHeader";
            genderHeader.ReadOnly = true;
            // 
            // contactNumHeader
            // 
            contactNumHeader.FillWeight = 63.63636F;
            contactNumHeader.HeaderText = "Date";
            contactNumHeader.Name = "contactNumHeader";
            contactNumHeader.ReadOnly = true;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBorder2.BackColor = Color.White;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = Color.BurlyWood;
            panelBorder2.Controls.Add(btnPatients);
            panelBorder2.Controls.Add(btnUsers);
            panelBorder2.Controls.Add(btnSessions);
            panelBorder2.Controls.Add(btnAll);
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.ForeColor = Color.Black;
            panelBorder2.Location = new Point(72, 163);
            panelBorder2.Margin = new Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new Size(794, 67);
            panelBorder2.TabIndex = 14;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = Color.Gainsboro;
            btnPatients.BackgroundColor = Color.Gainsboro;
            btnPatients.BorderColor = Color.PaleVioletRed;
            btnPatients.BorderRadius = 5;
            btnPatients.BorderSize = 0;
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = FlatStyle.Flat;
            btnPatients.Font = new Font("Poppins", 9F, FontStyle.Bold | FontStyle.Underline);
            btnPatients.ForeColor = Color.Gray;
            btnPatients.Location = new Point(309, 10);
            btnPatients.Margin = new Padding(1);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(93, 46);
            btnPatients.TabIndex = 18;
            btnPatients.Text = "Patients";
            btnPatients.TextColor = Color.Gray;
            btnPatients.UseVisualStyleBackColor = false;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Gainsboro;
            btnUsers.BackgroundColor = Color.Gainsboro;
            btnUsers.BorderColor = Color.PaleVioletRed;
            btnUsers.BorderRadius = 5;
            btnUsers.BorderSize = 0;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Poppins", 9F, FontStyle.Bold | FontStyle.Underline);
            btnUsers.ForeColor = Color.Gray;
            btnUsers.Location = new Point(210, 10);
            btnUsers.Margin = new Padding(1);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(93, 46);
            btnUsers.TabIndex = 17;
            btnUsers.Text = "Users";
            btnUsers.TextColor = Color.Gray;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnSessions
            // 
            btnSessions.BackColor = Color.Gainsboro;
            btnSessions.BackgroundColor = Color.Gainsboro;
            btnSessions.BorderColor = Color.PaleVioletRed;
            btnSessions.BorderRadius = 5;
            btnSessions.BorderSize = 0;
            btnSessions.FlatAppearance.BorderSize = 0;
            btnSessions.FlatStyle = FlatStyle.Flat;
            btnSessions.Font = new Font("Poppins", 9F, FontStyle.Bold | FontStyle.Underline);
            btnSessions.ForeColor = Color.Gray;
            btnSessions.Location = new Point(112, 10);
            btnSessions.Margin = new Padding(4, 3, 4, 3);
            btnSessions.Name = "btnSessions";
            btnSessions.Size = new Size(93, 46);
            btnSessions.TabIndex = 16;
            btnSessions.Text = "Sessions";
            btnSessions.TextColor = Color.Gray;
            btnSessions.UseVisualStyleBackColor = false;
            btnSessions.Click += btnSessions_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.FromArgb(18, 90, 211);
            btnAll.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnAll.BorderColor = Color.PaleVioletRed;
            btnAll.BorderRadius = 5;
            btnAll.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Poppins", 9F, FontStyle.Bold | FontStyle.Underline);
            btnAll.ForeColor = Color.White;
            btnAll.Location = new Point(14, 10);
            btnAll.Margin = new Padding(1);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(93, 46);
            btnAll.TabIndex = 15;
            btnAll.Text = "All";
            btnAll.TextColor = Color.White;
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // cbSort
            // 
            cbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSort.BackColor = Color.White;
            cbSort.BorderColor = Color.Gray;
            cbSort.BorderSize = 1;
            cbSort.DropDownStyle = ComboBoxStyle.DropDown;
            cbSort.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSort.ForeColor = Color.DimGray;
            cbSort.IconColor = Color.FromArgb(24, 90, 211);
            cbSort.Items.AddRange(new object[] { "Latest", "Earliest" });
            cbSort.ListBackColor = Color.White;
            cbSort.ListTextColor = Color.Black;
            cbSort.Location = new Point(499, 8);
            cbSort.Margin = new Padding(4, 3, 4, 3);
            cbSort.MinimumSize = new Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new Padding(1);
            cbSort.Size = new Size(284, 55);
            cbSort.TabIndex = 14;
            cbSort.Texts = "Latest";
            cbSort.OnSelectedIndexChanged += cbSort_OnSelectedIndexChanged;
            // 
            // LogHolder
            // 
            LogHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogHolder.AutoScroll = true;
            LogHolder.BackColor = Color.FromArgb(207, 249, 238);
            LogHolder.BorderRadius = 10;
            LogHolder.Color = Color.White;
            LogHolder.ForeColor = Color.Black;
            LogHolder.Location = new Point(72, 282);
            LogHolder.Margin = new Padding(4, 3, 4, 3);
            LogHolder.Name = "LogHolder";
            LogHolder.Padding = new Padding(6);
            LogHolder.Size = new Size(794, 15087);
            LogHolder.TabIndex = 8;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelBorder1.BackColor = Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder1.BackgroundImageLayout = ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = Color.BurlyWood;
            panelBorder1.Controls.Add(btnSearch);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(txtSearchBar);
            panelBorder1.ForeColor = Color.Black;
            panelBorder1.Location = new Point(284, 51);
            panelBorder1.Margin = new Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new Padding(6);
            panelBorder1.Size = new Size(582, 59);
            panelBorder1.TabIndex = 15;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(453, 8);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(2, 3, 0, 0);
            btnSearch.Size = new Size(118, 40);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.TextColor = Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search_icon;
            pictureBox1.Location = new Point(16, 17);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BackColor = Color.White;
            txtSearchBar.BorderColor = Color.White;
            txtSearchBar.BorderFocusColor = Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new Point(56, 10);
            txtSearchBar.Margin = new Padding(5);
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.Size = new Size(388, 32);
            txtSearchBar.TabIndex = 4;
            txtSearchBar.Texts = "Search for User name or Log ID";
            txtSearchBar.UnderlinedStyle = false;
            txtSearchBar._TextChanged += txtSearchBar__TextChanged;
            txtSearchBar.Enter += txtSearchBar_Enter;
            txtSearchBar.Leave += txtSearchBar_Leave;
            // 
            // lblHiddenForFocus
            // 
            lblHiddenForFocus.AutoSize = true;
            lblHiddenForFocus.ForeColor = Color.White;
            lblHiddenForFocus.Location = new Point(398, 95);
            lblHiddenForFocus.Margin = new Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new Size(135, 15);
            lblHiddenForFocus.TabIndex = 16;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // LogsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder1);
            Controls.Add(panelBorder2);
            Controls.Add(dataGridPatients);
            Controls.Add(LogHolder);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LogsPage";
            Size = new Size(726, 15273);
            Load += LogsPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPatients).EndInit();
            panelBorder2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private WindowsFormsApp2.CustomButton.PanelBorder LogHolder;
        private System.Windows.Forms.DataGridView dataGridPatients;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private CustomControls.RJControls.RJComboBox cbSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumHeader;
        private OrganizationProfile.CustomButton btnUsers;
        private OrganizationProfile.CustomButton btnSessions;
        private OrganizationProfile.CustomButton btnAll;
        private OrganizationProfile.CustomButton btnPatients;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private System.Windows.Forms.Label lblHiddenForFocus;
    }
}
