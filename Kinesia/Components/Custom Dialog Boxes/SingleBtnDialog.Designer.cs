namespace Kinesia.Components.Custom_Dialog_Boxes
{
    partial class SingleBtnDialog
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
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.btnOK = new OrganizationProfile.CustomButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dialogHeader = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.lblTitle = new System.Windows.Forms.Label();
            this.imgDialogIcon = new System.Windows.Forms.PictureBox();
            this.panelBorder1.SuspendLayout();
            this.dialogHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDialogIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBorder1
            // 
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BorderRadius = 30;
            this.panelBorder1.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder1.Controls.Add(this.btnOK);
            this.panelBorder1.Controls.Add(this.lblDescription);
            this.panelBorder1.Controls.Add(this.dialogHeader);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(150, 102);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(500, 247);
            this.panelBorder1.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnOK.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnOK.BorderColor = System.Drawing.Color.White;
            this.btnOK.BorderRadius = 10;
            this.btnOK.BorderSize = 0;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.Transparent;
            this.btnOK.Location = new System.Drawing.Point(189, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnOK.Size = new System.Drawing.Size(118, 40);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.TextColor = System.Drawing.Color.Transparent;
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(52, 89);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(401, 84);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description here";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogHeader
            // 
            this.dialogHeader.BackColor = System.Drawing.Color.White;
            this.dialogHeader.BorderRadius = 0;
            this.dialogHeader.Color = System.Drawing.Color.BurlyWood;
            this.dialogHeader.Controls.Add(this.lblTitle);
            this.dialogHeader.Controls.Add(this.imgDialogIcon);
            this.dialogHeader.ForeColor = System.Drawing.Color.Black;
            this.dialogHeader.Location = new System.Drawing.Point(-16, 0);
            this.dialogHeader.Name = "dialogHeader";
            this.dialogHeader.Size = new System.Drawing.Size(533, 60);
            this.dialogHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 22);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "title label";
            // 
            // imgDialogIcon
            // 
            this.imgDialogIcon.Image = global::Kinesia.Properties.Resources.yellow_triangle_warning_icon;
            this.imgDialogIcon.Location = new System.Drawing.Point(30, 3);
            this.imgDialogIcon.Name = "imgDialogIcon";
            this.imgDialogIcon.Size = new System.Drawing.Size(54, 54);
            this.imgDialogIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDialogIcon.TabIndex = 0;
            this.imgDialogIcon.TabStop = false;
            // 
            // SingleBtnDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBorder1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SingleBtnDialog";
            this.Text = "SingleBtnDialog";
            this.panelBorder1.ResumeLayout(false);
            this.dialogHeader.ResumeLayout(false);
            this.dialogHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDialogIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton btnOK;
        private System.Windows.Forms.Label lblDescription;
        private WindowsFormsApp2.CustomButton.PanelBorder dialogHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox imgDialogIcon;
    }
}