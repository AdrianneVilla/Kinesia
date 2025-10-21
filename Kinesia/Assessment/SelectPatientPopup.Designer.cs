namespace Kinesia.Assessment
{
    partial class SelectPatientPopup
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
            panelSelectPatient = new WindowsFormsApp2.CustomButton.PanelBorder();
            btnSelectPatient = new OrganizationProfile.CustomButton();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panelSelectPatient.SuspendLayout();
            SuspendLayout();
            // 
            // panelSelectPatient
            // 
            panelSelectPatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelSelectPatient.BackColor = System.Drawing.Color.White;
            panelSelectPatient.BackgroundImage = Properties.Resources.Add_Patient_Background;
            panelSelectPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelSelectPatient.BorderRadius = 30;
            panelSelectPatient.Color = System.Drawing.Color.BurlyWood;
            panelSelectPatient.Controls.Add(btnSelectPatient);
            panelSelectPatient.Controls.Add(label3);
            panelSelectPatient.Controls.Add(label2);
            panelSelectPatient.ForeColor = System.Drawing.Color.Black;
            panelSelectPatient.Location = new System.Drawing.Point(14, 17);
            panelSelectPatient.Margin = new System.Windows.Forms.Padding(70);
            panelSelectPatient.Name = "panelSelectPatient";
            panelSelectPatient.Size = new System.Drawing.Size(619, 241);
            panelSelectPatient.TabIndex = 1;
            // 
            // btnSelectPatient
            // 
            btnSelectPatient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectPatient.BackColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSelectPatient.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
            btnSelectPatient.BorderColor = System.Drawing.Color.White;
            btnSelectPatient.BorderRadius = 10;
            btnSelectPatient.BorderSize = 0;
            btnSelectPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSelectPatient.FlatAppearance.BorderSize = 0;
            btnSelectPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectPatient.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSelectPatient.ForeColor = System.Drawing.Color.White;
            btnSelectPatient.Image = Properties.Resources.newWhiteSelect;
            btnSelectPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSelectPatient.Location = new System.Drawing.Point(211, 156);
            btnSelectPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSelectPatient.Name = "btnSelectPatient";
            btnSelectPatient.Padding = new System.Windows.Forms.Padding(10, 3, 30, 0);
            btnSelectPatient.Size = new System.Drawing.Size(199, 51);
            btnSelectPatient.TabIndex = 9;
            btnSelectPatient.Text = "Select Patient";
            btnSelectPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSelectPatient.TextColor = System.Drawing.Color.White;
            btnSelectPatient.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.Gray;
            label3.Location = new System.Drawing.Point(3, 87);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(613, 49);
            label3.TabIndex = 2;
            label3.Text = "Search and select a patient to begin assessment";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(196, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 49);
            label2.TabIndex = 1;
            label2.Text = "Select patient";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectPatientPopup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(panelSelectPatient);
            DoubleBuffered = true;
            Name = "SelectPatientPopup";
            Size = new System.Drawing.Size(656, 274);
            panelSelectPatient.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private WindowsFormsApp2.CustomButton.PanelBorder panelSelectPatient;
        private OrganizationProfile.CustomButton btnSelectPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
