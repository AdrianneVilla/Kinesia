namespace Kinesia.Patients
{
    partial class AddPatient
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatient));
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            txtTitleLabel = new System.Windows.Forms.Label();
            btnClearInput = new OrganizationProfile.CustomButton();
            btnAddPatient = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            cbGender = new CustomControls.RJControls.RJComboBox();
            label13 = new System.Windows.Forms.Label();
            txtOccupation = new CustomControls.RJControls.RJTextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtAge = new CustomControls.RJControls.RJTextBox();
            label6 = new System.Windows.Forms.Label();
            txtMiddleName = new CustomControls.RJControls.RJTextBox();
            label10 = new System.Windows.Forms.Label();
            txtLastName = new CustomControls.RJControls.RJTextBox();
            label2 = new System.Windows.Forms.Label();
            txtFirstName = new CustomControls.RJControls.RJTextBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            dpBirthDate = new CustomControls.RJControls.RJDatePicker();
            txtAddress = new CustomControls.RJControls.RJTextBox();
            label9 = new System.Windows.Forms.Label();
            txtContact = new CustomControls.RJControls.RJTextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            btnBack = new OrganizationProfile.CustomButton();
            toolTipAge = new System.Windows.Forms.ToolTip(components);
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
            label1.Size = new System.Drawing.Size(233, 23);
            label1.TabIndex = 5;
            label1.Text = "Add patient's personal information";
            // 
            // nameHolder
            // 
            nameHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            nameHolder.AutoSize = true;
            nameHolder.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            nameHolder.ForeColor = System.Drawing.Color.DarkGray;
            nameHolder.Location = new System.Drawing.Point(71, 44);
            nameHolder.Margin = new System.Windows.Forms.Padding(0);
            nameHolder.Name = "nameHolder";
            nameHolder.Size = new System.Drawing.Size(114, 36);
            nameHolder.TabIndex = 4;
            nameHolder.Text = "Patients >";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitleLabel
            // 
            txtTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtTitleLabel.AutoSize = true;
            txtTitleLabel.BackColor = System.Drawing.Color.Transparent;
            txtTitleLabel.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtTitleLabel.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtTitleLabel.Location = new System.Drawing.Point(195, 35);
            txtTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            txtTitleLabel.Name = "txtTitleLabel";
            txtTitleLabel.Size = new System.Drawing.Size(182, 48);
            txtTitleLabel.TabIndex = 6;
            txtTitleLabel.Text = "Add Patient";
            txtTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearInput
            // 
            btnClearInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClearInput.BackColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnClearInput.BackgroundColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnClearInput.BorderColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnClearInput.BorderRadius = 10;
            btnClearInput.BorderSize = 1;
            btnClearInput.FlatAppearance.BorderSize = 0;
            btnClearInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearInput.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnClearInput.ForeColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnClearInput.Image = (System.Drawing.Image)resources.GetObject("btnClearInput.Image");
            btnClearInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnClearInput.Location = new System.Drawing.Point(1505, 892);
            btnClearInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClearInput.Name = "btnClearInput";
            btnClearInput.Padding = new System.Windows.Forms.Padding(12, 5, 47, 0);
            btnClearInput.Size = new System.Drawing.Size(202, 58);
            btnClearInput.TabIndex = 10;
            btnClearInput.Text = "Clear";
            btnClearInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnClearInput.TextColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnClearInput.UseVisualStyleBackColor = false;
            btnClearInput.Click += btnClearInput_Click;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddPatient.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnAddPatient.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.BorderRadius = 10;
            btnAddPatient.BorderSize = 1;
            btnAddPatient.FlatAppearance.BorderSize = 0;
            btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnAddPatient.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.Image = (System.Drawing.Image)resources.GetObject("btnAddPatient.Image");
            btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddPatient.Location = new System.Drawing.Point(1296, 892);
            btnAddPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Padding = new System.Windows.Forms.Padding(12, 5, 23, 0);
            btnAddPatient.Size = new System.Drawing.Size(202, 58);
            btnAddPatient.TabIndex = 9;
            btnAddPatient.Text = "Add Patient";
            btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnAddPatient.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 30;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(cbGender);
            panelBorder1.Controls.Add(label13);
            panelBorder1.Controls.Add(txtOccupation);
            panelBorder1.Controls.Add(label4);
            panelBorder1.Controls.Add(label5);
            panelBorder1.Controls.Add(txtAge);
            panelBorder1.Controls.Add(label6);
            panelBorder1.Controls.Add(txtMiddleName);
            panelBorder1.Controls.Add(label10);
            panelBorder1.Controls.Add(txtLastName);
            panelBorder1.Controls.Add(label2);
            panelBorder1.Controls.Add(txtFirstName);
            panelBorder1.Controls.Add(label11);
            panelBorder1.Controls.Add(label12);
            panelBorder1.Controls.Add(dpBirthDate);
            panelBorder1.Controls.Add(txtAddress);
            panelBorder1.Controls.Add(label9);
            panelBorder1.Controls.Add(txtContact);
            panelBorder1.Controls.Add(label8);
            panelBorder1.Controls.Add(label7);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(78, 132);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(1631, 540);
            panelBorder1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(576, 213);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(23, 23);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            toolTipAge.SetToolTip(pictureBox1, "Age is automatically computated when birthdate value changed");
            // 
            // cbGender
            // 
            cbGender.BackColor = System.Drawing.Color.White;
            cbGender.BorderColor = System.Drawing.Color.Black;
            cbGender.BorderSize = 1;
            cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbGender.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbGender.ForeColor = System.Drawing.Color.Black;
            cbGender.IconColor = System.Drawing.Color.Black;
            cbGender.Items.AddRange(new object[] { "Male", "Female", "Prefer not to say" });
            cbGender.ListBackColor = System.Drawing.Color.FromArgb(230, 228, 245);
            cbGender.ListTextColor = System.Drawing.Color.DimGray;
            cbGender.Location = new System.Drawing.Point(693, 242);
            cbGender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGender.MinimumSize = new System.Drawing.Size(233, 35);
            cbGender.Name = "cbGender";
            cbGender.Padding = new System.Windows.Forms.Padding(1);
            cbGender.Size = new System.Drawing.Size(233, 47);
            cbGender.TabIndex = 5;
            cbGender.Texts = "";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label13.ForeColor = System.Drawing.Color.Gray;
            label13.Location = new System.Drawing.Point(980, 254);
            label13.Margin = new System.Windows.Forms.Padding(35, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(34, 23);
            label13.TabIndex = 32;
            label13.Text = "+63";
            label13.Click += label13_Click;
            // 
            // txtOccupation
            // 
            txtOccupation.BackColor = System.Drawing.SystemColors.Window;
            txtOccupation.BorderColor = System.Drawing.Color.DimGray;
            txtOccupation.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtOccupation.BorderRadius = 5;
            txtOccupation.BorderSize = 1;
            txtOccupation.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtOccupation.ForeColor = System.Drawing.Color.Black;
            txtOccupation.Location = new System.Drawing.Point(1206, 242);
            txtOccupation.Margin = new System.Windows.Forms.Padding(35, 5, 5, 5);
            txtOccupation.Multiline = false;
            txtOccupation.Name = "txtOccupation";
            txtOccupation.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtOccupation.PasswordChar = false;
            txtOccupation.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtOccupation.PlaceholderText = "";
            txtOccupation.SelectionLength = 0;
            txtOccupation.SelectionStart = 0;
            txtOccupation.Size = new System.Drawing.Size(210, 43);
            txtOccupation.TabIndex = 7;
            txtOccupation.Texts = "";
            txtOccupation.UnderlinedStyle = false;
            txtOccupation.KeyPress += txtOccupation_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(1202, 213);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 23);
            label4.TabIndex = 31;
            label4.Text = "Occupation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(688, 215);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 23);
            label5.TabIndex = 29;
            label5.Text = "Gender";
            // 
            // txtAge
            // 
            txtAge.BackColor = System.Drawing.SystemColors.Window;
            txtAge.BorderColor = System.Drawing.Color.DimGray;
            txtAge.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtAge.BorderRadius = 5;
            txtAge.BorderSize = 1;
            txtAge.Enabled = false;
            txtAge.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAge.ForeColor = System.Drawing.Color.Black;
            txtAge.Location = new System.Drawing.Point(541, 242);
            txtAge.Margin = new System.Windows.Forms.Padding(35, 5, 5, 5);
            txtAge.Multiline = false;
            txtAge.Name = "txtAge";
            txtAge.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtAge.PasswordChar = false;
            txtAge.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtAge.PlaceholderText = "";
            txtAge.SelectionLength = 0;
            txtAge.SelectionStart = 0;
            txtAge.Size = new System.Drawing.Size(112, 43);
            txtAge.TabIndex = 26;
            txtAge.Texts = "";
            txtAge.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(537, 213);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 23);
            label6.TabIndex = 27;
            label6.Text = "Age";
            // 
            // txtMiddleName
            // 
            txtMiddleName.BackColor = System.Drawing.SystemColors.Window;
            txtMiddleName.BorderColor = System.Drawing.Color.DimGray;
            txtMiddleName.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtMiddleName.BorderRadius = 5;
            txtMiddleName.BorderSize = 1;
            txtMiddleName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMiddleName.ForeColor = System.Drawing.Color.Black;
            txtMiddleName.Location = new System.Drawing.Point(989, 129);
            txtMiddleName.Margin = new System.Windows.Forms.Padding(35, 5, 5, 5);
            txtMiddleName.Multiline = false;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtMiddleName.PasswordChar = false;
            txtMiddleName.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtMiddleName.PlaceholderText = "";
            txtMiddleName.SelectionLength = 0;
            txtMiddleName.SelectionStart = 0;
            txtMiddleName.Size = new System.Drawing.Size(427, 43);
            txtMiddleName.TabIndex = 3;
            txtMiddleName.Texts = "";
            txtMiddleName.UnderlinedStyle = false;
            txtMiddleName.KeyPress += txtMiddleName_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(985, 103);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(173, 23);
            label10.TabIndex = 25;
            label10.Text = "Middle Name (Optional)";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = System.Drawing.SystemColors.Window;
            txtLastName.BorderColor = System.Drawing.Color.DimGray;
            txtLastName.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtLastName.BorderRadius = 5;
            txtLastName.BorderSize = 1;
            txtLastName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtLastName.ForeColor = System.Drawing.Color.Black;
            txtLastName.Location = new System.Drawing.Point(523, 129);
            txtLastName.Margin = new System.Windows.Forms.Padding(35, 5, 5, 5);
            txtLastName.Multiline = false;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtLastName.PasswordChar = false;
            txtLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtLastName.PlaceholderText = "";
            txtLastName.SelectionLength = 0;
            txtLastName.SelectionStart = 0;
            txtLastName.Size = new System.Drawing.Size(427, 43);
            txtLastName.TabIndex = 2;
            txtLastName.Texts = "";
            txtLastName.UnderlinedStyle = false;
            txtLastName.KeyPress += txtLastName_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(518, 103);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 23);
            label2.TabIndex = 23;
            label2.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = System.Drawing.SystemColors.Window;
            txtFirstName.BorderColor = System.Drawing.Color.DimGray;
            txtFirstName.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtFirstName.BorderRadius = 5;
            txtFirstName.BorderSize = 1;
            txtFirstName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFirstName.ForeColor = System.Drawing.Color.Black;
            txtFirstName.Location = new System.Drawing.Point(56, 129);
            txtFirstName.Margin = new System.Windows.Forms.Padding(5);
            txtFirstName.Multiline = false;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtFirstName.PasswordChar = false;
            txtFirstName.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtFirstName.PlaceholderText = "";
            txtFirstName.SelectionLength = 0;
            txtFirstName.SelectionStart = 0;
            txtFirstName.Size = new System.Drawing.Size(427, 43);
            txtFirstName.TabIndex = 1;
            txtFirstName.Texts = "";
            txtFirstName.UnderlinedStyle = false;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(51, 103);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(86, 23);
            label11.TabIndex = 21;
            label11.Text = "First Name ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(47, 28);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(224, 34);
            label12.TabIndex = 19;
            label12.Text = "Personal Information";
            // 
            // dpBirthDate
            // 
            dpBirthDate.BorderColor = System.Drawing.Color.DimGray;
            dpBirthDate.BorderSize = 1;
            dpBirthDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dpBirthDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            dpBirthDate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dpBirthDate.Location = new System.Drawing.Point(59, 246);
            dpBirthDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dpBirthDate.MinimumSize = new System.Drawing.Size(4, 35);
            dpBirthDate.Name = "dpBirthDate";
            dpBirthDate.Size = new System.Drawing.Size(443, 35);
            dpBirthDate.SkinColor = System.Drawing.Color.White;
            dpBirthDate.TabIndex = 4;
            dpBirthDate.TextColor = System.Drawing.Color.Black;
            dpBirthDate.ValueChanged += dpBirthDate_ValueChanged;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = System.Drawing.SystemColors.Window;
            txtAddress.BorderColor = System.Drawing.Color.DimGray;
            txtAddress.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtAddress.BorderRadius = 5;
            txtAddress.BorderSize = 1;
            txtAddress.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAddress.ForeColor = System.Drawing.Color.Black;
            txtAddress.Location = new System.Drawing.Point(59, 353);
            txtAddress.Margin = new System.Windows.Forms.Padding(5);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtAddress.PasswordChar = false;
            txtAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtAddress.PlaceholderText = "";
            txtAddress.SelectionLength = 0;
            txtAddress.SelectionStart = 0;
            txtAddress.Size = new System.Drawing.Size(1357, 119);
            txtAddress.TabIndex = 8;
            txtAddress.Texts = "";
            txtAddress.UnderlinedStyle = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(55, 324);
            label9.Margin = new System.Windows.Forms.Padding(4, 35, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(66, 23);
            label9.TabIndex = 12;
            label9.Text = "Address";
            // 
            // txtContact
            // 
            txtContact.BackColor = System.Drawing.SystemColors.Window;
            txtContact.BorderColor = System.Drawing.Color.DimGray;
            txtContact.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtContact.BorderRadius = 5;
            txtContact.BorderSize = 1;
            txtContact.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtContact.ForeColor = System.Drawing.Color.Black;
            txtContact.Location = new System.Drawing.Point(971, 242);
            txtContact.Margin = new System.Windows.Forms.Padding(35, 5, 5, 5);
            txtContact.Multiline = false;
            txtContact.Name = "txtContact";
            txtContact.Padding = new System.Windows.Forms.Padding(45, 8, 12, 8);
            txtContact.PasswordChar = false;
            txtContact.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtContact.PlaceholderText = "";
            txtContact.SelectionLength = 0;
            txtContact.SelectionStart = 0;
            txtContact.Size = new System.Drawing.Size(209, 43);
            txtContact.TabIndex = 6;
            txtContact.Texts = "";
            txtContact.UnderlinedStyle = false;
            txtContact.KeyPress += txtContact_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(966, 213);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(123, 23);
            label8.TabIndex = 10;
            label8.Text = "Contact Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(55, 216);
            label7.Margin = new System.Windows.Forms.Padding(4, 35, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 23);
            label7.TabIndex = 8;
            label7.Text = "Birthdate";
            // 
            // btnBack
            // 
            btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnBack.BackColor = System.Drawing.Color.White;
            btnBack.BackgroundColor = System.Drawing.Color.White;
            btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnBack.BorderRadius = 10;
            btnBack.BorderSize = 0;
            btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnBack.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.Image = Properties.Resources.back_button_icon;
            btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnBack.Location = new System.Drawing.Point(1520, 45);
            btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Padding = new System.Windows.Forms.Padding(0, 3, 35, 0);
            btnBack.Size = new System.Drawing.Size(145, 46);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnBack.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += backBtn_Click;
            // 
            // AddPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            Controls.Add(btnClearInput);
            Controls.Add(btnAddPatient);
            Controls.Add(label1);
            Controls.Add(panelBorder1);
            Controls.Add(btnBack);
            Controls.Add(txtTitleLabel);
            Controls.Add(nameHolder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddPatient";
            Size = new System.Drawing.Size(1763, 973);
            Load += AddPatient_Load;
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private System.Windows.Forms.Label txtTitleLabel;
        private OrganizationProfile.CustomButton btnBack;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJTextBox txtContact;
        private System.Windows.Forms.Label label8;
        private OrganizationProfile.CustomButton btnAddPatient;
        private OrganizationProfile.CustomButton btnClearInput;
        private CustomControls.RJControls.RJDatePicker dpBirthDate;
        private CustomControls.RJControls.RJTextBox txtMiddleName;
        private System.Windows.Forms.Label label10;
        private CustomControls.RJControls.RJTextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CustomControls.RJControls.RJTextBox txtAge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtOccupation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private CustomControls.RJControls.RJComboBox cbGender;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTipAge;
    }
}
