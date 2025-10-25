namespace Kinesia.Assessment
{
    partial class SelectPatient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPatient));
            dataGridPatientSelection = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            splitter1 = new System.Windows.Forms.Splitter();
            btnAddPatient = new OrganizationProfile.CustomButton();
            btnClose = new OrganizationProfile.CustomButton();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridPatientSelection).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panelBorder2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridPatientSelection
            // 
            dataGridPatientSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridPatientSelection.BackgroundColor = System.Drawing.Color.White;
            dataGridPatientSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPatientSelection.Location = new System.Drawing.Point(47, 251);
            dataGridPatientSelection.Name = "dataGridPatientSelection";
            dataGridPatientSelection.Size = new System.Drawing.Size(770, 454);
            dataGridPatientSelection.TabIndex = 24;
            dataGridPatientSelection.CellContentClick += dataGridPatientSelection_CellContentClick;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            label2.Location = new System.Drawing.Point(30, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 49);
            label2.TabIndex = 21;
            label2.Text = "Select patient";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(splitter1);
            flowLayoutPanel2.Controls.Add(btnAddPatient);
            flowLayoutPanel2.Location = new System.Drawing.Point(44, 169);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(780, 51);
            flowLayoutPanel2.TabIndex = 22;
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(3, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(563, 43);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
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
            btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            btnAddPatient.ForeColor = System.Drawing.Color.White;
            btnAddPatient.Image = (System.Drawing.Image)resources.GetObject("btnAddPatient.Image");
            btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnAddPatient.Location = new System.Drawing.Point(573, 3);
            btnAddPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Padding = new System.Windows.Forms.Padding(10, 3, 45, 0);
            btnAddPatient.Size = new System.Drawing.Size(199, 43);
            btnAddPatient.TabIndex = 8;
            btnAddPatient.Text = "Add Patient";
            btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnAddPatient.TextColor = System.Drawing.Color.White;
            btnAddPatient.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.newSmallClose;
            btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnClose.BorderRadius = 15;
            btnClose.BorderSize = 0;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.Transparent;
            btnClose.Location = new System.Drawing.Point(785, 35);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(39, 30);
            btnClose.TabIndex = 25;
            btnClose.TextColor = System.Drawing.Color.Transparent;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(btnSearch);
            panelBorder2.Controls.Add(rjTextBox1);
            panelBorder2.Controls.Add(pictureBox2);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(44, 99);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(789, 53);
            panelBorder2.TabIndex = 26;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.Transparent;
            btnSearch.Location = new System.Drawing.Point(626, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(150, 40);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.Transparent;
            btnSearch.UseVisualStyleBackColor = false;
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
            rjTextBox1.Location = new System.Drawing.Point(60, 6);
            rjTextBox1.Margin = new System.Windows.Forms.Padding(5);
            rjTextBox1.MaxLength = 32767;
            rjTextBox1.Multiline = false;
            rjTextBox1.Name = "rjTextBox1";
            rjTextBox1.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            rjTextBox1.PasswordChar = false;
            rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            rjTextBox1.PlaceholderText = "Search Patient";
            rjTextBox1.SelectionLength = 0;
            rjTextBox1.SelectionStart = 0;
            rjTextBox1.Size = new System.Drawing.Size(558, 35);
            rjTextBox1.TabIndex = 5;
            rjTextBox1.Texts = "";
            rjTextBox1.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search_icon;
            pictureBox2.Location = new System.Drawing.Point(23, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(29, 27);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // SelectPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(874, 763);
            ControlBox = false;
            Controls.Add(panelBorder2);
            Controls.Add(btnClose);
            Controls.Add(dataGridPatientSelection);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SelectPatient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NewSelectPatient";
            Load += SelectPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPatientSelection).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            panelBorder2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPatientSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private OrganizationProfile.CustomButton btnAddPatient;
        private OrganizationProfile.CustomButton btnClose;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private OrganizationProfile.CustomButton btnSearch;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
    }
}