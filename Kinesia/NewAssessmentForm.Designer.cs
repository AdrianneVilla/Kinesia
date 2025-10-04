namespace Kinesia
{
    partial class NewAssessmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAssessmentForm));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            txtPatientName = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtPatientID = new Label();
            label1 = new Label();
            label2 = new Label();
            cbSort = new CustomControls.RJControls.RJComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            customButton1 = new OrganizationProfile.CustomButton();
            customButton2 = new OrganizationProfile.CustomButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.large_logo;
            pictureBox1.Location = new Point(14, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Orbbec_camera_icon;
            pictureBox2.Location = new Point(4, 98);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(606, 222);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // txtPatientName
            // 
            txtPatientName.AutoSize = true;
            txtPatientName.Dock = DockStyle.Top;
            txtPatientName.Font = new Font("Poppins Black", 30F, FontStyle.Bold);
            txtPatientName.ForeColor = Color.FromArgb(18, 90, 211);
            txtPatientName.Location = new Point(4, 0);
            txtPatientName.Margin = new Padding(4, 0, 4, 0);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(606, 70);
            txtPatientName.TabIndex = 2;
            txtPatientName.Text = "<PatientName>";
            txtPatientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(txtPatientName);
            flowLayoutPanel1.Controls.Add(txtPatientID);
            flowLayoutPanel1.Controls.Add(pictureBox2);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(cbSort);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(342, 98);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(614, 644);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // txtPatientID
            // 
            txtPatientID.AutoSize = true;
            txtPatientID.Dock = DockStyle.Fill;
            txtPatientID.Font = new Font("Poppins Black", 10F, FontStyle.Bold);
            txtPatientID.ForeColor = Color.Black;
            txtPatientID.Location = new Point(4, 70);
            txtPatientID.Margin = new Padding(4, 0, 4, 0);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.Size = new Size(606, 25);
            txtPatientID.TabIndex = 3;
            txtPatientID.Text = "<patientID>";
            txtPatientID.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Poppins", 10F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(4, 323);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(606, 25);
            label1.TabIndex = 4;
            label1.Text = "Astra Pro Plus";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(18, 90, 211);
            label2.Location = new Point(4, 383);
            label2.Margin = new Padding(4, 35, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(606, 23);
            label2.TabIndex = 5;
            label2.Text = "Body Group";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbSort
            // 
            cbSort.BackColor = Color.White;
            cbSort.BorderColor = Color.Gray;
            cbSort.BorderSize = 1;
            cbSort.Dock = DockStyle.Fill;
            cbSort.DropDownStyle = ComboBoxStyle.DropDown;
            cbSort.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSort.ForeColor = Color.DimGray;
            cbSort.IconColor = Color.FromArgb(24, 90, 211);
            cbSort.Items.AddRange(new object[] { "Lower Extremities", "Upper Extremities" });
            cbSort.ListBackColor = Color.White;
            cbSort.ListTextColor = Color.Black;
            cbSort.Location = new Point(117, 409);
            cbSort.Margin = new Padding(117, 3, 117, 3);
            cbSort.MinimumSize = new Size(233, 35);
            cbSort.Name = "cbSort";
            cbSort.Padding = new Padding(1);
            cbSort.Size = new Size(380, 55);
            cbSort.TabIndex = 15;
            cbSort.Texts = "Select body group";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(customButton1);
            flowLayoutPanel2.Controls.Add(customButton2);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(4, 502);
            flowLayoutPanel2.Margin = new Padding(4, 35, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(606, 115);
            flowLayoutPanel2.TabIndex = 16;
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.FromArgb(18, 90, 211);
            customButton1.BackgroundColor = Color.FromArgb(18, 90, 211);
            customButton1.BorderColor = Color.PaleVioletRed;
            customButton1.BorderRadius = 10;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.White;
            customButton1.Image = (Image)resources.GetObject("customButton1.Image");
            customButton1.ImageAlign = ContentAlignment.MiddleLeft;
            customButton1.Location = new Point(4, 3);
            customButton1.Margin = new Padding(4, 3, 4, 3);
            customButton1.Name = "customButton1";
            customButton1.Padding = new Padding(12, 1, 0, 0);
            customButton1.Size = new Size(295, 59);
            customButton1.TabIndex = 0;
            customButton1.Text = "Start Session";
            customButton1.TextColor = Color.White;
            customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            customButton2.BackColor = Color.FromArgb(195, 251, 237);
            customButton2.BackgroundColor = Color.FromArgb(195, 251, 237);
            customButton2.BorderColor = Color.FromArgb(21, 134, 105);
            customButton2.BorderRadius = 10;
            customButton2.BorderSize = 1;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = FlatStyle.Flat;
            customButton2.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton2.ForeColor = Color.FromArgb(21, 134, 105);
            customButton2.Image = (Image)resources.GetObject("customButton2.Image");
            customButton2.ImageAlign = ContentAlignment.MiddleLeft;
            customButton2.Location = new Point(307, 3);
            customButton2.Margin = new Padding(4, 3, 4, 3);
            customButton2.Name = "customButton2";
            customButton2.Padding = new Padding(12, 1, 0, 0);
            customButton2.Size = new Size(295, 59);
            customButton2.TabIndex = 1;
            customButton2.Text = "Patient Selection";
            customButton2.TextColor = Color.FromArgb(21, 134, 105);
            customButton2.UseVisualStyleBackColor = false;
            // 
            // NewAssessmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1406, 795);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "NewAssessmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewAssessmentForm";
            WindowState = FormWindowState.Maximized;
            Load += NewAssessmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtPatientName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label txtPatientID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJComboBox cbSort;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private OrganizationProfile.CustomButton customButton1;
        private OrganizationProfile.CustomButton customButton2;
    }
}