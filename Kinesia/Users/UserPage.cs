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
    public partial class UserPage : UserControl
    {
        public UserPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            PageObjects.displayUsers = new DisplayUsers();
            UsersHolder.Controls.Add(PageObjects.displayUsers);
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(PageObjects.CurrentControl);
            PageObjects.addUser = new AddUser();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addUser);
            PageObjects.CurrentControl = PageObjects.addUser;

        }
    }
}
