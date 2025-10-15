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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPatient));
            label2 = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            rjComboBox1 = new CustomControls.RJControls.RJComboBox();
            splitter1 = new System.Windows.Forms.Splitter();
            btnAddPatient = new OrganizationProfile.CustomButton();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            splitter2 = new System.Windows.Forms.Splitter();
            dataGridPatients = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPatients).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            label2.Location = new System.Drawing.Point(22, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 49);
            label2.TabIndex = 0;
            label2.Text = "Select patient";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(rjComboBox1);
            flowLayoutPanel2.Controls.Add(splitter1);
            flowLayoutPanel2.Controls.Add(btnAddPatient);
            flowLayoutPanel2.Location = new System.Drawing.Point(36, 150);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(780, 51);
            flowLayoutPanel2.TabIndex = 2;
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
            rjComboBox1.Items.AddRange(new object[] { "SELECT JOINT", "Knees", "Elbow", "Shoulder", "Hips" });
            rjComboBox1.ListBackColor = System.Drawing.Color.White;
            rjComboBox1.ListTextColor = System.Drawing.Color.Black;
            rjComboBox1.Location = new System.Drawing.Point(3, 3);
            rjComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            rjComboBox1.Size = new System.Drawing.Size(397, 43);
            rjComboBox1.TabIndex = 1;
            rjComboBox1.Texts = "";
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(406, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(164, 43);
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
            btnAddPatient.Location = new System.Drawing.Point(577, 3);
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
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.longSearchBar;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(btnSearch);
            panelBorder1.Controls.Add(customButton2);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(txtSearchBar);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(36, 75);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(780, 59);
            panelBorder1.TabIndex = 18;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(649, 9);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            btnSearch.Size = new System.Drawing.Size(118, 40);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            customButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton2.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton2.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton2.BorderRadius = 10;
            customButton2.BorderSize = 0;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton2.ForeColor = System.Drawing.Color.White;
            customButton2.Location = new System.Drawing.Point(877, 14);
            customButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton2.Name = "customButton2";
            customButton2.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            customButton2.Size = new System.Drawing.Size(118, 40);
            customButton2.TabIndex = 15;
            customButton2.Text = "Search";
            customButton2.TextColor = System.Drawing.Color.White;
            customButton2.UseVisualStyleBackColor = false;
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
            txtSearchBar.BackColor = System.Drawing.Color.White;
            txtSearchBar.BorderColor = System.Drawing.Color.White;
            txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(56, 9);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "Search Patient";
            txtSearchBar.Size = new System.Drawing.Size(580, 35);
            txtSearchBar.TabIndex = 4;
            txtSearchBar.Texts = "";
            txtSearchBar.UnderlinedStyle = false;
            // 
            // splitter2
            // 
            splitter2.Location = new System.Drawing.Point(0, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new System.Drawing.Size(3, 698);
            splitter2.TabIndex = 19;
            splitter2.TabStop = false;
            // 
            // dataGridPatients
            // 
            dataGridPatients.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridPatients.BackgroundColor = System.Drawing.Color.White;
            dataGridPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPatients.Location = new System.Drawing.Point(39, 232);
            dataGridPatients.Name = "dataGridPatients";
            dataGridPatients.Size = new System.Drawing.Size(770, 425);
            dataGridPatients.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(346, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 21;
            label1.Text = "label1";
            // 
            // SelectPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImage = Properties.Resources.Add_Patient_Background;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(label1);
            Controls.Add(dataGridPatients);
            Controls.Add(splitter2);
            Controls.Add(panelBorder1);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel2);
            DoubleBuffered = true;
            Name = "SelectPatient";
            Size = new System.Drawing.Size(852, 698);
            Load += SelectPatient_Load;
            flowLayoutPanel2.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton customButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
        private OrganizationProfile.CustomButton btnSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dataGridPatients;
        private OrganizationProfile.CustomButton btnAddPatient;
        private System.Windows.Forms.Label label1;
    }
}
