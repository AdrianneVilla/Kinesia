using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public partial class AddUser : UserControl
    {
        private bool isInitialized = false;

        public AddUser()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(1000, 700);
            this.AutoScroll = true;

            InitializeComponent();

            // CRITICAL: Reset all child panel locations to allow auto-layout
            ResetChildPanelLocations();
        }

        private void ResetChildPanelLocations()
        {
            // Reset name field panel locations to (0,0) to allow FlowLayoutPanel auto-positioning
            if (flowLayoutPanel3 != null) flowLayoutPanel3.Location = new Point(0, 0);
            if (flowLayoutPanel4 != null) flowLayoutPanel4.Location = new Point(0, 0);
            if (flowLayoutPanel5 != null) flowLayoutPanel5.Location = new Point(0, 0);

            // Reset account field panel locations
            if (flowLayoutPanel19 != null) flowLayoutPanel19.Location = new Point(0, 0);
            if (flowLayoutPanel20 != null) flowLayoutPanel20.Location = new Point(0, 0);
            if (flowLayoutPanel21 != null) flowLayoutPanel21.Location = new Point(0, 0);
            if (flowLayoutPanel22 != null) flowLayoutPanel22.Location = new Point(0, 0);

            // Reset other row panels
            if (flowLayoutPanel8 != null) flowLayoutPanel8.Location = new Point(0, 0);
            if (flowLayoutPanel9 != null) flowLayoutPanel9.Location = new Point(0, 0);
            if (flowLayoutPanel10 != null) flowLayoutPanel10.Location = new Point(0, 0);
            if (flowLayoutPanel11 != null) flowLayoutPanel11.Location = new Point(0, 0);
            if (flowLayoutPanel13 != null) flowLayoutPanel13.Location = new Point(0, 0);
            if (flowLayoutPanel15 != null) flowLayoutPanel15.Location = new Point(0, 0);
        }

        private void ConfigureFlowLayoutPanelsForResponsiveness()
        {
            // Main FlowLayoutPanel (flowLayoutPanel6)
            flowLayoutPanel6.AutoSize = false;
            flowLayoutPanel6.WrapContents = false;
            flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel6.Resize += FlowLayoutPanel6_Resize;

            // Container panels
            ConfigureContainerPanel(flowLayoutPanel2);  // Name fields (First, Last, Middle)
            ConfigureContainerPanel(flowLayoutPanel7);  // Birthdate, Age, Gender, Contact
            ConfigureContainerPanel(flowLayoutPanel12); // Email
            ConfigureContainerPanel(flowLayoutPanel18); // Account fields (Username, Password, Confirm Password, Role)

            // Configure the address section separately
            flowLayoutPanel14.AutoSize = false;
            flowLayoutPanel14.WrapContents = false;
            flowLayoutPanel14.FlowDirection = FlowDirection.TopDown;

            // Initial resize
            FlowLayoutPanel6_Resize(flowLayoutPanel6, EventArgs.Empty);
        }

        private void ConfigureContainerPanel(FlowLayoutPanel containerPanel)
        {
            containerPanel.AutoSize = false;
            containerPanel.WrapContents = true;
            containerPanel.FlowDirection = FlowDirection.LeftToRight;
            containerPanel.Padding = new Padding(0);
            containerPanel.Margin = new Padding(0);
        }

        private void FlowLayoutPanel6_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int availableWidth = flowLayoutPanel6.Width - flowLayoutPanel6.Padding.Left - flowLayoutPanel6.Padding.Right - 10;

            // Resize container panels to fill width AND SET HEIGHT
            flowLayoutPanel2.Width = availableWidth;
            flowLayoutPanel2.Height = 100;
            flowLayoutPanel2.Visible = true;

            flowLayoutPanel7.Width = availableWidth;
            flowLayoutPanel7.Height = 120;
            flowLayoutPanel7.Visible = true;

            flowLayoutPanel12.Width = availableWidth;
            flowLayoutPanel12.Height = 100;
            flowLayoutPanel12.Visible = true;

            flowLayoutPanel14.Width = availableWidth;
            flowLayoutPanel14.Height = 100;
            flowLayoutPanel14.Visible = true;

            flowLayoutPanel18.Width = availableWidth;
            flowLayoutPanel18.Height = 100;
            flowLayoutPanel18.Visible = true;

            flowLayoutPanel1.Width = availableWidth;

            // Resize child panels inside containers
            ResizeChildPanelsInContainer(flowLayoutPanel2, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel7, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel12, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel18, availableWidth);

            // Special handling for flowLayoutPanel14 (Address section)
            ResizeAddressSection(flowLayoutPanel14, availableWidth);

            // Force layout update
            flowLayoutPanel6.PerformLayout();
        }

        private void ResizeChildPanelsInContainer(FlowLayoutPanel containerPanel, int containerWidth)
        {
            containerPanel.SuspendLayout();
            containerPanel.Visible = true;

            List<FlowLayoutPanel> childPanels = new List<FlowLayoutPanel>();
            foreach (Control ctrl in containerPanel.Controls)
            {
                if (ctrl is FlowLayoutPanel childPanel)
                {
                    childPanels.Add(childPanel);
                    childPanel.Visible = true;
                    // CRITICAL: Reset margin to allow proper flow
                    childPanel.Margin = new Padding(3);
                }
            }

            if (childPanels.Count == 0)
            {
                containerPanel.ResumeLayout();
                return;
            }

            int margins = 10 * (childPanels.Count - 1);
            int availableWidth = containerWidth - margins - 20;

            foreach (var childPanel in childPanels)
            {
                int panelWidth = 0;

                if (containerPanel == flowLayoutPanel2) // NAME FIELDS (First, Last, Middle)
                {
                    // Proportional sizing for name fields
                    if (childPanel == flowLayoutPanel3) // First Name
                        panelWidth = Math.Max((int)(availableWidth * 0.38f), 200);
                    else if (childPanel == flowLayoutPanel4) // Last Name
                        panelWidth = Math.Max((int)(availableWidth * 0.36f), 200);
                    else if (childPanel == flowLayoutPanel5) // Middle Name
                        panelWidth = Math.Max((int)(availableWidth * 0.26f), 150);
                }
                else if (containerPanel == flowLayoutPanel7) // Birthdate, Age, Gender, Contact row
                {
                    if (childPanel == flowLayoutPanel8) // Birthdate
                        panelWidth = Math.Max((int)(availableWidth * 0.29f), 180);
                    else if (childPanel == flowLayoutPanel9) // Age
                        panelWidth = Math.Max((int)(availableWidth * 0.11f), 80);
                    else if (childPanel == flowLayoutPanel10) // Gender
                        panelWidth = Math.Max((int)(availableWidth * 0.22f), 140);
                    else if (childPanel == flowLayoutPanel11) // Contact
                        panelWidth = Math.Max((int)(availableWidth * 0.35f), 180);
                }
                else if (containerPanel == flowLayoutPanel12) // Email
                {
                    panelWidth = Math.Max(availableWidth / childPanels.Count, 250);
                }
                else if (containerPanel == flowLayoutPanel18) // Account fields (Username, Password, Confirm, Role)
                {
                    if (childPanel == flowLayoutPanel19) // Username
                        panelWidth = Math.Max((int)(availableWidth * 0.27f), 180);
                    else if (childPanel == flowLayoutPanel20) // Password
                        panelWidth = Math.Max((int)(availableWidth * 0.27f), 180);
                    else if (childPanel == flowLayoutPanel21) // Confirm Password
                        panelWidth = Math.Max((int)(availableWidth * 0.27f), 180);
                    else if (childPanel == flowLayoutPanel22) // Role
                        panelWidth = Math.Max((int)(availableWidth * 0.19f), 140);
                }

                childPanel.Width = panelWidth;
                childPanel.Height = 90;
                childPanel.MinimumSize = new Size(panelWidth, 90);
                childPanel.MaximumSize = new Size(panelWidth, 90);
                childPanel.Visible = true;

                ResizeControlsInChildPanel(childPanel, panelWidth);
            }

            containerPanel.ResumeLayout(true);
            containerPanel.PerformLayout();
        }

        private void ResizeAddressSection(FlowLayoutPanel addressContainer, int containerWidth)
        {
            addressContainer.SuspendLayout();

            FlowLayoutPanel addressPanel = null;
            foreach (Control ctrl in addressContainer.Controls)
            {
                if (ctrl is FlowLayoutPanel fp)
                {
                    addressPanel = fp;
                    break;
                }
            }

            if (addressPanel != null)
            {
                addressPanel.Width = containerWidth - 20;
                addressPanel.Visible = true;

                foreach (Control innerCtrl in addressPanel.Controls)
                {
                    if (innerCtrl == txtAddress)
                    {
                        int addressWidth = Math.Max(addressPanel.Width - addressPanel.Padding.Left - addressPanel.Padding.Right - 10, 300);
                        txtAddress.Width = addressWidth;
                        txtAddress.Visible = true;
                    }
                }
            }
            else
            {
                foreach (Control ctrl in addressContainer.Controls)
                {
                    if (ctrl == txtAddress)
                    {
                        int addressWidth = Math.Max(containerWidth - addressContainer.Padding.Left - addressContainer.Padding.Right - 20, 300);
                        txtAddress.Width = addressWidth;
                        txtAddress.Visible = true;
                    }
                }
            }

            addressContainer.ResumeLayout();
        }

        private void ResizeControlsInChildPanel(FlowLayoutPanel childPanel, int panelWidth)
        {
            int controlWidth = Math.Max(panelWidth - childPanel.Padding.Left - childPanel.Padding.Right - 10, 80);

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
                else if (ctrl is CustomControls.RJControls.RJComboBox comboBox)
                {
                    comboBox.MinimumSize = new Size(80, 30);
                    comboBox.Width = controlWidth;
                    comboBox.Size = new Size(controlWidth, comboBox.Height);
                    comboBox.MaximumSize = new Size(controlWidth, 100);
                    comboBox.Visible = true;
                    comboBox.Refresh();
                }
                else if (ctrl is CustomControls.RJControls.RJDatePicker datePicker)
                {
                    datePicker.Width = controlWidth;
                    datePicker.MinimumSize = new Size(150, datePicker.Height);
                    datePicker.Visible = true;
                }
            }

            childPanel.ResumeLayout();
        }

        private void SetupResponsiveLayout()
        {
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            SetupResponsiveLayout();

            isInitialized = true;

            ConfigureFlowLayoutPanelsForResponsiveness();

            dpBirthDate.MaxDate = DateTime.Today.AddYears(-18);
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            DialogResult addUserDiag = CustomDialog.Show("Are you sure you want to add this user?", "Add User Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);
            if (addUserDiag == DialogResult.Yes)
            {
                txtFirstName.Texts = txtFirstName.Texts.Trim();
                txtLastName.Texts = txtLastName.Texts.Trim();
                txtMiddleName.Texts = txtMiddleName.Texts.Trim();
                txtContact.Texts = txtContact.Texts.Trim();
                txtEmail.Texts = txtEmail.Texts.Trim();
                txtAddress.Texts = txtAddress.Texts.Trim();
                txtUsername.Texts = txtUsername.Texts.Trim();
                txtPassword.Texts = txtPassword.Texts.Trim();

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

                if (Queries.UserQueries.IsUserDetailsComplete(userData) && !await Queries.UserQueries.CheckExistingUser(userData) &&
                    Queries.UserQueries.IsContactValid(userData) && Queries.UserQueries.IsEmailValid(userData) &&
                    Queries.UserQueries.IsPasswordConfirmed(txtPassword.Texts, txtConfirmPassword.Texts) &&
                    !await Queries.UserQueries.CheckExistingAccount(txtUsername.Texts))
                {
                    string newUserID = await Queries.UserQueries.AddUser(userData);

                    if (!string.IsNullOrEmpty(newUserID))
                    {
                        await Queries.LogsQueries.AddLog($"Added {newUserID}", "Users");
                        clearInputs();
                        CustomDialog.Show("User has been added successfully!", "Add User Successful", CustomDialogButtons.OK, CustomDialogIcons.Information);
                        await Queries.UserQueries.GetUserDetails(newUserID);
                    }
                    else
                    {
                        CustomDialog.Show("Add user failed!", "Add User Unsuccessful", CustomDialogButtons.OK, CustomDialogIcons.Error);
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
            txtConfirmPassword.Texts = "";
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
            if (areInputsBlank())
            {
                DialogResult clearInputDiag = CustomDialog.Show("Are you sure you want to clear inputs?\n" +
                    "Any unsaved inputs will be lost!", "Clear Input Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (clearInputDiag == DialogResult.Yes)
                {
                    clearInputs();
                }
            }
        }

        private int getAge()
        {
            int age = 0;
            DateTime birthDate = dpBirthDate.Value;
            DateTime currentDate = DateTime.Now;
            int totalMonths = (currentDate.Year - birthDate.Year) * 12 + currentDate.Month - birthDate.Month;
            age = totalMonths / 12;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to User page?\n" +
                    "Any unsaved changes will be lost!", "Go back to user page?", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

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
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.userPage = new UserPage();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
                PageObjects.CurrentControl = PageObjects.userPage;
            }
        }

        private void newBtnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
