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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPatientName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPatientID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSort = new CustomControls.RJControls.RJComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.customButton1 = new OrganizationProfile.CustomButton();
            this.customButton2 = new OrganizationProfile.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kinesia.Properties.Resources.large_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Kinesia.Properties.Resources.Orbbec_camera_icon;
            this.pictureBox2.Location = new System.Drawing.Point(3, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(519, 192);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtPatientName
            // 
            this.txtPatientName.AutoSize = true;
            this.txtPatientName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPatientName.Font = new System.Drawing.Font("Poppins Black", 30F, System.Drawing.FontStyle.Bold);
            this.txtPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.txtPatientName.Location = new System.Drawing.Point(3, 0);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(519, 70);
            this.txtPatientName.TabIndex = 2;
            this.txtPatientName.Text = "<PatientName>";
            this.txtPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtPatientName);
            this.flowLayoutPanel1.Controls.Add(this.txtPatientID);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cbSort);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(293, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(526, 558);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // txtPatientID
            // 
            this.txtPatientID.AutoSize = true;
            this.txtPatientID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPatientID.Font = new System.Drawing.Font("Poppins Black", 10F, System.Drawing.FontStyle.Bold);
            this.txtPatientID.ForeColor = System.Drawing.Color.Black;
            this.txtPatientID.Location = new System.Drawing.Point(3, 70);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(519, 25);
            this.txtPatientID.TabIndex = 3;
            this.txtPatientID.Text = "<patientID>";
            this.txtPatientID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Astra Pro Plus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.label2.Location = new System.Drawing.Point(3, 348);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Body Group";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbSort
            // 
            this.cbSort.BackColor = System.Drawing.Color.White;
            this.cbSort.BorderColor = System.Drawing.Color.Gray;
            this.cbSort.BorderSize = 1;
            this.cbSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbSort.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.Color.DimGray;
            this.cbSort.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.cbSort.Items.AddRange(new object[] {
            "Lower Extremities",
            "Upper Extremities"});
            this.cbSort.ListBackColor = System.Drawing.Color.White;
            this.cbSort.ListTextColor = System.Drawing.Color.Black;
            this.cbSort.Location = new System.Drawing.Point(100, 374);
            this.cbSort.Margin = new System.Windows.Forms.Padding(100, 3, 100, 3);
            this.cbSort.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbSort.Name = "cbSort";
            this.cbSort.Padding = new System.Windows.Forms.Padding(1);
            this.cbSort.Size = new System.Drawing.Size(325, 48);
            this.cbSort.TabIndex = 15;
            this.cbSort.Texts = "Select body group";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.customButton1);
            this.flowLayoutPanel2.Controls.Add(this.customButton2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 455);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(519, 100);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.customButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.customButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customButton1.BorderRadius = 10;
            this.customButton1.BorderSize = 0;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customButton1.Location = new System.Drawing.Point(3, 3);
            this.customButton1.Name = "customButton1";
            this.customButton1.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
            this.customButton1.Size = new System.Drawing.Size(253, 51);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "Start Session";
            this.customButton1.TextColor = System.Drawing.Color.White;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(251)))), ((int)(((byte)(237)))));
            this.customButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(251)))), ((int)(((byte)(237)))));
            this.customButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(134)))), ((int)(((byte)(105)))));
            this.customButton2.BorderRadius = 10;
            this.customButton2.BorderSize = 1;
            this.customButton2.FlatAppearance.BorderSize = 0;
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(134)))), ((int)(((byte)(105)))));
            this.customButton2.Image = ((System.Drawing.Image)(resources.GetObject("customButton2.Image")));
            this.customButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customButton2.Location = new System.Drawing.Point(262, 3);
            this.customButton2.Name = "customButton2";
            this.customButton2.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
            this.customButton2.Size = new System.Drawing.Size(253, 51);
            this.customButton2.TabIndex = 1;
            this.customButton2.Text = "Patient Selection";
            this.customButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(134)))), ((int)(((byte)(105)))));
            this.customButton2.UseVisualStyleBackColor = false;
            // 
            // NewAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1205, 689);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewAssessmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewAssessmentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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