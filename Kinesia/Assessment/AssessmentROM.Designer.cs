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
            pictureBoxRgb = new PictureBox();
            btnCapture = new OrganizationProfile.CustomButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblStatus = new Label();
            cmbLimbSelection = new CustomControls.RJControls.RJComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxRgb
            // 
            pictureBoxRgb.Location = new Point(3, 51);
            pictureBoxRgb.Name = "pictureBoxRgb";
            pictureBoxRgb.Size = new Size(462, 373);
            pictureBoxRgb.TabIndex = 0;
            pictureBoxRgb.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.FromArgb(18, 90, 211);
            btnCapture.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnCapture.BorderColor = Color.PaleVioletRed;
            btnCapture.BorderRadius = 10;
            btnCapture.BorderSize = 0;
            btnCapture.FlatAppearance.BorderSize = 0;
            btnCapture.FlatStyle = FlatStyle.Flat;
            btnCapture.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapture.ForeColor = Color.Transparent;
            btnCapture.Location = new Point(3, 469);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(462, 49);
            btnCapture.TabIndex = 1;
            btnCapture.Text = "Capture";
            btnCapture.TextColor = Color.Transparent;
            btnCapture.UseVisualStyleBackColor = false;
            btnCapture.Click += btnCapture_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblStatus);
            flowLayoutPanel1.Controls.Add(pictureBoxRgb);
            flowLayoutPanel1.Controls.Add(cmbLimbSelection);
            flowLayoutPanel1.Controls.Add(btnCapture);
            flowLayoutPanel1.Location = new Point(240, 45);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(468, 525);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new Font("Poppins", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(3, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(99, 48);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "label1";
            lblStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // cmbLimbSelection
            // 
            cmbLimbSelection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbLimbSelection.BackColor = Color.White;
            cmbLimbSelection.BorderColor = Color.FromArgb(18, 90, 211);
            cmbLimbSelection.BorderSize = 1;
            cmbLimbSelection.DropDownStyle = ComboBoxStyle.DropDown;
            cmbLimbSelection.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbLimbSelection.ForeColor = Color.DimGray;
            cmbLimbSelection.IconColor = Color.FromArgb(18, 90, 211);
            cmbLimbSelection.Items.AddRange(new object[] { "Left Arm", "Right Arm" });
            cmbLimbSelection.ListBackColor = Color.White;
            cmbLimbSelection.ListTextColor = Color.Black;
            cmbLimbSelection.Location = new Point(3, 430);
            cmbLimbSelection.MinimumSize = new Size(200, 30);
            cmbLimbSelection.Name = "cmbLimbSelection";
            cmbLimbSelection.Padding = new Padding(1);
            cmbLimbSelection.Size = new Size(462, 33);
            cmbLimbSelection.TabIndex = 4;
            cmbLimbSelection.Texts = "Select body part";
            cmbLimbSelection.OnSelectedIndexChanged += cmbLimbSelection_OnSelectedIndexChanged;
            // 
            // AssessmentROM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 618);
            ControlBox = false;
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssessmentROM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssessmentROM";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBoxRgb;
        private OrganizationProfile.CustomButton btnCapture;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblStatus;
        private CustomControls.RJControls.RJComboBox cmbLimbSelection;
    }
}