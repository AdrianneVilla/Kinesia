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
        private bool isInitialized = false;
        public string PreviousPage { get { return previousPage; } set { previousPage = value; } }
        public EditUser()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(1000, 700);
            this.AutoScroll = true; 
            InitializeComponent();

            // Reset child panel locations for proper flow
            ResetChildPanelLocations();


            RemoveFixedAnchors();
        }

        private void RemoveFixedAnchors()
        {
            // Remove anchors from controls that need to be dynamically positioned
            txtFirstName.Anchor = AnchorStyles.None;
            txtLastName.Anchor = AnchorStyles.None;
            txtMiddleName.Anchor = AnchorStyles.None;
            dpBirthDate.Anchor = AnchorStyles.None;
            txtAge.Anchor = AnchorStyles.None;
            cbGender.Anchor = AnchorStyles.None;
            txtContact.Anchor = AnchorStyles.None;
            txtEmail.Anchor = AnchorStyles.None;
            cbRole.Anchor = AnchorStyles.None;
            txtAddress.Anchor = AnchorStyles.None;
            label11.Anchor = AnchorStyles.None; // Account Information label
            flowLayoutPanel1.Anchor = AnchorStyles.None; // Account section

            // Also remove anchors from labels
            label4.Anchor = AnchorStyles.None;
            label2.Anchor = AnchorStyles.None;
            label10.Anchor = AnchorStyles.None;
            lblBirthDate.Anchor = AnchorStyles.None;
            lblAge.Anchor = AnchorStyles.None;
            label5.Anchor = AnchorStyles.None;
            label8.Anchor = AnchorStyles.None;
            label16.Anchor = AnchorStyles.None;
            label15.Anchor = AnchorStyles.None;
            label9.Anchor = AnchorStyles.None;
        }

        private void ResetChildPanelLocations()
        {
            // Reset account field panel locations to allow FlowLayoutPanel auto-positioning
            if (flowLayoutPanel2 != null) flowLayoutPanel2.Location = new Point(0, 0);
            if (flowLayoutPanel3 != null) flowLayoutPanel3.Location = new Point(0, 0);
            if (flowLayoutPanel4 != null) flowLayoutPanel4.Location = new Point(0, 0);
            if (flowLayoutPanel5 != null) flowLayoutPanel5.Location = new Point(0, 0);
        }

        private void ConfigureResponsiveness()
        {
            // Configure the account fields FlowLayoutPanel
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Padding = new Padding(0);
            flowLayoutPanel1.Margin = new Padding(0);

            // Set up resize event
            this.Resize += EditUser_Resize;

            // Initial resize
            EditUser_Resize(this, EventArgs.Empty);
        }

        private void EditUser_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int containerWidth = panelBorder1.Width;
            int availableWidth = containerWidth - 120; // Account for margins (60px on each side)
            int leftMargin = 56;

            // Row 1: First Name, Last Name, Middle Name (3 equal columns with spacing)
            int spacing = 30;
            int nameFieldWidth = Math.Max((int)((availableWidth - (2 * spacing)) / 3f), 200);

            txtFirstName.Location = new Point(leftMargin, 129);
            txtFirstName.Width = nameFieldWidth;
            label4.Location = new Point(txtFirstName.Left - 5, 103);

            txtLastName.Location = new Point(txtFirstName.Right + spacing, 129);
            txtLastName.Width = nameFieldWidth;
            label2.Location = new Point(txtLastName.Left - 5, 103);

            txtMiddleName.Location = new Point(txtLastName.Right + spacing, 129);
            txtMiddleName.Width = nameFieldWidth;
            label10.Location = new Point(txtMiddleName.Left - 5, 103);

            // Row 2: Birthdate, Age, Gender, Contact
            int row2Y = 242;

            // Calculate widths so they fit properly
            int row2TotalWidth = availableWidth - (3 * spacing); // Account for 3 gaps
            int birthdateWidth = Math.Max((int)(row2TotalWidth * 0.31f), 180);
            int ageWidth = Math.Max((int)(row2TotalWidth * 0.12f), 80);
            int genderWidth = Math.Max((int)(row2TotalWidth * 0.22f), 140);
            int contactWidth = row2TotalWidth - birthdateWidth - ageWidth - genderWidth; // Use remaining space

            dpBirthDate.Location = new Point(leftMargin + 3, row2Y);
            dpBirthDate.Width = birthdateWidth;
            lblBirthDate.Location = new Point(dpBirthDate.Left - 4, row2Y - 26);

            txtAge.Location = new Point(dpBirthDate.Right + spacing, row2Y);
            txtAge.Width = ageWidth;
            lblAge.Location = new Point(txtAge.Left - 4, row2Y - 29);

            cbGender.Location = new Point(txtAge.Right + spacing, row2Y);
            cbGender.Width = genderWidth;
            label5.Location = new Point(cbGender.Left - 5, row2Y - 29);

            txtContact.Location = new Point(cbGender.Right + spacing, row2Y);
            txtContact.Width = Math.Max(contactWidth, 150); // Ensure minimum width
            label8.Location = new Point(txtContact.Left - 4, row2Y - 29);

            // Row 3: Email, Role
            int row3Y = 351;
            int emailWidth = Math.Max((int)(availableWidth * 0.60f), 300);
            int roleWidth = Math.Max((int)(availableWidth * 0.34f), 200);

            txtEmail.Location = new Point(leftMargin, row3Y);
            txtEmail.Width = emailWidth;
            label16.Location = new Point(txtEmail.Left - 1, row3Y - 27);

            cbRole.Location = new Point(txtEmail.Right + spacing, row3Y);
            cbRole.Width = roleWidth;
            label15.Location = new Point(cbRole.Left - 4, row3Y - 26);

            // Address (full width)
            int addressY = 464;
            txtAddress.Location = new Point(leftMargin, addressY);
            txtAddress.Width = availableWidth;
            label9.Location = new Point(txtAddress.Left - 5, addressY - 27);

            // Account Information section - positioned BELOW address with proper spacing
            int accountLabelY = addressY + 119 + 50; // Address Y + Address Height + 50px gap
            label11.Location = new Point(leftMargin - 2, accountLabelY);

            // Account section FlowLayoutPanel - positioned below label11
            int accountPanelY = accountLabelY + 37; // Label11 Y + 37px gap
            flowLayoutPanel1.Location = new Point(leftMargin - 3, accountPanelY);
            flowLayoutPanel1.Width = availableWidth + 10;
            ResizeAccountSection(availableWidth);

            // Force layout update
            panelBorder1.PerformLayout();
        }

        private void ResizeAccountSection(int containerWidth)
        {
            flowLayoutPanel1.SuspendLayout();

            List<FlowLayoutPanel> childPanels = new List<FlowLayoutPanel>();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is FlowLayoutPanel childPanel)
                {
                    childPanels.Add(childPanel);
                    childPanel.Visible = true;
                    childPanel.Margin = new Padding(3);
                }
            }

            if (childPanels.Count == 0)
            {
                flowLayoutPanel1.ResumeLayout();
                return;
            }

            int margins = 10 * (childPanels.Count - 1);
            int availableWidth = containerWidth - margins;

            foreach (var childPanel in childPanels)
            {
                int panelWidth = 0;

                // Account fields: Username, Old Password, New Password, Confirm Password
                if (childPanel == flowLayoutPanel2) // Username
                    panelWidth = Math.Max((int)(availableWidth * 0.23f), 180);
                else if (childPanel == flowLayoutPanel3) // Old Password
                    panelWidth = Math.Max((int)(availableWidth * 0.23f), 180);
                else if (childPanel == flowLayoutPanel4) // New Password
                    panelWidth = Math.Max((int)(availableWidth * 0.24f), 180);
                else if (childPanel == flowLayoutPanel5) // Confirm Password
                    panelWidth = Math.Max((int)(availableWidth * 0.25f), 180);

                childPanel.Width = panelWidth;
                childPanel.Height = 90;
                childPanel.MinimumSize = new Size(panelWidth, 90);
                childPanel.MaximumSize = new Size(panelWidth, 90);
                childPanel.Visible = true;

                ResizeControlsInChildPanel(childPanel, panelWidth);
            }

            flowLayoutPanel1.ResumeLayout(true);
            flowLayoutPanel1.PerformLayout();
        }

        private void ResizeControlsInChildPanel(FlowLayoutPanel childPanel, int panelWidth)
        {
            int controlWidth = Math.Max(panelWidth - 20, 80);

            childPanel.SuspendLayout();

            foreach (Control ctrl in childPanel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Visible = true;
                    lbl.AutoSize = true;
                    continue;
                }

                if (ctrl is CustomControls.RJControls.RJTextBox txtBox)
                {
                    txtBox.Width = controlWidth;
                    txtBox.MinimumSize = new Size(80, txtBox.Height);
                    txtBox.Visible = true;
                }
            }

            childPanel.ResumeLayout();
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

            if (DataHolder.UserDataHolder.Gender == "Male")
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
            cbRole.Texts = DataHolder.UserDataHolder.Role;

            if (DataHolder.UserDataHolder.Role == "Admin")
            {
                cbRole.SelectedIndex = 0; // will set the cbRole value to Admin
            }
            else
            {
                cbRole.SelectedIndex = 1; // will set the cbRole value to Therapist
            }

            isInitialized = true;
            ConfigureResponsiveness();
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DialogResult updateDiag = CustomDialog.Show("Are you sure you want to update\n" +
                $"{DataHolder.UserDataHolder.UserID}'s personal Information?", "Save changes", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (updateDiag == DialogResult.Yes)
            {
                txtFirstName.Texts = txtFirstName.Texts.Trim();
                txtLastName.Texts = txtLastName.Texts.Trim();
                txtLastName.Texts = txtLastName.Texts.Trim();
                txtContact.Texts = txtContact.Texts.Trim();
                txtEmail.Texts = txtEmail.Texts.Trim();
                txtAddress.Texts = txtAddress.Texts.Trim();
                txtUsername.Texts = txtUsername.Texts.Trim();
                txtPassword.Texts = txtPassword.Texts.Trim();
                txtNewPassword.Texts = txtNewPassword.Texts.Trim();
                txtConfirmPassword.Texts = txtConfirmPassword.Texts.Trim();

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
                userData.Role = cbRole.Texts;

                if (Queries.UserQueries.IsUserEditDetailsComplete(userData) && Queries.UserQueries.IsContactValid(userData) &&
                    Queries.UserQueries.IsEmailValid(userData))
                {
                    if (DataHolder.UserDataHolder.FirstName != userData.FirstName || DataHolder.UserDataHolder.LastName != userData.LastName ||
                        DataHolder.UserDataHolder.MiddleName != userData.MiddleName)
                    {
                        // will only check existing user if
                        // first, last, and middle name data were changed
                        if (await Queries.UserQueries.CheckExistingUser(userData))
                        {
                            return; // will exit the update method if user was already existing
                        }
                    }

                    if(DataHolder.UserDataHolder.UserName != userData.UserName)
                    {
                        if(await Queries.UserQueries.CheckExistingAccount(userData.UserName))
                        {
                            return;
                        }
                    }

                    if(txtPassword.Texts != "")
                    {
                        if (!Queries.UserQueries.IsOldPasswordCorrect(txtPassword.Texts, DataHolder.UserDataHolder) ||
                            !Queries.UserQueries.IsPasswordConfirmed(txtNewPassword.Texts, txtConfirmPassword.Texts))
                        {
                            return;
                        }

                        userData.Salt = CustomSecurity.GenerateSalt();
                        userData.Password = CustomSecurity.HashPassword(txtNewPassword.Texts, userData.Salt);
                    }

                    var success = await Queries.UserQueries.UpdateUser(userData);

                    if (success)
                    {
                        // will add a log for editing user
                        await Queries.LogsQueries.AddLog($"Edited {DataHolder.UserDataHolder.UserID}'s personal information", "Users");

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
                (txtPassword.Texts != "" && txtNewPassword.Texts != "" && txtConfirmPassword.Texts != "") ||
                cbRole.Texts.Trim() != user.Role;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (previousPage == "Users Page")
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

        private void txtNewPassword__TextChanged(object sender, EventArgs e)
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

        private void txtConfirmPassword__TextChanged(object sender, EventArgs e)
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
