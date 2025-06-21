using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnEditAccount.Enabled = false;

            if (btnEditAccount.Enabled == false)
            {
                btnEditAccount.BackColor = Color.Gray;
                btnEditAccount.BorderColor = Color.DarkGray;
            }
        }
    }
}
