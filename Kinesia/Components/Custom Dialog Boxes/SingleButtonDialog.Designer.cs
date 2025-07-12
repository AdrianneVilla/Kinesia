namespace Kinesia.Components.Custom_Dialog_Boxes
{
    partial class SingleButtonDialog
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
            this.customButton1 = new OrganizationProfile.CustomButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dialogHeader = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.lblDialogTitle = new System.Windows.Forms.Label();
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
            this.panelBorder1.Controls.Add(this.customButton1);
            this.panelBorder1.Controls.Add(this.lblDescription);
            this.panelBorder1.Controls.Add(this.dialogHeader);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(24, 6);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(500, 247);
            this.panelBorder1.TabIndex = 1;
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.customButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.customButton1.BorderColor = System.Drawing.Color.White;
            this.customButton1.BorderRadius = 10;
            this.customButton1.BorderSize = 0;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.customButton1.ForeColor = System.Drawing.Color.Transparent;
            this.customButton1.Location = new System.Drawing.Point(189, 190);
            this.customButton1.Name = "customButton1";
            this.customButton1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.customButton1.Size = new System.Drawing.Size(118, 40);
            this.customButton1.TabIndex = 2;
            this.customButton1.Text = "Continue";
            this.customButton1.TextColor = System.Drawing.Color.Transparent;
            this.customButton1.UseVisualStyleBackColor = false;
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
            this.lblDescription.Text = "Description Holder";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogHeader
            // 
            this.dialogHeader.BackColor = System.Drawing.Color.White;
            this.dialogHeader.BorderRadius = 0;
            this.dialogHeader.Color = System.Drawing.Color.BurlyWood;
            this.dialogHeader.Controls.Add(this.lblDialogTitle);
            this.dialogHeader.Controls.Add(this.imgDialogIcon);
            this.dialogHeader.ForeColor = System.Drawing.Color.Black;
            this.dialogHeader.Location = new System.Drawing.Point(-16, 0);
            this.dialogHeader.Name = "dialogHeader";
            this.dialogHeader.Size = new System.Drawing.Size(533, 60);
            this.dialogHeader.TabIndex = 0;
            // 
            // lblDialogTitle
            // 
            this.lblDialogTitle.AutoSize = true;
            this.lblDialogTitle.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDialogTitle.Location = new System.Drawing.Point(90, 22);
            this.lblDialogTitle.Name = "lblDialogTitle";
            this.lblDialogTitle.Size = new System.Drawing.Size(69, 22);
            this.lblDialogTitle.TabIndex = 1;
            this.lblDialogTitle.Text = "title label";
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
            // SingleButtonDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelBorder1);
            this.Name = "SingleButtonDialog";
            this.Size = new System.Drawing.Size(549, 259);
            this.panelBorder1.ResumeLayout(false);
            this.dialogHeader.ResumeLayout(false);
            this.dialogHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDialogIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private OrganizationProfile.CustomButton customButton1;
        private System.Windows.Forms.Label lblDescription;
        private WindowsFormsApp2.CustomButton.PanelBorder dialogHeader;
        private System.Windows.Forms.Label lblDialogTitle;
        private System.Windows.Forms.PictureBox imgDialogIcon;
    }
}
