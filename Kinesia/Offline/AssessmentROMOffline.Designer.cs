

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
            lblInitialROM = new Label();
            lblEndROM = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDeviation = new CustomControls.RJControls.RJTextBox();
            label7 = new Label();
            txtObjective = new CustomControls.RJControls.RJTextBox();
            label6 = new Label();
            txtSubjective = new CustomControls.RJControls.RJTextBox();
            label5 = new Label();
            cbMotionType = new CustomControls.RJControls.RJComboBox();
            label4 = new Label();
            btnSaveAssessment = new OrganizationProfile.CustomButton();
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
            // lblInitialROM
            // 
            lblInitialROM.AutoSize = true;
            lblInitialROM.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInitialROM.Location = new Point(618, 71);
            lblInitialROM.Name = "lblInitialROM";
            lblInitialROM.Size = new Size(0, 34);
            lblInitialROM.TabIndex = 8;
            lblInitialROM.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEndROM
            // 
            lblEndROM.AutoSize = true;
            lblEndROM.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndROM.Location = new Point(618, 114);
            lblEndROM.Name = "lblEndROM";
            lblEndROM.Size = new Size(0, 34);
            lblEndROM.TabIndex = 9;
            lblEndROM.TextAlign = ContentAlignment.TopCenter;
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
            label2.Location = new Point(486, 71);
            label2.Name = "label2";
            label2.Size = new Size(126, 34);
            label2.TabIndex = 11;
            label2.Text = "Initial ROM:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(486, 114);
            label3.Name = "label3";
            label3.Size = new Size(104, 34);
            label3.TabIndex = 12;
            label3.Text = "End ROM:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDeviation
            // 
            txtDeviation.BackColor = Color.White;
            txtDeviation.BorderColor = Color.Black;
            txtDeviation.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtDeviation.BorderRadius = 5;
            txtDeviation.BorderSize = 1;
            txtDeviation.Font = new Font("Poppins", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeviation.ForeColor = Color.FromArgb(64, 64, 64);
            txtDeviation.Location = new Point(487, 490);
            txtDeviation.Margin = new Padding(4);
            txtDeviation.Multiline = false;
            txtDeviation.Name = "txtDeviation";
            txtDeviation.Padding = new Padding(10, 7, 10, 7);
            txtDeviation.PasswordChar = false;
            txtDeviation.PlaceholderColor = Color.DarkGray;
            txtDeviation.PlaceholderText = "";
            txtDeviation.SelectionLength = 0;
            txtDeviation.SelectionStart = 0;
            txtDeviation.Size = new Size(544, 41);
            txtDeviation.TabIndex = 23;
            txtDeviation.Texts = "";
            txtDeviation.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(487, 463);
            label7.Name = "label7";
            label7.Size = new Size(74, 23);
            label7.TabIndex = 22;
            label7.Text = "Deviation";
            // 
            // txtObjective
            // 
            txtObjective.BackColor = Color.White;
            txtObjective.BorderColor = Color.Black;
            txtObjective.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtObjective.BorderRadius = 5;
            txtObjective.BorderSize = 1;
            txtObjective.Font = new Font("Poppins", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtObjective.ForeColor = Color.FromArgb(64, 64, 64);
            txtObjective.Location = new Point(486, 375);
            txtObjective.Margin = new Padding(4);
            txtObjective.Multiline = true;
            txtObjective.Name = "txtObjective";
            txtObjective.Padding = new Padding(10, 7, 10, 7);
            txtObjective.PasswordChar = false;
            txtObjective.PlaceholderColor = Color.DarkGray;
            txtObjective.PlaceholderText = "";
            txtObjective.SelectionLength = 0;
            txtObjective.SelectionStart = 0;
            txtObjective.Size = new Size(545, 70);
            txtObjective.TabIndex = 21;
            txtObjective.Texts = "";
            txtObjective.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(486, 348);
            label6.Name = "label6";
            label6.Size = new Size(147, 23);
            label6.TabIndex = 20;
            label6.Text = "Objective (Optional)";
            // 
            // txtSubjective
            // 
            txtSubjective.BackColor = Color.White;
            txtSubjective.BorderColor = Color.Black;
            txtSubjective.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtSubjective.BorderRadius = 5;
            txtSubjective.BorderSize = 1;
            txtSubjective.Font = new Font("Poppins", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSubjective.ForeColor = Color.FromArgb(64, 64, 64);
            txtSubjective.Location = new Point(486, 264);
            txtSubjective.Margin = new Padding(4);
            txtSubjective.Multiline = true;
            txtSubjective.Name = "txtSubjective";
            txtSubjective.Padding = new Padding(10, 7, 10, 7);
            txtSubjective.PasswordChar = false;
            txtSubjective.PlaceholderColor = Color.DarkGray;
            txtSubjective.PlaceholderText = "";
            txtSubjective.SelectionLength = 0;
            txtSubjective.SelectionStart = 0;
            txtSubjective.Size = new Size(545, 70);
            txtSubjective.TabIndex = 19;
            txtSubjective.Texts = "";
            txtSubjective.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(486, 237);
            label5.Name = "label5";
            label5.Size = new Size(154, 23);
            label5.TabIndex = 18;
            label5.Text = "Subjective (Optional)";
            // 
            // cbMotionType
            // 
            cbMotionType.BackColor = Color.White;
            cbMotionType.BorderColor = Color.Black;
            cbMotionType.BorderSize = 1;
            cbMotionType.DropDownStyle = ComboBoxStyle.DropDown;
            cbMotionType.Font = new Font("Segoe UI", 10F);
            cbMotionType.ForeColor = Color.DimGray;
            cbMotionType.IconColor = Color.FromArgb(18, 90, 211);
            cbMotionType.Items.AddRange(new object[] { "Active", "Passive" });
            cbMotionType.ListBackColor = Color.White;
            cbMotionType.ListTextColor = Color.Black;
            cbMotionType.Location = new Point(487, 184);
            cbMotionType.MinimumSize = new Size(200, 30);
            cbMotionType.Name = "cbMotionType";
            cbMotionType.Padding = new Padding(1);
            cbMotionType.Size = new Size(250, 41);
            cbMotionType.TabIndex = 17;
            cbMotionType.Texts = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(487, 158);
            label4.Name = "label4";
            label4.Size = new Size(92, 23);
            label4.TabIndex = 15;
            label4.Text = "Motion Type";
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
            btnSaveAssessment.Location = new Point(588, 538);
            btnSaveAssessment.Name = "btnSaveAssessment";
            btnSaveAssessment.Size = new Size(325, 49);
            btnSaveAssessment.TabIndex = 8;
            btnSaveAssessment.Text = "Save Assessment";
            btnSaveAssessment.TextColor = Color.Transparent;
            btnSaveAssessment.UseVisualStyleBackColor = false;
            // 
            // AssessmentROM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 599);
            ControlBox = false;
            Controls.Add(txtDeviation);
            Controls.Add(label7);
            Controls.Add(txtObjective);
            Controls.Add(label6);
            Controls.Add(txtSubjective);
            Controls.Add(btnSaveAssessment);
            Controls.Add(label5);
            Controls.Add(cbMotionType);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblEndROM);
            Controls.Add(lblInitialROM);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssessmentROM";
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
        private Label lblInitialROM;
        private Label lblEndROM;
        private Label label1;
        private Label label2;
        private Label label3;
        private CustomControls.RJControls.RJTextBox txtDeviation;
        private Label label7;
        private CustomControls.RJControls.RJTextBox txtObjective;
        private Label label6;
        private CustomControls.RJControls.RJTextBox txtSubjective;
        private Label label5;
        private CustomControls.RJControls.RJComboBox cbMotionType;
        private Label label4;
        private OrganizationProfile.CustomButton btnSaveAssessment;
    }
}