namespace Kinesia.Assessment
{
    partial class SelectPatient
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
            dataGridPatientSelection = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            splitter1 = new System.Windows.Forms.Splitter();
            btnClose = new OrganizationProfile.CustomButton();
            panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSearch = new OrganizationProfile.CustomButton();
            txtSearchBar = new CustomControls.RJControls.RJTextBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            lblHiddenForFocus = new System.Windows.Forms.Label();
            btnRefresh = new OrganizationProfile.CustomButton();
            ((System.ComponentModel.ISupportInitialize)dataGridPatientSelection).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panelBorder2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridPatientSelection
            // 
            dataGridPatientSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridPatientSelection.BackgroundColor = System.Drawing.Color.White;
            dataGridPatientSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPatientSelection.Location = new System.Drawing.Point(47, 251);
            dataGridPatientSelection.Name = "dataGridPatientSelection";
            dataGridPatientSelection.Size = new System.Drawing.Size(770, 454);
            dataGridPatientSelection.TabIndex = 24;
            dataGridPatientSelection.CellContentClick += dataGridPatientSelection_CellContentClick;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(18, 90, 211);
            label2.Location = new System.Drawing.Point(30, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 49);
            label2.TabIndex = 21;
            label2.Text = "Select patient";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(splitter1);
            flowLayoutPanel2.Controls.Add(btnRefresh);
            flowLayoutPanel2.Location = new System.Drawing.Point(44, 169);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(780, 51);
            flowLayoutPanel2.TabIndex = 22;
            // 
            // splitter1
            // 
            splitter1.Location = new System.Drawing.Point(3, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(639, 40);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
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
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.Transparent;
            btnClose.Location = new System.Drawing.Point(785, 35);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(39, 30);
            btnClose.TabIndex = 25;
            btnClose.TextColor = System.Drawing.Color.Transparent;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelBorder2
            // 
            panelBorder2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBorder2.BackColor = System.Drawing.Color.White;
            panelBorder2.BackgroundImage = Properties.Resources.search_background_new;
            panelBorder2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelBorder2.BorderRadius = 30;
            panelBorder2.Color = System.Drawing.Color.BurlyWood;
            panelBorder2.Controls.Add(btnSearch);
            panelBorder2.Controls.Add(txtSearchBar);
            panelBorder2.Controls.Add(pictureBox2);
            panelBorder2.ForeColor = System.Drawing.Color.Black;
            panelBorder2.Location = new System.Drawing.Point(44, 99);
            panelBorder2.Name = "panelBorder2";
            panelBorder2.Size = new System.Drawing.Size(789, 53);
            panelBorder2.TabIndex = 26;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnSearch.BorderRadius = 10;
            btnSearch.BorderSize = 0;
            btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.Transparent;
            btnSearch.Location = new System.Drawing.Point(626, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(150, 40);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.TextColor = System.Drawing.Color.Transparent;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchBar
            // 
            txtSearchBar.BackColor = System.Drawing.Color.White;
            txtSearchBar.BorderColor = System.Drawing.Color.White;
            txtSearchBar.BorderFocusColor = System.Drawing.Color.White;
            txtSearchBar.BorderRadius = 5;
            txtSearchBar.BorderSize = 1;
            txtSearchBar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtSearchBar.Location = new System.Drawing.Point(60, 6);
            txtSearchBar.Margin = new System.Windows.Forms.Padding(5);
            txtSearchBar.MaxLength = 50;
            txtSearchBar.Multiline = false;
            txtSearchBar.Name = "txtSearchBar";
            txtSearchBar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 0);
            txtSearchBar.PasswordChar = false;
            txtSearchBar.PlaceholderColor = System.Drawing.Color.DarkGray;
            txtSearchBar.PlaceholderText = "";
            txtSearchBar.SelectionLength = 0;
            txtSearchBar.SelectionStart = 0;
            txtSearchBar.Size = new System.Drawing.Size(558, 35);
            txtSearchBar.TabIndex = 5;
            txtSearchBar.Texts = "";
            txtSearchBar.UnderlinedStyle = false;
            txtSearchBar._TextChanged += txtSearchBar__TextChanged;
            txtSearchBar.Enter += txtSearchBar_Enter;
            txtSearchBar.Leave += txtSearchBar_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search_icon;
            pictureBox2.Location = new System.Drawing.Point(23, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(29, 27);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // lblHiddenForFocus
            // 
            lblHiddenForFocus.AutoSize = true;
            lblHiddenForFocus.ForeColor = System.Drawing.Color.White;
            lblHiddenForFocus.Location = new System.Drawing.Point(284, 43);
            lblHiddenForFocus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHiddenForFocus.Name = "lblHiddenForFocus";
            lblHiddenForFocus.Size = new System.Drawing.Size(135, 15);
            lblHiddenForFocus.TabIndex = 27;
            lblHiddenForFocus.Text = "<Focus Label (Hidden)>";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnRefresh.BackgroundColor = System.Drawing.Color.FromArgb(64, 210, 173);
            btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnRefresh.BorderRadius = 10;
            btnRefresh.BorderSize = 0;
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(649, 3);
            btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            btnRefresh.Size = new System.Drawing.Size(118, 40);
            btnRefresh.TabIndex = 17;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextColor = System.Drawing.Color.White;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // SelectPatient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(874, 763);
            ControlBox = false;
            Controls.Add(lblHiddenForFocus);
            Controls.Add(panelBorder2);
            Controls.Add(btnClose);
            Controls.Add(dataGridPatientSelection);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SelectPatient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NewSelectPatient";
            Load += SelectPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPatientSelection).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            panelBorder2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPatientSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private OrganizationProfile.CustomButton btnClose;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private OrganizationProfile.CustomButton btnSearch;
        private CustomControls.RJControls.RJTextBox txtSearchBar;
        private System.Windows.Forms.Label lblHiddenForFocus;
        private OrganizationProfile.CustomButton btnRefresh;
    }
}