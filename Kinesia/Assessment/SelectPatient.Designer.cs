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
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            customButton3 = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            splitter2 = new System.Windows.Forms.Splitter();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            btnAddPatient = new OrganizationProfile.CustomButton();
            flowLayoutPanel2.SuspendLayout();
            panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            label2.Click += label2_Click;
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
            // panelBorder1
            // 
            panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder1.BackColor = System.Drawing.Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.longSearchBar;
            panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder1.BorderRadius = 10;
            panelBorder1.Color = System.Drawing.Color.BurlyWood;
            panelBorder1.Controls.Add(customButton3);
            panelBorder1.Controls.Add(customButton2);
            panelBorder1.Controls.Add(pictureBox1);
            panelBorder1.Controls.Add(rjTextBox1);
            panelBorder1.ForeColor = System.Drawing.Color.Black;
            panelBorder1.Location = new System.Drawing.Point(36, 75);
            panelBorder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Padding = new System.Windows.Forms.Padding(6);
            panelBorder1.Size = new System.Drawing.Size(780, 59);
            panelBorder1.TabIndex = 18;
            // 
            // customButton3
            // 
            customButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            customButton3.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton3.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            customButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            customButton3.BorderRadius = 10;
            customButton3.BorderSize = 0;
            customButton3.FlatAppearance.BorderSize = 0;
            customButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButton3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customButton3.ForeColor = System.Drawing.Color.White;
            customButton3.Location = new System.Drawing.Point(649, 9);
            customButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            customButton3.Name = "customButton3";
            customButton3.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            customButton3.Size = new System.Drawing.Size(118, 40);
            customButton3.TabIndex = 16;
            customButton3.Text = "Search";
            customButton3.TextColor = System.Drawing.Color.White;
            customButton3.UseVisualStyleBackColor = false;
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
            rjTextBox1.Size = new System.Drawing.Size(580, 35);
            rjTextBox1.TabIndex = 4;
            rjTextBox1.Texts = "";
            rjTextBox1.UnderlinedStyle = false;
            // 
            // splitter2
            // 
            splitter2.Location = new System.Drawing.Point(0, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new System.Drawing.Size(3, 698);
            splitter2.TabIndex = 19;
            splitter2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(39, 232);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(770, 425);
            dataGridView1.TabIndex = 20;
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
            // SelectPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImage = Properties.Resources.Add_Patient_Background;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton customButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
        private OrganizationProfile.CustomButton customButton3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private OrganizationProfile.CustomButton btnAddPatient;
    }
}
