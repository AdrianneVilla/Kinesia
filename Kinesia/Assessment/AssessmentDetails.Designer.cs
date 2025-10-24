namespace Kinesia.Assessment
{
    partial class AssessmentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssessmentDetails));
            lblSelectedAssessment = new System.Windows.Forms.Label();
            titleNav = new System.Windows.Forms.Label();
            lblPatientID = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            lblAge = new System.Windows.Forms.Label();
            lblGender = new System.Windows.Forms.Label();
            lblExtremity = new System.Windows.Forms.Label();
            lblJoint = new System.Windows.Forms.Label();
            lblJointSide = new System.Windows.Forms.Label();
            lblAssessmentStatus = new System.Windows.Forms.Label();
            lblAssessmentDate = new System.Windows.Forms.Label();
            lblAssessmentEndDate = new System.Windows.Forms.Label();
            btnFinishAssessment = new OrganizationProfile.CustomButton();
            dataGridROM = new System.Windows.Forms.DataGridView();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            btnArchive = new OrganizationProfile.CustomButton();
            btnEdit = new OrganizationProfile.CustomButton();
            panelGraph = new System.Windows.Forms.Panel();
            romPlot = new ScottPlot.WinForms.FormsPlot();
            btnAddRom = new OrganizationProfile.CustomButton();
            btnBack = new OrganizationProfile.CustomButton();
            btnPrint = new OrganizationProfile.CustomButton();
            btnAll = new OrganizationProfile.CustomButton();
            btnFlexion = new OrganizationProfile.CustomButton();
            btnExtension = new OrganizationProfile.CustomButton();
            btnAbduction = new OrganizationProfile.CustomButton();
            btnAdduction = new OrganizationProfile.CustomButton();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridROM).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            panelGraph.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectedAssessment
            // 
            lblSelectedAssessment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSelectedAssessment.AutoSize = true;
            lblSelectedAssessment.BackColor = System.Drawing.Color.Transparent;
            lblSelectedAssessment.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            lblSelectedAssessment.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblSelectedAssessment.Location = new System.Drawing.Point(236, 36);
            lblSelectedAssessment.Margin = new System.Windows.Forms.Padding(0);
            lblSelectedAssessment.Name = "lblSelectedAssessment";
            lblSelectedAssessment.Size = new System.Drawing.Size(220, 48);
            lblSelectedAssessment.TabIndex = 34;
            lblSelectedAssessment.Text = "AssessmentID";
            lblSelectedAssessment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleNav
            // 
            titleNav.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            titleNav.AutoSize = true;
            titleNav.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleNav.ForeColor = System.Drawing.Color.DarkGray;
            titleNav.Location = new System.Drawing.Point(71, 44);
            titleNav.Margin = new System.Windows.Forms.Padding(0);
            titleNav.Name = "titleNav";
            titleNav.Size = new System.Drawing.Size(155, 36);
            titleNav.TabIndex = 33;
            titleNav.Text = "Assessment >";
            titleNav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientID
            // 
            lblPatientID.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPatientID.AutoSize = true;
            lblPatientID.BackColor = System.Drawing.Color.Transparent;
            lblPatientID.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            lblPatientID.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            lblPatientID.Location = new System.Drawing.Point(0, 0);
            lblPatientID.Margin = new System.Windows.Forms.Padding(0);
            lblPatientID.Name = "lblPatientID";
            lblPatientID.Size = new System.Drawing.Size(148, 48);
            lblPatientID.TabIndex = 35;
            lblPatientID.Text = "PatientID";
            lblPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(lblPatientID);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(btnFinishAssessment);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(71, 95);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(439, 393);
            flowLayoutPanel1.TabIndex = 36;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 51);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(413, 281);
            flowLayoutPanel2.TabIndex = 36;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label5);
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(label10);
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(label11);
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(label6);
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(200, 278);
            flowLayoutPanel3.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(3, 0);
            label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 23);
            label5.TabIndex = 3;
            label5.Text = "Age:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(3, 33);
            label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 23);
            label2.TabIndex = 0;
            label2.Text = "Gender:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(3, 66);
            label10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 23);
            label10.TabIndex = 4;
            label10.Text = "Extremity:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(3, 99);
            label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 23);
            label4.TabIndex = 2;
            label4.Text = "Joint";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(3, 132);
            label11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(80, 23);
            label11.TabIndex = 5;
            label11.Text = "Joint Side:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(3, 165);
            label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(142, 23);
            label3.TabIndex = 1;
            label3.Text = "Assessment Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(3, 198);
            label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(166, 23);
            label6.TabIndex = 7;
            label6.Text = "Assessment Start Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(3, 231);
            label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(158, 23);
            label1.TabIndex = 6;
            label1.Text = "Assessment End Date:";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(lblAge);
            flowLayoutPanel4.Controls.Add(lblGender);
            flowLayoutPanel4.Controls.Add(lblExtremity);
            flowLayoutPanel4.Controls.Add(lblJoint);
            flowLayoutPanel4.Controls.Add(lblJointSide);
            flowLayoutPanel4.Controls.Add(lblAssessmentStatus);
            flowLayoutPanel4.Controls.Add(lblAssessmentDate);
            flowLayoutPanel4.Controls.Add(lblAssessmentEndDate);
            flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel4.Location = new System.Drawing.Point(209, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(200, 278);
            flowLayoutPanel4.TabIndex = 38;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblAge.Location = new System.Drawing.Point(3, 0);
            lblAge.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(50, 23);
            lblAge.TabIndex = 4;
            lblAge.Text = "<Age>";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblGender.Location = new System.Drawing.Point(3, 33);
            lblGender.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(72, 23);
            lblGender.TabIndex = 6;
            lblGender.Text = "<Gender>";
            // 
            // lblExtremity
            // 
            lblExtremity.AutoSize = true;
            lblExtremity.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblExtremity.Location = new System.Drawing.Point(3, 66);
            lblExtremity.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblExtremity.Name = "lblExtremity";
            lblExtremity.Size = new System.Drawing.Size(83, 23);
            lblExtremity.TabIndex = 7;
            lblExtremity.Text = "<Extremity>";
            // 
            // lblJoint
            // 
            lblJoint.AutoSize = true;
            lblJoint.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblJoint.Location = new System.Drawing.Point(3, 99);
            lblJoint.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblJoint.Name = "lblJoint";
            lblJoint.Size = new System.Drawing.Size(55, 23);
            lblJoint.TabIndex = 5;
            lblJoint.Text = "<Joint>";
            // 
            // lblJointSide
            // 
            lblJointSide.AutoSize = true;
            lblJointSide.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblJointSide.Location = new System.Drawing.Point(3, 132);
            lblJointSide.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblJointSide.Name = "lblJointSide";
            lblJointSide.Size = new System.Drawing.Size(89, 23);
            lblJointSide.TabIndex = 8;
            lblJointSide.Text = " <Joint Side>";
            // 
            // lblAssessmentStatus
            // 
            lblAssessmentStatus.AutoSize = true;
            lblAssessmentStatus.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblAssessmentStatus.Location = new System.Drawing.Point(3, 165);
            lblAssessmentStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblAssessmentStatus.Name = "lblAssessmentStatus";
            lblAssessmentStatus.Size = new System.Drawing.Size(151, 23);
            lblAssessmentStatus.TabIndex = 9;
            lblAssessmentStatus.Text = " <Assessment Status>";
            // 
            // lblAssessmentDate
            // 
            lblAssessmentDate.AutoSize = true;
            lblAssessmentDate.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblAssessmentDate.Location = new System.Drawing.Point(3, 198);
            lblAssessmentDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblAssessmentDate.Name = "lblAssessmentDate";
            lblAssessmentDate.Size = new System.Drawing.Size(175, 23);
            lblAssessmentDate.TabIndex = 10;
            lblAssessmentDate.Text = " <Assessment Start Date>";
            // 
            // lblAssessmentEndDate
            // 
            lblAssessmentEndDate.AutoSize = true;
            lblAssessmentEndDate.Font = new System.Drawing.Font("Poppins", 9.75F);
            lblAssessmentEndDate.Location = new System.Drawing.Point(3, 231);
            lblAssessmentEndDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblAssessmentEndDate.Name = "lblAssessmentEndDate";
            lblAssessmentEndDate.Size = new System.Drawing.Size(167, 23);
            lblAssessmentEndDate.TabIndex = 11;
            lblAssessmentEndDate.Text = " <Assessment End Date>";
            // 
            // btnFinishAssessment
            // 
            btnFinishAssessment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFinishAssessment.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnFinishAssessment.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnFinishAssessment.BorderColor = System.Drawing.Color.White;
            btnFinishAssessment.BorderRadius = 10;
            btnFinishAssessment.BorderSize = 0;
            btnFinishAssessment.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFinishAssessment.FlatAppearance.BorderSize = 0;
            btnFinishAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFinishAssessment.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnFinishAssessment.ForeColor = System.Drawing.Color.White;
            btnFinishAssessment.Image = Properties.Resources.newWhiteSelect;
            btnFinishAssessment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnFinishAssessment.Location = new System.Drawing.Point(9, 338);
            btnFinishAssessment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFinishAssessment.Name = "btnFinishAssessment";
            btnFinishAssessment.Padding = new System.Windows.Forms.Padding(20, 3, 30, 0);
            btnFinishAssessment.Size = new System.Drawing.Size(406, 51);
            btnFinishAssessment.TabIndex = 37;
            btnFinishAssessment.Text = "Finish Assessment";
            btnFinishAssessment.TextColor = System.Drawing.Color.White;
            btnFinishAssessment.UseVisualStyleBackColor = false;
            btnFinishAssessment.Click += btnFinishAssessment_Click;
            // 
            // dataGridROM
            // 
            dataGridROM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridROM.BackgroundColor = System.Drawing.Color.White;
            dataGridROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridROM.Location = new System.Drawing.Point(68, 541);
            dataGridROM.Name = "dataGridROM";
            dataGridROM.Size = new System.Drawing.Size(1091, 168);
            dataGridROM.TabIndex = 37;
            dataGridROM.RowsAdded += dataGridROM_RowsAdded;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel5.Controls.Add(btnArchive);
            flowLayoutPanel5.Controls.Add(btnEdit);
            flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel5.Location = new System.Drawing.Point(516, 95);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new System.Drawing.Size(643, 54);
            flowLayoutPanel5.TabIndex = 38;
            // 
            // btnArchive
            // 
            btnArchive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnArchive.BackColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnArchive.BackgroundColor = System.Drawing.Color.FromArgb(255, 216, 216);
            btnArchive.BorderColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnArchive.BorderRadius = 10;
            btnArchive.BorderSize = 1;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnArchive.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnArchive.ForeColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnArchive.Image = (System.Drawing.Image)resources.GetObject("btnArchive.Image");
            btnArchive.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnArchive.Location = new System.Drawing.Point(441, 3);
            btnArchive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Padding = new System.Windows.Forms.Padding(6, 3, 18, 0);
            btnArchive.Size = new System.Drawing.Size(198, 46);
            btnArchive.TabIndex = 30;
            btnArchive.Text = "Archive Assessment";
            btnArchive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnArchive.TextColor = System.Drawing.Color.FromArgb(210, 64, 66);
            btnArchive.UseVisualStyleBackColor = false;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEdit.BackColor = System.Drawing.Color.FromArgb(207, 249, 238);
            btnEdit.BackgroundColor = System.Drawing.Color.FromArgb(207, 249, 238);
            btnEdit.BorderColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnEdit.BorderRadius = 10;
            btnEdit.BorderSize = 1;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnEdit.ForeColor = System.Drawing.Color.FromArgb(21, 134, 105);
            btnEdit.Image = (System.Drawing.Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnEdit.Location = new System.Drawing.Point(235, 3);
            btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Padding = new System.Windows.Forms.Padding(6, 3, 18, 0);
            btnEdit.Size = new System.Drawing.Size(198, 46);
            btnEdit.TabIndex = 29;
            btnEdit.Text = "Edit Assessment";
            btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnEdit.TextColor = System.Drawing.Color.FromArgb(21, 134, 105);
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // panelGraph
            // 
            panelGraph.Controls.Add(romPlot);
            panelGraph.Location = new System.Drawing.Point(516, 155);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new System.Drawing.Size(667, 272);
            panelGraph.TabIndex = 31;
            // 
            // romPlot
            // 
            romPlot.DisplayScale = 1F;
            romPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            romPlot.Location = new System.Drawing.Point(0, 0);
            romPlot.Name = "romPlot";
            romPlot.Size = new System.Drawing.Size(667, 272);
            romPlot.TabIndex = 0;
            // 
            // btnAddRom
            // 
            btnAddRom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddRom.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddRom.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAddRom.BorderColor = System.Drawing.Color.White;
            btnAddRom.BorderRadius = 10;
            btnAddRom.BorderSize = 0;
            btnAddRom.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddRom.FlatAppearance.BorderSize = 0;
            btnAddRom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddRom.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnAddRom.ForeColor = System.Drawing.Color.White;
            btnAddRom.Image = Properties.Resources.add_btn;
            btnAddRom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddRom.Location = new System.Drawing.Point(976, 438);
            btnAddRom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddRom.Name = "btnAddRom";
            btnAddRom.Padding = new System.Windows.Forms.Padding(10, 3, 10, 0);
            btnAddRom.Size = new System.Drawing.Size(183, 51);
            btnAddRom.TabIndex = 38;
            btnAddRom.Text = "Add ROM";
            btnAddRom.TextColor = System.Drawing.Color.White;
            btnAddRom.UseVisualStyleBackColor = false;
            btnAddRom.Click += btnAddRom_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnBack.BackColor = System.Drawing.Color.White;
            btnBack.BackgroundColor = System.Drawing.Color.White;
            btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnBack.BorderRadius = 10;
            btnBack.BorderSize = 0;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnBack.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.Image = (System.Drawing.Image)resources.GetObject("btnBack.Image");
            btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnBack.Location = new System.Drawing.Point(1014, 40);
            btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Padding = new System.Windows.Forms.Padding(0, 3, 35, 0);
            btnBack.Size = new System.Drawing.Size(145, 46);
            btnBack.TabIndex = 39;
            btnBack.Text = "Back";
            btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnBack.TextColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPrint.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnPrint.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnPrint.BorderColor = System.Drawing.Color.White;
            btnPrint.BorderRadius = 10;
            btnPrint.BorderSize = 0;
            btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrint.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.Image = Properties.Resources.add_btn;
            btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPrint.Location = new System.Drawing.Point(785, 439);
            btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPrint.Name = "btnPrint";
            btnPrint.Padding = new System.Windows.Forms.Padding(10, 3, 10, 0);
            btnPrint.Size = new System.Drawing.Size(183, 51);
            btnPrint.TabIndex = 40;
            btnPrint.Text = "Print";
            btnPrint.TextColor = System.Drawing.Color.White;
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAll.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnAll.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAll.BorderRadius = 5;
            btnAll.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAll.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAll.ForeColor = System.Drawing.Color.White;
            btnAll.Location = new System.Drawing.Point(68, 492);
            btnAll.Margin = new System.Windows.Forms.Padding(1);
            btnAll.Name = "btnAll";
            btnAll.Size = new System.Drawing.Size(93, 46);
            btnAll.TabIndex = 41;
            btnAll.Text = "All";
            btnAll.TextColor = System.Drawing.Color.White;
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // btnFlexion
            // 
            btnFlexion.BackColor = System.Drawing.Color.Gainsboro;
            btnFlexion.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnFlexion.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnFlexion.BorderRadius = 5;
            btnFlexion.BorderSize = 0;
            btnFlexion.FlatAppearance.BorderSize = 0;
            btnFlexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFlexion.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnFlexion.ForeColor = System.Drawing.Color.Gray;
            btnFlexion.Location = new System.Drawing.Point(163, 492);
            btnFlexion.Margin = new System.Windows.Forms.Padding(1);
            btnFlexion.Name = "btnFlexion";
            btnFlexion.Size = new System.Drawing.Size(141, 46);
            btnFlexion.TabIndex = 42;
            btnFlexion.Text = "Flexion";
            btnFlexion.TextColor = System.Drawing.Color.Gray;
            btnFlexion.UseVisualStyleBackColor = false;
            btnFlexion.Click += btnFlexion_Click;
            // 
            // btnExtension
            // 
            btnExtension.BackColor = System.Drawing.Color.Gainsboro;
            btnExtension.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnExtension.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnExtension.BorderRadius = 5;
            btnExtension.BorderSize = 0;
            btnExtension.FlatAppearance.BorderSize = 0;
            btnExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExtension.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnExtension.ForeColor = System.Drawing.Color.Gray;
            btnExtension.Location = new System.Drawing.Point(307, 492);
            btnExtension.Margin = new System.Windows.Forms.Padding(1);
            btnExtension.Name = "btnExtension";
            btnExtension.Size = new System.Drawing.Size(141, 46);
            btnExtension.TabIndex = 43;
            btnExtension.Text = "Extension";
            btnExtension.TextColor = System.Drawing.Color.Gray;
            btnExtension.UseVisualStyleBackColor = false;
            btnExtension.Click += btnExtension_Click;
            // 
            // btnAbduction
            // 
            btnAbduction.BackColor = System.Drawing.Color.Gainsboro;
            btnAbduction.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnAbduction.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAbduction.BorderRadius = 5;
            btnAbduction.BorderSize = 0;
            btnAbduction.FlatAppearance.BorderSize = 0;
            btnAbduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAbduction.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAbduction.ForeColor = System.Drawing.Color.Gray;
            btnAbduction.Location = new System.Drawing.Point(450, 492);
            btnAbduction.Margin = new System.Windows.Forms.Padding(1);
            btnAbduction.Name = "btnAbduction";
            btnAbduction.Size = new System.Drawing.Size(141, 46);
            btnAbduction.TabIndex = 44;
            btnAbduction.Text = "Abduction";
            btnAbduction.TextColor = System.Drawing.Color.Gray;
            btnAbduction.UseVisualStyleBackColor = false;
            btnAbduction.Click += btnAbduction_Click;
            // 
            // btnAdduction
            // 
            btnAdduction.BackColor = System.Drawing.Color.Gainsboro;
            btnAdduction.BackgroundColor = System.Drawing.Color.Gainsboro;
            btnAdduction.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAdduction.BorderRadius = 5;
            btnAdduction.BorderSize = 0;
            btnAdduction.FlatAppearance.BorderSize = 0;
            btnAdduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdduction.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            btnAdduction.ForeColor = System.Drawing.Color.Gray;
            btnAdduction.Location = new System.Drawing.Point(593, 492);
            btnAdduction.Margin = new System.Windows.Forms.Padding(1);
            btnAdduction.Name = "btnAdduction";
            btnAdduction.Size = new System.Drawing.Size(141, 46);
            btnAdduction.TabIndex = 45;
            btnAdduction.Text = "Adduction";
            btnAdduction.TextColor = System.Drawing.Color.Gray;
            btnAdduction.UseVisualStyleBackColor = false;
            btnAdduction.Click += btnAdduction_Click;
            // 
            // AssessmentDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(btnAdduction);
            Controls.Add(panelGraph);
            Controls.Add(btnAbduction);
            Controls.Add(btnExtension);
            Controls.Add(btnFlexion);
            Controls.Add(btnAll);
            Controls.Add(btnPrint);
            Controls.Add(btnBack);
            Controls.Add(dataGridROM);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblSelectedAssessment);
            Controls.Add(btnAddRom);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(titleNav);
            Name = "AssessmentDetails";
            Size = new System.Drawing.Size(1186, 712);
            Load += AssessmentDetails_Load;
            Paint += AssessmentDetails_Paint;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridROM).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            panelGraph.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSelectedAssessment;
        private System.Windows.Forms.Label titleNav;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblJoint;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblExtremity;
        private OrganizationProfile.CustomButton btnFinishAssessment;
        private System.Windows.Forms.DataGridView dataGridROM;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private OrganizationProfile.CustomButton btnArchive;
        private OrganizationProfile.CustomButton btnEdit;
        private OrganizationProfile.CustomButton btnAddRom;
        private OrganizationProfile.CustomButton btnBack;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblJointSide;
        private System.Windows.Forms.Label lblAssessmentStatus;
        private OrganizationProfile.CustomButton btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssessmentDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAssessmentEndDate;
        private OrganizationProfile.CustomButton btnAll;
        private OrganizationProfile.CustomButton btnFlexion;
        private OrganizationProfile.CustomButton btnExtension;
        private OrganizationProfile.CustomButton btnAbduction;
        private OrganizationProfile.CustomButton btnAdduction;
        private System.Windows.Forms.Panel panelGraph;
        private ScottPlot.WinForms.FormsPlot romPlot;
    }
}
