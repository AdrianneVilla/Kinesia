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
        private string previousPage;

        public string PreviousPage { get { return previousPage; } set { previousPage = value; } }

        public AddPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(1000, 700);
            this.AutoScroll = true;

            InitializeComponent();

            // CRITICAL: Subscribe to this control's Resize event
            this.Resize += AddPatient_Resize;
        }

        // THIS IS THE MISSING EVENT HANDLER!
        private void AddPatient_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            // Recalculate panelBorder1 width
            int newWidth = this.ClientSize.Width - 42; // 21 margin on each side
            if (newWidth > 600) // minimum width
            {
                panelBorder1.Width = newWidth;
            }
        }

        private void ConfigureFlowLayoutPanelsForResponsiveness()
        {
            // Main FlowLayoutPanel (flowLayoutPanel5)
            flowLayoutPanel5.AutoSize = false;
            flowLayoutPanel5.WrapContents = false;
            flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel5.Resize += FlowLayoutPanel5_Resize;

            // Container panels
            ConfigureContainerPanel(flowLayoutPanel1);
            ConfigureContainerPanel(flowLayoutPanel7);

            // Address section
            flowLayoutPanel13.WrapContents = false;
            flowLayoutPanel13.FlowDirection = FlowDirection.TopDown;

            // Button panel
            flowLayoutPanel15.AutoSize = false;
            flowLayoutPanel15.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel15.WrapContents = false;
            flowLayoutPanel15.Visible = true;

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

            // Resize container panels
            flowLayoutPanel1.Width = availableWidth;
            flowLayoutPanel7.Width = availableWidth;
            flowLayoutPanel13.Width = availableWidth;
            flowLayoutPanel15.Width = availableWidth;
            flowLayoutPanel15.Height = 70;
            flowLayoutPanel15.Visible = true;

            // Resize children
            ResizeChildPanelsInContainer(flowLayoutPanel1, availableWidth);
            ResizeChildPanelsInContainer(flowLayoutPanel7, availableWidth);
            ResizeAddressSection(flowLayoutPanel13, availableWidth);
        }

        private void ResizeChildPanelsInContainer(FlowLayoutPanel containerPanel, int containerWidth)
        {
            containerPanel.SuspendLayout();

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

            int margins = 10 * (childPanels.Count - 1);
            int availableWidth = containerWidth - margins - 20;

            foreach (var childPanel in childPanels)
            {
                int panelWidth = 0;

                if (containerPanel == flowLayoutPanel1)
                {
                    if (childPanel == flowLayoutPanel2)
                        panelWidth = (int)(availableWidth * 0.31f);
                    else if (childPanel == flowLayoutPanel3)
                        panelWidth = (int)(availableWidth * 0.31f);
                    else if (childPanel == flowLayoutPanel6)
                        panelWidth = (int)(availableWidth * 0.31f);
                }
                else if (containerPanel == flowLayoutPanel7)
                {
                    if (childPanel == flowLayoutPanel8)
                        panelWidth = (int)(availableWidth * 0.22f);
                    else if (childPanel == flowLayoutPanel9)
                        panelWidth = (int)(availableWidth * 0.10f);
                    else if (childPanel == flowLayoutPanel10)
                        panelWidth = (int)(availableWidth * 0.20f);
                    else if (childPanel == flowLayoutPanel11)
                        panelWidth = (int)(availableWidth * 0.20f);
                    else if (childPanel == flowLayoutPanel12)
                        panelWidth = (int)(availableWidth * 0.20f);
                }

                childPanel.Width = panelWidth;
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
                    comboBox.MinimumSize = new Size(50, 30);
                    comboBox.Width = controlWidth;
                    comboBox.Size = new Size(controlWidth, comboBox.Height);
                    comboBox.MaximumSize = new Size(controlWidth, 100);
                    comboBox.Refresh();
                }
                else if (ctrl is CustomControls.RJControls.RJDatePicker datePicker)
                {
                    datePicker.Width = controlWidth;
                }
            }

            childPanel.ResumeLayout();
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

        private void SetupResponsiveLayout()
        {
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Main panel stretches horizontally only
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Inner flow panel fills panelBorder1
            flowLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Button panel flows naturally
            flowLayoutPanel15.Anchor = AnchorStyles.None;
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {
            SetupResponsiveLayout();
            ConfigureFlowLayoutPanelsForResponsiveness();
            isInitialized = true;

            dpBirthDate.Text = DateTime.Now.ToString();
            txtAge.BackColor = System.Drawing.Color.White;

            // Trigger initial resize
            AddPatient_Resize(this, EventArgs.Empty);
        }

        // Keep all your existing methods below
        private void backBtn_Click(object sender, EventArgs e)
        {
            if(previousPage == "Dashboard Page")
            {
                goBackToDashboardPage();
            }
            else if(previousPage == "Add Assessment Page")
            {
                goBackToAddAssessment();
            }
            else
            {
                goBackToPatientsPage();
            }
        }

        private void goBackToDashboardPage()
        {
            if (areInputsBlank())
            {
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to dashboard page?\n" +
                    "Any unsaved changes will be lost!", "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (backDialog == DialogResult.Yes)
                {
                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                    PageObjects.dashboardPage = new Components.DashboardPage();
                    PageObjects.dashboard.ContentsPanel.Controls.Clear();
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
                    PageObjects.CurrentControl = PageObjects.dashboardPage;
                }
            }
            else
            {
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboardPage = new Components.DashboardPage();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
                PageObjects.CurrentControl = PageObjects.dashboardPage;
            }
        }

        private void goBackToPatientsPage()
        {
            if (areInputsBlank())
            {
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to Patient page?\n" +
                    "Any unsaved changes will be lost!", "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

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
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.patientsPage = new PatientsPage();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
                PageObjects.CurrentControl = PageObjects.patientsPage;
            }
        }

        private void goBackToAddAssessment()
        {
            if (areInputsBlank())
            {
                DialogResult backDialog = CustomDialog.Show("Are you sure you want to go back to Add Assessment page?\n" +
                    "Any unsaved changes will be lost!", "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (backDialog == DialogResult.Yes)
                {
                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                    PageObjects.addAssessment = new Assessment.AddAssessment();
                    PageObjects.dashboard.ContentsPanel.Controls.Clear();
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
                    PageObjects.CurrentControl = PageObjects.addAssessment;
                }
            }
            else
            {
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.addAssessment = new Assessment.AddAssessment();
                PageObjects.dashboard.ContentsPanel.Controls.Clear();
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
                PageObjects.CurrentControl = PageObjects.addAssessment;
            }
        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Texts = getAge().ToString();
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
            DateTime birthDate = dpBirthDate.Value;
            DateTime currentDate = DateTime.Now;
            int totalMonths = (currentDate.Year - birthDate.Year) * 12 + currentDate.Month - birthDate.Month;
            age = totalMonths / 12;
            return age;
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                DialogResult clearDialog = CustomDialog.Show("Are you sure you want to clear inputs?\n" +
                    "Any unsaved inputs will be lost!", "Add Patient Notification", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (clearDialog == DialogResult.Yes)
                {
                    clearAllInputs();
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
                txtFirstName.Texts = txtFirstName.Texts.Trim();
                txtLastName.Texts = txtLastName.Texts.Trim();
                txtMiddleName.Texts = txtMiddleName.Texts.Trim();
                txtContact.Texts = txtContact.Texts.Trim();
                txtOccupation.Texts = txtOccupation.Texts.Trim();
                txtAddress.Texts = txtAddress.Texts.Trim();

                DataHolder.PatientDataHolder = new PatientDataHolder
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
                    string newPatientID = await this.FindForm().RunTaskWithLoading("Adding patient's data...", async () =>
                    {
                        return await Queries.PatientQueries.AddPatient(DataHolder.PatientDataHolder);
                    });

                    if (!string.IsNullOrEmpty(newPatientID))
                    {
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
                        CustomDialog.Show("Failed to add patient!", "Add Patient Notification", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
                else
                {
                    DataHolder.PatientDataHolder = null;
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

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtAddress__TextChanged(object sender, EventArgs e)
        {
        }
    }
}
