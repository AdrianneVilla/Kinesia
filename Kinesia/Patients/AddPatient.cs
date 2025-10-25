using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Patients
{
    public partial class AddPatient : UserControl
    {
        private bool isInitialized = false;
        public AddPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(1000, 700);
            this.AutoScroll = true;

            InitializeComponent();

        }

        private void ConfigureFlowLayoutPanelsForResponsiveness()
        {
            // Main FlowLayoutPanel (flowLayoutPanel5)
            flowLayoutPanel5.AutoSize = false;
            flowLayoutPanel5.WrapContents = false;
            flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel5.Resize += FlowLayoutPanel5_Resize;

            // Container panels (flowLayoutPanel1, flowLayoutPanel7, flowLayoutPanel13)
            ConfigureContainerPanel(flowLayoutPanel1);
            ConfigureContainerPanel(flowLayoutPanel7);

            // Configure the address section separately
            flowLayoutPanel13.AutoSize = false;
            flowLayoutPanel13.WrapContents = false;
            flowLayoutPanel13.FlowDirection = FlowDirection.TopDown;

            // Initial resize
            FlowLayoutPanel5_Resize(flowLayoutPanel5, EventArgs.Empty);
        }

        private void ConfigureContainerPanel(FlowLayoutPanel containerPanel)
        {
            containerPanel.AutoSize = false;
            containerPanel.WrapContents = true;
            containerPanel.FlowDirection = FlowDirection.LeftToRight;
        }

        private void FlowLayoutPanel5_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int availableWidth = flowLayoutPanel5.Width - flowLayoutPanel5.Padding.Left - flowLayoutPanel5.Padding.Right - 10;

            // Resize container panels to fill width
            flowLayoutPanel1.Width = availableWidth;
            flowLayoutPanel7.Width = availableWidth;
            flowLayoutPanel13.Width = availableWidth;
            flowLayoutPanel15.Width = availableWidth; // Button panel

            // Resize child panels inside containers
            ResizeChildPanelsInContainer(flowLayoutPanel1, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel7, availableWidth);

            // Special handling for flowLayoutPanel13 (Address section)
            ResizeAddressSection(flowLayoutPanel13, availableWidth);
        }

        private void ResizeChildPanelsInContainer(FlowLayoutPanel containerPanel, int containerWidth)
        {
            containerPanel.SuspendLayout();

            // Count how many child flowLayoutPanels
            List<FlowLayoutPanel> childPanels = new List<FlowLayoutPanel>();
            foreach (Control ctrl in containerPanel.Controls)
            {
                if (ctrl is FlowLayoutPanel childPanel)
                {
                    childPanels.Add(childPanel);
                }
            }

            if (childPanels.Count == 0)
            {
                containerPanel.ResumeLayout();
                return;
            }

            // Calculate width for each child panel with margins
            int margins = 5 * (childPanels.Count - 1); // Smaller margins
            int availableWidth = containerWidth - margins - 10;

            // Distribute width based on panel
            foreach (var childPanel in childPanels)
            {
                int panelWidth = 0;

                // Set widths based on which row/container
                if (containerPanel == flowLayoutPanel1) // First, Last, Middle Name row
                {
                    panelWidth = (int)(availableWidth / 3f); // Equal distribution
                }
                else if (containerPanel == flowLayoutPanel7) // Birthdate, Age, Gender, Contact, Occupation row
                {
                    if (childPanel == flowLayoutPanel8) // Birthdate
                        panelWidth = (int)(availableWidth * 0.26f);
                    else if (childPanel == flowLayoutPanel9) // Age
                        panelWidth = (int)(availableWidth * 0.11f);
                    else if (childPanel == flowLayoutPanel10) // Gender
                        panelWidth = (int)(availableWidth * 0.19f);
                    else if (childPanel == flowLayoutPanel11) // Contact
                        panelWidth = (int)(availableWidth * 0.20f);
                    else if (childPanel == flowLayoutPanel12) // Occupation
                        panelWidth = (int)(availableWidth * 0.20f);
                }

                childPanel.Width = panelWidth;

                // Resize controls inside each child panel
                ResizeControlsInChildPanel(childPanel, panelWidth);
            }

            containerPanel.ResumeLayout();
        }

        private void ResizeAddressSection(FlowLayoutPanel addressContainer, int containerWidth)
        {
            addressContainer.SuspendLayout();

            // Check if address is in a nested panel (flowLayoutPanel14)
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
                // Address is nested in flowLayoutPanel14
                addressPanel.Width = containerWidth - 20;

                foreach (Control innerCtrl in addressPanel.Controls)
                {
                    if (innerCtrl == txtAddress)
                    {
                        int addressWidth = addressPanel.Width - addressPanel.Padding.Left - addressPanel.Padding.Right - 10;
                        txtAddress.Width = addressWidth;
                    }
                }
            }
            else
            {
                // Address is directly in flowLayoutPanel13
                foreach (Control ctrl in addressContainer.Controls)
                {
                    if (ctrl == txtAddress)
                    {
                        int addressWidth = containerWidth - addressContainer.Padding.Left - addressContainer.Padding.Right - 20;
                        txtAddress.Width = addressWidth;
                    }
                }
            }

            addressContainer.ResumeLayout();
        }

        private void ResizeControlsInChildPanel(FlowLayoutPanel childPanel, int panelWidth)
        {
            int controlWidth = panelWidth - childPanel.Padding.Left - childPanel.Padding.Right - 10;

            childPanel.SuspendLayout();

            foreach (Control ctrl in childPanel.Controls)
            {
                // Skip labels - they don't need resizing
                if (ctrl is Label)
                    continue;

                if (ctrl is CustomControls.RJControls.RJTextBox txtBox)
                {
                    txtBox.Width = controlWidth;
                }
                else if (ctrl is CustomControls.RJControls.RJComboBox comboBox)
                {
                    // Set MinimumSize first to prevent size constraints
                    comboBox.MinimumSize = new Size(50, 30);

                    // Set the actual size
                    comboBox.Width = controlWidth;
                    comboBox.Size = new Size(controlWidth, comboBox.Height);

                    // Set MaximumSize to lock the width
                    comboBox.MaximumSize = new Size(controlWidth, 100);

                    // Force the control to update
                    comboBox.Refresh();
                }
                else if (ctrl is CustomControls.RJControls.RJDatePicker datePicker)
                {
                    datePicker.Width = controlWidth;
                }
            }

            childPanel.ResumeLayout();
        }

        private void SetupResponsiveLayout()
        {
            // Set anchors for header elements
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Main panel - stretch horizontally
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Main FlowLayoutPanel - stretch horizontally
            flowLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Button panel anchor
            flowLayoutPanel15.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Bottom buttons
            btnAddPatient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to Patient page?\n" +
                    "Any unsaved changes will be lost!", "Edit Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (backDialog == DialogResult.Yes)
                {
                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                    PageObjects.patientsPage = new PatientsPage();
                    PageObjects.dashboard.ContentsPanel.Controls.Clear();
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
                    PageObjects.CurrentControl = PageObjects.patientsPage;
                }
            }
            else
            {
                // will directly go back to Patient page if there's no unsaved input    
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.patientsPage = new PatientsPage();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
                PageObjects.CurrentControl = PageObjects.patientsPage;
            }
        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Texts = getAge().ToString(); // txtAge value will changed if the value of DatePicker dpBirthDate changed 
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {
            // Setup responsive layout
            SetupResponsiveLayout();

            // Configure FlowLayoutPanels for responsiveness
            ConfigureFlowLayoutPanelsForResponsiveness();

            isInitialized = true;

            dpBirthDate.Text = DateTime.Now.ToString(); // will set the value of DatePicker dpBirthDate to date today
            txtAge.BackColor = System.Drawing.Color.White;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void clearAllInputs()
        {
            txtFirstName.Texts = "";
            txtLastName.Texts = "";
            txtMiddleName.Texts = "";
            dpBirthDate.Value = DateTime.Now;
            cbGender.Texts = "";
            txtContact.Texts = "";
            txtOccupation.Texts = "";
            txtAddress.Texts = "";
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

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult clearDialog = CustomDialog.Show("Are you sure you want to clear inputs?\n" +
                    "Any unsaved inputs will be lost!", "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (clearDialog == DialogResult.Yes)
                {
                    clearAllInputs(); // will clear all inputs
                }
            }
        }

        private bool areInputsBlank()
        {
            if (!txtFirstName.Texts.Equals("") || !txtMiddleName.Texts.Equals("") || !txtLastName.Texts.Equals("") || !txtContact.Texts.Equals("") ||
                !txtOccupation.Texts.Equals("") || !txtAddress.Texts.Equals("") || !cbGender.Texts.Equals(""))
            {
                return true;
            }
            return false;
        }

        private async void btnAddPatient_Click(object sender, EventArgs e)
        {
            DialogResult addPatientDialog = CustomDialog.Show("Are you sure you want to add this patient?",
                        "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (addPatientDialog == DialogResult.Yes)
            {
                // will remove extra whitespaces on beginning and end of the textboxes
                txtFirstName.Texts = txtFirstName.Texts.Trim();
                txtLastName.Texts = txtLastName.Texts.Trim();
                txtMiddleName.Texts = txtMiddleName.Texts.Trim();
                txtContact.Texts = txtContact.Texts.Trim();
                txtOccupation.Texts = txtOccupation.Texts.Trim();
                txtAddress.Texts = txtAddress.Texts.Trim();

                DataHolder.PatientDataHolder = new PatientDataHolder // will create an insatnce of PatientDataHolder and set the values of it
                {
                    FirstName = txtFirstName.Texts,
                    MiddleName = txtMiddleName.Texts,
                    LastName = txtLastName.Texts,
                    Contact = txtContact.Texts,
                    Age = Convert.ToInt32(txtAge.Texts),
                    Birthdate = dpBirthDate.Value.ToString("yyyy-MM-dd"),
                    Gender = cbGender.Texts,
                    Address = txtAddress.Texts,
                    Occupation = txtOccupation.Texts,
                };

                if (Queries.PatientQueries.IsPatientDetailsComplete(DataHolder.PatientDataHolder) && !await Queries.PatientQueries.CheckExistingPatient(DataHolder.PatientDataHolder) &&
                    Queries.PatientQueries.IsAgeValid(DataHolder.PatientDataHolder) && Queries.PatientQueries.IsContactValid(DataHolder.PatientDataHolder))
                {
                    // will continue to add the patient if PatientDataHolder passed the data validations
                    string newPatientID = await this.FindForm().RunTaskWithLoading("Adding patient's data...", async () =>
                    {
                        return await Queries.PatientQueries.AddPatient(DataHolder.PatientDataHolder);
                    });

                    if (!string.IsNullOrEmpty(newPatientID))
                    {
                        // if adding patient was successful
                        // will add a log for adding a patient
                        // will clear all inputs
                        // will show a success message
                        // will redirect to Patient Details page
                        await Queries.LogsQueries.AddLog($"Added {newPatientID}", "Patients");

                        clearAllInputs();
                        CustomDialog.Show("Patient added successfully!",
                        "Add Patient Notification", CustomDialogButtons.OK, CustomDialogIcons.Information);
                        await this.FindForm().RunTaskWithLoading("Fetching patient's data...", async () =>
                        {
                            await Queries.PatientQueries.GetPatientDetails(newPatientID);
                        });
                    }
                    else
                    {
                        // if adding patient was not successful
                        // will show an error message
                        CustomDialog.Show("Failed to add patient!", "Add Patient Notification", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }

                }
                else
                {
                    DataHolder.PatientDataHolder = null; // will remove the instance of PatientDataHolder if it didn't pass the data validations
                }
            }

        }

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

        private void txtOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.CharactersOnly(sender, e);
        }
        #endregion

        private void panelBorder1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
