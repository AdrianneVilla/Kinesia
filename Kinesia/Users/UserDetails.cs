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
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
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
        public string Username { get { return lblUsername.Text; } set { lblUsername.Text = value; } }
        public string DateAdded { get { return lblDateAdded.Text; } set { lblDateAdded.Text = value; } }
        public string LastArchiveDate { get { return lblArchiveDate.Text; } set { lblArchiveDate.Text = value; } }
        public string Status { get { return lblStatus.Text; } set { lblStatus.Text = value; } }
        public CustomButton BtnArchive { get { return btnArchive; } }
        private void btnBack_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.userPage = new UserPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            PageObjects.CurrentControl = PageObjects.userPage;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            DataHolder.UserDataHolder = new UserDataHolder();
            await Queries.UserQueries.GetUserDetails(lblUserID.Text, DataHolder.UserDataHolder);
            PageObjects.editUser.PreviousPage = "User Details Page";
        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Active")
            {
                var archiveDiag = CustomDialog.Show($"Are you sure you want to archive {lblUserID.Text}?", "Archive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (archiveDiag == DialogResult.Yes)
                {
                    var success = await Queries.UserQueries.UpdateUserStatus(lblUserID.Text, 0);

                    if (success)
                    {
                        // will add a log for archiving user
                        await Queries.LogsQueries.AddLog($"Archived {lblUserID.Text}", "Users");

                        CustomDialog.Show($"{lblUserID.Text} has been archived successfully!", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                        await Queries.UserQueries.GetUserDetails(lblUserID.Text);
                    }
                    else
                    {
                        CustomDialog.Show($"Failed to archive {lblUserID.Text}", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
            else
            {
                var unarchiveDiag = CustomDialog.Show($"Are you sure you want to unarchive {lblUserID.Text}?", "Unarchive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (unarchiveDiag == DialogResult.Yes)
                {
                    var success = await Queries.UserQueries.UpdateUserStatus(lblUserID.Text, 1);

                    if (success)
                    {
                        // will add a log for unarchiving user
                        await Queries.LogsQueries.AddLog($"Unarchived {lblUserID.Text}", "Users");

                        CustomDialog.Show($"{lblUserID.Text} has been unarchived successfully!", "Unarchive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                        await Queries.UserQueries.GetUserDetails(lblUserID.Text);
                    }
                    else
                    {
                        CustomDialog.Show($"Failed to unarchive {lblUserID.Text}", "Unarchive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            if (lblArchiveDate.Text != "N/A")
            {
                if (lblStatus.Text == "Active")
                {
                    lastArchiveUnarchiveDateLabel.Text = "Last Unarchive Date:";
                }
                else
                {
                    lastArchiveUnarchiveDateLabel.Text = "Last Archive Date:";
                }
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            DialogResult resetPasswordDiag = CustomDialog.Show($"Are you sure you want to reset {lblUserID.Text}'s password?\n" +
                $"Resetting it will set its password to username.birthday (e.g., juan.20021128).\n" +
                $"Do you want to continue?", "Reset Password", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

            if(resetPasswordDiag == DialogResult.Yes)
            {
                var success = await Queries.UserQueries.ResetPassword(lblUserID.Text);

                if (success)
                {
                    CustomDialog.Show($"{lblUserID.Text}'s password has been reset successfully!", "Reset Password",
                        CustomDialogButtons.OK, CustomDialogIcons.Information);
                    await Queries.LogsQueries.AddLog($"Reset {lblUserID.Text}'s password", "Users");
                }
                else
                {
                    CustomDialog.Show($"Failed to reset {lblUserID}'s password", "Reset Password",
                        CustomDialogButtons.OK, CustomDialogIcons.Information);
                }
            }
        }
    }
}
