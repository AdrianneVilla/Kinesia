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

        public string SelectedUser { get { return lblSelectedUser.Text; } set { lblSelectedUser.Text = value; } }
        public string Name { get { return lblName.Text; } set { lblName.Text = value; } }
        public string UserID { get { return lblUserID.Text; } set { lblUserID.Text = value; } }
        public string Role { get { return lblRole.Text; } set { lblRole.Text = value; } }
        public string Gender { get { return lblGender.Text; } set { lblGender.Text = value; } }
        public string Contact { get { return lblContact.Text; } set { lblContact.Text = value; } }
        public string Age { get { return lblAge.Text; } set { lblAge.Text = value; } }
        public string Address { get { return lblAddress.Text; } set { lblAddress.Text = value; } }
        public string Birthdate { get { return lblBirthdate.Text; } set { lblBirthdate.Text = value; } }
        public string Email { get { return lblEmail.Text; } set { lblEmail.Text = value; } }
        public string DateAdded { get { return lblDateAdded.Text; } set { lblDateAdded.Text = value; } }
        public string LastArchiveDate { get { return lblArchiveDate.Text; } set { lblArchiveDate.Text = value; } }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.userPage = new UserPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            PageObjects.CurrentControl = PageObjects.userPage;
        }
    }
}
