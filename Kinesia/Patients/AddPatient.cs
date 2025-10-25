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

            ResetChildPanelLocations(); 

        }
        private void ResetChildPanelLocations()
        {
            // Reset name field panel locations to (0,0) to allow FlowLayoutPanel auto-positioning
            if (flowLayoutPanel2 != null) flowLayoutPanel2.Location = new Point(0, 0);
            if (flowLayoutPanel3 != null) flowLayoutPanel3.Location = new Point(0, 0);
            if (flowLayoutPanel4 != null) flowLayoutPanel4.Location = new Point(0, 0);

            // Reset other row panels
            if (flowLayoutPanel8 != null) flowLayoutPanel8.Location = new Point(0, 0);
            if (flowLayoutPanel9 != null) flowLayoutPanel9.Location = new Point(0, 0);
            if (flowLayoutPanel10 != null) flowLayoutPanel10.Location = new Point(0, 0);
            if (flowLayoutPanel11 != null) flowLayoutPanel11.Location = new Point(0, 0);
            if (flowLayoutPanel12 != null) flowLayoutPanel12.Location = new Point(0, 0);

            if (flowLayoutPanel14 != null) flowLayoutPanel14.Location = new Point(0, 0);
        }

        private void ConfigureFlowLayoutPanelsForResponsiveness()
        {
            // Main FlowLayoutPanel (flowLayoutPanel5)
            flowLayoutPanel5.AutoSize = false;
            flowLayoutPanel5.WrapContents = false;
            flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel5.Resize += FlowLayoutPanel5_Resize;

            // Container panels
            ConfigureContainerPanel(flowLayoutPanel1);  // Name fields
            ConfigureContainerPanel(flowLayoutPanel7);  // Birthdate, Age, Gender, Contact, Occupation

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
            containerPanel.Padding = new Padding(0);
            containerPanel.Margin = new Padding(0);
        }

        private void FlowLayoutPanel5_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int availableWidth = flowLayoutPanel5.Width - flowLayoutPanel5.Padding.Left - flowLayoutPanel5.Padding.Right - 10;

            // Resize container panels to fill width AND SET HEIGHT
            flowLayoutPanel1.Width = availableWidth;
            flowLayoutPanel1.Height = 100; // Set explicit height
            flowLayoutPanel1.Visible = true;

            flowLayoutPanel7.Width = availableWidth;
            flowLayoutPanel7.Height = 120; // Set explicit height for 5-field row
            flowLayoutPanel7.Visible = true;

            flowLayoutPanel13.Width = availableWidth;
            flowLayoutPanel13.Height = 100; // Address section
            flowLayoutPanel13.Visible = true;

            flowLayoutPanel15.Width = availableWidth; // Button panel
            flowLayoutPanel15.Height = 80; // SET HEIGHT for button panel
            flowLayoutPanel15.Visible = true; // CRITICAL: Make button panel visible

            // Resize child panels inside containers
            ResizeChildPanelsInContainer(flowLayoutPanel1, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel7, availableWidth);

            // Special handling for flowLayoutPanel13 (Address section)
            ResizeAddressSection(flowLayoutPanel13, availableWidth);

            // Force layout update
            flowLayoutPanel5.PerformLayout();
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
                    childPanel.Margin = new Padding(3); // Reset margin for proper flow
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

                if (containerPanel == flowLayoutPanel1) // First, Last, Middle Name row
                {
                    panelWidth = Math.Max((int)(availableWidth / 3f), 200); // Minimum 200px
                }
                else if (containerPanel == flowLayoutPanel7) // Birthdate, Age, Gender, Contact, Occupation row
                {
                    if (childPanel == flowLayoutPanel8) // Birthdate
                        panelWidth = Math.Max((int)(availableWidth * 0.26f), 180);
                    else if (childPanel == flowLayoutPanel9) // Age
                        panelWidth = Math.Max((int)(availableWidth * 0.11f), 80);
                    else if (childPanel == flowLayoutPanel10) // Gender
                        panelWidth = Math.Max((int)(availableWidth * 0.19f), 140);
                    else if (childPanel == flowLayoutPanel11) // Contact
                        panelWidth = Math.Max((int)(availableWidth * 0.20f), 150);
                    else if (childPanel == flowLayoutPanel12) // Occupation
                        panelWidth = Math.Max((int)(availableWidth * 0.20f), 150);
                }

                childPanel.Width = panelWidth;
                childPanel.Height = 90; // Set explicit height
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
            flowLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            flowLayoutPanel15.Anchor = AnchorStyles.Top | AnchorStyles.Left;

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
