namespace CustomControls.RJControls
{
    partial class RJTextBox
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
            textBox1 = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox1.Location = new System.Drawing.Point(10, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(230, 22);
            textBox1.TabIndex = 0;
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.Leave += textBox1_Leave;
            textBox1.MouseEnter += textBox1_MouseEnter;
            textBox1.MouseLeave += textBox1_MouseLeave;
            // 
            // RJTextBox
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(textBox1);
            Font = new System.Drawing.Font("Poppins", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "RJTextBox";
            Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            Size = new System.Drawing.Size(250, 30);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}
