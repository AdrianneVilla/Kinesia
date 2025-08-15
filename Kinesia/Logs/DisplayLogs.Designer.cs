namespace Kinesia.Logs
{
    partial class DisplayLogs
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
            this.txtLogID = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.Label();
            this.panelBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorder1
            // 
            this.panelBorder1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelBorder1.BackColor = System.Drawing.Color.White;
            this.panelBorder1.BorderRadius = 20;
            this.panelBorder1.Color = System.Drawing.Color.White;
            this.panelBorder1.Controls.Add(this.txtLogID);
            this.panelBorder1.Controls.Add(this.txtDate);
            this.panelBorder1.Controls.Add(this.txtDescription);
            this.panelBorder1.Controls.Add(this.txtUserName);
            this.panelBorder1.ForeColor = System.Drawing.Color.Black;
            this.panelBorder1.Location = new System.Drawing.Point(7, 5);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(1497, 91);
            this.panelBorder1.TabIndex = 1;
            // 
            // txtLogID
            // 
            this.txtLogID.AutoSize = true;
            this.txtLogID.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtLogID.Location = new System.Drawing.Point(14, 37);
            this.txtLogID.Name = "txtLogID";
            this.txtLogID.Size = new System.Drawing.Size(37, 19);
            this.txtLogID.TabIndex = 8;
            this.txtLogID.Text = "logID";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(1310, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(37, 22);
            this.txtDate.TabIndex = 4;
            this.txtDate.Text = "date";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(732, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(60, 22);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "log desc";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(297, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(92, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "Name of user";
            // 
            // DisplayLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.panelBorder1);
            this.Name = "DisplayLogs";
            this.Size = new System.Drawing.Size(1510, 101);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder1;
        private System.Windows.Forms.Label txtLogID;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtUserName;
    }
}
