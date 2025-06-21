namespace Kinesia.Users
{
    partial class UserPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPage));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nameHolder = new System.Windows.Forms.Label();
            this.UsersHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnAddPatient = new OrganizationProfile.CustomButton();
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelBorder1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameHeader,
            this.EmployeeID,
            this.EmpPosition,
            this.ageHeader,
            this.contactNumHeader,
            this.statusHeader,
            this.editHeader});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(67, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 24);
            this.dataGridView1.TabIndex = 14;
            // 
            // nameHeader
            // 
            this.nameHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHeader.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameHeader.HeaderText = "Name";
            this.nameHeader.Name = "nameHeader";
            this.nameHeader.ReadOnly = true;
            this.nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // EmployeeID
            // 
            this.EmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmployeeID.FillWeight = 60F;
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // EmpPosition
            // 
            this.EmpPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmpPosition.FillWeight = 60F;
            this.EmpPosition.HeaderText = "Position";
            this.EmpPosition.Name = "EmpPosition";
            this.EmpPosition.ReadOnly = true;
            // 
            // ageHeader
            // 
            this.ageHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ageHeader.FillWeight = 50F;
            this.ageHeader.HeaderText = "Age";
            this.ageHeader.Name = "ageHeader";
            this.ageHeader.ReadOnly = true;
            // 
            // contactNumHeader
            // 
            this.contactNumHeader.FillWeight = 63.63636F;
            this.contactNumHeader.HeaderText = "Contact Number";
            this.contactNumHeader.Name = "contactNumHeader";
            this.contactNumHeader.ReadOnly = true;
            // 
            // statusHeader
            // 
            this.statusHeader.FillWeight = 63.63636F;
            this.statusHeader.HeaderText = "Address";
            this.statusHeader.Name = "statusHeader";
            this.statusHeader.ReadOnly = true;
            // 
            // editHeader
            // 
            this.editHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.editHeader.FillWeight = 25F;
            this.editHeader.HeaderText = "Select";
            this.editHeader.Name = "editHeader";
            this.editHeader.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = " Helps you move better and feel better";
            // 
            // nameHolder
            // 
            this.nameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameHolder.AutoSize = true;
            this.nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHolder.Location = new System.Drawing.Point(59, 31);
            this.nameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.nameHolder.Name = "nameHolder";
            this.nameHolder.Size = new System.Drawing.Size(98, 48);
            this.nameHolder.TabIndex = 9;
            this.nameHolder.Text = "Users";
            this.nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsersHolder
            // 
            this.UsersHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.UsersHolder.BorderRadius = 10;
            this.UsersHolder.Color = System.Drawing.Color.White;
            this.UsersHolder.ForeColor = System.Drawing.Color.Black;
            this.UsersHolder.Location = new System.Drawing.Point(59, 173);
            this.UsersHolder.Name = "UsersHolder";
            this.UsersHolder.Padding = new System.Windows.Forms.Padding(5);
            this.UsersHolder.Size = new System.Drawing.Size(1129, 472);
            this.UsersHolder.TabIndex = 13;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnAddPatient.BorderColor = System.Drawing.Color.White;
            this.btnAddPatient.BorderRadius = 10;
            this.btnAddPatient.BorderSize = 0;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPatient.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPatient.Image")));
            this.btnAddPatient.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddPatient.Location = new System.Drawing.Point(1039, 38);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Padding = new System.Windows.Forms.Padding(5, 5, 20, 0);
            this.btnAddPatient.Size = new System.Drawing.Size(150, 48);
            this.btnAddPatient.TabIndex = 12;
            this.btnAddPatient.Text = "Add Users";
            this.btnAddPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPatient.TextColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.UseVisualStyleBackColor = false;
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BackgroundImage = global::Kinesia.Properties.Resources.search_background_new;
            this.panelBorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBorder1.BorderRadius = 10;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.pictureBox1);
            this.panelBorder1.Controls.Add(this.rjTextBox1);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(595, 37);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Padding = new System.Windows.Forms.Padding(5);
            this.panelBorder1.Size = new System.Drawing.Size(438, 51);
            this.panelBorder1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kinesia.Properties.Resources.search_icon;
            this.pictureBox1.Location = new System.Drawing.Point(13, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.Color.White;
            this.rjTextBox1.BorderColor = System.Drawing.Color.White;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.White;
            this.rjTextBox1.BorderRadius = 5;
            this.rjTextBox1.BorderSize = 1;
            this.rjTextBox1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.Location = new System.Drawing.Point(48, 8);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 0);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "Search Users";
            this.rjTextBox1.Size = new System.Drawing.Size(381, 34);
            this.rjTextBox1.TabIndex = 4;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameHolder);
            this.Controls.Add(this.UsersHolder);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.panelBorder1);
            this.Name = "UserPage";
            this.Size = new System.Drawing.Size(1249, 676);
            this.Load += new System.EventHandler(this.UserPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelBorder1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private WindowsFormsApp2.CustomButton.PanelBorder UsersHolder;
        private OrganizationProfile.CustomButton btnAddPatient;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn editHeader;
    }
}
