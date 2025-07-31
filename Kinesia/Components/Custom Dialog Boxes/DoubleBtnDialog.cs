using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Components.Custom_Dialog_Boxes
{
    public partial class DoubleBtnDialog : Form, ICustomDialog
    {
        public DoubleBtnDialog()
        {
            InitializeComponent();
        }

        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        public string Description { get { return lblDescription.Text; } set { lblDescription.Text = value; } }
        public PictureBox DialogIcon { get { return pbIcon; } set { pbIcon = value; } }

        private void btnYes_Enter(object sender, EventArgs e)
        {
            // will change the btnYes and btnNo colors when btnYes got focus
            btnYes.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnYes.ForeColor = Color.White;

            btnNo.BackgroundColor = Color.Silver;
            btnNo.ForeColor = Color.Black;

        }

        private void btnNo_Enter(object sender, EventArgs e)
        {
            // will change the btnYes and btnNo colors when btnNo got focus
            btnNo.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnNo.ForeColor = Color.White;

            btnYes.BackgroundColor = Color.Silver;
            btnYes.ForeColor = Color.Black;
        }
    }
}
