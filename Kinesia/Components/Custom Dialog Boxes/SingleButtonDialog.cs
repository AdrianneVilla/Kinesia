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
    public partial class SingleButtonDialog : UserControl
    {
        public SingleButtonDialog()
        {
            InitializeComponent();
            this.Controls.Add(this);
        }

        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        public string Description { get { return lblDescription.Text; } set { lblDescription.Text = value; } }
        public PictureBox DialogIcon { get { return imgDialogIcon; } set { imgDialogIcon = value; } }
    }
}
