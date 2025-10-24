

using System.Drawing;
using System.Windows.Forms;

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
            flowLayoutPanel1 = new FlowLayoutPanel();
            cmbMovementSelection = new CustomControls.RJControls.RJComboBox();
            btnStartStopMeasurement = new OrganizationProfile.CustomButton();
            lblStartingPositionValue = new Label();
            lblRomValue = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSaveROM = new OrganizationProfile.CustomButton();
            label4 = new Label();
            lblExtremity = new Label();
            label5 = new Label();
            lblJoint = new Label();
            label6 = new Label();
            lblJointSide = new Label();
            label7 = new Label();
            lblMotionType = new Label();
            label8 = new Label();
            lblNormalRange = new Label();
            lblDeficit = new Label();
            label10 = new Label();
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
            flowLayoutPanel1.Controls.Add(cmbMovementSelection);
            flowLayoutPanel1.Controls.Add(btnStartStopMeasurement);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(468, 481);
            flowLayoutPanel1.TabIndex = 2;
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
            cmbMovementSelection.Location = new Point(3, 382);
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
            btnStartStopMeasurement.Location = new Point(3, 421);
            btnStartStopMeasurement.Name = "btnStartStopMeasurement";
            btnStartStopMeasurement.Size = new Size(462, 49);
            btnStartStopMeasurement.TabIndex = 7;
            btnStartStopMeasurement.Text = "Start Measurement";
            btnStartStopMeasurement.TextColor = Color.Transparent;
            btnStartStopMeasurement.UseVisualStyleBackColor = false;
            btnStartStopMeasurement.Click += btnStartStopMeasurement_Click;
            // 
            // lblStartingPositionValue
            // 
            lblStartingPositionValue.AutoSize = true;
            lblStartingPositionValue.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartingPositionValue.Location = new Point(671, 236);
            lblStartingPositionValue.Name = "lblStartingPositionValue";
            lblStartingPositionValue.Size = new Size(0, 34);
            lblStartingPositionValue.TabIndex = 8;
            lblStartingPositionValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRomValue
            // 
            lblRomValue.AutoSize = true;
            lblRomValue.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRomValue.Location = new Point(555, 286);
            lblRomValue.Name = "lblRomValue";
            lblRomValue.Size = new Size(0, 34);
            lblRomValue.TabIndex = 9;
            lblRomValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(18, 90, 211);
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
            label2.Font = new Font("Poppins", 14.25F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(486, 236);
            label2.Name = "label2";
            label2.Size = new Size(173, 34);
            label2.TabIndex = 11;
            label2.Text = "Starting Position:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 14.25F);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(485, 286);
            label3.Name = "label3";
            label3.Size = new Size(63, 34);
            label3.TabIndex = 12;
            label3.Text = "Rom:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSaveROM
            // 
            btnSaveROM.BackColor = Color.FromArgb(18, 90, 211);
            btnSaveROM.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnSaveROM.BorderColor = Color.PaleVioletRed;
            btnSaveROM.BorderRadius = 10;
            btnSaveROM.BorderSize = 0;
            btnSaveROM.FlatAppearance.BorderSize = 0;
            btnSaveROM.FlatStyle = FlatStyle.Flat;
            btnSaveROM.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveROM.ForeColor = Color.Transparent;
            btnSaveROM.Location = new Point(588, 538);
            btnSaveROM.Name = "btnSaveROM";
            btnSaveROM.Size = new Size(325, 49);
            btnSaveROM.TabIndex = 8;
            btnSaveROM.Text = "Save ROM";
            btnSaveROM.TextColor = Color.Transparent;
            btnSaveROM.UseVisualStyleBackColor = false;
            btnSaveROM.Click += btnSaveROM_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 14.25F);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(486, 71);
            label4.Name = "label4";
            label4.Size = new Size(107, 34);
            label4.TabIndex = 13;
            label4.Text = "Extremity:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblExtremity
            // 
            lblExtremity.AutoSize = true;
            lblExtremity.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExtremity.ForeColor = Color.Black;
            lblExtremity.Location = new Point(712, 71);
            lblExtremity.Name = "lblExtremity";
            lblExtremity.Size = new Size(130, 34);
            lblExtremity.TabIndex = 14;
            lblExtremity.Text = "<Extremity>";
            lblExtremity.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 14.25F);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(486, 111);
            label5.Name = "label5";
            label5.Size = new Size(65, 34);
            label5.TabIndex = 15;
            label5.Text = "Joint:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblJoint
            // 
            lblJoint.AutoSize = true;
            lblJoint.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJoint.ForeColor = Color.Black;
            lblJoint.Location = new Point(712, 111);
            lblJoint.Name = "lblJoint";
            lblJoint.Size = new Size(85, 34);
            lblJoint.TabIndex = 16;
            lblJoint.Text = "<Joint>";
            lblJoint.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 14.25F);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(486, 154);
            label6.Name = "label6";
            label6.Size = new Size(111, 34);
            label6.TabIndex = 17;
            label6.Text = "Joint Side:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblJointSide
            // 
            lblJointSide.AutoSize = true;
            lblJointSide.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJointSide.ForeColor = Color.Black;
            lblJointSide.Location = new Point(712, 154);
            lblJointSide.Name = "lblJointSide";
            lblJointSide.Size = new Size(132, 34);
            lblJointSide.TabIndex = 18;
            lblJointSide.Text = "<Joint Side>";
            lblJointSide.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins", 14.25F);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(486, 193);
            label7.Name = "label7";
            label7.Size = new Size(134, 34);
            label7.TabIndex = 19;
            label7.Text = "Motion Type:";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMotionType
            // 
            lblMotionType.AutoSize = true;
            lblMotionType.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMotionType.ForeColor = Color.Black;
            lblMotionType.Location = new Point(712, 193);
            lblMotionType.Name = "lblMotionType";
            lblMotionType.Size = new Size(78, 34);
            lblMotionType.TabIndex = 20;
            lblMotionType.Text = "Active";
            lblMotionType.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Poppins", 14.25F);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(486, 329);
            label8.Name = "label8";
            label8.Size = new Size(156, 34);
            label8.TabIndex = 21;
            label8.Text = "Normal Range:";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNormalRange
            // 
            lblNormalRange.AutoSize = true;
            lblNormalRange.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNormalRange.ForeColor = Color.Black;
            lblNormalRange.Location = new Point(712, 329);
            lblNormalRange.Name = "lblNormalRange";
            lblNormalRange.Size = new Size(175, 34);
            lblNormalRange.TabIndex = 22;
            lblNormalRange.Text = "<Normal Range>";
            lblNormalRange.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDeficit
            // 
            lblDeficit.AutoSize = true;
            lblDeficit.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeficit.ForeColor = Color.Black;
            lblDeficit.Location = new Point(712, 372);
            lblDeficit.Name = "lblDeficit";
            lblDeficit.Size = new Size(99, 34);
            lblDeficit.TabIndex = 24;
            lblDeficit.Text = "<Deficit>";
            lblDeficit.TextAlign = ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Poppins", 14.25F);
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(486, 372);
            label10.Name = "label10";
            label10.Size = new Size(79, 34);
            label10.TabIndex = 23;
            label10.Text = "Deficit:";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // AssessmentROM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1061, 599);
            Controls.Add(lblDeficit);
            Controls.Add(label10);
            Controls.Add(lblNormalRange);
            Controls.Add(label8);
            Controls.Add(lblMotionType);
            Controls.Add(label7);
            Controls.Add(lblJointSide);
            Controls.Add(label6);
            Controls.Add(lblJoint);
            Controls.Add(label5);
            Controls.Add(lblExtremity);
            Controls.Add(label4);
            Controls.Add(btnSaveROM);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblRomValue);
            Controls.Add(lblStartingPositionValue);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssessmentROM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssessmentROM";
            TopMost = true;
            Load += AssessmentROM_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRgb).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxRgb;
        private FlowLayoutPanel flowLayoutPanel1;
        private CustomControls.RJControls.RJComboBox cmbMovementSelection;
        private OrganizationProfile.CustomButton btnStartStopMeasurement;
        private Label lblStartingPositionValue;
        private Label lblRomValue;
        private Label label1;
        private Label label2;
        private Label label3;
        private OrganizationProfile.CustomButton btnSaveROM;
        private Label label4;
        private Label lblExtremity;
        private Label label5;
        private Label lblJoint;
        private Label label6;
        private Label lblJointSide;
        private Label label7;
        private Label lblMotionType;
        private Label label8;
        private Label lblNormalRange;
        private Label lblDeficit;
        private Label label10;
    }
}