namespace Kinesia.Assessment
{
    partial class ManualAddROM
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
            label1 = new System.Windows.Forms.Label();
            txtInitialROM = new CustomControls.RJControls.RJTextBox();
            txtEndROM = new CustomControls.RJControls.RJTextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cbMovement = new CustomControls.RJControls.RJComboBox();
            cbMotionType = new CustomControls.RJControls.RJComboBox();
            txtSubjective = new CustomControls.RJControls.RJTextBox();
            label5 = new System.Windows.Forms.Label();
            txtObjective = new CustomControls.RJControls.RJTextBox();
            label6 = new System.Windows.Forms.Label();
            txtDeviation = new CustomControls.RJControls.RJTextBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            btnCancel = new OrganizationProfile.CustomButton();
            btnSave = new OrganizationProfile.CustomButton();
            btnClose = new OrganizationProfile.CustomButton();
            txtGoniometer = new CustomControls.RJControls.RJTextBox();
            label9 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(52, 146);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 23);
            label1.TabIndex = 0;
            label1.Text = "Initial ROM";
            // 
            // txtInitialROM
            // 
            txtInitialROM.BackColor = System.Drawing.Color.White;
            txtInitialROM.BorderColor = System.Drawing.Color.Black;
            txtInitialROM.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtInitialROM.BorderRadius = 5;
            txtInitialROM.BorderSize = 1;
            txtInitialROM.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtInitialROM.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtInitialROM.Location = new System.Drawing.Point(52, 173);
            txtInitialROM.Margin = new System.Windows.Forms.Padding(4);
            txtInitialROM.Multiline = false;
            txtInitialROM.Name = "txtInitialROM";
            txtInitialROM.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtInitialROM.PasswordChar = false;
            txtInitialROM.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtInitialROM.PlaceholderText = "";
            txtInitialROM.SelectionLength = 0;
            txtInitialROM.SelectionStart = 0;
            txtInitialROM.Size = new System.Drawing.Size(250, 41);
            txtInitialROM.TabIndex = 1;
            txtInitialROM.Texts = "";
            txtInitialROM.UnderlinedStyle = false;
            txtInitialROM.KeyPress += txtInitialROM_KeyPress;
            // 
            // txtEndROM
            // 
            txtEndROM.BackColor = System.Drawing.Color.White;
            txtEndROM.BorderColor = System.Drawing.Color.Black;
            txtEndROM.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtEndROM.BorderRadius = 5;
            txtEndROM.BorderSize = 1;
            txtEndROM.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtEndROM.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtEndROM.Location = new System.Drawing.Point(347, 173);
            txtEndROM.Margin = new System.Windows.Forms.Padding(4);
            txtEndROM.Multiline = false;
            txtEndROM.Name = "txtEndROM";
            txtEndROM.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtEndROM.PasswordChar = false;
            txtEndROM.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtEndROM.PlaceholderText = "";
            txtEndROM.SelectionLength = 0;
            txtEndROM.SelectionStart = 0;
            txtEndROM.Size = new System.Drawing.Size(250, 41);
            txtEndROM.TabIndex = 3;
            txtEndROM.Texts = "";
            txtEndROM.UnderlinedStyle = false;
            txtEndROM.KeyPress += txtEndROM_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(347, 146);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 23);
            label2.TabIndex = 2;
            label2.Text = "End ROM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(347, 241);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92, 23);
            label3.TabIndex = 5;
            label3.Text = "Motion Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(52, 241);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 23);
            label4.TabIndex = 4;
            label4.Text = "Movement";
            // 
            // cbMovement
            // 
            cbMovement.AutoCompleteCustomSource.AddRange(new string[] { "Flexion" });
            cbMovement.BackColor = System.Drawing.Color.White;
            cbMovement.BorderColor = System.Drawing.Color.Black;
            cbMovement.BorderSize = 1;
            cbMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbMovement.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbMovement.ForeColor = System.Drawing.Color.DimGray;
            cbMovement.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            cbMovement.ListBackColor = System.Drawing.Color.White;
            cbMovement.ListTextColor = System.Drawing.Color.Black;
            cbMovement.Location = new System.Drawing.Point(52, 267);
            cbMovement.MinimumSize = new System.Drawing.Size(200, 30);
            cbMovement.Name = "cbMovement";
            cbMovement.Padding = new System.Windows.Forms.Padding(1);
            cbMovement.Size = new System.Drawing.Size(250, 41);
            cbMovement.TabIndex = 6;
            cbMovement.Texts = "";
            // 
            // cbMotionType
            // 
            cbMotionType.BackColor = System.Drawing.Color.White;
            cbMotionType.BorderColor = System.Drawing.Color.Black;
            cbMotionType.BorderSize = 1;
            cbMotionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbMotionType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbMotionType.ForeColor = System.Drawing.Color.DimGray;
            cbMotionType.IconColor = System.Drawing.Color.FromArgb(18, 90, 211);
            cbMotionType.Items.AddRange(new object[] { "Active", "Passive" });
            cbMotionType.ListBackColor = System.Drawing.Color.White;
            cbMotionType.ListTextColor = System.Drawing.Color.Black;
            cbMotionType.Location = new System.Drawing.Point(347, 267);
            cbMotionType.MinimumSize = new System.Drawing.Size(200, 30);
            cbMotionType.Name = "cbMotionType";
            cbMotionType.Padding = new System.Windows.Forms.Padding(1);
            cbMotionType.Size = new System.Drawing.Size(250, 41);
            cbMotionType.TabIndex = 7;
            cbMotionType.Texts = "";
            // 
            // txtSubjective
            // 
            txtSubjective.BackColor = System.Drawing.Color.White;
            txtSubjective.BorderColor = System.Drawing.Color.Black;
            txtSubjective.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtSubjective.BorderRadius = 5;
            txtSubjective.BorderSize = 1;
            txtSubjective.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSubjective.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSubjective.Location = new System.Drawing.Point(53, 369);
            txtSubjective.Margin = new System.Windows.Forms.Padding(4);
            txtSubjective.Multiline = true;
            txtSubjective.Name = "txtSubjective";
            txtSubjective.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtSubjective.PasswordChar = false;
            txtSubjective.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSubjective.PlaceholderText = "";
            txtSubjective.SelectionLength = 0;
            txtSubjective.SelectionStart = 0;
            txtSubjective.Size = new System.Drawing.Size(545, 70);
            txtSubjective.TabIndex = 9;
            txtSubjective.Texts = "";
            txtSubjective.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(53, 342);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(154, 23);
            label5.TabIndex = 8;
            label5.Text = "Subjective (Optional)";
            // 
            // txtObjective
            // 
            txtObjective.BackColor = System.Drawing.Color.White;
            txtObjective.BorderColor = System.Drawing.Color.Black;
            txtObjective.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtObjective.BorderRadius = 5;
            txtObjective.BorderSize = 1;
            txtObjective.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtObjective.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtObjective.Location = new System.Drawing.Point(52, 502);
            txtObjective.Margin = new System.Windows.Forms.Padding(4);
            txtObjective.Multiline = true;
            txtObjective.Name = "txtObjective";
            txtObjective.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtObjective.PasswordChar = false;
            txtObjective.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtObjective.PlaceholderText = "";
            txtObjective.SelectionLength = 0;
            txtObjective.SelectionStart = 0;
            txtObjective.Size = new System.Drawing.Size(545, 70);
            txtObjective.TabIndex = 11;
            txtObjective.Texts = "";
            txtObjective.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(52, 475);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(147, 23);
            label6.TabIndex = 10;
            label6.Text = "Objective (Optional)";
            // 
            // txtDeviation
            // 
            txtDeviation.BackColor = System.Drawing.Color.White;
            txtDeviation.BorderColor = System.Drawing.Color.Black;
            txtDeviation.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtDeviation.BorderRadius = 5;
            txtDeviation.BorderSize = 1;
            txtDeviation.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtDeviation.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtDeviation.Location = new System.Drawing.Point(53, 635);
            txtDeviation.Margin = new System.Windows.Forms.Padding(4);
            txtDeviation.Multiline = false;
            txtDeviation.Name = "txtDeviation";
            txtDeviation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtDeviation.PasswordChar = false;
            txtDeviation.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtDeviation.PlaceholderText = "";
            txtDeviation.SelectionLength = 0;
            txtDeviation.SelectionStart = 0;
            txtDeviation.Size = new System.Drawing.Size(544, 41);
            txtDeviation.TabIndex = 13;
            txtDeviation.Texts = "";
            txtDeviation.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(53, 608);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 23);
            label7.TabIndex = 12;
            label7.Text = "Deviation";
            // 
            // label8
            // 
            label8.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label8.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            label8.Location = new System.Drawing.Point(39, 22);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(194, 49);
            label8.TabIndex = 23;
            label8.Text = "Goniometer";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnCancel.BorderColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderSize = 1;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnCancel.Image = Properties.Resources.redCancelBtn;
            btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCancel.Location = new System.Drawing.Point(425, 714);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new System.Windows.Forms.Padding(12, 5, 47, 0);
            btnCancel.Size = new System.Drawing.Size(172, 58);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnCancel.TextColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSave.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSave.BorderColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSave.BorderRadius = 10;
            btnSave.BorderSize = 1;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Image = Properties.Resources.whiteSve;
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSave.Location = new System.Drawing.Point(243, 714);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Padding = new System.Windows.Forms.Padding(12, 5, 50, 0);
            btnSave.Size = new System.Drawing.Size(172, 58);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save";
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSave.TextColor = System.Drawing.Color.White;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.newSmallClose;
            btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnClose.BorderRadius = 15;
            btnClose.BorderSize = 0;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.Transparent;
            btnClose.Location = new System.Drawing.Point(559, 31);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(39, 30);
            btnClose.TabIndex = 26;
            btnClose.TextColor = System.Drawing.Color.Transparent;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // txtGoniometer
            // 
            txtGoniometer.BackColor = System.Drawing.Color.White;
            txtGoniometer.BorderColor = System.Drawing.Color.Black;
            txtGoniometer.BorderFocusColor = System.Drawing.Color.FromArgb(18, 90, 211);
            txtGoniometer.BorderRadius = 5;
            txtGoniometer.BorderSize = 1;
            txtGoniometer.Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtGoniometer.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtGoniometer.Location = new System.Drawing.Point(52, 98);
            txtGoniometer.Margin = new System.Windows.Forms.Padding(4);
            txtGoniometer.Multiline = false;
            txtGoniometer.Name = "txtGoniometer";
            txtGoniometer.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            txtGoniometer.PasswordChar = false;
            txtGoniometer.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtGoniometer.PlaceholderText = "";
            txtGoniometer.SelectionLength = 0;
            txtGoniometer.SelectionStart = 0;
            txtGoniometer.Size = new System.Drawing.Size(545, 41);
            txtGoniometer.TabIndex = 28;
            txtGoniometer.Texts = "";
            txtGoniometer.UnderlinedStyle = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(52, 71);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(126, 23);
            label9.TabIndex = 27;
            label9.Text = "Goniometer Type";
            // 
            // ManualAddROM
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(659, 797);
            Controls.Add(txtGoniometer);
            Controls.Add(label9);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label8);
            Controls.Add(txtDeviation);
            Controls.Add(label7);
            Controls.Add(txtObjective);
            Controls.Add(label6);
            Controls.Add(txtSubjective);
            Controls.Add(label5);
            Controls.Add(cbMotionType);
            Controls.Add(cbMovement);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtEndROM);
            Controls.Add(label2);
            Controls.Add(txtInitialROM);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ManualAddROM";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ManualPopup";
            Load += ManualAddROM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtInitialROM;
        private CustomControls.RJControls.RJTextBox txtEndROM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.RJControls.RJComboBox cbMovement;
        private CustomControls.RJControls.RJComboBox cbMotionType;
        private CustomControls.RJControls.RJTextBox txtSubjective;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtObjective;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJTextBox txtDeviation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private OrganizationProfile.CustomButton btnCancel;
        private OrganizationProfile.CustomButton btnSave;
        private OrganizationProfile.CustomButton btnClose;
        private CustomControls.RJControls.RJTextBox txtGoniometer;
        private System.Windows.Forms.Label label9;
    }
}