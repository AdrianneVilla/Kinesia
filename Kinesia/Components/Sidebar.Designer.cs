namespace Kinesia.Components
{
    partial class Sidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sidebar));
            this.logoutBtn = new OrganizationProfile.CustomButton();
            this.logsModule = new OrganizationProfile.CustomButton();
            this.assessmentModule = new OrganizationProfile.CustomButton();
            this.usersModule = new OrganizationProfile.CustomButton();
            this.patientModule = new OrganizationProfile.CustomButton();
            this.dashboardModule = new OrganizationProfile.CustomButton();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.logoutBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(210)))), ((int)(((byte)(173)))));
            this.logoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoutBtn.BorderColor = System.Drawing.Color.White;
            this.logoutBtn.BorderRadius = 10;
            this.logoutBtn.BorderSize = 0;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutBtn.Image")));
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.Location = new System.Drawing.Point(21, 568);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.logoutBtn.Size = new System.Drawing.Size(206, 54);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.TextColor = System.Drawing.Color.White;
            this.logoutBtn.UseVisualStyleBackColor = false;
            // 
            // logsModule
            // 
            this.logsModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsModule.BackColor = System.Drawing.Color.White;
            this.logsModule.BackgroundColor = System.Drawing.Color.White;
            this.logsModule.BackgroundImage = global::Kinesia.Properties.Resources.btn_back;
            this.logsModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logsModule.BorderColor = System.Drawing.Color.White;
            this.logsModule.BorderRadius = 10;
            this.logsModule.BorderSize = 0;
            this.logsModule.FlatAppearance.BorderSize = 0;
            this.logsModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logsModule.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.logsModule.Image = ((System.Drawing.Image)(resources.GetObject("logsModule.Image")));
            this.logsModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logsModule.Location = new System.Drawing.Point(21, 378);
            this.logsModule.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.logsModule.Name = "logsModule";
            this.logsModule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.logsModule.Size = new System.Drawing.Size(206, 54);
            this.logsModule.TabIndex = 4;
            this.logsModule.Text = "Logs";
            this.logsModule.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.logsModule.UseVisualStyleBackColor = false;
            // 
            // assessmentModule
            // 
            this.assessmentModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assessmentModule.BackColor = System.Drawing.Color.White;
            this.assessmentModule.BackgroundColor = System.Drawing.Color.White;
            this.assessmentModule.BackgroundImage = global::Kinesia.Properties.Resources.btn_back;
            this.assessmentModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.assessmentModule.BorderColor = System.Drawing.Color.White;
            this.assessmentModule.BorderRadius = 10;
            this.assessmentModule.BorderSize = 0;
            this.assessmentModule.FlatAppearance.BorderSize = 0;
            this.assessmentModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assessmentModule.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assessmentModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.assessmentModule.Image = ((System.Drawing.Image)(resources.GetObject("assessmentModule.Image")));
            this.assessmentModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assessmentModule.Location = new System.Drawing.Point(21, 306);
            this.assessmentModule.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.assessmentModule.Name = "assessmentModule";
            this.assessmentModule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.assessmentModule.Size = new System.Drawing.Size(206, 54);
            this.assessmentModule.TabIndex = 3;
            this.assessmentModule.Text = "Assessment";
            this.assessmentModule.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.assessmentModule.UseVisualStyleBackColor = false;
            // 
            // usersModule
            // 
            this.usersModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersModule.BackColor = System.Drawing.Color.White;
            this.usersModule.BackgroundColor = System.Drawing.Color.White;
            this.usersModule.BackgroundImage = global::Kinesia.Properties.Resources.btn_back;
            this.usersModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usersModule.BorderColor = System.Drawing.Color.White;
            this.usersModule.BorderRadius = 10;
            this.usersModule.BorderSize = 0;
            this.usersModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usersModule.FlatAppearance.BorderSize = 0;
            this.usersModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersModule.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.usersModule.Image = ((System.Drawing.Image)(resources.GetObject("usersModule.Image")));
            this.usersModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersModule.Location = new System.Drawing.Point(21, 234);
            this.usersModule.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.usersModule.Name = "usersModule";
            this.usersModule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.usersModule.Size = new System.Drawing.Size(206, 54);
            this.usersModule.TabIndex = 2;
            this.usersModule.Text = "Users";
            this.usersModule.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.usersModule.UseVisualStyleBackColor = false;
            this.usersModule.Click += new System.EventHandler(this.usersModule_Click);
            // 
            // patientModule
            // 
            this.patientModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientModule.BackColor = System.Drawing.Color.White;
            this.patientModule.BackgroundColor = System.Drawing.Color.White;
            this.patientModule.BackgroundImage = global::Kinesia.Properties.Resources.btn_back;
            this.patientModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.patientModule.BorderColor = System.Drawing.Color.White;
            this.patientModule.BorderRadius = 10;
            this.patientModule.BorderSize = 1;
            this.patientModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patientModule.FlatAppearance.BorderSize = 0;
            this.patientModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patientModule.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.patientModule.Image = ((System.Drawing.Image)(resources.GetObject("patientModule.Image")));
            this.patientModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientModule.Location = new System.Drawing.Point(21, 161);
            this.patientModule.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.patientModule.Name = "patientModule";
            this.patientModule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.patientModule.Size = new System.Drawing.Size(206, 55);
            this.patientModule.TabIndex = 1;
            this.patientModule.Text = "Patients";
            this.patientModule.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.patientModule.UseVisualStyleBackColor = false;
            this.patientModule.Click += new System.EventHandler(this.patientModule_Click);
            // 
            // dashboardModule
            // 
            this.dashboardModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dashboardModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.dashboardModule.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.dashboardModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardModule.BorderColor = System.Drawing.Color.Transparent;
            this.dashboardModule.BorderRadius = 10;
            this.dashboardModule.BorderSize = 0;
            this.dashboardModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardModule.FlatAppearance.BorderSize = 0;
            this.dashboardModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardModule.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardModule.ForeColor = System.Drawing.Color.Transparent;
            this.dashboardModule.Image = ((System.Drawing.Image)(resources.GetObject("dashboardModule.Image")));
            this.dashboardModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardModule.Location = new System.Drawing.Point(21, 93);
            this.dashboardModule.Name = "dashboardModule";
            this.dashboardModule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dashboardModule.Size = new System.Drawing.Size(206, 50);
            this.dashboardModule.TabIndex = 0;
            this.dashboardModule.Text = "Dashboard";
            this.dashboardModule.TextColor = System.Drawing.Color.Transparent;
            this.dashboardModule.UseVisualStyleBackColor = false;
            this.dashboardModule.Click += new System.EventHandler(this.dashboardModule_Click);
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.logsModule);
            this.Controls.Add(this.assessmentModule);
            this.Controls.Add(this.usersModule);
            this.Controls.Add(this.patientModule);
            this.Controls.Add(this.dashboardModule);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(258, 635);
            this.ResumeLayout(false);

        }

        #endregion

        private OrganizationProfile.CustomButton dashboardModule;
        private OrganizationProfile.CustomButton usersModule;
        private OrganizationProfile.CustomButton assessmentModule;
        private OrganizationProfile.CustomButton logsModule;
        private OrganizationProfile.CustomButton logoutBtn;
        public OrganizationProfile.CustomButton patientModule;
    }
}
