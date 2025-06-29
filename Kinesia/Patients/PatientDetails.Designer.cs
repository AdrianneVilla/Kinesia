﻿namespace Kinesia.Patients
{
    partial class PatientDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientDetails));
            this.lblSelectedPatient = new System.Windows.Forms.Label();
            this.titleNav = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhysicalTherapistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssessmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnArchive = new OrganizationProfile.CustomButton();
            this.btnEditInfo = new OrganizationProfile.CustomButton();
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBack = new OrganizationProfile.CustomButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectedPatient
            // 
            this.lblSelectedPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedPatient.AutoSize = true;
            this.lblSelectedPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedPatient.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.lblSelectedPatient.Location = new System.Drawing.Point(165, 38);
            this.lblSelectedPatient.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelectedPatient.Name = "lblSelectedPatient";
            this.lblSelectedPatient.Size = new System.Drawing.Size(180, 36);
            this.lblSelectedPatient.TabIndex = 8;
            this.lblSelectedPatient.Text = "Selected Patient";
            this.lblSelectedPatient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleNav
            // 
            this.titleNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.titleNav.AutoSize = true;
            this.titleNav.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNav.ForeColor = System.Drawing.Color.DarkGray;
            this.titleNav.Location = new System.Drawing.Point(61, 38);
            this.titleNav.Margin = new System.Windows.Forms.Padding(0);
            this.titleNav.Name = "titleNav";
            this.titleNav.Size = new System.Drawing.Size(114, 36);
            this.titleNav.TabIndex = 7;
            this.titleNav.Text = "Patients >";
            this.titleNav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientName
            // 
            this.lblPatientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Poppins", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.lblPatientName.Location = new System.Drawing.Point(57, 100);
            this.lblPatientName.Margin = new System.Windows.Forms.Padding(0);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(255, 58);
            this.lblPatientName.TabIndex = 10;
            this.lblPatientName.Text = "Patient Name";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblPatientID);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(67, 163);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(442, 26);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.label3.Size = new System.Drawing.Size(85, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Patient ID";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.ForeColor = System.Drawing.Color.Black;
            this.lblPatientID.Location = new System.Drawing.Point(94, 3);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(65, 22);
            this.lblPatientID.TabIndex = 1;
            this.lblPatientID.Text = "<Id here>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(130, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 22);
            this.label12.TabIndex = 1;
            this.label12.Text = "<condition here>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label11.Size = new System.Drawing.Size(121, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Condition";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label11);
            this.flowLayoutPanel5.Controls.Add(this.label12);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(67, 195);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(442, 29);
            this.flowLayoutPanel5.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Poppins", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(78, 416);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 30);
            this.label17.TabIndex = 24;
            this.label17.Text = "Assessments";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssessmentID,
            this.PhysicalTherapistName,
            this.BodyGroup,
            this.AssessmentDate});
            this.dataGridView1.Location = new System.Drawing.Point(67, 450);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1093, 256);
            this.dataGridView1.TabIndex = 25;
            // 
            // AssessmentID
            // 
            this.AssessmentID.HeaderText = "Assessment ID";
            this.AssessmentID.Name = "AssessmentID";
            // 
            // PhysicalTherapistName
            // 
            this.PhysicalTherapistName.HeaderText = "Physical Therapist";
            this.PhysicalTherapistName.Name = "PhysicalTherapistName";
            // 
            // BodyGroup
            // 
            this.BodyGroup.HeaderText = "Body Group";
            this.BodyGroup.Name = "BodyGroup";
            // 
            // AssessmentDate
            // 
            this.AssessmentDate.HeaderText = "Date";
            this.AssessmentDate.Name = "AssessmentDate";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.linkLabel1.Location = new System.Drawing.Point(978, 421);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(184, 22);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View Detailed Assessment >";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.btnArchive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.btnArchive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnArchive.BorderRadius = 10;
            this.btnArchive.BorderSize = 1;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnArchive.Image")));
            this.btnArchive.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnArchive.Location = new System.Drawing.Point(990, 100);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Padding = new System.Windows.Forms.Padding(5, 3, 15, 0);
            this.btnArchive.Size = new System.Drawing.Size(170, 40);
            this.btnArchive.TabIndex = 28;
            this.btnArchive.Text = "Archive Patient";
            this.btnArchive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchive.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnArchive.UseVisualStyleBackColor = false;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.btnEditInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.btnEditInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.btnEditInfo.BorderRadius = 10;
            this.btnEditInfo.BorderSize = 1;
            this.btnEditInfo.FlatAppearance.BorderSize = 0;
            this.btnEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditInfo.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(134)))), ((int)(((byte)(105)))));
            this.btnEditInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnEditInfo.Image")));
            this.btnEditInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEditInfo.Location = new System.Drawing.Point(804, 100);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Padding = new System.Windows.Forms.Padding(5, 3, 15, 0);
            this.btnEditInfo.Size = new System.Drawing.Size(170, 40);
            this.btnEditInfo.TabIndex = 27;
            this.btnEditInfo.Text = "Edit Information";
            this.btnEditInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditInfo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(134)))), ((int)(((byte)(105)))));
            this.btnEditInfo.UseVisualStyleBackColor = false;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BackgroundImage = global::Kinesia.Properties.Resources.general_information_background;
            this.panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBorder1.BorderRadius = 30;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.lblBirthdate);
            this.panelBorder1.Controls.Add(this.lblAddress);
            this.panelBorder1.Controls.Add(this.lblAge);
            this.panelBorder1.Controls.Add(this.lblContact);
            this.panelBorder1.Controls.Add(this.lblGender);
            this.panelBorder1.Controls.Add(this.label9);
            this.panelBorder1.Controls.Add(this.label7);
            this.panelBorder1.Controls.Add(this.label8);
            this.panelBorder1.Controls.Add(this.label6);
            this.panelBorder1.Controls.Add(this.label19);
            this.panelBorder1.Controls.Add(this.label5);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(62, 244);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1098, 146);
            this.panelBorder1.TabIndex = 13;
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.ForeColor = System.Drawing.Color.Black;
            this.lblBirthdate.Location = new System.Drawing.Point(879, 58);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.lblBirthdate.Size = new System.Drawing.Size(159, 22);
            this.lblBirthdate.TabIndex = 23;
            this.lblBirthdate.Text = "<birthday here>";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(508, 96);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.lblAddress.Size = new System.Drawing.Size(155, 22);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "<address here>";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.Color.Black;
            this.lblAge.Location = new System.Drawing.Point(508, 58);
            this.lblAge.Name = "lblAge";
            this.lblAge.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.lblAge.Size = new System.Drawing.Size(128, 22);
            this.lblAge.TabIndex = 21;
            this.lblAge.Text = "<age here>";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.Black;
            this.lblContact.Location = new System.Drawing.Point(150, 96);
            this.lblContact.Name = "lblContact";
            this.lblContact.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.lblContact.Size = new System.Drawing.Size(185, 22);
            this.lblContact.TabIndex = 20;
            this.lblContact.Text = "<contact num here>";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(150, 58);
            this.lblGender.Name = "lblGender";
            this.lblGender.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.lblGender.Size = new System.Drawing.Size(148, 22);
            this.lblGender.TabIndex = 19;
            this.lblGender.Text = "<gender here>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(806, 58);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label9.Size = new System.Drawing.Size(111, 22);
            this.label9.TabIndex = 18;
            this.label9.Text = "Birthday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(420, 96);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(420, 58);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label8.Size = new System.Drawing.Size(85, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Age";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(18, 96);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label6.Size = new System.Drawing.Size(160, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Contact Number";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Poppins", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(16, 8);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(189, 30);
            this.label19.TabIndex = 14;
            this.label19.Text = "General Information";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(18, 58);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 52, 0);
            this.label5.Size = new System.Drawing.Size(105, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "Gender";
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
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBack.Location = new System.Drawing.Point(1041, 39);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(0, 3, 30, 0);
            this.btnBack.Size = new System.Drawing.Size(124, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panelBorder1);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblSelectedPatient);
            this.Controls.Add(this.titleNav);
            this.Name = "PatientDetails";
            this.Size = new System.Drawing.Size(1249, 737);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectedPatient;
        private System.Windows.Forms.Label titleNav;
        private OrganizationProfile.CustomButton btnBack;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPatientID;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhysicalTherapistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssessmentDate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private OrganizationProfile.CustomButton btnEditInfo;
        private OrganizationProfile.CustomButton btnArchive;
    }
}
