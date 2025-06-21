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
    public partial class DisplayUsers : UserControl
    {
        public DisplayUsers()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.Dock = DockStyle.Top;
            InitializeComponent();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            PageObjects.userDetails = new UserDetails();

            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.userDetails);
        }
    }
}
