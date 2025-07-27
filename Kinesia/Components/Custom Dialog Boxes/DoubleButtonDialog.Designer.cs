namespace Kinesia.Components.Custom_Dialog_Boxes
{
    partial class DoubleButtonDialog
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
            this.panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnNo = new OrganizationProfile.CustomButton();
            this.btnYes = new OrganizationProfile.CustomButton();
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
            this.panelBorder1.Controls.Add(this.lblDescription);
            this.panelBorder1.Controls.Add(this.btnNo);
            this.panelBorder1.Controls.Add(this.btnYes);
            this.panelBorder1.Controls.Add(this.dialogHeader);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(22, 3);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(500, 247);
            this.panelBorder1.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(50, 81);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(401, 84);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description Holder";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Silver;
            this.btnNo.BackgroundColor = System.Drawing.Color.Silver;
            this.btnNo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNo.BorderRadius = 10;
            this.btnNo.BorderSize = 0;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Location = new System.Drawing.Point(292, 194);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnNo.Size = new System.Drawing.Size(118, 40);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.TextColor = System.Drawing.Color.Black;
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnYes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.btnYes.BorderColor = System.Drawing.Color.White;
            this.btnYes.BorderRadius = 10;
            this.btnYes.BorderSize = 0;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.Transparent;
            this.btnYes.Location = new System.Drawing.Point(93, 194);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnYes.Size = new System.Drawing.Size(118, 40);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.TextColor = System.Drawing.Color.Transparent;
            this.btnYes.UseVisualStyleBackColor = false;
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
            this.imgDialogIcon.Image = global::Kinesia.Properties.Resources.warning_icon;
            this.imgDialogIcon.Location = new System.Drawing.Point(30, 3);
            this.imgDialogIcon.Name = "imgDialogIcon";
            this.imgDialogIcon.Size = new System.Drawing.Size(54, 54);
            this.imgDialogIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDialogIcon.TabIndex = 0;
            this.imgDialogIcon.TabStop = false;
            // 
            // DoubleButtonDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelBorder1);
            this.Name = "DoubleButtonDialog";
            this.Size = new System.Drawing.Size(549, 259);
            this.panelBorder1.ResumeLayout(false);
            this.dialogHeader.ResumeLayout(false);
            this.dialogHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDialogIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private WindowsFormsApp2.CustomButton.PanelBorder dialogHeader;
        private System.Windows.Forms.PictureBox imgDialogIcon;
        private OrganizationProfile.CustomButton btnNo;
        private OrganizationProfile.CustomButton btnYes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
    }
}
