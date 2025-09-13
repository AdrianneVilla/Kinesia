using System;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // will only limit the Date Picker to age 18 of the current date
            // this means, the user can only pick a birth date that is 18 years old and older of the current date
            dpBirthDate.MaxDate = DateTime.Today.AddYears(-18);
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            DialogResult addUserDiag = CustomDialog.Show("Are you sure you want to add this user?", "Add User Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if(addUserDiag == DialogResult.Yes)
            {
                // will remove extra white spaces on beginning and end of the textboxes
                txtFirstName.Texts.Trim();
                txtLastName.Texts.Trim();
                txtMiddleName.Texts.Trim();
                txtContact.Texts.Trim();
                txtEmail.Texts.Trim();
                txtAddress.Texts.Trim();
                txtUsername.Texts.Trim();
                txtPassword.Texts.Trim();

                var userData = new UserDataHolder
                {
                    FirstName = txtFirstName.Texts,
                    LastName = txtLastName.Texts,
                    MiddleName = txtMiddleName.Texts,
                    BirthDate = dpBirthDate.Value.ToString("yyyy-MM-dd"),
                    Age = Convert.ToInt32(txtAge.Texts),
                    Gender = cbGender.Texts,
                    Contact = txtContact.Texts,
                    Email = txtEmail.Texts,
                    Address = txtAddress.Texts,
                    UserName = txtUsername.Texts,
                    Password = txtPassword.Texts,
                    Role = cbRole.Texts
                };

                if(Queries.UserQueries.IsUserDetailsComplete(userData) && !Queries.UserQueries.CheckExistingUser(userData) &&
                    Queries.UserQueries.IsContactValid(userData) && Queries.UserQueries.IsEmailValid(userData))
                {
                    // will continue to add the user if UserDataHolder passed the data validations
                    Queries.UserQueries.SetUserID(userData);
                    var success = await Queries.UserQueries.AddUser(userData);

                    if (success)
                    {
                        // will add a log for adding user
                        Queries.LogsQueries.AddLog($"Added {userData.UserID}", "Users");

                        clearInputs();
                        CustomDialog.Show("User has been added successfully!", "Add User Successful", CustomDialogButtons.OK, CustomDialogIcons.Information);
                        await Queries.UserQueries.GetUserDetails(userData.UserID);
                    } 
                    else
                    {
                        CustomDialog.Show("Add user failed!", "Add User Successful", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
        }

        private void clearInputs()
        {
            txtFirstName.Texts = "";
            txtLastName.Texts = "";
            txtMiddleName.Texts = "";
            dpBirthDate.Value = DateTime.Today.AddYears(-18);
            txtContact.Texts = "";
            txtEmail.Texts = "";
            txtAddress.Texts = "";
            txtUsername.Texts = "";
            txtPassword.Texts = "";
        }

        private bool areInputsBlank()
        {
            if (!txtFirstName.Texts.Equals("") || !txtLastName.Texts.Equals("") || !txtMiddleName.Texts.Equals("") || !txtContact.Texts.Equals("")
                || !txtEmail.Texts.Equals("") || !txtAddress.Texts.Equals("") || !txtUsername.Texts.Equals("") || !txtPassword.Texts.Equals(""))
            {
                return true;
            }
            return false;
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            if(areInputsBlank())
            {
                // will only show dialog if there's an unsaved inputs
                DialogResult clearInputDiag = CustomDialog.Show("Are you sure you want to clear inputs?\n" +
                    "Any unsaved inputs will be lost!", "Clear Input Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if(clearInputDiag == DialogResult.Yes)
                {
                    clearInputs(); // will clear all inputs
                }
            }
        }

        private int getAge()
        {
            int age = 0;

            DateTime birthDate = dpBirthDate.Value; // will get the value from dpBirthDate
            DateTime currentDate = DateTime.Now; // will get the currentDate

            int totalMonths = (currentDate.Year - birthDate.Year) * 12 + currentDate.Month - birthDate.Month; // will get the total months
            age = totalMonths / 12; // will divide the total months to 12 to get the age

            return age;
        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Texts = getAge().ToString();
        }

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
    }
}
