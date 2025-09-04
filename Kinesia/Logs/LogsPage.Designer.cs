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
            this.label1 = new System.Windows.Forms.Label();
            this.nameHolder = new System.Windows.Forms.Label();
            this.dataGridPatients = new System.Windows.Forms.DataGridView();
            this.LogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnPatients = new OrganizationProfile.CustomButton();
            this.btnUsers = new OrganizationProfile.CustomButton();
            this.btnSessions = new OrganizationProfile.CustomButton();
            this.btnAll = new OrganizationProfile.CustomButton();
            this.cbSort = new CustomControls.RJControls.RJComboBox();
            this.LogHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnSearch = new OrganizationProfile.CustomButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchBar = new CustomControls.RJControls.RJTextBox();
            this.lblHiddenForFocus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPatients)).BeginInit();
            this.panelBorder2.SuspendLayout();
            this.panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Keep track on system\'s activity";
            // 
            // nameHolder
            // 
            this.nameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameHolder.AutoSize = true;
            this.nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHolder.Location = new System.Drawing.Point(61, 32);
            this.nameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.nameHolder.Name = "nameHolder";
            this.nameHolder.Size = new System.Drawing.Size(83, 48);
            this.nameHolder.TabIndex = 4;
            this.nameHolder.Text = "Logs";
            this.nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridPatients
            // 
            this.dataGridPatients.AllowUserToAddRows = false;
            this.dataGridPatients.AllowUserToDeleteRows = false;
            this.dataGridPatients.AllowUserToResizeColumns = false;
            this.dataGridPatients.AllowUserToResizeRows = false;
            this.dataGridPatients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPatients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridPatients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridPatients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogID,
            this.Column1,
            this.nameHeader,
            this.genderHeader,
            this.contactNumHeader});
            this.dataGridPatients.GridColor = System.Drawing.Color.White;
            this.dataGridPatients.Location = new System.Drawing.Point(70, 206);
            this.dataGridPatients.Name = "dataGridPatients";
            this.dataGridPatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridPatients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridPatients.ShowCellErrors = false;
            this.dataGridPatients.ShowCellToolTips = false;
            this.dataGridPatients.ShowEditingIcon = false;
            this.dataGridPatients.ShowRowErrors = false;
            this.dataGridPatients.Size = new System.Drawing.Size(1111, 27);
            this.dataGridPatients.TabIndex = 9;
            // 
            // LogID
            // 
            this.LogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LogID.FillWeight = 50F;
            this.LogID.HeaderText = "Log ID";
            this.LogID.Name = "LogID";
            this.LogID.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Log Type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // nameHeader
            // 
            this.nameHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHeader.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameHeader.HeaderText = "Name of User";
            this.nameHeader.Name = "nameHeader";
            this.nameHeader.ReadOnly = true;
            this.nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // genderHeader
            // 
            this.genderHeader.FillWeight = 50F;
            this.genderHeader.HeaderText = "Log Description";
            this.genderHeader.Name = "genderHeader";
            this.genderHeader.ReadOnly = true;
            // 
            // contactNumHeader
            // 
            this.contactNumHeader.FillWeight = 63.63636F;
            this.contactNumHeader.HeaderText = "Date";
            this.contactNumHeader.Name = "contactNumHeader";
            this.contactNumHeader.ReadOnly = true;
            // 
            // panelBorder2
            // 
            this.panelBorder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder2.BackColor = System.Drawing.Color.White;
            this.panelBorder2.BorderRadius = 30;
            this.panelBorder2.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder2.Controls.Add(this.btnPatients);
            this.panelBorder2.Controls.Add(this.btnUsers);
            this.panelBorder2.Controls.Add(this.btnSessions);
            this.panelBorder2.Controls.Add(this.btnAll);
            this.panelBorder2.Controls.Add(this.cbSort);
            this.panelBorder2.ForeColor = System.Drawing.Color.Black;
            this.panelBorder2.Location = new System.Drawing.Point(62, 141);
            this.panelBorder2.Name = "panelBorder2";
            this.panelBorder2.Size = new System.Drawing.Size(1129, 58);
            this.panelBorder2.TabIndex = 14;
            // 
            // btnPatients
            // 
            this.btnPatients.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPatients.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnPatients.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPatients.BorderRadius = 5;
            this.btnPatients.BorderSize = 0;
            this.btnPatients.FlatAppearance.BorderSize = 0;
            this.btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatients.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnPatients.ForeColor = System.Drawing.Color.Gray;
            this.btnPatients.Location = new System.Drawing.Point(265, 9);
            this.btnPatients.Margin = new System.Windows.Forms.Padding(1);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(80, 40);
            this.btnPatients.TabIndex = 18;
            this.btnPatients.Text = "Patients";
            this.btnPatients.TextColor = System.Drawing.Color.Gray;
            this.btnPatients.UseVisualStyleBackColor = false;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUsers.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnUsers.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUsers.BorderRadius = 5;
            this.btnUsers.BorderSize = 0;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnUsers.ForeColor = System.Drawing.Color.Gray;
            this.btnUsers.Location = new System.Drawing.Point(180, 9);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(1);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(80, 40);
            this.btnUsers.TabIndex = 17;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextColor = System.Drawing.Color.Gray;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnSessions
            // 
            this.btnSessions.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSessions.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnSessions.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSessions.BorderRadius = 5;
            this.btnSessions.BorderSize = 0;
            this.btnSessions.FlatAppearance.BorderSize = 0;
            this.btnSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSessions.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnSessions.ForeColor = System.Drawing.Color.Gray;
            this.btnSessions.Location = new System.Drawing.Point(96, 9);
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(80, 40);
            this.btnSessions.TabIndex = 16;
            this.btnSessions.Text = "Sessions";
            this.btnSessions.TextColor = System.Drawing.Color.Gray;
            this.btnSessions.UseVisualStyleBackColor = false;
            this.btnSessions.Click += new System.EventHandler(this.btnSessions_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAll.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAll.BorderRadius = 5;
            this.btnAll.BorderSize = 0;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(12, 9);
            this.btnAll.Margin = new System.Windows.Forms.Padding(1);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(80, 40);
            this.btnAll.TabIndex = 15;
            this.btnAll.Text = "All";
            this.btnAll.TextColor = System.Drawing.Color.White;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // cbSort
            // 
            this.cbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSort.BackColor = System.Drawing.Color.White;
            this.cbSort.BorderColor = System.Drawing.Color.Gray;
            this.cbSort.BorderSize = 1;
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbSort.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.Color.DimGray;
            this.cbSort.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.cbSort.Items.AddRange(new object[] {
            "Latest",
            "Earliest"});
            this.cbSort.ListBackColor = System.Drawing.Color.White;
            this.cbSort.ListTextColor = System.Drawing.Color.Black;
            this.cbSort.Location = new System.Drawing.Point(876, 7);
            this.cbSort.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbSort.Name = "cbSort";
            this.cbSort.Padding = new System.Windows.Forms.Padding(1);
            this.cbSort.Size = new System.Drawing.Size(243, 48);
            this.cbSort.TabIndex = 14;
            this.cbSort.Texts = "Latest";
            this.cbSort.OnSelectedIndexChanged += new System.EventHandler(this.cbSort_OnSelectedIndexChanged);
            // 
            // LogHolder
            // 
            this.LogHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogHolder.AutoScroll = true;
            this.LogHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.LogHolder.BorderRadius = 10;
            this.LogHolder.Color = System.Drawing.Color.White;
            this.LogHolder.ForeColor = System.Drawing.Color.Black;
            this.LogHolder.Location = new System.Drawing.Point(62, 244);
            this.LogHolder.Name = "LogHolder";
            this.LogHolder.Padding = new System.Windows.Forms.Padding(5);
            this.LogHolder.Size = new System.Drawing.Size(1129, 496);
            this.LogHolder.TabIndex = 8;
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BackgroundImage = global::Kinesia.Properties.Resources.search_background_new;
            this.panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBorder1.BorderRadius = 10;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.btnSearch);
            this.panelBorder1.Controls.Add(this.pictureBox1);
            this.panelBorder1.Controls.Add(this.txtSearchBar);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(692, 44);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Padding = new System.Windows.Forms.Padding(5);
            this.panelBorder1.Size = new System.Drawing.Size(499, 51);
            this.panelBorder1.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(388, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(101, 35);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kinesia.Properties.Resources.search_icon;
            this.pictureBox1.Location = new System.Drawing.Point(14, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.BackColor = System.Drawing.Color.White;
            this.txtSearchBar.BorderColor = System.Drawing.Color.White;
            this.txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            this.txtSearchBar.BorderRadius = 5;
            this.txtSearchBar.BorderSize = 1;
            this.txtSearchBar.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchBar.Location = new System.Drawing.Point(48, 9);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchBar.Multiline = false;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 0);
            this.txtSearchBar.PasswordChar = false;
            this.txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchBar.PlaceholderText = "";
            this.txtSearchBar.Size = new System.Drawing.Size(333, 31);
            this.txtSearchBar.TabIndex = 4;
            this.txtSearchBar.Texts = "Search for User name or Log ID";
            this.txtSearchBar.UnderlinedStyle = false;
            this.txtSearchBar._TextChanged += new System.EventHandler(this.txtSearchBar__TextChanged);
            this.txtSearchBar.Enter += new System.EventHandler(this.txtSearchBar_Enter);
            this.txtSearchBar.Leave += new System.EventHandler(this.txtSearchBar_Leave);
            // 
            // lblHiddenForFocus
            // 
            this.lblHiddenForFocus.AutoSize = true;
            this.lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            this.lblHiddenForFocus.Location = new System.Drawing.Point(341, 82);
            this.lblHiddenForFocus.Name = "lblHiddenForFocus";
            this.lblHiddenForFocus.Size = new System.Drawing.Size(120, 13);
            this.lblHiddenForFocus.TabIndex = 16;
            this.lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // LogsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblHiddenForFocus);
            this.Controls.Add(this.panelBorder1);
            this.Controls.Add(this.panelBorder2);
            this.Controls.Add(this.dataGridPatients);
            this.Controls.Add(this.LogHolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameHolder);
            this.Name = "LogsPage";
            this.Size = new System.Drawing.Size(1249, 758);
            this.Load += new System.EventHandler(this.LogsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPatients)).EndInit();
            this.panelBorder2.ResumeLayout(false);
            this.panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
