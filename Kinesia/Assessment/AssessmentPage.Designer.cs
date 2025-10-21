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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssessmentPage));
            label1 = new System.Windows.Forms.Label();
            nameHolder = new System.Windows.Forms.Label();
            PatientHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            AssessmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Joint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dateHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            editHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            archiveHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnAddAssessment = new OrganizationProfile.CustomButton();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            customButton3 = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            customButton4 = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            customButton1 = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            PatientHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            PatientHolder.Controls.Add(dataGridView1);
            PatientHolder.ForeColor = System.Drawing.Color.Black;
            PatientHolder.Location = new System.Drawing.Point(72, 236);
            PatientHolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PatientHolder.Name = "PatientHolder";
            PatientHolder.Padding = new System.Windows.Forms.Padding(6);
            PatientHolder.Size = new System.Drawing.Size(1317, 586);
            PatientHolder.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { AssessmentID, PatientName, Joint, dateHeader, editHeader, archiveHeader });
            dataGridView1.GridColor = System.Drawing.Color.White;
            dataGridView1.Location = new System.Drawing.Point(16, 16);
            dataGridView1.Margin = new System.Windows.Forms.Padding(10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new System.Drawing.Size(1285, 554);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // AssessmentID
            // 
            AssessmentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            AssessmentID.FillWeight = 60F;
            AssessmentID.HeaderText = "Assesment ID";
            AssessmentID.Name = "AssessmentID";
            AssessmentID.ReadOnly = true;
            // 
            // PatientName
            // 
            PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            PatientName.DefaultCellStyle = dataGridViewCellStyle2;
            PatientName.FillWeight = 110F;
            PatientName.HeaderText = "Patient Name";
            PatientName.Name = "PatientName";
            PatientName.ReadOnly = true;
            PatientName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Joint
            // 
            Joint.FillWeight = 63.63636F;
            Joint.HeaderText = "Joint";
            Joint.Name = "Joint";
            Joint.ReadOnly = true;
            // 
            // dateHeader
            // 
            dateHeader.FillWeight = 63.63636F;
            dateHeader.HeaderText = "Status";
            dateHeader.Name = "dateHeader";
            dateHeader.ReadOnly = true;
            // 
            // editHeader
            // 
            editHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            editHeader.FillWeight = 25F;
            editHeader.HeaderText = "Select";
            editHeader.Name = "editHeader";
            editHeader.ReadOnly = true;
            // 
            // archiveHeader
            // 
            archiveHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            archiveHeader.FillWeight = 30F;
            archiveHeader.HeaderText = "Archive";
            archiveHeader.Name = "archiveHeader";
            archiveHeader.ReadOnly = true;
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
            panelBorder2.Controls.Add(customButton3);
            panelBorder2.Controls.Add(customButton2);
            panelBorder2.Controls.Add(customButton4);
            panelBorder2.Controls.Add(btnAddAssessment);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(72, 163);
            panelBorder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(1317, 67);
            panelBorder2.TabIndex = 16;
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
            customButton3.Location = new System.Drawing.Point(273, 12);
            customButton3.Margin = new System.Windows.Forms.Padding(1);
            customButton3.Name = "customButton3";
            customButton3.Size = new System.Drawing.Size(156, 46);
            customButton3.TabIndex = 12;
            customButton3.Text = "Lower Extremities";
            customButton3.TextColor = System.Drawing.Color.Gray;
            customButton3.UseVisualStyleBackColor = false;
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
            customButton2.Location = new System.Drawing.Point(112, 10);
            customButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton2.Name = "customButton2";
            customButton2.Size = new System.Drawing.Size(156, 46);
            customButton2.TabIndex = 11;
            customButton2.Text = "Upper Extrimities";
            customButton2.TextColor = System.Drawing.Color.Gray;
            customButton2.UseVisualStyleBackColor = false;
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
            customButton4.Size = new System.Drawing.Size(93, 46);
            customButton4.TabIndex = 10;
            customButton4.Text = "All";
            customButton4.TextColor = System.Drawing.Color.White;
            customButton4.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelBorder2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private OrganizationProfile.CustomButton btnAddAssessment;
        private WindowsFormsApp2.CustomButton.PanelBorder PatientHolder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private OrganizationProfile.CustomButton customButton3;
        private OrganizationProfile.CustomButton customButton2;
        private OrganizationProfile.CustomButton customButton4;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton customButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssessmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn editHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn archiveHeader;
    }
}
