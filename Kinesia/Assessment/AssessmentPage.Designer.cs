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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnAllStatus = new OrganizationProfile.CustomButton();
            btnOngoing = new OrganizationProfile.CustomButton();
            btnFinished = new OrganizationProfile.CustomButton();
            btnArchived = new OrganizationProfile.CustomButton();
            dataGridAssessments = new System.Windows.Forms.DataGridView();
            btnAddAssessment = new OrganizationProfile.CustomButton();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            panelBorder3 = new WindowsFormsApp2.CustomButton.PanelBorder();
            cbSort = new CustomControls.RJControls.RJComboBox();
            btnLowerExtremities = new OrganizationProfile.CustomButton();
            btnUpperExtremities = new OrganizationProfile.CustomButton();
            btnAllExtremity = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            lblHiddenForFocus = new System.Windows.Forms.Label();
            PatientHolder.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAssessments).BeginInit();
            panelBorder2.SuspendLayout();
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
            PatientHolder.Controls.Add(flowLayoutPanel1);
            PatientHolder.Controls.Add(dataGridAssessments);
            PatientHolder.ForeColor = System.Drawing.Color.Black;
            PatientHolder.Location = new System.Drawing.Point(72, 236);
            PatientHolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PatientHolder.Name = "PatientHolder";
            PatientHolder.Padding = new System.Windows.Forms.Padding(6);
            PatientHolder.Size = new System.Drawing.Size(1317, 636);
            PatientHolder.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnAllStatus);
            flowLayoutPanel1.Controls.Add(btnOngoing);
            flowLayoutPanel1.Controls.Add(btnFinished);
            flowLayoutPanel1.Controls.Add(btnArchived);
            flowLayoutPanel1.Location = new System.Drawing.Point(722, 18);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(579, 37);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // btnAllStatus
            // 
            btnAllStatus.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAllStatus.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAllStatus.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAllStatus.BorderRadius = 5;
            btnAllStatus.BorderSize = 0;
            btnAllStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAllStatus.FlatAppearance.BorderSize = 0;
            btnAllStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAllStatus.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAllStatus.ForeColor = System.Drawing.Color.White;
            btnAllStatus.Location = new System.Drawing.Point(2, 2);
            btnAllStatus.Margin = new System.Windows.Forms.Padding(2);
            btnAllStatus.Name = "btnAllStatus";
            btnAllStatus.Size = new System.Drawing.Size(93, 33);
            btnAllStatus.TabIndex = 10;
            btnAllStatus.Text = "All";
            btnAllStatus.TextColor = System.Drawing.Color.White;
            btnAllStatus.UseVisualStyleBackColor = false;
            btnAllStatus.Click += btnAllStatus_Click;
            // 
            // btnOngoing
            // 
            btnOngoing.BackColor = System.Drawing.Color.Gainsboro;
            btnOngoing.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnOngoing.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnOngoing.BorderRadius = 5;
            btnOngoing.BorderSize = 0;
            btnOngoing.Cursor = System.Windows.Forms.Cursors.Hand;
            btnOngoing.FlatAppearance.BorderSize = 0;
            btnOngoing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOngoing.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnOngoing.ForeColor = System.Drawing.Color.Gray;
            btnOngoing.Location = new System.Drawing.Point(99, 2);
            btnOngoing.Margin = new System.Windows.Forms.Padding(2);
            btnOngoing.Name = "btnOngoing";
            btnOngoing.Size = new System.Drawing.Size(156, 33);
            btnOngoing.TabIndex = 11;
            btnOngoing.Text = "Ongoing";
            btnOngoing.TextColor = System.Drawing.Color.Gray;
            btnOngoing.UseVisualStyleBackColor = false;
            btnOngoing.Click += btnOngoing_Click;
            // 
            // btnFinished
            // 
            btnFinished.BackColor = System.Drawing.Color.Gainsboro;
            btnFinished.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnFinished.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnFinished.BorderRadius = 5;
            btnFinished.BorderSize = 0;
            btnFinished.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFinished.FlatAppearance.BorderSize = 0;
            btnFinished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFinished.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnFinished.ForeColor = System.Drawing.Color.Gray;
            btnFinished.Location = new System.Drawing.Point(259, 2);
            btnFinished.Margin = new System.Windows.Forms.Padding(2);
            btnFinished.Name = "btnFinished";
            btnFinished.Size = new System.Drawing.Size(156, 33);
            btnFinished.TabIndex = 12;
            btnFinished.Text = "Finished";
            btnFinished.TextColor = System.Drawing.Color.Gray;
            btnFinished.UseVisualStyleBackColor = false;
            btnFinished.Click += btnFinished_Click;
            // 
            // btnArchived
            // 
            btnArchived.BackColor = System.Drawing.Color.Gainsboro;
            btnArchived.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnArchived.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnArchived.BorderRadius = 5;
            btnArchived.BorderSize = 0;
            btnArchived.Cursor = System.Windows.Forms.Cursors.Hand;
            btnArchived.FlatAppearance.BorderSize = 0;
            btnArchived.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnArchived.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnArchived.ForeColor = System.Drawing.Color.Gray;
            btnArchived.Location = new System.Drawing.Point(419, 2);
            btnArchived.Margin = new System.Windows.Forms.Padding(2);
            btnArchived.Name = "btnArchived";
            btnArchived.Size = new System.Drawing.Size(156, 33);
            btnArchived.TabIndex = 16;
            btnArchived.Text = "Archived";
            btnArchived.TextColor = System.Drawing.Color.Gray;
            btnArchived.UseVisualStyleBackColor = false;
            btnArchived.Click += btnArchived_Click;
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
            dataGridAssessments.Size = new System.Drawing.Size(1285, 564);
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
            panelBorder2.Controls.Add(panelBorder3);
            panelBorder2.Controls.Add(cbSort);
            panelBorder2.Controls.Add(btnLowerExtremities);
            panelBorder2.Controls.Add(btnUpperExtremities);
            panelBorder2.Controls.Add(btnAllExtremity);
            panelBorder2.Controls.Add(btnAddAssessment);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(1317, 67);
            panelBorder2.TabIndex = 16;
            // 
            // panelBorder3
            // 
            panelBorder3.BackColor = System.Drawing.Color.White;
            panelBorder3.BorderRadius = 30;
            panelBorder3.Color = System.Drawing.Color.BurlyWood;
            panelBorder3.ForeColor = System.Drawing.Color.Black;
            panelBorder3.Location = new System.Drawing.Point(1078, 8);
            panelBorder3.Name = "panelBorder3";
            panelBorder3.Size = new System.Drawing.Size(11, 54);
            panelBorder3.TabIndex = 16;
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
            cbSort.Location = new System.Drawing.Point(787, 8);
            cbSort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSort.MinimumSize = new System.Drawing.Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new System.Windows.Forms.Padding(1);
            cbSort.Size = new System.Drawing.Size(284, 55);
            cbSort.TabIndex = 15;
            cbSort.Texts = "Default";
            cbSort.OnSelectedIndexChanged += cbSort_OnSelectedIndexChanged;
            // 
            // btnLowerExtremities
            // 
            btnLowerExtremities.BackColor = System.Drawing.Color.Gainsboro;
            btnLowerExtremities.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnLowerExtremities.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnLowerExtremities.BorderRadius = 5;
            btnLowerExtremities.BorderSize = 0;
            btnLowerExtremities.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLowerExtremities.FlatAppearance.BorderSize = 0;
            btnLowerExtremities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLowerExtremities.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnLowerExtremities.ForeColor = System.Drawing.Color.Gray;
            btnLowerExtremities.Location = new System.Drawing.Point(273, 10);
            btnLowerExtremities.Margin = new System.Windows.Forms.Padding(1);
            btnLowerExtremities.Name = "btnLowerExtremities";
            btnLowerExtremities.Size = new System.Drawing.Size(156, 46);
            btnLowerExtremities.TabIndex = 12;
            btnLowerExtremities.Text = "Lower Extremities";
            btnLowerExtremities.TextColor = System.Drawing.Color.Gray;
            btnLowerExtremities.UseVisualStyleBackColor = false;
            btnLowerExtremities.Click += btnLowerExtremities_Click;
            // 
            // btnUpperExtremities
            // 
            btnUpperExtremities.BackColor = System.Drawing.Color.Gainsboro;
            btnUpperExtremities.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnUpperExtremities.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnUpperExtremities.BorderRadius = 5;
            btnUpperExtremities.BorderSize = 0;
            btnUpperExtremities.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnUpperExtremities.Click += btnUpperExtremities_Click;
            // 
            // btnAllExtremity
            // 
            btnAllExtremity.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAllExtremity.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAllExtremity.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAllExtremity.BorderRadius = 5;
            btnAllExtremity.BorderSize = 0;
            btnAllExtremity.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAllExtremity.FlatAppearance.BorderSize = 0;
            btnAllExtremity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAllExtremity.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAllExtremity.ForeColor = System.Drawing.Color.White;
            btnAllExtremity.Location = new System.Drawing.Point(14, 10);
            btnAllExtremity.Margin = new System.Windows.Forms.Padding(1);
            btnAllExtremity.Name = "btnAllExtremity";
            btnAllExtremity.Size = new System.Drawing.Size(93, 46);
            btnAllExtremity.TabIndex = 10;
            btnAllExtremity.Text = "All";
            btnAllExtremity.TextColor = System.Drawing.Color.White;
            btnAllExtremity.UseVisualStyleBackColor = false;
            btnAllExtremity.Click += btnAllExtremity_Click;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(btnSearch);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(txtSearchBar);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(807, 51);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(582, 59);
            panelBorder1.TabIndex = 17;
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
            btnSearch.Location = new System.Drawing.Point(453, 8);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            btnSearch.Size = new System.Drawing.Size(118, 40);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
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
            // txtSearchBar
            // 
            txtSearchBar.AutoSize = true;
            txtSearchBar.BackColor = System.Drawing.Color.White;
            txtSearchBar.BorderColor = System.Drawing.Color.White;
            txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(56, 9);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.MaxLength = 32767;
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.SelectionLength = 0;
            txtSearchBar.SelectionStart = 0;
            txtSearchBar.Size = new System.Drawing.Size(388, 35);
            txtSearchBar.TabIndex = 4;
            txtSearchBar.Texts = "";
            txtSearchBar.UnderlinedStyle = false;
            txtSearchBar._TextChanged += txtSearchBar__TextChanged;
            txtSearchBar.Enter += txtSearchBar_Enter;
            txtSearchBar.Leave += txtSearchBar_Leave;
            // 
            // lblHiddenForFocus
            // 
            lblHiddenForFocus.AutoSize = true;
            lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            lblHiddenForFocus.Location = new System.Drawing.Point(395, 86);
            lblHiddenForFocus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new System.Drawing.Size(135, 15);
            lblHiddenForFocus.TabIndex = 18;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // AssessmentPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            Controls.Add(panelBorder1);
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder2);
            Controls.Add(PatientHolder);
            Controls.Add(label1);
            Controls.Add(nameHolder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AssessmentPage";
            Size = new System.Drawing.Size(1457, 875);
            Load += AssessmentPage_Load;
            PatientHolder.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridAssessments).EndInit();
            panelBorder2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private OrganizationProfile.CustomButton btnAllExtremity;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private System.Windows.Forms.Label lblHiddenForFocus;
        private CustomControls.RJControls.RJComboBox cbSort;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private OrganizationProfile.CustomButton btnAllStatus;
        private OrganizationProfile.CustomButton btnOngoing;
        private OrganizationProfile.CustomButton btnFinished;
        private OrganizationProfile.CustomButton btnArchived;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder3;
    }
}
