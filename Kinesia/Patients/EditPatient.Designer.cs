namespace Kinesia.Patients
{
    partial class EditPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPatient));
            txtTitleLabel = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            lblPatientID = new System.Windows.Forms.Label();
            btnBack = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            label11 = new System.Windows.Forms.Label();
            txtFirstName = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            txtLastName = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            label10 = new System.Windows.Forms.Label();
            txtMiddleName = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            dpBirthDate = new CustomControls.RJControls.RJDatePicker();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            txtAge = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            cbGender = new CustomControls.RJControls.RJComboBox();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            label8 = new System.Windows.Forms.Label();
            txtContact = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            txtOccupation = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            label9 = new System.Windows.Forms.Label();
            txtAddress = new CustomControls.RJControls.RJTextBox();
            flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            btnSaveChanges = new OrganizationProfile.CustomButton();
            label12 = new System.Windows.Forms.Label();
            toolTipAge = new System.Windows.Forms.ToolTip(components);
            panelBorder1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel12.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel13.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            SuspendLayout();
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
            txtTitleLabel.Size = new System.Drawing.Size(72, 48);
            txtTitleLabel.TabIndex = 13;
            txtTitleLabel.Text = "Edit";
            txtTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            nameHolder.TabIndex = 11;
            nameHolder.Text = "Patients >";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientID
            // 
            lblPatientID.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPatientID.AutoSize = true;
            lblPatientID.BackColor = System.Drawing.Color.Transparent;
            lblPatientID.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblPatientID.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblPatientID.Location = new System.Drawing.Point(268, 33);
            lblPatientID.Margin = new System.Windows.Forms.Padding(0);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new System.Drawing.Size(184, 48);
            lblPatientID.TabIndex = 17;
            lblPatientID.Text = "<Patient ID>";
            lblPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnBack.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 30;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(flowLayoutPanel1);
            panelBorder1.Controls.Add(label12);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(78, 132);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new System.Drawing.Size(1631, 518);
            panelBorder1.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel11);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel12);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel13);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel10);
            flowLayoutPanel1.Location = new System.Drawing.Point(43, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1568, 430);
            flowLayoutPanel1.TabIndex = 37;
            // 
            // flowLayoutPanel11
            // 
            flowLayoutPanel11.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel11.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel11.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            flowLayoutPanel11.Size = new System.Drawing.Size(1333, 102);
            flowLayoutPanel11.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label11);
            flowLayoutPanel2.Controls.Add(txtFirstName);
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(438, 89);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(4, 0);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(83, 23);
            label11.TabIndex = 21;
            label11.Text = "First Name";
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
            txtFirstName.Location = new System.Drawing.Point(5, 28);
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
            txtFirstName.TabIndex = 20;
            txtFirstName.Texts = "";
            txtFirstName.UnderlinedStyle = false;
            txtFirstName._TextChanged += txtFirstName__TextChanged;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(txtLastName);
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel3.Location = new System.Drawing.Point(447, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(332, 89);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(4, 0);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 23);
            label2.TabIndex = 23;
            label2.Text = "Last Name";
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
            txtLastName.Location = new System.Drawing.Point(5, 28);
            txtLastName.Margin = new System.Windows.Forms.Padding(5);
            txtLastName.Multiline = false;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtLastName.PasswordChar = false;
            txtLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtLastName.PlaceholderText = "";
            txtLastName.SelectionLength = 0;
            txtLastName.SelectionStart = 0;
            txtLastName.Size = new System.Drawing.Size(319, 43);
            txtLastName.TabIndex = 22;
            txtLastName.Texts = "";
            txtLastName.UnderlinedStyle = false;
            txtLastName._TextChanged += txtLastName__TextChanged;
            txtLastName.KeyPress += txtLastName_KeyPress;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label10);
            flowLayoutPanel4.Controls.Add(txtMiddleName);
            flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel4.Location = new System.Drawing.Point(785, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(328, 89);
            flowLayoutPanel4.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(4, 0);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(173, 23);
            label10.TabIndex = 25;
            label10.Text = "Middle Name (Optional)";
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
            txtMiddleName.Location = new System.Drawing.Point(5, 28);
            txtMiddleName.Margin = new System.Windows.Forms.Padding(5);
            txtMiddleName.Multiline = false;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtMiddleName.PasswordChar = false;
            txtMiddleName.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtMiddleName.PlaceholderText = "";
            txtMiddleName.SelectionLength = 0;
            txtMiddleName.SelectionStart = 0;
            txtMiddleName.Size = new System.Drawing.Size(296, 43);
            txtMiddleName.TabIndex = 24;
            txtMiddleName.Texts = "";
            txtMiddleName.UnderlinedStyle = false;
            txtMiddleName._TextChanged += txtMiddleName__TextChanged;
            txtMiddleName.KeyPress += txtMiddleName_KeyPress;
            // 
            // flowLayoutPanel12
            // 
            flowLayoutPanel12.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel12.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel12.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel12.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel12.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel12.Location = new System.Drawing.Point(3, 111);
            flowLayoutPanel12.Name = "flowLayoutPanel12";
            flowLayoutPanel12.Size = new System.Drawing.Size(1565, 108);
            flowLayoutPanel12.TabIndex = 10;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label7);
            flowLayoutPanel5.Controls.Add(dpBirthDate);
            flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new System.Drawing.Size(339, 89);
            flowLayoutPanel5.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(4, 0);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 23);
            label7.TabIndex = 8;
            label7.Text = "Birthdate";
            // 
            // dpBirthDate
            // 
            dpBirthDate.BorderColor = System.Drawing.Color.DimGray;
            dpBirthDate.BorderSize = 1;
            dpBirthDate.CalendarFont = new System.Drawing.Font("Poppins", 10.75F);
            dpBirthDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            dpBirthDate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dpBirthDate.Location = new System.Drawing.Point(4, 33);
            dpBirthDate.Margin = new System.Windows.Forms.Padding(4, 10, 4, 3);
            dpBirthDate.MinimumSize = new System.Drawing.Size(4, 35);
            dpBirthDate.Name = "dpBirthDate";
            dpBirthDate.Size = new System.Drawing.Size(324, 35);
            dpBirthDate.SkinColor = System.Drawing.Color.White;
            dpBirthDate.TabIndex = 14;
            dpBirthDate.TextColor = System.Drawing.Color.Black;
            dpBirthDate.ValueChanged += dpBirthDate_ValueChanged;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(label6);
            flowLayoutPanel6.Controls.Add(txtAge);
            flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel6.Location = new System.Drawing.Point(348, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new System.Drawing.Size(128, 89);
            flowLayoutPanel6.TabIndex = 4;
            // 
            // label6
            // 
            label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label6.Image = Properties.Resources.helpIcon;
            label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label6.Location = new System.Drawing.Point(4, 0);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(61, 23);
            label6.TabIndex = 27;
            label6.Text = "Age";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolTipAge.SetToolTip(label6, "Age is automatically computated when birthdate value changed");
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
            txtAge.Location = new System.Drawing.Point(5, 28);
            txtAge.Margin = new System.Windows.Forms.Padding(5);
            txtAge.Multiline = false;
            txtAge.Name = "txtAge";
            txtAge.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtAge.PasswordChar = false;
            txtAge.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtAge.PlaceholderText = "";
            txtAge.SelectionLength = 0;
            txtAge.SelectionStart = 0;
            txtAge.Size = new System.Drawing.Size(117, 43);
            txtAge.TabIndex = 26;
            txtAge.Texts = "";
            txtAge.UnderlinedStyle = false;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(label5);
            flowLayoutPanel7.Controls.Add(cbGender);
            flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel7.Location = new System.Drawing.Point(482, 3);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new System.Drawing.Size(311, 89);
            flowLayoutPanel7.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(4, 0);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 23);
            label5.TabIndex = 29;
            label5.Text = "Gender";
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
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.ListBackColor = System.Drawing.Color.FromArgb(230, 228, 245);
            cbGender.ListTextColor = System.Drawing.Color.DimGray;
            cbGender.Location = new System.Drawing.Point(4, 26);
            cbGender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGender.MinimumSize = new System.Drawing.Size(233, 35);
            cbGender.Name = "cbGender";
            cbGender.Padding = new System.Windows.Forms.Padding(1);
            cbGender.Size = new System.Drawing.Size(297, 43);
            cbGender.TabIndex = 33;
            cbGender.Texts = "";
            cbGender.OnSelectedIndexChanged += cbGender_OnSelectedIndexChanged;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(label8);
            flowLayoutPanel8.Controls.Add(txtContact);
            flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel8.Location = new System.Drawing.Point(799, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new System.Drawing.Size(261, 89);
            flowLayoutPanel8.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(4, 0);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(123, 23);
            label8.TabIndex = 10;
            label8.Text = "Contact Number";
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
            txtContact.Location = new System.Drawing.Point(5, 28);
            txtContact.Margin = new System.Windows.Forms.Padding(5);
            txtContact.Multiline = false;
            txtContact.Name = "txtContact";
            txtContact.Padding = new System.Windows.Forms.Padding(10, 8, 2, 8);
            txtContact.PasswordChar = false;
            txtContact.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtContact.PlaceholderText = "";
            txtContact.SelectionLength = 0;
            txtContact.SelectionStart = 0;
            txtContact.Size = new System.Drawing.Size(247, 43);
            txtContact.TabIndex = 9;
            txtContact.Texts = "+63";
            txtContact.UnderlinedStyle = false;
            txtContact._TextChanged += txtContact__TextChanged;
            txtContact.KeyPress += txtContact_KeyPress;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(label4);
            flowLayoutPanel9.Controls.Add(txtOccupation);
            flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel9.Location = new System.Drawing.Point(1066, 3);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new System.Drawing.Size(267, 89);
            flowLayoutPanel9.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(4, 0);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 23);
            label4.TabIndex = 31;
            label4.Text = "Occupation";
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
            txtOccupation.Location = new System.Drawing.Point(5, 28);
            txtOccupation.Margin = new System.Windows.Forms.Padding(5);
            txtOccupation.Multiline = false;
            txtOccupation.Name = "txtOccupation";
            txtOccupation.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtOccupation.PasswordChar = false;
            txtOccupation.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtOccupation.PlaceholderText = "";
            txtOccupation.SelectionLength = 0;
            txtOccupation.SelectionStart = 0;
            txtOccupation.Size = new System.Drawing.Size(252, 43);
            txtOccupation.TabIndex = 30;
            txtOccupation.Texts = "";
            txtOccupation.UnderlinedStyle = false;
            txtOccupation._TextChanged += txtOccupation__TextChanged;
            txtOccupation.KeyPress += txtOccupation_KeyPress;
            // 
            // flowLayoutPanel13
            // 
            flowLayoutPanel13.Controls.Add(label9);
            flowLayoutPanel13.Controls.Add(txtAddress);
            flowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel13.Location = new System.Drawing.Point(3, 225);
            flowLayoutPanel13.Name = "flowLayoutPanel13";
            flowLayoutPanel13.Size = new System.Drawing.Size(1333, 121);
            flowLayoutPanel13.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(4, 10);
            label9.Margin = new System.Windows.Forms.Padding(4, 10, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(66, 23);
            label9.TabIndex = 12;
            label9.Text = "Address";
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
            txtAddress.Location = new System.Drawing.Point(5, 38);
            txtAddress.Margin = new System.Windows.Forms.Padding(5);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            txtAddress.PasswordChar = false;
            txtAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtAddress.PlaceholderText = "";
            txtAddress.SelectionLength = 0;
            txtAddress.SelectionStart = 0;
            txtAddress.Size = new System.Drawing.Size(1318, 73);
            txtAddress.TabIndex = 11;
            txtAddress.Texts = "";
            txtAddress.UnderlinedStyle = false;
            txtAddress._TextChanged += txtAddress__TextChanged;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel10.Controls.Add(btnSaveChanges);
            flowLayoutPanel10.Location = new System.Drawing.Point(3, 352);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new System.Drawing.Size(231, 91);
            flowLayoutPanel10.TabIndex = 17;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnSaveChanges.BackgroundColor = System.Drawing.Color.FromArgb(200, 220, 255);
            btnSaveChanges.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveChanges.BorderRadius = 10;
            btnSaveChanges.BorderSize = 1;
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveChanges.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSaveChanges.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveChanges.Image = (System.Drawing.Image)resources.GetObject("btnSaveChanges.Image");
            btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSaveChanges.Location = new System.Drawing.Point(4, 3);
            btnSaveChanges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Padding = new System.Windows.Forms.Padding(12, 5, 23, 0);
            btnSaveChanges.Size = new System.Drawing.Size(202, 58);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSaveChanges.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Visible = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(43, 30);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(224, 34);
            label12.TabIndex = 19;
            label12.Text = "Personal Information";
            // 
            // EditPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(lblPatientID);
            Controls.Add(btnBack);
            Controls.Add(panelBorder1);
            Controls.Add(txtTitleLabel);
            Controls.Add(nameHolder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EditPatient";
            Size = new System.Drawing.Size(1763, 973);
            Load += EditPatient_Load;
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel12.ResumeLayout(false);
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel13.ResumeLayout(false);
            flowLayoutPanel13.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private OrganizationProfile.CustomButton btnBack;
        private CustomControls.RJControls.RJComboBox cbGender;
        private CustomControls.RJControls.RJTextBox txtOccupation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtAge;
        private System.Windows.Forms.Label label6;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private CustomControls.RJControls.RJTextBox txtMiddleName;
        private System.Windows.Forms.Label label10;
        private CustomControls.RJControls.RJTextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CustomControls.RJControls.RJDatePicker dpBirthDate;
        private CustomControls.RJControls.RJTextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJTextBox txtContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtTitleLabel;
        private System.Windows.Forms.Label nameHolder;
        private OrganizationProfile.CustomButton btnSaveChanges;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.ToolTip toolTipAge;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
    }
}
