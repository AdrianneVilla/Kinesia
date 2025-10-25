

using System.Drawing;
using System.Windows.Forms;

namespace Kinesia.Offline
{
    partial class AssessmentROMOffline
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            cmbLimbSelection = new CustomControls.RJControls.RJComboBox();
            cmbJointSelection = new CustomControls.RJControls.RJComboBox();
            cmbMovementSelection = new CustomControls.RJControls.RJComboBox();
            btnStartStopMeasurement = new OrganizationProfile.CustomButton();
            lblStartingPosition = new Label();
            lblROM = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSaveAssessment = new OrganizationProfile.CustomButton();
            label4 = new Label();
            lblNormalRange = new Label();
            label5 = new Label();
            lblDeficit = new Label();
            label6 = new Label();
            lblMotionType = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxRgb
            // 
            pictureBoxRgb.Location = new Point(3, 3);
            pictureBoxRgb.Name = "pictureBoxRgb";
            pictureBoxRgb.Size = new Size(462, 373);
            pictureBoxRgb.TabIndex = 0;
            pictureBoxRgb.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pictureBoxRgb);
            flowLayoutPanel1.Controls.Add(cmbLimbSelection);
            flowLayoutPanel1.Controls.Add(cmbJointSelection);
            flowLayoutPanel1.Controls.Add(cmbMovementSelection);
            flowLayoutPanel1.Controls.Add(btnStartStopMeasurement);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(468, 562);
            flowLayoutPanel1.TabIndex = 2;
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
            cmbLimbSelection.Location = new Point(3, 382);
            cmbLimbSelection.MinimumSize = new Size(200, 30);
            cmbLimbSelection.Name = "cmbLimbSelection";
            cmbLimbSelection.Padding = new Padding(1);
            cmbLimbSelection.Size = new Size(462, 33);
            cmbLimbSelection.TabIndex = 4;
            cmbLimbSelection.Texts = "Select body part";
            cmbLimbSelection.OnSelectedIndexChanged += cmbLimbSelection_SelectedIndexChanged;
            // 
            // cmbJointSelection
            // 
            cmbJointSelection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbJointSelection.BackColor = Color.White;
            cmbJointSelection.BorderColor = Color.FromArgb(18, 90, 211);
            cmbJointSelection.BorderSize = 1;
            cmbJointSelection.DropDownStyle = ComboBoxStyle.DropDown;
            cmbJointSelection.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbJointSelection.ForeColor = Color.DimGray;
            cmbJointSelection.IconColor = Color.FromArgb(18, 90, 211);
            cmbJointSelection.Items.AddRange(new object[] { "Left Arm", "Right Arm" });
            cmbJointSelection.ListBackColor = Color.White;
            cmbJointSelection.ListTextColor = Color.Black;
            cmbJointSelection.Location = new Point(3, 421);
            cmbJointSelection.MinimumSize = new Size(200, 30);
            cmbJointSelection.Name = "cmbJointSelection";
            cmbJointSelection.Padding = new Padding(1);
            cmbJointSelection.Size = new Size(462, 33);
            cmbJointSelection.TabIndex = 5;
            cmbJointSelection.Texts = "Select joint";
            cmbJointSelection.OnSelectedIndexChanged += cmbJointSelection_SelectedIndexChanged;
            // 
            // cmbMovementSelection
            // 
            cmbMovementSelection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbMovementSelection.BackColor = Color.White;
            cmbMovementSelection.BorderColor = Color.FromArgb(18, 90, 211);
            cmbMovementSelection.BorderSize = 1;
            cmbMovementSelection.DropDownStyle = ComboBoxStyle.DropDown;
            cmbMovementSelection.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMovementSelection.ForeColor = Color.DimGray;
            cmbMovementSelection.IconColor = Color.FromArgb(18, 90, 211);
            cmbMovementSelection.Items.AddRange(new object[] { "Left Arm", "Right Arm" });
            cmbMovementSelection.ListBackColor = Color.White;
            cmbMovementSelection.ListTextColor = Color.Black;
            cmbMovementSelection.Location = new Point(3, 460);
            cmbMovementSelection.MinimumSize = new Size(200, 30);
            cmbMovementSelection.Name = "cmbMovementSelection";
            cmbMovementSelection.Padding = new Padding(1);
            cmbMovementSelection.Size = new Size(462, 33);
            cmbMovementSelection.TabIndex = 6;
            cmbMovementSelection.Texts = "Select movement";
            cmbMovementSelection.OnSelectedIndexChanged += cmbMovementSelection_SelectedIndexChanged;
            // 
            // btnStartStopMeasurement
            // 
            btnStartStopMeasurement.BackColor = Color.FromArgb(18, 90, 211);
            btnStartStopMeasurement.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnStartStopMeasurement.BorderColor = Color.PaleVioletRed;
            btnStartStopMeasurement.BorderRadius = 10;
            btnStartStopMeasurement.BorderSize = 0;
            btnStartStopMeasurement.FlatAppearance.BorderSize = 0;
            btnStartStopMeasurement.FlatStyle = FlatStyle.Flat;
            btnStartStopMeasurement.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStartStopMeasurement.ForeColor = Color.Transparent;
            btnStartStopMeasurement.Location = new Point(3, 499);
            btnStartStopMeasurement.Name = "btnStartStopMeasurement";
            btnStartStopMeasurement.Size = new Size(462, 49);
            btnStartStopMeasurement.TabIndex = 7;
            btnStartStopMeasurement.Text = "Start Measurement";
            btnStartStopMeasurement.TextColor = Color.Transparent;
            btnStartStopMeasurement.UseVisualStyleBackColor = false;
            btnStartStopMeasurement.Click += btnStartStopMeasurement_Click;
            // 
            // lblStartingPosition
            // 
            lblStartingPosition.AutoSize = true;
            lblStartingPosition.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartingPosition.Location = new Point(677, 66);
            lblStartingPosition.Name = "lblStartingPosition";
            lblStartingPosition.Size = new Size(200, 34);
            lblStartingPosition.TabIndex = 8;
            lblStartingPosition.Text = "<Starting Position>";
            lblStartingPosition.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblROM
            // 
            lblROM.AutoSize = true;
            lblROM.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblROM.Location = new Point(588, 114);
            lblROM.Name = "lblROM";
            lblROM.Size = new Size(79, 34);
            lblROM.TabIndex = 9;
            lblROM.Text = "<ROM>";
            lblROM.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(486, 12);
            label1.Name = "label1";
            label1.Size = new Size(224, 40);
            label1.TabIndex = 10;
            label1.Text = "ROM Information:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(486, 66);
            label2.Name = "label2";
            label2.Size = new Size(185, 34);
            label2.TabIndex = 11;
            label2.Text = "Starting Position:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(486, 114);
            label3.Name = "label3";
            label3.Size = new Size(64, 34);
            label3.TabIndex = 12;
            label3.Text = "ROM:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSaveAssessment
            // 
            btnSaveAssessment.BackColor = Color.FromArgb(18, 90, 211);
            btnSaveAssessment.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnSaveAssessment.BorderColor = Color.PaleVioletRed;
            btnSaveAssessment.BorderRadius = 10;
            btnSaveAssessment.BorderSize = 0;
            btnSaveAssessment.FlatAppearance.BorderSize = 0;
            btnSaveAssessment.FlatStyle = FlatStyle.Flat;
            btnSaveAssessment.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAssessment.ForeColor = Color.Transparent;
            btnSaveAssessment.Location = new Point(576, 511);
            btnSaveAssessment.Name = "btnSaveAssessment";
            btnSaveAssessment.Size = new Size(325, 49);
            btnSaveAssessment.TabIndex = 8;
            btnSaveAssessment.Text = "Save Assessment";
            btnSaveAssessment.TextColor = Color.Transparent;
            btnSaveAssessment.UseVisualStyleBackColor = false;
            btnSaveAssessment.Click += btnSaveAssessment_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(486, 201);
            label4.Name = "label4";
            label4.Size = new Size(160, 34);
            label4.TabIndex = 13;
            label4.Text = "Normal Range:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNormalRange
            // 
            lblNormalRange.AutoSize = true;
            lblNormalRange.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNormalRange.Location = new Point(652, 201);
            lblNormalRange.Name = "lblNormalRange";
            lblNormalRange.Size = new Size(175, 34);
            lblNormalRange.TabIndex = 14;
            lblNormalRange.Text = "<Normal Range>";
            lblNormalRange.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(486, 244);
            label5.Name = "label5";
            label5.Size = new Size(84, 34);
            label5.TabIndex = 15;
            label5.Text = "Deficit:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDeficit
            // 
            lblDeficit.AutoSize = true;
            lblDeficit.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeficit.Location = new Point(576, 244);
            lblDeficit.Name = "lblDeficit";
            lblDeficit.Size = new Size(99, 34);
            lblDeficit.TabIndex = 16;
            lblDeficit.Text = "<Deficit>";
            lblDeficit.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(486, 158);
            label6.Name = "label6";
            label6.Size = new Size(140, 34);
            label6.TabIndex = 17;
            label6.Text = "Motion Type:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMotionType
            // 
            lblMotionType.AutoSize = true;
            lblMotionType.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMotionType.Location = new Point(652, 158);
            lblMotionType.Name = "lblMotionType";
            lblMotionType.Size = new Size(92, 34);
            lblMotionType.TabIndex = 18;
            lblMotionType.Text = "Passive";
            lblMotionType.TextAlign = ContentAlignment.TopCenter;
            // 
            // AssessmentROMOffline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 599);
            Controls.Add(lblMotionType);
            Controls.Add(label6);
            Controls.Add(lblDeficit);
            Controls.Add(label5);
            Controls.Add(lblNormalRange);
            Controls.Add(label4);
            Controls.Add(btnSaveAssessment);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblROM);
            Controls.Add(lblStartingPosition);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssessmentROMOffline";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssessmentROM";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxRgb;
        private FlowLayoutPanel flowLayoutPanel1;
        private CustomControls.RJControls.RJComboBox cmbLimbSelection;
        private CustomControls.RJControls.RJComboBox cmbJointSelection;
        private CustomControls.RJControls.RJComboBox cmbMovementSelection;
        private OrganizationProfile.CustomButton btnStartStopMeasurement;
        private Label lblStartingPosition;
        private Label lblROM;
        private Label label1;
        private Label label2;
        private Label label3;
        private OrganizationProfile.CustomButton btnSaveAssessment;
        private Label label4;
        private Label lblNormalRange;
        private Label label5;
        private Label lblDeficit;
        private Label label6;
        private Label lblMotionType;
    }
}