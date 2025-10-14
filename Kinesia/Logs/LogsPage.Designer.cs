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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            dataGridPatients = new System.Windows.Forms.DataGridView();
            LogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            genderHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            contactNumHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnPatients = new OrganizationProfile.CustomButton();
            btnUsers = new OrganizationProfile.CustomButton();
            btnSessions = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            cbSort = new CustomControls.RJControls.RJComboBox();
            LogHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            lblHiddenForFocus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridPatients).BeginInit();
            panelBorder2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(76, 83);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(208, 23);
            label1.TabIndex = 5;
            label1.Text = "Keep track on system's activity";
            // 
            // nameHolder
            // 
            nameHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            nameHolder.AutoSize = true;
            nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            nameHolder.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            nameHolder.Location = new System.Drawing.Point(71, 37);
            nameHolder.Margin = new System.Windows.Forms.Padding(0);
            nameHolder.Name = "nameHolder";
            nameHolder.Size = new System.Drawing.Size(83, 48);
            nameHolder.TabIndex = 4;
            nameHolder.Text = "Logs";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridPatients
            // 
            dataGridPatients.AllowUserToAddRows = false;
            dataGridPatients.AllowUserToDeleteRows = false;
            dataGridPatients.AllowUserToResizeColumns = false;
            dataGridPatients.AllowUserToResizeRows = false;
            dataGridPatients.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPatients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridPatients.BackgroundColor = System.Drawing.Color.White;
            dataGridPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridPatients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { LogID, Column1, nameHeader, genderHeader, contactNumHeader });
            dataGridPatients.GridColor = System.Drawing.Color.White;
            dataGridPatients.Location = new System.Drawing.Point(82, 238);
            dataGridPatients.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridPatients.Name = "dataGridPatients";
            dataGridPatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridPatients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridPatients.ShowCellErrors = false;
            dataGridPatients.ShowCellToolTips = false;
            dataGridPatients.ShowEditingIcon = false;
            dataGridPatients.ShowRowErrors = false;
            dataGridPatients.Size = new System.Drawing.Size(2773, 31);
            dataGridPatients.TabIndex = 9;
            // 
            // LogID
            // 
            LogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            LogID.FillWeight = 50F;
            LogID.HeaderText = "Log ID";
            LogID.Name = "LogID";
            LogID.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Column1.FillWeight = 50F;
            Column1.HeaderText = "Log Type";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
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
            nameHeader.HeaderText = "Name of User";
            nameHeader.Name = "nameHeader";
            nameHeader.ReadOnly = true;
            nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(btnPatients);
            panelBorder2.Controls.Add(btnUsers);
            panelBorder2.Controls.Add(btnSessions);
            panelBorder2.Controls.Add(btnAll);
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(2794, 67);
            panelBorder2.TabIndex = 14;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = System.Drawing.Color.Gainsboro;
            btnPatients.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnPatients.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnPatients.BorderRadius = 5;
            btnPatients.BorderSize = 0;
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPatients.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnPatients.ForeColor = System.Drawing.Color.Gray;
            btnPatients.Location = new System.Drawing.Point(309, 10);
            btnPatients.Margin = new System.Windows.Forms.Padding(1);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new System.Drawing.Size(93, 46);
            btnPatients.TabIndex = 18;
            btnPatients.Text = "Patients";
            btnPatients.TextColor = System.Drawing.Color.Gray;
            btnPatients.UseVisualStyleBackColor = false;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = System.Drawing.Color.Gainsboro;
            btnUsers.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnUsers.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnUsers.BorderRadius = 5;
            btnUsers.BorderSize = 0;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUsers.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnUsers.ForeColor = System.Drawing.Color.Gray;
            btnUsers.Location = new System.Drawing.Point(210, 10);
            btnUsers.Margin = new System.Windows.Forms.Padding(1);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new System.Drawing.Size(93, 46);
            btnUsers.TabIndex = 17;
            btnUsers.Text = "Users";
            btnUsers.TextColor = System.Drawing.Color.Gray;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnSessions
            // 
            btnSessions.BackColor = System.Drawing.Color.Gainsboro;
            btnSessions.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnSessions.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSessions.BorderRadius = 5;
            btnSessions.BorderSize = 0;
            btnSessions.FlatAppearance.BorderSize = 0;
            btnSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSessions.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnSessions.ForeColor = System.Drawing.Color.Gray;
            btnSessions.Location = new System.Drawing.Point(112, 10);
            btnSessions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSessions.Name = "btnSessions";
            btnSessions.Size = new System.Drawing.Size(93, 46);
            btnSessions.TabIndex = 16;
            btnSessions.Text = "Sessions";
            btnSessions.TextColor = System.Drawing.Color.Gray;
            btnSessions.UseVisualStyleBackColor = false;
            btnSessions.Click += btnSessions_Click;
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
            btnAll.TabIndex = 15;
            btnAll.Text = "All";
            btnAll.TextColor = System.Drawing.Color.White;
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
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
            cbSort.Items.AddRange(new object[] { "Latest", "Earliest" });
            cbSort.ListBackColor = System.Drawing.Color.White;
            cbSort.ListTextColor = System.Drawing.Color.Black;
            cbSort.Location = new System.Drawing.Point(2499, 8);
            cbSort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSort.MinimumSize = new System.Drawing.Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new System.Windows.Forms.Padding(1);
            cbSort.Size = new System.Drawing.Size(284, 55);
            cbSort.TabIndex = 14;
            cbSort.Texts = "Latest";
            cbSort.OnSelectedIndexChanged += cbSort_OnSelectedIndexChanged;
            // 
            // LogHolder
            // 
            LogHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LogHolder.AutoScroll = true;
            LogHolder.BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            LogHolder.BorderRadius = 10;
            LogHolder.Color = System.Drawing.Color.White;
            LogHolder.ForeColor = System.Drawing.Color.Black;
            LogHolder.Location = new System.Drawing.Point(72, 282);
            LogHolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LogHolder.Name = "LogHolder";
            LogHolder.Padding = new System.Windows.Forms.Padding(6);
            LogHolder.Size = new System.Drawing.Size(2794, 21500);
            LogHolder.TabIndex = 8;
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
            panelBorder1.Location = new System.Drawing.Point(2284, 51);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(582, 59);
            panelBorder1.TabIndex = 15;
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
            btnSearch.TabIndex = 14;
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
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(56, 10);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.Size = new System.Drawing.Size(388, 32);
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
            lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            lblHiddenForFocus.Location = new System.Drawing.Point(315, 123);
            lblHiddenForFocus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new System.Drawing.Size(135, 15);
            lblHiddenForFocus.TabIndex = 16;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // LogsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackColor = System.Drawing.Color.White;
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder1);
            Controls.Add(panelBorder2);
            Controls.Add(dataGridPatients);
            Controls.Add(LogHolder);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LogsPage";
            Size = new System.Drawing.Size(2726, 21686);
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
