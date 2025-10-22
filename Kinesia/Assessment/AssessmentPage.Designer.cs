namespace Kinesia.Assessment
{
    partial class AssessmentPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssessmentPage));
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            PatientHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            dataGridAssessments = new System.Windows.Forms.DataGridView();
            btnAddAssessment = new OrganizationProfile.CustomButton();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnLowerExtremities = new OrganizationProfile.CustomButton();
            btnUpperExtremities = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            customButton1 = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            cbSort = new CustomControls.RJControls.RJComboBox();
            panelBorder3 = new WindowsFormsApp2.CustomButton.PanelBorder();
            rjComboBox1 = new CustomControls.RJControls.RJComboBox();
            customButton2 = new OrganizationProfile.CustomButton();
            customButton3 = new OrganizationProfile.CustomButton();
            customButton4 = new OrganizationProfile.CustomButton();
            customButton5 = new OrganizationProfile.CustomButton();
            customButton6 = new OrganizationProfile.CustomButton();
            PatientHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAssessments).BeginInit();
            panelBorder2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelBorder3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(76, 83);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(248, 23);
            label1.TabIndex = 5;
            label1.Text = "Select patient to see the assessment";
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
            nameHolder.Size = new System.Drawing.Size(192, 48);
            nameHolder.TabIndex = 4;
            nameHolder.Text = "Assessment";
            nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatientHolder
            // 
            PatientHolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PatientHolder.BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            PatientHolder.BorderRadius = 10;
            PatientHolder.Color = System.Drawing.Color.White;
            PatientHolder.Controls.Add(panelBorder3);
            PatientHolder.Controls.Add(dataGridAssessments);
            PatientHolder.ForeColor = System.Drawing.Color.Black;
            PatientHolder.Location = new System.Drawing.Point(72, 236);
            PatientHolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PatientHolder.Name = "PatientHolder";
            PatientHolder.Padding = new System.Windows.Forms.Padding(6);
            PatientHolder.Size = new System.Drawing.Size(1317, 586);
            PatientHolder.TabIndex = 10;
            // 
            // dataGridAssessments
            // 
            dataGridAssessments.AllowUserToAddRows = false;
            dataGridAssessments.AllowUserToDeleteRows = false;
            dataGridAssessments.AllowUserToResizeColumns = false;
            dataGridAssessments.AllowUserToResizeRows = false;
            dataGridAssessments.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridAssessments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAssessments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridAssessments.BackgroundColor = System.Drawing.Color.White;
            dataGridAssessments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridAssessments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridAssessments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridAssessments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridAssessments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridAssessments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAssessments.GridColor = System.Drawing.Color.White;
            dataGridAssessments.Location = new System.Drawing.Point(16, 56);
            dataGridAssessments.Margin = new System.Windows.Forms.Padding(10);
            dataGridAssessments.Name = "dataGridAssessments";
            dataGridAssessments.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridAssessments.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridAssessments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridAssessments.ShowCellErrors = false;
            dataGridAssessments.ShowCellToolTips = false;
            dataGridAssessments.ShowEditingIcon = false;
            dataGridAssessments.ShowRowErrors = false;
            dataGridAssessments.Size = new System.Drawing.Size(1285, 514);
            dataGridAssessments.TabIndex = 11;
            dataGridAssessments.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddAssessment
            // 
            btnAddAssessment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddAssessment.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddAssessment.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddAssessment.BorderColor = System.Drawing.Color.White;
            btnAddAssessment.BorderRadius = 10;
            btnAddAssessment.BorderSize = 0;
            btnAddAssessment.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddAssessment.FlatAppearance.BorderSize = 0;
            btnAddAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddAssessment.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            btnAddAssessment.ForeColor = System.Drawing.Color.White;
            btnAddAssessment.Image = (System.Drawing.Image)resources.GetObject("btnAddAssessment.Image");
            btnAddAssessment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddAssessment.Location = new System.Drawing.Point(1096, 7);
            btnAddAssessment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddAssessment.Name = "btnAddAssessment";
            btnAddAssessment.Padding = new System.Windows.Forms.Padding(10, 0, 23, 0);
            btnAddAssessment.Size = new System.Drawing.Size(214, 55);
            btnAddAssessment.TabIndex = 7;
            btnAddAssessment.Text = "Add Assessment";
            btnAddAssessment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnAddAssessment.TextColor = System.Drawing.Color.White;
            btnAddAssessment.UseVisualStyleBackColor = false;
            btnAddAssessment.Click += btnAddAssessment_Click;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.Controls.Add(btnLowerExtremities);
            panelBorder2.Controls.Add(btnUpperExtremities);
            panelBorder2.Controls.Add(btnAll);
            panelBorder2.Controls.Add(btnAddAssessment);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(1317, 67);
            panelBorder2.TabIndex = 16;
            // 
            // btnLowerExtremities
            // 
            btnLowerExtremities.BackColor = System.Drawing.Color.Gainsboro;
            btnLowerExtremities.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnLowerExtremities.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnLowerExtremities.BorderRadius = 5;
            btnLowerExtremities.BorderSize = 0;
            btnLowerExtremities.FlatAppearance.BorderSize = 0;
            btnLowerExtremities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLowerExtremities.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnLowerExtremities.ForeColor = System.Drawing.Color.Gray;
            btnLowerExtremities.Location = new System.Drawing.Point(273, 12);
            btnLowerExtremities.Margin = new System.Windows.Forms.Padding(1);
            btnLowerExtremities.Name = "btnLowerExtremities";
            btnLowerExtremities.Size = new System.Drawing.Size(156, 46);
            btnLowerExtremities.TabIndex = 12;
            btnLowerExtremities.Text = "Lower Extremities";
            btnLowerExtremities.TextColor = System.Drawing.Color.Gray;
            btnLowerExtremities.UseVisualStyleBackColor = false;
            // 
            // btnUpperExtremities
            // 
            btnUpperExtremities.BackColor = System.Drawing.Color.Gainsboro;
            btnUpperExtremities.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnUpperExtremities.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnUpperExtremities.BorderRadius = 5;
            btnUpperExtremities.BorderSize = 0;
            btnUpperExtremities.FlatAppearance.BorderSize = 0;
            btnUpperExtremities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpperExtremities.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnUpperExtremities.ForeColor = System.Drawing.Color.Gray;
            btnUpperExtremities.Location = new System.Drawing.Point(112, 10);
            btnUpperExtremities.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnUpperExtremities.Name = "btnUpperExtremities";
            btnUpperExtremities.Size = new System.Drawing.Size(156, 46);
            btnUpperExtremities.TabIndex = 11;
            btnUpperExtremities.Text = "Upper Extrimities";
            btnUpperExtremities.TextColor = System.Drawing.Color.Gray;
            btnUpperExtremities.UseVisualStyleBackColor = false;
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
            btnAll.TabIndex = 10;
            btnAll.Text = "All";
            btnAll.TextColor = System.Drawing.Color.White;
            btnAll.UseVisualStyleBackColor = false;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(customButton1);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(rjTextBox1);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(807, 51);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(582, 59);
            panelBorder1.TabIndex = 17;
            // 
            // customButton1
            // 
            customButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton1.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton1.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton1.BorderRadius = 10;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton1.ForeColor = System.Drawing.Color.White;
            customButton1.Location = new System.Drawing.Point(453, 8);
            customButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton1.Name = "customButton1";
            customButton1.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            customButton1.Size = new System.Drawing.Size(118, 40);
            customButton1.TabIndex = 15;
            customButton1.Text = "Search";
            customButton1.TextColor = System.Drawing.Color.White;
            customButton1.UseVisualStyleBackColor = false;
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
            // rjTextBox1
            // 
            rjTextBox1.BackColor = System.Drawing.Color.White;
            rjTextBox1.BorderColor = System.Drawing.Color.White;
            rjTextBox1.BorderFocusColor = System.Drawing.Color.White;
            rjTextBox1.BorderRadius = 5;
            rjTextBox1.BorderSize = 1;
            rjTextBox1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            rjTextBox1.Location = new System.Drawing.Point(56, 9);
            rjTextBox1.Margin = new System.Windows.Forms.Padding(5);
            rjTextBox1.Multiline = false;
            rjTextBox1.Name = "rjTextBox1";
            rjTextBox1.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            rjTextBox1.PasswordChar = false;
            rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            rjTextBox1.PlaceholderText = "Search Patient";
            rjTextBox1.SelectionLength = 0;
            rjTextBox1.SelectionStart = 0;
            rjTextBox1.Size = new System.Drawing.Size(388, 35);
            rjTextBox1.TabIndex = 4;
            rjTextBox1.Texts = "";
            rjTextBox1.UnderlinedStyle = false;
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
            cbSort.Items.AddRange(new object[] { "Default", "Alphabetical (Name)", "Earliest (Date Added)", "Latest (Date Added)" });
            cbSort.ListBackColor = System.Drawing.Color.White;
            cbSort.ListTextColor = System.Drawing.Color.Black;
            cbSort.Location = new System.Drawing.Point(804, 7);
            cbSort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSort.MinimumSize = new System.Drawing.Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new System.Windows.Forms.Padding(1);
            cbSort.Size = new System.Drawing.Size(284, 55);
            cbSort.TabIndex = 15;
            cbSort.Texts = "Default";
            // 
            // panelBorder3
            // 
            panelBorder3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder3.BackColor = System.Drawing.Color.Transparent;
            panelBorder3.BorderRadius = 15;
            panelBorder3.Color = System.Drawing.Color.BurlyWood;
            panelBorder3.Controls.Add(customButton6);
            panelBorder3.Controls.Add(rjComboBox1);
            panelBorder3.Controls.Add(customButton2);
            panelBorder3.Controls.Add(customButton3);
            panelBorder3.Controls.Add(customButton4);
            panelBorder3.Controls.Add(customButton5);
            panelBorder3.ForeColor = System.Drawing.Color.Black;
            panelBorder3.Location = new System.Drawing.Point(707, 9);
            panelBorder3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder3.Name = "panelBorder3";
            panelBorder3.Size = new System.Drawing.Size(603, 46);
            panelBorder3.TabIndex = 17;
            // 
            // rjComboBox1
            // 
            rjComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rjComboBox1.BackColor = System.Drawing.Color.White;
            rjComboBox1.BorderColor = System.Drawing.Color.Gray;
            rjComboBox1.BorderSize = 1;
            rjComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            rjComboBox1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            rjComboBox1.ForeColor = System.Drawing.Color.DimGray;
            rjComboBox1.IconColor = System.Drawing.Color.FromArgb(24, 90, 211);
            rjComboBox1.Items.AddRange(new object[] { "Default", "Alphabetical (Name)", "Earliest (Date Added)", "Latest (Date Added)" });
            rjComboBox1.ListBackColor = System.Drawing.Color.White;
            rjComboBox1.ListTextColor = System.Drawing.Color.Black;
            rjComboBox1.Location = new System.Drawing.Point(1057, 7);
            rjComboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rjComboBox1.MinimumSize = new System.Drawing.Size(233, 35);
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            rjComboBox1.Size = new System.Drawing.Size(284, 55);
            rjComboBox1.TabIndex = 15;
            rjComboBox1.Texts = "Default";
            // 
            // customButton2
            // 
            customButton2.BackColor = System.Drawing.Color.Gainsboro;
            customButton2.BackgroundColor = System.Drawing.Color.Gainsboro;
            customButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton2.BorderRadius = 5;
            customButton2.BorderSize = 0;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            customButton2.ForeColor = System.Drawing.Color.Gray;
            customButton2.Location = new System.Drawing.Point(273, 12);
            customButton2.Margin = new System.Windows.Forms.Padding(1);
            customButton2.Name = "customButton2";
            customButton2.Size = new System.Drawing.Size(156, 31);
            customButton2.TabIndex = 12;
            customButton2.Text = "Finished";
            customButton2.TextColor = System.Drawing.Color.Gray;
            customButton2.UseVisualStyleBackColor = false;
            // 
            // customButton3
            // 
            customButton3.BackColor = System.Drawing.Color.Gainsboro;
            customButton3.BackgroundColor = System.Drawing.Color.Gainsboro;
            customButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton3.BorderRadius = 5;
            customButton3.BorderSize = 0;
            customButton3.FlatAppearance.BorderSize = 0;
            customButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            customButton3.ForeColor = System.Drawing.Color.Gray;
            customButton3.Location = new System.Drawing.Point(112, 10);
            customButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton3.Name = "customButton3";
            customButton3.Size = new System.Drawing.Size(156, 33);
            customButton3.TabIndex = 11;
            customButton3.Text = "Ongoing";
            customButton3.TextColor = System.Drawing.Color.Gray;
            customButton3.UseVisualStyleBackColor = false;
            // 
            // customButton4
            // 
            customButton4.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton4.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton4.BorderRadius = 5;
            customButton4.BorderSize = 0;
            customButton4.FlatAppearance.BorderSize = 0;
            customButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            customButton4.ForeColor = System.Drawing.Color.White;
            customButton4.Location = new System.Drawing.Point(14, 10);
            customButton4.Margin = new System.Windows.Forms.Padding(1);
            customButton4.Name = "customButton4";
            customButton4.Size = new System.Drawing.Size(93, 33);
            customButton4.TabIndex = 10;
            customButton4.Text = "All";
            customButton4.TextColor = System.Drawing.Color.White;
            customButton4.UseVisualStyleBackColor = false;
            // 
            // customButton5
            // 
            customButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton5.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton5.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            customButton5.BorderColor = System.Drawing.Color.White;
            customButton5.BorderRadius = 10;
            customButton5.BorderSize = 0;
            customButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            customButton5.FlatAppearance.BorderSize = 0;
            customButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            customButton5.ForeColor = System.Drawing.Color.White;
            customButton5.Image = (System.Drawing.Image)resources.GetObject("customButton5.Image");
            customButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            customButton5.Location = new System.Drawing.Point(1349, 7);
            customButton5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton5.Name = "customButton5";
            customButton5.Padding = new System.Windows.Forms.Padding(10, 0, 23, 0);
            customButton5.Size = new System.Drawing.Size(214, 55);
            customButton5.TabIndex = 7;
            customButton5.Text = "Add Assessment";
            customButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            customButton5.TextColor = System.Drawing.Color.White;
            customButton5.UseVisualStyleBackColor = false;
            // 
            // customButton6
            // 
            customButton6.BackColor = System.Drawing.Color.Gainsboro;
            customButton6.BackgroundColor = System.Drawing.Color.Gainsboro;
            customButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton6.BorderRadius = 5;
            customButton6.BorderSize = 0;
            customButton6.FlatAppearance.BorderSize = 0;
            customButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            customButton6.ForeColor = System.Drawing.Color.Gray;
            customButton6.Location = new System.Drawing.Point(434, 12);
            customButton6.Margin = new System.Windows.Forms.Padding(1);
            customButton6.Name = "customButton6";
            customButton6.Size = new System.Drawing.Size(156, 31);
            customButton6.TabIndex = 16;
            customButton6.Text = "Archived";
            customButton6.TextColor = System.Drawing.Color.Gray;
            customButton6.UseVisualStyleBackColor = false;
            // 
            // AssessmentPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            Controls.Add(panelBorder1);
            Controls.Add(panelBorder2);
            Controls.Add(PatientHolder);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AssessmentPage";
            Size = new System.Drawing.Size(1457, 875);
            Load += AssessmentPage_Load;
            PatientHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridAssessments).EndInit();
            panelBorder2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelBorder3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private OrganizationProfile.CustomButton btnAddAssessment;
        private WindowsFormsApp2.CustomButton.PanelBorder PatientHolder;
        private System.Windows.Forms.DataGridView dataGridAssessments;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private OrganizationProfile.CustomButton btnLowerExtremities;
        private OrganizationProfile.CustomButton btnUpperExtremities;
        private OrganizationProfile.CustomButton btnAll;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton customButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder3;
        private OrganizationProfile.CustomButton customButton6;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
        private OrganizationProfile.CustomButton customButton2;
        private OrganizationProfile.CustomButton customButton3;
        private OrganizationProfile.CustomButton customButton4;
        private OrganizationProfile.CustomButton customButton5;
        private CustomControls.RJControls.RJComboBox cbSort;
    }
}
