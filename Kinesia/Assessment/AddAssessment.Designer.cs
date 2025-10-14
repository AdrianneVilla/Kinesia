namespace Kinesia.Assessment
{
    partial class AddAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAssessment));
            label1 = new System.Windows.Forms.Label();
            lblSelectedUser = new System.Windows.Forms.Label();
            titleNav = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnAddPatient = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            customButton2 = new OrganizationProfile.CustomButton();
            rjComboBox1 = new CustomControls.RJControls.RJComboBox();
            customButton1 = new OrganizationProfile.CustomButton();
            selectedPatientDetails = new WindowsFormsApp2.CustomButton.PanelBorder();
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
            label7 = new System.Windows.Forms.Label();
            txtFirstName = new CustomControls.RJControls.RJTextBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            dpBirthDate = new CustomControls.RJControls.RJDatePicker();
            txtAddress = new CustomControls.RJControls.RJTextBox();
            label9 = new System.Windows.Forms.Label();
            txtContact = new CustomControls.RJControls.RJTextBox();
            label8 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            panelBorder1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            selectedPatientDetails.SuspendLayout();
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
            label1.Size = new System.Drawing.Size(228, 23);
            label1.TabIndex = 19;
            label1.Text = "Select patient to add assessment";
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSelectedUser.AutoSize = true;
            lblSelectedUser.BackColor = System.Drawing.Color.Transparent;
            lblSelectedUser.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            lblSelectedUser.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblSelectedUser.Location = new System.Drawing.Point(240, 35);
            lblSelectedUser.Margin = new System.Windows.Forms.Padding(0);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new System.Drawing.Size(254, 48);
            lblSelectedUser.TabIndex = 32;
            lblSelectedUser.Text = "Add Assessment";
            lblSelectedUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleNav
            // 
            titleNav.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            titleNav.AutoSize = true;
            titleNav.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleNav.ForeColor = System.Drawing.Color.DarkGray;
            titleNav.Location = new System.Drawing.Point(71, 44);
            titleNav.Margin = new System.Windows.Forms.Padding(0);
            titleNav.Name = "titleNav";
            titleNav.Size = new System.Drawing.Size(155, 36);
            titleNav.TabIndex = 31;
            titleNav.Text = "Assessment >";
            titleNav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(219, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 49);
            label2.TabIndex = 1;
            label2.Text = "Select patient";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.Gray;
            label3.Location = new System.Drawing.Point(22, 87);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(628, 49);
            label3.TabIndex = 2;
            label3.Text = "Search and select a patient to begin assessment";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddPatient.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddPatient.BorderColor = System.Drawing.Color.White;
            btnAddPatient.BorderRadius = 10;
            btnAddPatient.BorderSize = 0;
            btnAddPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddPatient.FlatAppearance.BorderSize = 0;
            btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddPatient.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnAddPatient.ForeColor = System.Drawing.Color.White;
            btnAddPatient.Image = Properties.Resources.newWhiteSelect;
            btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddPatient.Location = new System.Drawing.Point(221, 160);
            btnAddPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Padding = new System.Windows.Forms.Padding(10, 3, 30, 0);
            btnAddPatient.Size = new System.Drawing.Size(199, 51);
            btnAddPatient.TabIndex = 9;
            btnAddPatient.Text = "Select Patient";
            btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnAddPatient.TextColor = System.Drawing.Color.White;
            btnAddPatient.UseVisualStyleBackColor = false;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 30;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(btnAddPatient);
            panelBorder1.Controls.Add(label3);
            panelBorder1.Controls.Add(label2);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(429, 129);
            panelBorder1.Margin = new System.Windows.Forms.Padding(70);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(661, 242);
            panelBorder1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(customButton1);
            flowLayoutPanel1.Controls.Add(customButton2);
            flowLayoutPanel1.Controls.Add(rjComboBox1);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(89, 132);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1291, 58);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // customButton2
            // 
            customButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            customButton2.BackgroundColor = System.Drawing.Color.FromArgb(64, 64, 64);
            customButton2.BorderColor = System.Drawing.Color.White;
            customButton2.BorderRadius = 10;
            customButton2.BorderSize = 0;
            customButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton2.ForeColor = System.Drawing.Color.White;
            customButton2.Image = Properties.Resources.newReselect;
            customButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButton2.Location = new System.Drawing.Point(878, 3);
            customButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton2.Name = "customButton2";
            customButton2.Padding = new System.Windows.Forms.Padding(10, 3, 30, 0);
            customButton2.Size = new System.Drawing.Size(199, 51);
            customButton2.TabIndex = 11;
            customButton2.Text = "Change Patient";
            customButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            customButton2.TextColor = System.Drawing.Color.White;
            customButton2.UseVisualStyleBackColor = false;
            // 
            // rjComboBox1
            // 
            rjComboBox1.BackColor = System.Drawing.Color.White;
            rjComboBox1.BorderColor = System.Drawing.Color.Black;
            rjComboBox1.BorderSize = 1;
            rjComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            rjComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            rjComboBox1.ForeColor = System.Drawing.Color.DimGray;
            rjComboBox1.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            rjComboBox1.ListBackColor = System.Drawing.Color.White;
            rjComboBox1.ListTextColor = System.Drawing.Color.Black;
            rjComboBox1.Location = new System.Drawing.Point(564, 3);
            rjComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            rjComboBox1.Size = new System.Drawing.Size(307, 51);
            rjComboBox1.TabIndex = 12;
            rjComboBox1.Texts = "";
            // 
            // customButton1
            // 
            customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButton1.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            customButton1.BackgroundColor = System.Drawing.Color.FromArgb(200, 220, 255);
            customButton1.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.BorderRadius = 10;
            customButton1.BorderSize = 1;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.Image = (System.Drawing.Image)resources.GetObject("customButton1.Image");
            customButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButton1.Location = new System.Drawing.Point(1085, 3);
            customButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton1.Name = "customButton1";
            customButton1.Padding = new System.Windows.Forms.Padding(12, 5, 23, 0);
            customButton1.Size = new System.Drawing.Size(202, 51);
            customButton1.TabIndex = 13;
            customButton1.Text = "Save Assessment";
            customButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            customButton1.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton1.UseVisualStyleBackColor = false;
            // 
            // selectedPatientDetails
            // 
            selectedPatientDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            selectedPatientDetails.BackColor = System.Drawing.Color.White;
            selectedPatientDetails.BackgroundImage = Properties.Resources.Add_Patient_Background;
            selectedPatientDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            selectedPatientDetails.BorderRadius = 30;
            selectedPatientDetails.Color = System.Drawing.Color.BurlyWood;
            selectedPatientDetails.Controls.Add(panelBorder1);
            selectedPatientDetails.Controls.Add(pictureBox1);
            selectedPatientDetails.Controls.Add(cbGender);
            selectedPatientDetails.Controls.Add(label13);
            selectedPatientDetails.Controls.Add(txtOccupation);
            selectedPatientDetails.Controls.Add(label4);
            selectedPatientDetails.Controls.Add(label5);
            selectedPatientDetails.Controls.Add(txtAge);
            selectedPatientDetails.Controls.Add(label6);
            selectedPatientDetails.Controls.Add(txtMiddleName);
            selectedPatientDetails.Controls.Add(label10);
            selectedPatientDetails.Controls.Add(txtLastName);
            selectedPatientDetails.Controls.Add(label7);
            selectedPatientDetails.Controls.Add(txtFirstName);
            selectedPatientDetails.Controls.Add(label11);
            selectedPatientDetails.Controls.Add(label12);
            selectedPatientDetails.Controls.Add(dpBirthDate);
            selectedPatientDetails.Controls.Add(txtAddress);
            selectedPatientDetails.Controls.Add(label9);
            selectedPatientDetails.Controls.Add(txtContact);
            selectedPatientDetails.Controls.Add(label8);
            selectedPatientDetails.Controls.Add(label14);
            selectedPatientDetails.ForeColor = System.Drawing.Color.Black;
            selectedPatientDetails.Location = new System.Drawing.Point(76, 239);
            selectedPatientDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            selectedPatientDetails.Name = "selectedPatientDetails";
            selectedPatientDetails.Size = new System.Drawing.Size(1631, 540);
            selectedPatientDetails.TabIndex = 35;
            selectedPatientDetails.Visible = false;
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
            txtOccupation.Size = new System.Drawing.Size(210, 43);
            txtOccupation.TabIndex = 7;
            txtOccupation.Texts = "";
            txtOccupation.UnderlinedStyle = false;
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
            txtMiddleName.Size = new System.Drawing.Size(427, 43);
            txtMiddleName.TabIndex = 3;
            txtMiddleName.Texts = "";
            txtMiddleName.UnderlinedStyle = false;
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
            txtLastName.Size = new System.Drawing.Size(427, 43);
            txtLastName.TabIndex = 2;
            txtLastName.Texts = "";
            txtLastName.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(518, 103);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(81, 23);
            label7.TabIndex = 23;
            label7.Text = "Last Name";
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
            txtFirstName.Size = new System.Drawing.Size(427, 43);
            txtFirstName.TabIndex = 1;
            txtFirstName.Texts = "";
            txtFirstName.UnderlinedStyle = false;
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
            txtContact.Size = new System.Drawing.Size(209, 43);
            txtContact.TabIndex = 6;
            txtContact.Texts = "";
            txtContact.UnderlinedStyle = false;
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
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label14.Location = new System.Drawing.Point(55, 216);
            label14.Margin = new System.Windows.Forms.Padding(4, 35, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(74, 23);
            label14.TabIndex = 8;
            label14.Text = "Birthdate";
            // 
            // AddAssessment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(selectedPatientDetails);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblSelectedUser);
            Controls.Add(titleNav);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddAssessment";
            Size = new System.Drawing.Size(1827, 875);
            panelBorder1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            selectedPatientDetails.ResumeLayout(false);
            selectedPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label titleNav;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton btnAddPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private OrganizationProfile.CustomButton customButton2;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
        private OrganizationProfile.CustomButton customButton1;
        private WindowsFormsApp2.CustomButton.PanelBorder selectedPatientDetails;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJComboBox cbGender;
        private System.Windows.Forms.Label label13;
        private CustomControls.RJControls.RJTextBox txtOccupation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtAge;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJTextBox txtMiddleName;
        private System.Windows.Forms.Label label10;
        private CustomControls.RJControls.RJTextBox txtLastName;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox txtFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CustomControls.RJControls.RJDatePicker dpBirthDate;
        private CustomControls.RJControls.RJTextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJTextBox txtContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
    }
}
