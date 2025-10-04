namespace Kinesia.Users
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            label1 = new Label();
            nameHolder = new Label();
            txtTitleLabel = new Label();
            btnBack = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            txtEmail = new CustomControls.RJControls.RJTextBox();
            label16 = new Label();
            label15 = new Label();
            cbRole = new CustomControls.RJControls.RJComboBox();
            cbGender = new CustomControls.RJControls.RJComboBox();
            label14 = new Label();
            txtPassword = new CustomControls.RJControls.RJTextBox();
            label13 = new Label();
            txtUsername = new CustomControls.RJControls.RJTextBox();
            label12 = new Label();
            label11 = new Label();
            txtMiddleName = new CustomControls.RJControls.RJTextBox();
            label10 = new Label();
            txtLastName = new CustomControls.RJControls.RJTextBox();
            label2 = new Label();
            dpBirthDate = new CustomControls.RJControls.RJDatePicker();
            txtAddress = new CustomControls.RJControls.RJTextBox();
            label9 = new Label();
            txtContact = new CustomControls.RJControls.RJTextBox();
            label8 = new Label();
            label7 = new Label();
            txtAge = new CustomControls.RJControls.RJTextBox();
            label6 = new Label();
            label5 = new Label();
            txtFirstName = new CustomControls.RJControls.RJTextBox();
            label4 = new Label();
            label3 = new Label();
            btnClearInput = new OrganizationProfile.CustomButton();
            btnAddUser = new OrganizationProfile.CustomButton();
            panelBorder1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(76, 83);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(268, 23);
            label1.TabIndex = 12;
            label1.Text = "users personal information and account";
            // 
            // nameHolder
            // 
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            nameHolder.AutoSize = true;
            nameHolder.Font = new Font("Poppins", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameHolder.ForeColor = Color.DarkGray;
            nameHolder.Location = new Point(71, 44);
            nameHolder.Margin = new Padding(0);
            nameHolder.Name = "nameHolder";
            nameHolder.Size = new Size(87, 36);
            nameHolder.TabIndex = 11;
            nameHolder.Text = "Users >";
            nameHolder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTitleLabel
            // 
            txtTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtTitleLabel.AutoSize = true;
            txtTitleLabel.BackColor = Color.Transparent;
            txtTitleLabel.Font = new Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitleLabel.ForeColor = Color.FromArgb(18, 90, 211);
            txtTitleLabel.Location = new Point(164, 35);
            txtTitleLabel.Margin = new Padding(0);
            txtTitleLabel.Name = "txtTitleLabel";
            txtTitleLabel.Size = new Size(145, 48);
            txtTitleLabel.TabIndex = 13;
            txtTitleLabel.Text = "Add User";
            txtTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.White;
            btnBack.BackgroundColor = Color.White;
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.BorderColor = Color.PaleVioletRed;
            btnBack.BorderRadius = 10;
            btnBack.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(18, 90, 211);
            btnBack.Image = Properties.Resources.back_button_icon;
            btnBack.ImageAlign = ContentAlignment.TopLeft;
            btnBack.Location = new Point(1520, 45);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Padding = new Padding(0, 3, 35, 0);
            btnBack.Size = new Size(145, 46);
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.TextAlign = ContentAlignment.MiddleRight;
            btnBack.TextColor = Color.FromArgb(18, 90, 211);
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBorder1.BackColor = Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelBorder1.BackgroundImageLayout = ImageLayout.Stretch;
            panelBorder1.BorderRadius = 30;
            panelBorder1.Color = Color.BurlyWood;
            panelBorder1.Controls.Add(txtEmail);
            panelBorder1.Controls.Add(label16);
            panelBorder1.Controls.Add(label15);
            panelBorder1.Controls.Add(cbRole);
            panelBorder1.Controls.Add(cbGender);
            panelBorder1.Controls.Add(label14);
            panelBorder1.Controls.Add(txtPassword);
            panelBorder1.Controls.Add(label13);
            panelBorder1.Controls.Add(txtUsername);
            panelBorder1.Controls.Add(label12);
            panelBorder1.Controls.Add(label11);
            panelBorder1.Controls.Add(txtMiddleName);
            panelBorder1.Controls.Add(label10);
            panelBorder1.Controls.Add(txtLastName);
            panelBorder1.Controls.Add(label2);
            panelBorder1.Controls.Add(dpBirthDate);
            panelBorder1.Controls.Add(txtAddress);
            panelBorder1.Controls.Add(label9);
            panelBorder1.Controls.Add(txtContact);
            panelBorder1.Controls.Add(label8);
            panelBorder1.Controls.Add(label7);
            panelBorder1.Controls.Add(txtAge);
            panelBorder1.Controls.Add(label6);
            panelBorder1.Controls.Add(label5);
            panelBorder1.Controls.Add(txtFirstName);
            panelBorder1.Controls.Add(label4);
            panelBorder1.Controls.Add(label3);
            panelBorder1.ForeColor = Color.Black;
            panelBorder1.Location = new Point(78, 132);
            panelBorder1.Margin = new Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new Size(1658, 856);
            panelBorder1.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Window;
            txtEmail.BorderColor = Color.DimGray;
            txtEmail.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtEmail.BorderRadius = 5;
            txtEmail.BorderSize = 1;
            txtEmail.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(56, 351);
            txtEmail.Margin = new Padding(5, 5, 5, 5);
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(12, 8, 12, 8);
            txtEmail.PasswordChar = false;
            txtEmail.PlaceholderColor = Color.DarkGray;
            txtEmail.PlaceholderText = "";
            txtEmail.Size = new Size(427, 43);
            txtEmail.TabIndex = 7;
            txtEmail.Texts = "";
            txtEmail.UnderlinedStyle = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(55, 324);
            label16.Margin = new Padding(4, 35, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(107, 23);
            label16.TabIndex = 38;
            label16.Text = "Email Address";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(825, 697);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(38, 23);
            label15.TabIndex = 36;
            label15.Text = "Role";
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.White;
            cbRole.BorderColor = Color.Black;
            cbRole.BorderSize = 1;
            cbRole.DropDownStyle = ComboBoxStyle.DropDown;
            cbRole.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbRole.ForeColor = Color.Black;
            cbRole.IconColor = Color.Black;
            cbRole.Items.AddRange(new object[] { "Admin", "Therapist" });
            cbRole.ListBackColor = Color.White;
            cbRole.ListTextColor = Color.Black;
            cbRole.Location = new Point(826, 725);
            cbRole.Margin = new Padding(4, 3, 4, 3);
            cbRole.MinimumSize = new Size(233, 35);
            cbRole.Name = "cbRole";
            cbRole.Padding = new Padding(1);
            cbRole.Size = new Size(266, 45);
            cbRole.TabIndex = 11;
            cbRole.Texts = "";
            // 
            // cbGender
            // 
            cbGender.BackColor = Color.White;
            cbGender.BorderColor = Color.Black;
            cbGender.BorderSize = 1;
            cbGender.DropDownStyle = ComboBoxStyle.DropDown;
            cbGender.Font = new Font("Microsoft Sans Serif", 10F);
            cbGender.ForeColor = Color.DimGray;
            cbGender.IconColor = Color.Black;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.ListBackColor = Color.FromArgb(230, 228, 245);
            cbGender.ListTextColor = Color.Black;
            cbGender.Location = new Point(693, 242);
            cbGender.Margin = new Padding(35, 3, 4, 3);
            cbGender.MinimumSize = new Size(233, 35);
            cbGender.Name = "cbGender";
            cbGender.Padding = new Padding(1);
            cbGender.Size = new Size(233, 47);
            cbGender.TabIndex = 5;
            cbGender.Texts = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(946, 255);
            label14.Margin = new Padding(35, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(34, 23);
            label14.TabIndex = 33;
            label14.Text = "+63";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.BorderColor = Color.DimGray;
            txtPassword.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtPassword.BorderRadius = 5;
            txtPassword.BorderSize = 1;
            txtPassword.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(440, 722);
            txtPassword.Margin = new Padding(5, 5, 5, 5);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(12, 8, 12, 8);
            txtPassword.PasswordChar = false;
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(343, 43);
            txtPassword.TabIndex = 10;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(435, 696);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(75, 23);
            label13.TabIndex = 23;
            label13.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.Window;
            txtUsername.BorderColor = Color.DimGray;
            txtUsername.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtUsername.BorderRadius = 5;
            txtUsername.BorderSize = 1;
            txtUsername.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(61, 722);
            txtUsername.Margin = new Padding(5, 5, 5, 5);
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(12, 8, 12, 8);
            txtUsername.PasswordChar = false;
            txtUsername.PlaceholderColor = Color.DarkGray;
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(340, 43);
            txtUsername.TabIndex = 9;
            txtUsername.Texts = "";
            txtUsername.UnderlinedStyle = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(56, 696);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(80, 23);
            label12.TabIndex = 21;
            label12.Text = "Username";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(18, 90, 211);
            label11.Location = new Point(54, 633);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(159, 34);
            label11.TabIndex = 19;
            label11.Text = "Setup Account";
            // 
            // txtMiddleName
            // 
            txtMiddleName.BackColor = SystemColors.Window;
            txtMiddleName.BorderColor = Color.DimGray;
            txtMiddleName.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtMiddleName.BorderRadius = 5;
            txtMiddleName.BorderSize = 1;
            txtMiddleName.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMiddleName.ForeColor = Color.Black;
            txtMiddleName.Location = new Point(989, 129);
            txtMiddleName.Margin = new Padding(35, 5, 5, 5);
            txtMiddleName.Multiline = false;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Padding = new Padding(12, 8, 12, 8);
            txtMiddleName.PasswordChar = false;
            txtMiddleName.PlaceholderColor = Color.DarkGray;
            txtMiddleName.PlaceholderText = "";
            txtMiddleName.Size = new Size(427, 43);
            txtMiddleName.TabIndex = 3;
            txtMiddleName.Texts = "";
            txtMiddleName.UnderlinedStyle = false;
            txtMiddleName.KeyPress += txtMiddleName_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(985, 103);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(173, 23);
            label10.TabIndex = 18;
            label10.Text = "Middle Name (Optional)";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = SystemColors.Window;
            txtLastName.BorderColor = Color.DimGray;
            txtLastName.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtLastName.BorderRadius = 5;
            txtLastName.BorderSize = 1;
            txtLastName.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.ForeColor = Color.Black;
            txtLastName.Location = new Point(523, 129);
            txtLastName.Margin = new Padding(35, 5, 5, 5);
            txtLastName.Multiline = false;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new Padding(12, 8, 12, 8);
            txtLastName.PasswordChar = false;
            txtLastName.PlaceholderColor = Color.DarkGray;
            txtLastName.PlaceholderText = "";
            txtLastName.Size = new Size(427, 43);
            txtLastName.TabIndex = 2;
            txtLastName.Texts = "";
            txtLastName.UnderlinedStyle = false;
            txtLastName.KeyPress += txtLastName_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(518, 103);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 16;
            label2.Text = "Last Name";
            // 
            // dpBirthDate
            // 
            dpBirthDate.BorderColor = Color.DimGray;
            dpBirthDate.BorderSize = 1;
            dpBirthDate.CalendarFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dpBirthDate.DropDownAlign = LeftRightAlignment.Right;
            dpBirthDate.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dpBirthDate.Location = new Point(59, 246);
            dpBirthDate.Margin = new Padding(4, 3, 4, 3);
            dpBirthDate.MinimumSize = new Size(4, 35);
            dpBirthDate.Name = "dpBirthDate";
            dpBirthDate.Size = new Size(443, 35);
            dpBirthDate.SkinColor = Color.White;
            dpBirthDate.TabIndex = 4;
            dpBirthDate.TextColor = Color.Black;
            dpBirthDate.ValueChanged += dpBirthDate_ValueChanged;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = SystemColors.Window;
            txtAddress.BorderColor = Color.DimGray;
            txtAddress.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtAddress.BorderRadius = 5;
            txtAddress.BorderSize = 1;
            txtAddress.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.ForeColor = Color.Black;
            txtAddress.Location = new Point(56, 464);
            txtAddress.Margin = new Padding(5, 5, 5, 5);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new Padding(12, 8, 12, 8);
            txtAddress.PasswordChar = false;
            txtAddress.PlaceholderColor = Color.DarkGray;
            txtAddress.PlaceholderText = "";
            txtAddress.Size = new Size(1357, 119);
            txtAddress.TabIndex = 8;
            txtAddress.Texts = "";
            txtAddress.UnderlinedStyle = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(51, 437);
            label9.Margin = new Padding(4, 35, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(66, 23);
            label9.TabIndex = 12;
            label9.Text = "Address";
            // 
            // txtContact
            // 
            txtContact.BackColor = SystemColors.Window;
            txtContact.BorderColor = Color.DimGray;
            txtContact.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtContact.BorderRadius = 5;
            txtContact.BorderSize = 1;
            txtContact.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.ForeColor = Color.Black;
            txtContact.Location = new Point(989, 242);
            txtContact.Margin = new Padding(35, 5, 5, 5);
            txtContact.Multiline = false;
            txtContact.Name = "txtContact";
            txtContact.Padding = new Padding(12, 8, 12, 8);
            txtContact.PasswordChar = false;
            txtContact.PlaceholderColor = Color.DarkGray;
            txtContact.PlaceholderText = "";
            txtContact.Size = new Size(427, 43);
            txtContact.TabIndex = 6;
            txtContact.Texts = "";
            txtContact.UnderlinedStyle = false;
            txtContact.KeyPress += txtContact_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(985, 213);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(123, 23);
            label8.TabIndex = 10;
            label8.Text = "Contact Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(55, 216);
            label7.Margin = new Padding(4, 35, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(74, 23);
            label7.TabIndex = 8;
            label7.Text = "Birthdate";
            // 
            // txtAge
            // 
            txtAge.BackColor = SystemColors.Window;
            txtAge.BorderColor = Color.DimGray;
            txtAge.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtAge.BorderRadius = 5;
            txtAge.BorderSize = 1;
            txtAge.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.ForeColor = Color.Black;
            txtAge.Location = new Point(541, 242);
            txtAge.Margin = new Padding(35, 5, 5, 5);
            txtAge.Multiline = false;
            txtAge.Name = "txtAge";
            txtAge.Padding = new Padding(12, 8, 12, 8);
            txtAge.PasswordChar = false;
            txtAge.PlaceholderColor = Color.DarkGray;
            txtAge.PlaceholderText = "";
            txtAge.Size = new Size(112, 43);
            txtAge.TabIndex = 5;
            txtAge.Texts = "";
            txtAge.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(537, 213);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(37, 23);
            label6.TabIndex = 6;
            label6.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(688, 213);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 4;
            label5.Text = "Gender";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = SystemColors.Window;
            txtFirstName.BorderColor = Color.DimGray;
            txtFirstName.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtFirstName.BorderRadius = 5;
            txtFirstName.BorderSize = 1;
            txtFirstName.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Location = new Point(56, 129);
            txtFirstName.Margin = new Padding(5, 5, 5, 5);
            txtFirstName.Multiline = false;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Padding = new Padding(12, 8, 12, 8);
            txtFirstName.PasswordChar = false;
            txtFirstName.PlaceholderColor = Color.DarkGray;
            txtFirstName.PlaceholderText = "";
            txtFirstName.Size = new Size(427, 43);
            txtFirstName.TabIndex = 1;
            txtFirstName.Texts = "";
            txtFirstName.UnderlinedStyle = false;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(51, 103);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 23);
            label4.TabIndex = 2;
            label4.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(18, 90, 211);
            label3.Location = new Point(47, 28);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(224, 34);
            label3.TabIndex = 0;
            label3.Text = "Personal Information";
            // 
            // btnClearInput
            // 
            btnClearInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearInput.BackColor = Color.FromArgb(255, 216, 216);
            btnClearInput.BackgroundColor = Color.FromArgb(255, 216, 216);
            btnClearInput.BorderColor = Color.FromArgb(210, 64, 66);
            btnClearInput.BorderRadius = 10;
            btnClearInput.BorderSize = 1;
            btnClearInput.FlatAppearance.BorderSize = 0;
            btnClearInput.FlatStyle = FlatStyle.Flat;
            btnClearInput.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearInput.ForeColor = Color.FromArgb(210, 64, 66);
            btnClearInput.Image = (Image)resources.GetObject("btnClearInput.Image");
            btnClearInput.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearInput.Location = new Point(1416, 1064);
            btnClearInput.Margin = new Padding(4, 3, 4, 3);
            btnClearInput.Name = "btnClearInput";
            btnClearInput.Padding = new Padding(12, 5, 47, 0);
            btnClearInput.Size = new Size(202, 58);
            btnClearInput.TabIndex = 17;
            btnClearInput.Text = "Clear";
            btnClearInput.TextAlign = ContentAlignment.MiddleRight;
            btnClearInput.TextColor = Color.FromArgb(210, 64, 66);
            btnClearInput.UseVisualStyleBackColor = false;
            btnClearInput.Click += btnClearInput_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddUser.BackColor = Color.FromArgb(200, 220, 255);
            btnAddUser.BackgroundColor = Color.FromArgb(200, 220, 255);
            btnAddUser.BorderColor = Color.FromArgb(18, 90, 211);
            btnAddUser.BorderRadius = 10;
            btnAddUser.BorderSize = 1;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.FromArgb(18, 90, 211);
            btnAddUser.Image = (Image)resources.GetObject("btnAddUser.Image");
            btnAddUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddUser.Location = new Point(1208, 1064);
            btnAddUser.Margin = new Padding(4, 3, 4, 3);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Padding = new Padding(12, 5, 35, 0);
            btnAddUser.Size = new Size(202, 58);
            btnAddUser.TabIndex = 16;
            btnAddUser.Text = "Add User";
            btnAddUser.TextAlign = ContentAlignment.MiddleRight;
            btnAddUser.TextColor = Color.FromArgb(18, 90, 211);
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Controls.Add(btnBack);
            Controls.Add(panelBorder1);
            Controls.Add(btnClearInput);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Controls.Add(btnAddUser);
            Controls.Add(txtTitleLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddUser";
            Size = new Size(1511, 991);
            Load += AddUser_Load;
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private OrganizationProfile.CustomButton btnBack;
        private CustomControls.RJControls.RJDatePicker dpBirthDate;
        private CustomControls.RJControls.RJTextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private CustomControls.RJControls.RJTextBox txtContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox txtAge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private OrganizationProfile.CustomButton btnClearInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private OrganizationProfile.CustomButton btnAddUser;
        private System.Windows.Forms.Label txtTitleLabel;
        private CustomControls.RJControls.RJTextBox txtMiddleName;
        private System.Windows.Forms.Label label10;
        private CustomControls.RJControls.RJTextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private CustomControls.RJControls.RJTextBox txtPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private CustomControls.RJControls.RJComboBox cbGender;
        private System.Windows.Forms.Label label15;
        private CustomControls.RJControls.RJComboBox cbRole;
        private CustomControls.RJControls.RJTextBox txtEmail;
        private System.Windows.Forms.Label label16;
    }
}
