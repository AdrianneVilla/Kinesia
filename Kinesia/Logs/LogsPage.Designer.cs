namespace Kinesia.Logs
{
    partial class LogsPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameHolder = new System.Windows.Forms.Label();
            this.LogHolder = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.dataGridPatients = new System.Windows.Forms.DataGridView();
            this.LogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBorder2 = new WindowsFormsApp2.CustomButton.PanelBorder();
            this.cbSort = new CustomControls.RJControls.RJComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPatients)).BeginInit();
            this.panelBorder2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Keep track on system\'s activity";
            // 
            // nameHolder
            // 
            this.nameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nameHolder.AutoSize = true;
            this.nameHolder.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.nameHolder.Location = new System.Drawing.Point(61, 32);
            this.nameHolder.Margin = new System.Windows.Forms.Padding(0);
            this.nameHolder.Name = "nameHolder";
            this.nameHolder.Size = new System.Drawing.Size(83, 48);
            this.nameHolder.TabIndex = 4;
            this.nameHolder.Text = "Logs";
            this.nameHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogHolder
            // 
            this.LogHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.LogHolder.BorderRadius = 10;
            this.LogHolder.Color = System.Drawing.Color.White;
            this.LogHolder.ForeColor = System.Drawing.Color.Black;
            this.LogHolder.Location = new System.Drawing.Point(62, 244);
            this.LogHolder.Name = "LogHolder";
            this.LogHolder.Padding = new System.Windows.Forms.Padding(5);
            this.LogHolder.Size = new System.Drawing.Size(1129, 496);
            this.LogHolder.TabIndex = 8;
            // 
            // dataGridPatients
            // 
            this.dataGridPatients.AllowUserToAddRows = false;
            this.dataGridPatients.AllowUserToDeleteRows = false;
            this.dataGridPatients.AllowUserToResizeColumns = false;
            this.dataGridPatients.AllowUserToResizeRows = false;
            this.dataGridPatients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPatients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridPatients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridPatients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogID,
            this.nameHeader,
            this.genderHeader,
            this.contactNumHeader});
            this.dataGridPatients.GridColor = System.Drawing.Color.White;
            this.dataGridPatients.Location = new System.Drawing.Point(70, 206);
            this.dataGridPatients.Name = "dataGridPatients";
            this.dataGridPatients.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridPatients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridPatients.ShowCellErrors = false;
            this.dataGridPatients.ShowCellToolTips = false;
            this.dataGridPatients.ShowEditingIcon = false;
            this.dataGridPatients.ShowRowErrors = false;
            this.dataGridPatients.Size = new System.Drawing.Size(1111, 27);
            this.dataGridPatients.TabIndex = 9;
            // 
            // LogID
            // 
            this.LogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LogID.FillWeight = 60F;
            this.LogID.HeaderText = "Log ID";
            this.LogID.Name = "LogID";
            this.LogID.ReadOnly = true;
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
            this.nameHeader.FillWeight = 120F;
            this.nameHeader.HeaderText = "Name of User";
            this.nameHeader.Name = "nameHeader";
            this.nameHeader.ReadOnly = true;
            this.nameHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // genderHeader
            // 
            this.genderHeader.FillWeight = 63.63636F;
            this.genderHeader.HeaderText = "Log Description";
            this.genderHeader.Name = "genderHeader";
            this.genderHeader.ReadOnly = true;
            // 
            // contactNumHeader
            // 
            this.contactNumHeader.FillWeight = 63.63636F;
            this.contactNumHeader.HeaderText = "Date";
            this.contactNumHeader.Name = "contactNumHeader";
            this.contactNumHeader.ReadOnly = true;
            // 
            // panelBorder2
            // 
            this.panelBorder2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder2.BackColor = System.Drawing.Color.White;
            this.panelBorder2.BorderRadius = 30;
            this.panelBorder2.Color = System.Drawing.Color.BurlyWood;
            this.panelBorder2.Controls.Add(this.cbSort);
            this.panelBorder2.ForeColor = System.Drawing.Color.Black;
            this.panelBorder2.Location = new System.Drawing.Point(62, 141);
            this.panelBorder2.Name = "panelBorder2";
            this.panelBorder2.Size = new System.Drawing.Size(1129, 58);
            this.panelBorder2.TabIndex = 14;
            // 
            // cbSort
            // 
            this.cbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSort.BackColor = System.Drawing.Color.White;
            this.cbSort.BorderColor = System.Drawing.Color.Gray;
            this.cbSort.BorderSize = 1;
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbSort.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.Color.DimGray;
            this.cbSort.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(211)))));
            this.cbSort.Items.AddRange(new object[] {
            "Default",
            "Alphabetical (Name)",
            "Earliest (Date Added)",
            "Latest (Date Added)"});
            this.cbSort.ListBackColor = System.Drawing.Color.White;
            this.cbSort.ListTextColor = System.Drawing.Color.Black;
            this.cbSort.Location = new System.Drawing.Point(876, 7);
            this.cbSort.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbSort.Name = "cbSort";
            this.cbSort.Padding = new System.Windows.Forms.Padding(1);
            this.cbSort.Size = new System.Drawing.Size(243, 48);
            this.cbSort.TabIndex = 14;
            this.cbSort.Texts = "Default";
            // 
            // LogsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelBorder2);
            this.Controls.Add(this.dataGridPatients);
            this.Controls.Add(this.LogHolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameHolder);
            this.Name = "LogsPage";
            this.Size = new System.Drawing.Size(1249, 758);
            this.Load += new System.EventHandler(this.LogsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPatients)).EndInit();
            this.panelBorder2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameHolder;
        private WindowsFormsApp2.CustomButton.PanelBorder LogHolder;
        private System.Windows.Forms.DataGridView dataGridPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumHeader;
        private WindowsFormsApp2.CustomButton.PanelBorder panelBorder2;
        private CustomControls.RJControls.RJComboBox cbSort;
    }
}
