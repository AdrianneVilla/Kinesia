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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatient));
            this.label1 = new System.Windows.Forms.Label();
            this.nameHolder = new System.Windows.Forms.Label();
            this.txtTitleLabel = new System.Windows.Forms.Label();
            this.btnClearInput = new OrganizationProfile.CustomButton();
            this.btnAddPatient = new OrganizationProfile.CustomButton();
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.txtUserGender = new CustomControls.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserAge = new CustomControls.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserMiddleName = new CustomControls.RJControls.RJTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserLastName = new CustomControls.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserFirstName = new CustomControls.RJControls.RJTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rjDatePicker1 = new CustomControls.RJControls.RJDatePicker();
            this.rjTextBox6 = new CustomControls.RJControls.RJTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rjTextBox5 = new CustomControls.RJControls.RJTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBack = new OrganizationProfile.CustomButton();
            this.panelBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "add patients personal information";
            // 
            // nameHolder
            // 
            this.nameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameHolder.AutoSize = true;
            this.nameHolder.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHolder.ForeColor = System.Drawing.Color.DarkGray;
            this.nameHolder.Location = new System.Drawing.Point(61, 38);
            this.nameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.nameHolder.Name = "nameHolder";
            this.nameHolder.Size = new System.Drawing.Size(114, 36);
            this.nameHolder.TabIndex = 4;
            this.nameHolder.Text = "Patients >";
            this.nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitleLabel
            // 
            this.txtTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTitleLabel.AutoSize = true;
            this.txtTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.txtTitleLabel.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtTitleLabel.Location = new System.Drawing.Point(167, 30);
            this.txtTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.txtTitleLabel.Name = "txtTitleLabel";
            this.txtTitleLabel.Size = new System.Drawing.Size(182, 48);
            this.txtTitleLabel.TabIndex = 6;
            this.txtTitleLabel.Text = "Add Patient";
            this.txtTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearInput
            // 
            this.btnClearInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.btnClearInput.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.btnClearInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnClearInput.BorderRadius = 10;
            this.btnClearInput.BorderSize = 1;
            this.btnClearInput.FlatAppearance.BorderSize = 0;
            this.btnClearInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearInput.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnClearInput.Image = ((System.Drawing.Image)(resources.GetObject("btnClearInput.Image")));
            this.btnClearInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearInput.Location = new System.Drawing.Point(1290, 773);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Padding = new System.Windows.Forms.Padding(10, 4, 40, 0);
            this.btnClearInput.Size = new System.Drawing.Size(173, 50);
            this.btnClearInput.TabIndex = 10;
            this.btnClearInput.Text = "Clear";
            this.btnClearInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearInput.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnClearInput.UseVisualStyleBackColor = false;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnAddPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.BorderRadius = 10;
            this.btnAddPatient.BorderSize = 1;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPatient.Image")));
            this.btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPatient.Location = new System.Drawing.Point(1111, 773);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Padding = new System.Windows.Forms.Padding(10, 4, 20, 0);
            this.btnAddPatient.Size = new System.Drawing.Size(173, 50);
            this.btnAddPatient.TabIndex = 9;
            this.btnAddPatient.Text = "Add Patient";
            this.btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPatient.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.UseVisualStyleBackColor = false;
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BackgroundImage = global::Kinesia.Properties.Resources.Add_Patient_Background;
            this.panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBorder1.BorderRadius = 30;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.txtUserGender);
            this.panelBorder1.Controls.Add(this.label5);
            this.panelBorder1.Controls.Add(this.txtUserAge);
            this.panelBorder1.Controls.Add(this.label6);
            this.panelBorder1.Controls.Add(this.txtUserMiddleName);
            this.panelBorder1.Controls.Add(this.label10);
            this.panelBorder1.Controls.Add(this.txtUserLastName);
            this.panelBorder1.Controls.Add(this.label2);
            this.panelBorder1.Controls.Add(this.txtUserFirstName);
            this.panelBorder1.Controls.Add(this.label11);
            this.panelBorder1.Controls.Add(this.label12);
            this.panelBorder1.Controls.Add(this.rjDatePicker1);
            this.panelBorder1.Controls.Add(this.rjTextBox6);
            this.panelBorder1.Controls.Add(this.label9);
            this.panelBorder1.Controls.Add(this.rjTextBox5);
            this.panelBorder1.Controls.Add(this.label8);
            this.panelBorder1.Controls.Add(this.label7);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(67, 114);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1398, 468);
            this.panelBorder1.TabIndex = 8;
            // 
            // txtUserGender
            // 
            this.txtUserGender.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserGender.BorderColor = System.Drawing.Color.DimGray;
            this.txtUserGender.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtUserGender.BorderRadius = 5;
            this.txtUserGender.BorderSize = 1;
            this.txtUserGender.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserGender.ForeColor = System.Drawing.Color.Black;
            this.txtUserGender.Location = new System.Drawing.Point(594, 210);
            this.txtUserGender.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.txtUserGender.Multiline = false;
            this.txtUserGender.Name = "txtUserGender";
            this.txtUserGender.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserGender.PasswordChar = false;
            this.txtUserGender.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserGender.PlaceholderText = "";
            this.txtUserGender.Size = new System.Drawing.Size(156, 41);
            this.txtUserGender.TabIndex = 28;
            this.txtUserGender.Texts = "";
            this.txtUserGender.UnderlinedStyle = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(590, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Gender";
            // 
            // txtUserAge
            // 
            this.txtUserAge.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserAge.BorderColor = System.Drawing.Color.DimGray;
            this.txtUserAge.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtUserAge.BorderRadius = 5;
            this.txtUserAge.BorderSize = 1;
            this.txtUserAge.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserAge.ForeColor = System.Drawing.Color.Black;
            this.txtUserAge.Location = new System.Drawing.Point(464, 210);
            this.txtUserAge.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.txtUserAge.Multiline = false;
            this.txtUserAge.Name = "txtUserAge";
            this.txtUserAge.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserAge.PasswordChar = false;
            this.txtUserAge.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserAge.PlaceholderText = "";
            this.txtUserAge.Size = new System.Drawing.Size(96, 41);
            this.txtUserAge.TabIndex = 26;
            this.txtUserAge.Texts = "";
            this.txtUserAge.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "Age";
            // 
            // txtUserMiddleName
            // 
            this.txtUserMiddleName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserMiddleName.BorderColor = System.Drawing.Color.DimGray;
            this.txtUserMiddleName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtUserMiddleName.BorderRadius = 5;
            this.txtUserMiddleName.BorderSize = 1;
            this.txtUserMiddleName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserMiddleName.ForeColor = System.Drawing.Color.Black;
            this.txtUserMiddleName.Location = new System.Drawing.Point(704, 112);
            this.txtUserMiddleName.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.txtUserMiddleName.Multiline = false;
            this.txtUserMiddleName.Name = "txtUserMiddleName";
            this.txtUserMiddleName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserMiddleName.PasswordChar = false;
            this.txtUserMiddleName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserMiddleName.PlaceholderText = "";
            this.txtUserMiddleName.Size = new System.Drawing.Size(294, 41);
            this.txtUserMiddleName.TabIndex = 24;
            this.txtUserMiddleName.Texts = "";
            this.txtUserMiddleName.UnderlinedStyle = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(700, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 25;
            this.label10.Text = "Middle Name";
            // 
            // txtUserLastName
            // 
            this.txtUserLastName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserLastName.BorderColor = System.Drawing.Color.DimGray;
            this.txtUserLastName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtUserLastName.BorderRadius = 5;
            this.txtUserLastName.BorderSize = 1;
            this.txtUserLastName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLastName.ForeColor = System.Drawing.Color.Black;
            this.txtUserLastName.Location = new System.Drawing.Point(376, 112);
            this.txtUserLastName.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.txtUserLastName.Multiline = false;
            this.txtUserLastName.Name = "txtUserLastName";
            this.txtUserLastName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserLastName.PasswordChar = false;
            this.txtUserLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserLastName.PlaceholderText = "";
            this.txtUserLastName.Size = new System.Drawing.Size(294, 41);
            this.txtUserLastName.TabIndex = 22;
            this.txtUserLastName.Texts = "";
            this.txtUserLastName.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last Name";
            // 
            // txtUserFirstName
            // 
            this.txtUserFirstName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserFirstName.BorderColor = System.Drawing.Color.DimGray;
            this.txtUserFirstName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtUserFirstName.BorderRadius = 5;
            this.txtUserFirstName.BorderSize = 1;
            this.txtUserFirstName.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtUserFirstName.Location = new System.Drawing.Point(48, 112);
            this.txtUserFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserFirstName.Multiline = false;
            this.txtUserFirstName.Name = "txtUserFirstName";
            this.txtUserFirstName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserFirstName.PasswordChar = false;
            this.txtUserFirstName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserFirstName.PlaceholderText = "";
            this.txtUserFirstName.Size = new System.Drawing.Size(294, 41);
            this.txtUserFirstName.TabIndex = 20;
            this.txtUserFirstName.Texts = "";
            this.txtUserFirstName.UnderlinedStyle = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(44, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "First Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(40, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(224, 34);
            this.label12.TabIndex = 19;
            this.label12.Text = "Personal Information";
            // 
            // rjDatePicker1
            // 
            this.rjDatePicker1.BorderColor = System.Drawing.Color.DimGray;
            this.rjDatePicker1.BorderSize = 1;
            this.rjDatePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.rjDatePicker1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjDatePicker1.Location = new System.Drawing.Point(51, 213);
            this.rjDatePicker1.MinimumSize = new System.Drawing.Size(4, 35);
            this.rjDatePicker1.Name = "rjDatePicker1";
            this.rjDatePicker1.Size = new System.Drawing.Size(380, 35);
            this.rjDatePicker1.SkinColor = System.Drawing.Color.White;
            this.rjDatePicker1.TabIndex = 14;
            this.rjDatePicker1.TextColor = System.Drawing.Color.Black;
            this.rjDatePicker1.ValueChanged += new System.EventHandler(this.rjDatePicker1_ValueChanged);
            // 
            // rjTextBox6
            // 
            this.rjTextBox6.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox6.BorderColor = System.Drawing.Color.DimGray;
            this.rjTextBox6.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.rjTextBox6.BorderRadius = 5;
            this.rjTextBox6.BorderSize = 1;
            this.rjTextBox6.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox6.ForeColor = System.Drawing.Color.Black;
            this.rjTextBox6.Location = new System.Drawing.Point(51, 306);
            this.rjTextBox6.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox6.Multiline = true;
            this.rjTextBox6.Name = "rjTextBox6";
            this.rjTextBox6.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox6.PasswordChar = false;
            this.rjTextBox6.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox6.PlaceholderText = "";
            this.rjTextBox6.Size = new System.Drawing.Size(947, 103);
            this.rjTextBox6.TabIndex = 11;
            this.rjTextBox6.Texts = "";
            this.rjTextBox6.UnderlinedStyle = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Address";
            // 
            // rjTextBox5
            // 
            this.rjTextBox5.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox5.BorderColor = System.Drawing.Color.DimGray;
            this.rjTextBox5.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.rjTextBox5.BorderRadius = 5;
            this.rjTextBox5.BorderSize = 1;
            this.rjTextBox5.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox5.ForeColor = System.Drawing.Color.Black;
            this.rjTextBox5.Location = new System.Drawing.Point(784, 210);
            this.rjTextBox5.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.rjTextBox5.Multiline = false;
            this.rjTextBox5.Name = "rjTextBox5";
            this.rjTextBox5.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox5.PasswordChar = false;
            this.rjTextBox5.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox5.PlaceholderText = "";
            this.rjTextBox5.Size = new System.Drawing.Size(214, 41);
            this.rjTextBox5.TabIndex = 9;
            this.rjTextBox5.Texts = "";
            this.rjTextBox5.UnderlinedStyle = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(780, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Contact Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Birthdate";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.BackgroundColor = System.Drawing.Color.White;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBack.BorderRadius = 10;
            this.btnBack.BorderSize = 0;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnBack.Image = global::Kinesia.Properties.Resources.back_button_icon;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBack.Location = new System.Drawing.Point(1303, 39);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(0, 3, 30, 0);
            this.btnBack.Size = new System.Drawing.Size(124, 40);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClearInput);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBorder1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTitleLabel);
            this.Controls.Add(this.nameHolder);
            this.Name = "AddPatient";
            this.Size = new System.Drawing.Size(1511, 843);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private System.Windows.Forms.Label txtTitleLabel;
        private OrganizationProfile.CustomButton btnBack;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox rjTextBox6;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJTextBox rjTextBox5;
        private System.Windows.Forms.Label label8;
        private OrganizationProfile.CustomButton btnAddPatient;
        private OrganizationProfile.CustomButton btnClearInput;
        private CustomControls.RJControls.RJDatePicker rjDatePicker1;
        private CustomControls.RJControls.RJTextBox txtUserMiddleName;
        private System.Windows.Forms.Label label10;
        private CustomControls.RJControls.RJTextBox txtUserLastName;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtUserFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CustomControls.RJControls.RJTextBox txtUserAge;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJTextBox txtUserGender;
        private System.Windows.Forms.Label label5;
    }
}
