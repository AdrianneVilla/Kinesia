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
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            cbSort = new CustomControls.RJControls.RJComboBox();
            btnROM = new OrganizationProfile.CustomButton();
            btnAssessment = new OrganizationProfile.CustomButton();
            btnPatients = new OrganizationProfile.CustomButton();
            btnUsers = new OrganizationProfile.CustomButton();
            btnSessions = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            dataGridLogs = new System.Windows.Forms.DataGridView();
            panelBorder3 = new WindowsFormsApp2.CustomButton.PanelBorder();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnSearch = new OrganizationProfile.CustomButton();
            lblHiddenForFocus = new System.Windows.Forms.Label();
            panelBorder2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLogs).BeginInit();
            panelBorder3.SuspendLayout();
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
            label1.TabIndex = 7;
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
            nameHolder.TabIndex = 6;
            nameHolder.Text = "Logs";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.Controls.Add(btnROM);
            panelBorder2.Controls.Add(btnAssessment);
            panelBorder2.Controls.Add(btnPatients);
            panelBorder2.Controls.Add(btnUsers);
            panelBorder2.Controls.Add(btnSessions);
            panelBorder2.Controls.Add(btnAll);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(1069, 67);
            panelBorder2.TabIndex = 15;
            // 
            // cbSort
            // 
            cbSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbSort.BackColor = System.Drawing.Color.White;
            cbSort.BorderColor = System.Drawing.Color.Gray;
            cbSort.BorderSize = 1;
            cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbSort.ForeColor = System.Drawing.Color.DimGray;
            cbSort.IconColor = System.Drawing.Color.FromArgb(24, 90, 211);
            cbSort.Items.AddRange(new object[] { "Latest", "Earliest" });
            cbSort.ListBackColor = System.Drawing.Color.White;
            cbSort.ListTextColor = System.Drawing.Color.Black;
            cbSort.Location = new System.Drawing.Point(790, 10);
            cbSort.MinimumSize = new System.Drawing.Size(200, 30);
            cbSort.Name = "cbSort";
            cbSort.Padding = new System.Windows.Forms.Padding(1);
            cbSort.Size = new System.Drawing.Size(273, 46);
            cbSort.TabIndex = 22;
            cbSort.Texts = "Latest";
            cbSort.OnSelectedIndexChanged += cbSort_OnSelectedIndexChanged;
            // 
            // btnROM
            // 
            btnROM.BackColor = System.Drawing.Color.Gainsboro;
            btnROM.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnROM.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnROM.BorderRadius = 5;
            btnROM.BorderSize = 0;
            btnROM.Cursor = System.Windows.Forms.Cursors.Hand;
            btnROM.FlatAppearance.BorderSize = 0;
            btnROM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnROM.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnROM.ForeColor = System.Drawing.Color.Gray;
            btnROM.Location = new System.Drawing.Point(519, 10);
            btnROM.Margin = new System.Windows.Forms.Padding(1);
            btnROM.Name = "btnROM";
            btnROM.Size = new System.Drawing.Size(93, 46);
            btnROM.TabIndex = 21;
            btnROM.Text = "ROM";
            btnROM.TextColor = System.Drawing.Color.Gray;
            btnROM.UseVisualStyleBackColor = false;
            btnROM.Click += btnROM_Click;
            // 
            // btnAssessment
            // 
            btnAssessment.BackColor = System.Drawing.Color.Gainsboro;
            btnAssessment.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnAssessment.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAssessment.BorderRadius = 5;
            btnAssessment.BorderSize = 0;
            btnAssessment.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAssessment.FlatAppearance.BorderSize = 0;
            btnAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAssessment.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAssessment.ForeColor = System.Drawing.Color.Gray;
            btnAssessment.Location = new System.Drawing.Point(409, 10);
            btnAssessment.Margin = new System.Windows.Forms.Padding(1);
            btnAssessment.Name = "btnAssessment";
            btnAssessment.Size = new System.Drawing.Size(101, 46);
            btnAssessment.TabIndex = 20;
            btnAssessment.Text = "Assessment";
            btnAssessment.TextColor = System.Drawing.Color.Gray;
            btnAssessment.UseVisualStyleBackColor = false;
            btnAssessment.Click += btnAssessment_Click;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = System.Drawing.Color.Gainsboro;
            btnPatients.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnPatients.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnPatients.BorderRadius = 5;
            btnPatients.BorderSize = 0;
            btnPatients.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnSessions.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(dataGridLogs);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(86, 236);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(1049, 436);
            panelBorder1.TabIndex = 16;
            // 
            // dataGridLogs
            // 
            dataGridLogs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridLogs.BackgroundColor = System.Drawing.Color.White;
            dataGridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridLogs.GridColor = System.Drawing.Color.White;
            dataGridLogs.Location = new System.Drawing.Point(10, 10);
            dataGridLogs.Margin = new System.Windows.Forms.Padding(10);
            dataGridLogs.Name = "dataGridLogs";
            dataGridLogs.Size = new System.Drawing.Size(1029, 416);
            dataGridLogs.TabIndex = 0;
            // 
            // panelBorder3
            // 
            panelBorder3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelBorder3.BackColor = System.Drawing.Color.White;
            panelBorder3.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder3.BorderRadius = 30;
            panelBorder3.Color = System.Drawing.Color.BurlyWood;
            panelBorder3.Controls.Add(txtSearchBar);
            panelBorder3.Controls.Add(pictureBox1);
            panelBorder3.Controls.Add(btnSearch);
            panelBorder3.ForeColor = System.Drawing.Color.Black;
            panelBorder3.Location = new System.Drawing.Point(559, 47);
            panelBorder3.Name = "panelBorder3";
            panelBorder3.Size = new System.Drawing.Size(582, 59);
            panelBorder3.TabIndex = 17;
            // 
            // txtSearchBar
            // 
            txtSearchBar.AutoSize = true;
            txtSearchBar.BackColor = System.Drawing.Color.White;
            txtSearchBar.BorderColor = System.Drawing.Color.White;
            txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(57, 11);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.SelectionLength = 0;
            txtSearchBar.SelectionStart = 0;
            txtSearchBar.Size = new System.Drawing.Size(388, 35);
            txtSearchBar.TabIndex = 18;
            txtSearchBar.Texts = "";
            txtSearchBar.UnderlinedStyle = false;
            txtSearchBar._TextChanged += txtSearchBar__TextChanged;
            txtSearchBar.Enter += txtSearchBar_Enter;
            txtSearchBar.Leave += txtSearchBar_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search_icon;
            pictureBox1.Location = new System.Drawing.Point(16, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(33, 28);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(448, 9);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            btnSearch.Size = new System.Drawing.Size(118, 40);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblHiddenForFocus
            // 
            lblHiddenForFocus.AutoSize = true;
            lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            lblHiddenForFocus.Location = new System.Drawing.Point(339, 86);
            lblHiddenForFocus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new System.Drawing.Size(135, 15);
            lblHiddenForFocus.TabIndex = 19;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // LogsPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder3);
            Controls.Add(panelBorder1);
            Controls.Add(panelBorder2);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Name = "LogsPage";
            Size = new System.Drawing.Size(1231, 686);
            Load += LogsPage_Load;
            Paint += LogsPage_Paint;
            panelBorder2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLogs).EndInit();
            panelBorder3.ResumeLayout(false);
            panelBorder3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private OrganizationProfile.CustomButton btnPatients;
        private OrganizationProfile.CustomButton btnUsers;
        private OrganizationProfile.CustomButton btnSessions;
        private OrganizationProfile.CustomButton btnAll;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.DataGridView dataGridLogs;
        private OrganizationProfile.CustomButton btnROM;
        private OrganizationProfile.CustomButton btnAssessment;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder3;
        private OrganizationProfile.CustomButton btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJComboBox cbSort;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private System.Windows.Forms.Label lblHiddenForFocus;
    }
}
