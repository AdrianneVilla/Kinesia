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
            Queries.UserQueries.GetUserDetails(lblUserID.Text);
        }

        public string UserID { get { return lblUserID.Text; } set { lblUserID.Text = value; } }
        public string Name { get { return lblName.Text; } set { lblName.Text = value; } }
        public string Role { get { return lblRole.Text; } set { lblRole.Text = value; } }
        public CustomButton BtnView { get { return btnView; } }
        public CustomButton BtnEdit { get { return btnEdit; } }
        public CustomButton BtnArchive { get { return btnArchive; } }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if(btnArchive.Tag == "Archive")
            {
                var archiveDiag = CustomDialog.Show($"Are you sure you want to archive {lblUserID.Text}?", "Archive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if(archiveDiag == DialogResult.Yes)
                {
                    Queries.UserQueries.ArchiveUser(lblUserID.Text);

                    // will add a log for archiving user
                    Queries.LogsQueries.AddLog($"Archived {lblUserID.Text}", "Users");

                    CustomDialog.Show($"{lblUserID.Text} has been archived successfully!", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                    Queries.UserQueries.DisplayUsers("", PageObjects.userPage.CurrentTab, "Default");
                }
            } 
            else
            {
                var unarchiveDiag = CustomDialog.Show($"Are you sure you want to unarchive {lblUserID.Text}?", "Unarchive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if(unarchiveDiag == DialogResult.Yes)
                {
                    Queries.UserQueries.UnarchiveUser(lblUserID.Text);

                    // will add a log for unarchiving user
                    Queries.LogsQueries.AddLog($"Unarchived {lblUserID.Text}", "Users");

                    CustomDialog.Show($"{lblUserID.Text} has been unarchived successfully!", "Unarchive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                    Queries.UserQueries.DisplayUsers("", PageObjects.userPage.CurrentTab, "Default");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataHolder.UserDataHolder = new UserDataHolder();
            Queries.UserQueries.GetUserDetails(lblUserID.Text, DataHolder.UserDataHolder);
            PageObjects.editUser.PreviousPage = "Users Page";
        }
    }
}
