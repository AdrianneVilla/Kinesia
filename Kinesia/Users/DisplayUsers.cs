using OrganizationProfile;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            Queries.UserQueries.GetUserDetails(btnView.Tag.ToString());
        }

        public string UserID { get { return lblUserID.Text; } set { lblUserID.Text = value; } }
        public string Name { get { return lblName.Text; } set { lblName.Text = value; } }
        public string Role { get { return lblRole.Text; } set { lblRole.Text = value; } }
        public CustomButton BtnView { get { return btnView; } }
        public CustomButton BtnEdit { get { return btnEdit; } }
        public CustomButton BtnArchive { get { return btnArchive; } }
    }
}
