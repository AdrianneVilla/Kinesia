namespace Kinesia.Assessment
{
    partial class PatientAssessmentDetails
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
            panelPatientInformation = new WindowsFormsApp2.CustomButton.PanelBorder();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            label11 = new System.Windows.Forms.Label();
            cbExtremity = new CustomControls.RJControls.RJComboBox();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            label13 = new System.Windows.Forms.Label();
            cbJoint = new CustomControls.RJControls.RJComboBox();
            flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            label14 = new System.Windows.Forms.Label();
            cbJointSide = new CustomControls.RJControls.RJComboBox();
            label10 = new System.Windows.Forms.Label();
            lblPatientID = new System.Windows.Forms.Label();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            lblPatientName = new System.Windows.Forms.Label();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            lblAge = new System.Windows.Forms.Label();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            label8 = new System.Windows.Forms.Label();
            lblGender = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            panelPatientInformation.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // panelPatientInformation
            // 
            panelPatientInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panelPatientInformation.BackColor = System.Drawing.Color.White;
            panelPatientInformation.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelPatientInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelPatientInformation.BorderRadius = 30;
            panelPatientInformation.Color = System.Drawing.Color.BurlyWood;
            panelPatientInformation.Controls.Add(flowLayoutPanel6);
            panelPatientInformation.Controls.Add(label10);
            panelPatientInformation.Controls.Add(lblPatientID);
            panelPatientInformation.Controls.Add(flowLayoutPanel3);
            panelPatientInformation.Controls.Add(label12);
            panelPatientInformation.ForeColor = System.Drawing.Color.Black;
            panelPatientInformation.Location = new System.Drawing.Point(4, 10);
            panelPatientInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelPatientInformation.Name = "panelPatientInformation";
            panelPatientInformation.Size = new System.Drawing.Size(1457, 404);
            panelPatientInformation.TabIndex = 36;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel6.Location = new System.Drawing.Point(47, 266);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new System.Drawing.Size(1334, 90);
            flowLayoutPanel6.TabIndex = 25;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(label11);
            flowLayoutPanel7.Controls.Add(cbExtremity);
            flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new System.Drawing.Size(407, 81);
            flowLayoutPanel7.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(3, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(85, 26);
            label11.TabIndex = 1;
            label11.Text = "Extremity";
            // 
            // cbExtremity
            // 
            cbExtremity.BackColor = System.Drawing.Color.White;
            cbExtremity.BorderColor = System.Drawing.Color.Black;
            cbExtremity.BorderSize = 1;
            cbExtremity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbExtremity.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbExtremity.ForeColor = System.Drawing.Color.DimGray;
            cbExtremity.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            cbExtremity.Items.AddRange(new object[] { "Upper Extremity", "Lower Extremity" });
            cbExtremity.ListBackColor = System.Drawing.Color.White;
            cbExtremity.ListTextColor = System.Drawing.Color.Black;
            cbExtremity.Location = new System.Drawing.Point(3, 29);
            cbExtremity.MinimumSize = new System.Drawing.Size(200, 30);
            cbExtremity.Name = "cbExtremity";
            cbExtremity.Padding = new System.Windows.Forms.Padding(1);
            cbExtremity.Size = new System.Drawing.Size(316, 45);
            cbExtremity.TabIndex = 0;
            cbExtremity.Texts = "Select Extremity";
            cbExtremity.OnSelectedIndexChanged += cbExtremity_OnSelectedIndexChanged;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(label13);
            flowLayoutPanel8.Controls.Add(cbJoint);
            flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel8.Location = new System.Drawing.Point(416, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new System.Drawing.Size(405, 81);
            flowLayoutPanel8.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label13.Location = new System.Drawing.Point(3, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(51, 26);
            label13.TabIndex = 3;
            label13.Text = "Joint";
            // 
            // cbJoint
            // 
            cbJoint.BackColor = System.Drawing.Color.White;
            cbJoint.BorderColor = System.Drawing.Color.Black;
            cbJoint.BorderSize = 1;
            cbJoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbJoint.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbJoint.ForeColor = System.Drawing.Color.DimGray;
            cbJoint.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            cbJoint.ListBackColor = System.Drawing.Color.White;
            cbJoint.ListTextColor = System.Drawing.Color.Black;
            cbJoint.Location = new System.Drawing.Point(3, 29);
            cbJoint.MinimumSize = new System.Drawing.Size(200, 30);
            cbJoint.Name = "cbJoint";
            cbJoint.Padding = new System.Windows.Forms.Padding(1);
            cbJoint.Size = new System.Drawing.Size(316, 45);
            cbJoint.TabIndex = 2;
            cbJoint.Texts = "Select Joint";
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(label14);
            flowLayoutPanel9.Controls.Add(cbJointSide);
            flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel9.Location = new System.Drawing.Point(827, 3);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new System.Drawing.Size(420, 81);
            flowLayoutPanel9.TabIndex = 2;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label14.Location = new System.Drawing.Point(3, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(86, 26);
            label14.TabIndex = 5;
            label14.Text = "Joint Side";
            // 
            // cbJointSide
            // 
            cbJointSide.BackColor = System.Drawing.Color.White;
            cbJointSide.BorderColor = System.Drawing.Color.Black;
            cbJointSide.BorderSize = 1;
            cbJointSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbJointSide.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbJointSide.ForeColor = System.Drawing.Color.DimGray;
            cbJointSide.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            cbJointSide.Items.AddRange(new object[] { "Right", "Left" });
            cbJointSide.ListBackColor = System.Drawing.Color.White;
            cbJointSide.ListTextColor = System.Drawing.Color.Black;
            cbJointSide.Location = new System.Drawing.Point(3, 29);
            cbJointSide.MinimumSize = new System.Drawing.Size(200, 30);
            cbJointSide.Name = "cbJointSide";
            cbJointSide.Padding = new System.Windows.Forms.Padding(1);
            cbJointSide.Size = new System.Drawing.Size(316, 45);
            cbJointSide.TabIndex = 4;
            cbJointSide.Texts = "Select Joint Side";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(53, 210);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(187, 34);
            label10.TabIndex = 24;
            label10.Text = "Joint Information";
            // 
            // lblPatientID
            // 
            lblPatientID.AutoSize = true;
            lblPatientID.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold);
            lblPatientID.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblPatientID.Location = new System.Drawing.Point(288, 28);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new System.Drawing.Size(131, 34);
            lblPatientID.TabIndex = 22;
            lblPatientID.Text = "<Patient ID>";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel3.Location = new System.Drawing.Point(47, 97);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(1347, 50);
            flowLayoutPanel3.TabIndex = 23;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(lblPatientName);
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(442, 37);
            flowLayoutPanel2.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.Gray;
            label4.Location = new System.Drawing.Point(3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(119, 26);
            label4.TabIndex = 20;
            label4.Text = "Patient Name:";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            lblPatientName.Location = new System.Drawing.Point(128, 0);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new System.Drawing.Size(131, 26);
            lblPatientName.TabIndex = 21;
            lblPatientName.Text = "<Patient Name>";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label6);
            flowLayoutPanel4.Controls.Add(lblAge);
            flowLayoutPanel4.Location = new System.Drawing.Point(451, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(442, 40);
            flowLayoutPanel4.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label6.ForeColor = System.Drawing.Color.Gray;
            label6.Location = new System.Drawing.Point(3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(46, 26);
            label6.TabIndex = 20;
            label6.Text = "Age:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            lblAge.Location = new System.Drawing.Point(55, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(58, 26);
            lblAge.TabIndex = 21;
            lblAge.Text = "<Age>";
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label8);
            flowLayoutPanel5.Controls.Add(lblGender);
            flowLayoutPanel5.Location = new System.Drawing.Point(899, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new System.Drawing.Size(442, 40);
            flowLayoutPanel5.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            label8.ForeColor = System.Drawing.Color.Gray;
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(67, 26);
            label8.TabIndex = 20;
            label8.Text = "Gender";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Bold);
            lblGender.Location = new System.Drawing.Point(76, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(83, 26);
            lblGender.TabIndex = 21;
            lblGender.Text = "<Gender>";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(47, 28);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(247, 34);
            label12.TabIndex = 19;
            label12.Text = "Personal Information of";
            // 
            // PatientAssessmentDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(panelPatientInformation);
            Name = "PatientAssessmentDetails";
            Size = new System.Drawing.Size(1465, 420);
            panelPatientInformation.ResumeLayout(false);
            panelPatientInformation.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelPatientInformation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label11;
        private CustomControls.RJControls.RJComboBox cbExtremity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label13;
        private CustomControls.RJControls.RJComboBox cbJoint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label14;
        private CustomControls.RJControls.RJComboBox cbJointSide;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPatientID;
    }
}
