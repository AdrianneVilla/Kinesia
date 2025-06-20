using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Components
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exitDiag = MessageBox.Show("Are you sure you want to exit the application?",
                                                    "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (exitDiag == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
