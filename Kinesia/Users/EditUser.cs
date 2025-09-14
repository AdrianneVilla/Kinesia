using Kinesia.Patients;
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
    public partial class EditUser : UserControl
    {
        private string previousPage;

        public string PreviousPage { get { return previousPage; } set { previousPage = value; } }   
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            // will only limit the Date Picker to age 18 of the current date
            // this means, the user can only pick a birth date that is 18 years old and older of the current date
            dpBirthDate.MaxDate = DateTime.Today.AddYears(-18);

            lblUserID.Text = DataHolder.UserDataHolder.UserID + " Personal Information";
            txtFirstName.Texts = DataHolder.UserDataHolder.FirstName;
            txtLastName.Texts = DataHolder.UserDataHolder.LastName;
            txtMiddleName.Texts = DataHolder.UserDataHolder.MiddleName;
            dpBirthDate.Value = DateTime.Parse(DataHolder.UserDataHolder.BirthDate);
            txtAge.Texts = getAge().ToString();

            if(DataHolder.UserDataHolder.Gender == "Male")
            {
                cbGender.SelectedIndex = 0; // will set the cbGender value to Male
            } 
            else
            {
                cbGender.SelectedIndex = 1; // will set the cbGender value to Female
            }

            txtContact.Texts = DataHolder.UserDataHolder.Contact.Remove(0, 3); // will remove the "+63" from the contact
            txtEmail.Texts = DataHolder.UserDataHolder.Email;
            txtAddress.Texts = DataHolder.UserDataHolder.Address;
            txtUsername.Texts = DataHolder.UserDataHolder.UserName;
            txtPassword.Texts = DataHolder.UserDataHolder.Password;
            
            if(DataHolder.UserDataHolder.Role == "Admin")
            {
                cbRole.SelectedIndex = 0; // will set the cbRole value to Admin
            } 
            else
            {
                cbRole.SelectedIndex = 1; // will set the cbRole value to Therapist
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DialogResult updateDiag = CustomDialog.Show("Are you sure you want to update\n" +
                $"{DataHolder.UserDataHolder.UserID}'s personal Information?", "Save changes", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if(updateDiag == DialogResult.Yes)
            {
                txtFirstName.Texts.Trim();
                txtLastName.Texts.Trim();
                txtLastName.Texts.Trim();
                txtContact.Texts.Trim();
                txtEmail.Texts.Trim();
                txtAddress.Texts.Trim();
                txtUsername.Texts.Trim();
                txtPassword.Texts.Trim();

                var userData = new UserDataHolder();
                userData.UserID = DataHolder.UserDataHolder.UserID;
                userData.FirstName = txtFirstName.Texts;
                userData.LastName = txtLastName.Texts;
                userData.MiddleName = txtMiddleName.Texts;
                userData.BirthDate = dpBirthDate.Value.ToString("yyyy-MM-dd");
                userData.Gender = cbGender.Texts;
                userData.Contact = txtContact.Texts;
                userData.Email = txtEmail.Texts;
                userData.Address = txtAddress.Texts;
                userData.UserName = txtUsername.Texts;
                userData.Password = txtPassword.Texts;
                userData.Role = cbRole.Texts;

                if(Queries.UserQueries.IsUserDetailsComplete(userData) && Queries.UserQueries.IsContactValid(userData) &&
                    Queries.UserQueries.IsEmailValid(userData))
                {
                    if(DataHolder.UserDataHolder.FirstName != userData.FirstName || DataHolder.UserDataHolder.LastName != userData.LastName || 
                        DataHolder.UserDataHolder.MiddleName != userData.MiddleName)
                    {
                        // will only check existing user if
                        // first, last, and middle name data were changed
                        if (Queries.UserQueries.CheckExistingUser(userData))
                        {
                            return; // will exit the update method if user was already existing
                        }
                    }

                    var success = await Queries.UserQueries.UpdateUser(userData);

                    if (success)
                    {
                        // will add a log for editing user
                        Queries.LogsQueries.AddLog($"Edited {DataHolder.UserDataHolder.UserID}'s personal information", "Users");

                        CustomDialog.Show($"{DataHolder.UserDataHolder.UserID}'s personal information \n" +
                            $"has been updated successfully!", "Update successful", CustomDialogButtons.OK, CustomDialogIcons.Information);

                        // will go back to User page
                        PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                        PageObjects.userPage = new UserPage();
                        PageObjects.dashboard.ContentsPanel.Controls.Clear();
                        PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
                        PageObjects.CurrentControl = PageObjects.userPage;
                    } 
                    else
                    {
                        CustomDialog.Show($"Failed to edit {userData.UserID}'s personal information", "Failed to edit", CustomDialogButtons.OK, CustomDialogIcons.Information);
                    }
                }
            }
        }

        private int getAge()
        {
            int age = 0;

            var birthDate = dpBirthDate.Value; // will get the value from dpBirthDate
            var currentDate = DateTime.Now; // will get the currentDate

            int totalMonths = (currentDate.Year - birthDate.Year) * 12 + currentDate.Month - birthDate.Month; // will get the total months
            age = totalMonths / 12; // will divide the total months to 12 to get the age

            return age;
        }

        private bool hasChanged()
        {
            var user = DataHolder.UserDataHolder;

            return
                txtFirstName.Texts.Trim() != user.FirstName ||
                txtLastName.Texts.Trim() != user.LastName ||
                txtMiddleName.Texts.Trim() != user.MiddleName ||
                dpBirthDate.Value.ToString("yyyy-MM-dd") != user.BirthDate ||
                cbGender.Texts != user.Gender ||
                txtContact.Texts.Trim() != user.Contact.Remove(0, 3) ||
                txtEmail.Texts.Trim() != user.Email ||
                txtAddress.Texts.Trim() != user.Address ||
                txtUsername.Texts.Trim() != user.UserName ||
                txtPassword.Texts.Trim() != user.Password ||
                cbRole.Texts.Trim() != user.Role;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(previousPage == "Users Page")
            {
                goBackToUserPage();
            } 
            else
            {
                goBackToUserDetailsPage();
            }
        }

        private void goBackToUserPage()
        {
            if (hasChanged())
            {
                // will only show dialog if there's an unsaved changes
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to User page?\n" +
                    "Any unsaved changes will be lost!", "Go back to User page", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                if (backDialog == DialogResult.Yes)
                {
                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                    PageObjects.userPage = new UserPage();
                    PageObjects.dashboard.ContentsPanel.Controls.Clear();
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
                    PageObjects.CurrentControl = PageObjects.userPage;
                }
            }
            else
            {
                // will go back to user page directly if there's no unsaved changes
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.userPage = new UserPage();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
                PageObjects.CurrentControl = PageObjects.userPage;
            }
        }

        private async void goBackToUserDetailsPage()
        {
            if (hasChanged())
            {
                // will only show dialog if there's an unsaved changes
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to User Details page?\n" +
                    "Any unsaved changes will be lost!", "Go back to User page", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                if (backDialog == DialogResult.Yes)
                {
                    await Queries.UserQueries.GetUserDetails(DataHolder.UserDataHolder.UserID);
                }
            }
            else
            {
                // will go back to user details page directly if there's no unsaved changes
                await Queries.UserQueries.GetUserDetails(DataHolder.UserDataHolder.UserID);
            }
        }

        #region btnSaveChanges Visibility
        // Everytime the input value has changed
        // it will check if there's a changes/difference to the original value
        // will show btnSaveChange if there's changes/difference to the original value
        // will remove btnSaveChange if there's no changes/difference to the original value
        private void txtFirstName__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtLastName__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtMiddleName__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Texts = getAge().ToString();

            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void cbGender_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtContact__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtEmail__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtAddress__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtUsername__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void txtPassword__TextChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        private void cbRole_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                btnSaveChanges.Visible = true;
            }
            else
            {
                btnSaveChanges.Visible = false;
            }
        }

        #endregion

        #region Textboxes Input Validation
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.CharactersOnly(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.CharactersOnly(sender, e);
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.CharactersOnly(sender, e);
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.WholeNumbersOnly(sender, e);
        }
        #endregion
    }
}
