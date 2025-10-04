namespace Kinesia.Assessment
{
    partial class AssessmentROM
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
            pictureBox1 = new PictureBox();
            customButton1 = new OrganizationProfile.CustomButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            rjComboBox1 = new CustomControls.RJControls.RJComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(462, 373);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            customButton1.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.Transparent;
            customButton1.Location = new Point(3, 469);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(462, 49);
            customButton1.TabIndex = 1;
            customButton1.Text = "Capture";
            customButton1.TextColor = Color.Transparent;
            customButton1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(rjComboBox1);
            flowLayoutPanel1.Controls.Add(customButton1);
            flowLayoutPanel1.Location = new Point(240, 45);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(468, 525);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 48);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // rjComboBox1
            // 
            rjComboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            rjComboBox1.BackColor = Color.White;
            rjComboBox1.BorderColor = Color.FromArgb(18, 90, 211);
            rjComboBox1.BorderSize = 1;
            rjComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rjComboBox1.ForeColor = Color.DimGray;
            rjComboBox1.IconColor = Color.FromArgb(18, 90, 211);
            rjComboBox1.Items.AddRange(new object[] { "Left Arm", "Right Arm" });
            rjComboBox1.ListBackColor = Color.White;
            rjComboBox1.ListTextColor = Color.Black;
            rjComboBox1.Location = new Point(3, 430);
            rjComboBox1.MinimumSize = new Size(200, 30);
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Padding = new Padding(1);
            rjComboBox1.Size = new Size(462, 33);
            rjComboBox1.TabIndex = 4;
            rjComboBox1.Texts = "Select body part";
            // 
            // AssessmentROM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 618);
            ControlBox = false;
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssessmentROM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssessmentROM";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private OrganizationProfile.CustomButton customButton1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
    }
}