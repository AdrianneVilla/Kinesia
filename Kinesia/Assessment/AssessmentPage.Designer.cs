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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            PatientHolder.SuspendLayout();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridAssessments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridAssessments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAssessments.GridColor = System.Drawing.Color.White;
            dataGridAssessments.Location = new System.Drawing.Point(16, 16);
            dataGridAssessments.Margin = new System.Windows.Forms.Padding(10);
            dataGridAssessments.Name = "dataGridAssessments";
            dataGridAssessments.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridAssessments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridAssessments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridAssessments.ShowCellErrors = false;
            dataGridAssessments.ShowCellToolTips = false;
            dataGridAssessments.ShowEditingIcon = false;
            dataGridAssessments.ShowRowErrors = false;
            dataGridAssessments.Size = new System.Drawing.Size(1285, 554);
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
    }
}
