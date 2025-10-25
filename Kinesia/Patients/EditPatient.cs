using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Patients
{
    public partial class EditPatient : UserControl
    {
        private string previousPage;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Size originalSize;
        private Rectangle originalPanelBounds;
        private bool isInitialized = false;
        public string PreviousPage { get { return previousPage; } set { previousPage = value; } }

        public EditPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(1000, 700);
            this.AutoScroll = true;
            InitializeComponent();
        }

        private void ConfigureFlowLayoutPanelsForResponsiveness()
        {
            // Main FlowLayoutPanel (flowLayoutPanel1)
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Resize += FlowLayoutPanel1_Resize;

            // Container panels (flowLayoutPanel11, flowLayoutPanel12, flowLayoutPanel13)
            ConfigureContainerPanel(flowLayoutPanel11);
            ConfigureContainerPanel(flowLayoutPanel12);
            ConfigureContainerPanel(flowLayoutPanel13);

            // Configure the address section separately
            flowLayoutPanel13.WrapContents = false;
            flowLayoutPanel13.FlowDirection = FlowDirection.TopDown;

            // Initial resize
            FlowLayoutPanel1_Resize(flowLayoutPanel1, EventArgs.Empty);
        }

        private void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int availableWidth = flowLayoutPanel1.Width - flowLayoutPanel1.Padding.Left - flowLayoutPanel1.Padding.Right - 10;

            // Resize container panels to fill width
            flowLayoutPanel11.Width = availableWidth;
            flowLayoutPanel12.Width = availableWidth;
            flowLayoutPanel13.Width = availableWidth;

            // Resize child panels inside containers
            ResizeChildPanelsInContainer(flowLayoutPanel11, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel12, availableWidth);

            // Special handling for flowLayoutPanel13 (Address section)
            ResizeAddressSection(flowLayoutPanel13, availableWidth);
        }

        private void ResizeAddressSection(FlowLayoutPanel addressContainer, int containerWidth)
        {
            addressContainer.SuspendLayout();

            // Check if address is in a nested panel (flowLayoutPanel10) or directly in flowLayoutPanel13
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
                // Address is nested in flowLayoutPanel10
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

        private void ConfigureContainerPanel(FlowLayoutPanel containerPanel)
        {
            containerPanel.AutoSize = false;
            containerPanel.WrapContents = true;
            containerPanel.FlowDirection = FlowDirection.LeftToRight;
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
            int margins = 10 * (childPanels.Count - 1); // Space between panels
            int availableWidth = containerWidth - margins - 20;

            // Distribute width based on panel
            foreach (var childPanel in childPanels)
            {
                int panelWidth = 0;

                // Set widths based on which row/container
                if (containerPanel == flowLayoutPanel11) // First, Last, Middle Name row
                {
                    if (childPanel == flowLayoutPanel2) // First Name
                        panelWidth = (int)(availableWidth * 0.31f);
                    else if (childPanel == flowLayoutPanel3) // Last Name
                        panelWidth = (int)(availableWidth * 0.31f);
                    else if (childPanel == flowLayoutPanel4) // Middle Name
                        panelWidth = (int)(availableWidth * 0.31f);
                }
                else if (containerPanel == flowLayoutPanel12) // Birthdate, Age, Gender, Contact, Occupation row
                {
                    if (childPanel == flowLayoutPanel5) // Birthdate
                        panelWidth = (int)(availableWidth * 0.22f);
                    else if (childPanel == flowLayoutPanel6) // Age
                        panelWidth = (int)(availableWidth * 0.10f);
                    else if (childPanel == flowLayoutPanel7) // Gender
                        panelWidth = (int)(availableWidth * 0.20f);
                    else if (childPanel == flowLayoutPanel8) // Contact
                        panelWidth = (int)(availableWidth * 0.20f);
                    else if (childPanel == flowLayoutPanel9) // Occupation
                        panelWidth = (int)(availableWidth * 0.20f);
                }
                else if (containerPanel == flowLayoutPanel13) // Address row
                {
                    panelWidth = availableWidth; // Full width
                }

                childPanel.Width = panelWidth;

                // Resize controls inside each child panel
                ResizeControlsInChildPanel(childPanel, panelWidth);
            }

            containerPanel.ResumeLayout();
        }

        private void ResizeControlsInChildPanel(FlowLayoutPanel childPanel, int panelWidth)
        {
            int controlWidth = panelWidth - childPanel.Padding.Left - childPanel.Padding.Right - 10;

            childPanel.SuspendLayout();

            foreach (Control ctrl in childPanel.Controls)
            {
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
            lblPatientID.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Main panel - stretch horizontally
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Main FlowLayoutPanel - stretch horizontally
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Bottom buttons
            btnSaveChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }




        private void EditPatient_Load(object sender, EventArgs e)
        {
           SetupResponsiveLayout();


            ConfigureFlowLayoutPanelsForResponsiveness();
            isInitialized = true;


            // will set the value of the textboxes to the values of the patient
            lblPatientID.Text = DataHolder.PatientDataHolder.PatientID + " Personal Information";
            txtFirstName.Texts = DataHolder.PatientDataHolder.FirstName;
            txtLastName.Texts = DataHolder.PatientDataHolder.LastName;
            txtMiddleName.Texts = DataHolder.PatientDataHolder.MiddleName;
            dpBirthDate.Value = DateTime.Parse(DataHolder.PatientDataHolder.Birthdate);

            if (DataHolder.PatientDataHolder.Gender == "Male")
            {
                cbGender.SelectedIndex = 0; // will set the cbGender value to Male
            }
            else
            {
                cbGender.SelectedIndex = 1; // will set the cbGender value to Female
            }

            txtContact.Texts = DataHolder.PatientDataHolder.Contact.Remove(0, 3); // will remove the "+63" from the contact
            txtOccupation.Texts = DataHolder.PatientDataHolder.Occupation;
            txtAddress.Texts = DataHolder.PatientDataHolder.Address;

            txtAge.BackColor = System.Drawing.Color.White;
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
            var patient = DataHolder.PatientDataHolder;

            return
                txtFirstName.Texts.Trim() != patient.FirstName ||
                txtLastName.Texts.Trim() != patient.LastName ||
                txtMiddleName.Texts.Trim() != patient.MiddleName ||
                dpBirthDate.Value.ToString("yyyy-MM-dd") != patient.Birthdate ||
                cbGender.Texts != patient.Gender ||
                txtContact.Texts.Trim() != patient.Contact.Remove(0, 3) ||
                txtOccupation.Texts.Trim() != patient.Occupation ||
                txtAddress.Texts.Trim() != patient.Address;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (previousPage == "Patients Page")
            {
                goBackToPatientPage();
            }
            else
            {
                goBackToPatientDetailsPage();
            }
        }

        private void goBackToPatientPage()
        {
            if (hasChanged())
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

        private async void goBackToPatientDetailsPage()
        {
            if (hasChanged())
            {
                // will only show dialog if there's an unsaved input
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to Patient details page?\n" +
                    "Any unsaved changes will be lost!", "Edit Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (backDialog == DialogResult.Yes)
                {
                    await Queries.PatientQueries.GetPatientDetails(DataHolder.PatientDataHolder.PatientID);
                }
            }
            else
            {
                // will directly go back to Patient Details page if there's no unsaved input    
                await Queries.PatientQueries.GetPatientDetails(DataHolder.PatientDataHolder.PatientID);
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DialogResult updateDialog = CustomDialog.Show($"Are you sure you want to update\n" +
                        $"{DataHolder.PatientDataHolder.PatientID}'s personal information?",
                        "Edit Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (updateDialog == DialogResult.Yes)
            {
                // will remove extra whitespaces on beginning and end of the textboxes
                txtFirstName.Texts.Trim();
                txtLastName.Texts.Trim();
                txtMiddleName.Texts.Trim();
                txtContact.Texts.Trim();
                txtAddress.Texts.Trim();

                var patientData = new PatientDataHolder();

                patientData.PatientID = DataHolder.PatientDataHolder.PatientID;
                patientData.FirstName = txtFirstName.Texts;
                patientData.LastName = txtLastName.Texts;
                patientData.MiddleName = txtMiddleName.Texts;
                patientData.Contact = txtContact.Texts;
                patientData.Age = Convert.ToInt32(txtAge.Texts);
                patientData.Birthdate = dpBirthDate.Value.ToString("yyyy-MM-dd");
                patientData.Gender = cbGender.Texts;
                patientData.Occupation = txtOccupation.Texts;
                patientData.Address = txtAddress.Texts;

                if (Queries.PatientQueries.IsPatientDetailsComplete(patientData) &&
                    Queries.PatientQueries.IsAgeValid(patientData) && Queries.PatientQueries.IsContactValid(patientData))
                {
                    if (DataHolder.PatientDataHolder.FirstName != patientData.FirstName || DataHolder.PatientDataHolder.LastName != patientData.LastName
                        || DataHolder.PatientDataHolder.MiddleName != patientData.MiddleName)
                    {
                        // will only check existing patient if
                        // first, last, and middle name data were changed
                        if (await Queries.PatientQueries.CheckExistingPatient(patientData))
                        {
                            return; // will exit the update method if patient was already existing
                        }
                    }
                    // will update the patient's personal information if patientData passed all data validations
                    var success = await this.FindForm().RunTaskWithLoading("Updating patient's data...", async () =>
                    {
                        return await Queries.PatientQueries.UpdatePatient(patientData);
                    });

                    if (success)
                    {
                        // will add a log for editing a patient
                        await Queries.LogsQueries.AddLog($"Edited {DataHolder.PatientDataHolder.PatientID}'s personal information", "Patients");

                        CustomDialog.Show($"{DataHolder.PatientDataHolder.PatientID}'s personal information \n" +
                            $"has been updated successfully!", "Edit Patient Notification", CustomDialogButtons.OK, CustomDialogIcons.Information);

                        // will go back to Patient page
                        PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                        PageObjects.patientsPage = new PatientsPage();
                        PageObjects.dashboard.ContentsPanel.Controls.Clear();
                        PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
                        PageObjects.CurrentControl = PageObjects.patientsPage;
                    }
                    else
                    {
                        // will display an error message if failed to edit
                        CustomDialog.Show($"Failed to edit {DataHolder.PatientDataHolder.PatientID}'s personal information", "Failed to edit",
                            CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
                else
                {
                    DataHolder.PatientDataHolder = null;
                }
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

        private void txtOccupation__TextChanged(object sender, EventArgs e)
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

        private void txtOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.CharactersOnly(sender, e);
        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
