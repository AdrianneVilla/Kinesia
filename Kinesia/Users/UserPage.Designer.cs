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
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.UserIDHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nameHolder = new System.Windows.Forms.Label();
            this.panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.cbSort = new CustomControls.RJControls.RJComboBox();
            this.btnInactive = new OrganizationProfile.CustomButton();
            this.btnActive = new OrganizationProfile.CustomButton();
            this.btnAll = new OrganizationProfile.CustomButton();
            this.btnAddPatient = new OrganizationProfile.CustomButton();
            this.UserHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnSearch = new OrganizationProfile.CustomButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchBar = new CustomControls.RJControls.RJTextBox();
            this.lblHiddenForFocus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.panelBorder2.SuspendLayout();
            this.panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.AllowUserToResizeColumns = false;
            this.dataGridUsers.AllowUserToResizeRows = false;
            this.dataGridUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridUsers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserIDHeader,
            this.nameHeader,
            this.EmpPosition,
            this.editHeader,
            this.Column1,
            this.Column2});
            this.dataGridUsers.GridColor = System.Drawing.Color.White;
            this.dataGridUsers.Location = new System.Drawing.Point(70, 218);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridUsers.ShowCellErrors = false;
            this.dataGridUsers.ShowCellToolTips = false;
            this.dataGridUsers.ShowEditingIcon = false;
            this.dataGridUsers.ShowRowErrors = false;
            this.dataGridUsers.Size = new System.Drawing.Size(1111, 24);
            this.dataGridUsers.TabIndex = 14;
            // 
            // UserIDHeader
            // 
            this.UserIDHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserIDHeader.FillWeight = 50F;
            this.UserIDHeader.HeaderText = "User ID";
            this.UserIDHeader.Name = "UserIDHeader";
            this.UserIDHeader.ReadOnly = true;
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
            this.nameHeader.HeaderText = "Name";
            this.nameHeader.Name = "nameHeader";
            this.nameHeader.ReadOnly = true;
            this.nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // EmpPosition
            // 
            this.EmpPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmpPosition.FillWeight = 60F;
            this.EmpPosition.HeaderText = "Position";
            this.EmpPosition.Name = "EmpPosition";
            this.EmpPosition.ReadOnly = true;
            // 
            // editHeader
            // 
            this.editHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.editHeader.DefaultCellStyle = dataGridViewCellStyle3;
            this.editHeader.FillWeight = 20F;
            this.editHeader.HeaderText = "Select";
            this.editHeader.Name = "editHeader";
            this.editHeader.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 20F;
            this.Column1.HeaderText = "Edit";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 20F;
            this.Column2.HeaderText = "Archive";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = " Helps you move better and feel better";
            // 
            // nameHolder
            // 
            this.nameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameHolder.AutoSize = true;
            this.nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHolder.Location = new System.Drawing.Point(59, 31);
            this.nameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.nameHolder.Name = "nameHolder";
            this.nameHolder.Size = new System.Drawing.Size(98, 48);
            this.nameHolder.TabIndex = 9;
            this.nameHolder.Text = "Users";
            this.nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBorder2
            // 
            this.panelBorder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder2.BackColor = System.Drawing.Color.White;
            this.panelBorder2.BorderRadius = 30;
            this.panelBorder2.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder2.Controls.Add(this.cbSort);
            this.panelBorder2.Controls.Add(this.btnInactive);
            this.panelBorder2.Controls.Add(this.btnActive);
            this.panelBorder2.Controls.Add(this.btnAll);
            this.panelBorder2.Controls.Add(this.btnAddPatient);
            this.panelBorder2.ForeColor = System.Drawing.Color.Black;
            this.panelBorder2.Location = new System.Drawing.Point(62, 141);
            this.panelBorder2.Name = "panelBorder2";
            this.panelBorder2.Size = new System.Drawing.Size(1129, 58);
            this.panelBorder2.TabIndex = 15;
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
            "Default",
            "Alphabetical (Name)",
            "Earliest (Date Added)",
            "Latest (Date Added)"});
            this.cbSort.ListBackColor = System.Drawing.Color.White;
            this.cbSort.ListTextColor = System.Drawing.Color.Black;
            this.cbSort.Location = new System.Drawing.Point(719, 5);
            this.cbSort.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbSort.Name = "cbSort";
            this.cbSort.Padding = new System.Windows.Forms.Padding(1);
            this.cbSort.Size = new System.Drawing.Size(243, 48);
            this.cbSort.TabIndex = 16;
            this.cbSort.Texts = "Default";
            this.cbSort.OnSelectedIndexChanged += new System.EventHandler(this.cbSort_OnSelectedIndexChanged);
            // 
            // btnInactive
            // 
            this.btnInactive.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInactive.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnInactive.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnInactive.BorderRadius = 5;
            this.btnInactive.BorderSize = 0;
            this.btnInactive.FlatAppearance.BorderSize = 0;
            this.btnInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactive.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnInactive.ForeColor = System.Drawing.Color.Gray;
            this.btnInactive.Location = new System.Drawing.Point(180, 9);
            this.btnInactive.Margin = new System.Windows.Forms.Padding(1);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(80, 40);
            this.btnInactive.TabIndex = 12;
            this.btnInactive.Text = "Inactive";
            this.btnInactive.TextColor = System.Drawing.Color.Gray;
            this.btnInactive.UseVisualStyleBackColor = false;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // btnActive
            // 
            this.btnActive.BackColor = System.Drawing.Color.Gainsboro;
            this.btnActive.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnActive.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActive.BorderRadius = 5;
            this.btnActive.BorderSize = 0;
            this.btnActive.FlatAppearance.BorderSize = 0;
            this.btnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActive.Font = new System.Drawing.Font("Poppins", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnActive.ForeColor = System.Drawing.Color.Gray;
            this.btnActive.Location = new System.Drawing.Point(96, 9);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(80, 40);
            this.btnActive.TabIndex = 11;
            this.btnActive.Text = "Active";
            this.btnActive.TextColor = System.Drawing.Color.Gray;
            this.btnActive.UseVisualStyleBackColor = false;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
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
            this.btnAll.TabIndex = 10;
            this.btnAll.Text = "All";
            this.btnAll.TextColor = System.Drawing.Color.White;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.BorderColor = System.Drawing.Color.White;
            this.btnAddPatient.BorderRadius = 10;
            this.btnAddPatient.BorderSize = 0;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPatient.Image")));
            this.btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddPatient.Location = new System.Drawing.Point(972, 5);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Padding = new System.Windows.Forms.Padding(5, 5, 20, 0);
            this.btnAddPatient.Size = new System.Drawing.Size(150, 48);
            this.btnAddPatient.TabIndex = 12;
            this.btnAddPatient.Text = "Add Users";
            this.btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPatient.TextColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.UseVisualStyleBackColor = false;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // UserHolder
            // 
            this.UserHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.UserHolder.BorderRadius = 10;
            this.UserHolder.Color = System.Drawing.Color.White;
            this.UserHolder.ForeColor = System.Drawing.Color.Black;
            this.UserHolder.Location = new System.Drawing.Point(62, 244);
            this.UserHolder.Name = "UserHolder";
            this.UserHolder.Padding = new System.Windows.Forms.Padding(5);
            this.UserHolder.Size = new System.Drawing.Size(1129, 468);
            this.UserHolder.TabIndex = 13;
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
            this.panelBorder1.TabIndex = 11;
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
            this.btnSearch.TabIndex = 15;
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
            this.txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchBar.Location = new System.Drawing.Point(48, 8);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchBar.Multiline = false;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 0);
            this.txtSearchBar.PasswordChar = false;
            this.txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchBar.PlaceholderText = "";
            this.txtSearchBar.Size = new System.Drawing.Size(333, 34);
            this.txtSearchBar.TabIndex = 4;
            this.txtSearchBar.Texts = "";
            this.txtSearchBar.UnderlinedStyle = false;
            this.txtSearchBar._TextChanged += new System.EventHandler(this.txtSearchBar__TextChanged);
            this.txtSearchBar.Enter += new System.EventHandler(this.txtSearchBar_Enter);
            this.txtSearchBar.Leave += new System.EventHandler(this.txtSearchBar_Leave);
            // 
            // lblHiddenForFocus
            // 
            this.lblHiddenForFocus.AutoSize = true;
            this.lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            this.lblHiddenForFocus.Location = new System.Drawing.Point(371, 73);
            this.lblHiddenForFocus.Name = "lblHiddenForFocus";
            this.lblHiddenForFocus.Size = new System.Drawing.Size(120, 13);
            this.lblHiddenForFocus.TabIndex = 16;
            this.lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblHiddenForFocus);
            this.Controls.Add(this.panelBorder2);
            this.Controls.Add(this.dataGridUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameHolder);
            this.Controls.Add(this.UserHolder);
            this.Controls.Add(this.panelBorder1);
            this.Name = "UserPage";
            this.Size = new System.Drawing.Size(1249, 758);
            this.Load += new System.EventHandler(this.UserPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.panelBorder2.ResumeLayout(false);
            this.panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn editHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private OrganizationProfile.CustomButton btnInactive;
        private OrganizationProfile.CustomButton btnActive;
        private OrganizationProfile.CustomButton btnAll;
        private OrganizationProfile.CustomButton btnSearch;
        private CustomControls.RJControls.RJComboBox cbSort;
        private System.Windows.Forms.Label lblHiddenForFocus;
    }
}
