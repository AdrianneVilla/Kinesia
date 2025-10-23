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
    public partial class AddPatient : UserControl
    {
        private Size designResolution = new Size(1763, 973);
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Rectangle originalPanelBounds;
        public AddPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(800, 600);
            this.AutoScroll = true;

            InitializeComponent();

            StoreOriginalSizes();
            SetupResponsiveLayout();
        }

        private void StoreOriginalSizes()
        {
            // Store original panel size
            originalPanelBounds = panelBorder1.Bounds;

            // Store original sizes of all controls inside the panel
            foreach (Control ctrl in panelBorder1.Controls)
            {
                originalControlBounds[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
            }

            // Store button positions
            originalControlBounds[btnAddPatient] = new Rectangle(btnAddPatient.Location, btnAddPatient.Size);
            originalControlBounds[btnClearInput] = new Rectangle(btnClearInput.Location, btnClearInput.Size);
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

            // Bottom buttons - anchor to bottom right
            btnAddPatient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Subscribe to resize events
            this.Resize += AddPatient_Resize;
            panelBorder1.Resize += PanelBorder1_Resize;
        }

        private void AddPatient_Resize(object sender, EventArgs e)
        {
            AdjustButtonPositions();
        }

        private void PanelBorder1_Resize(object sender, EventArgs e)
        {
            ResizeControlsInPanel();
        }

        private void ResizeControlsInPanel()
        {
            if (originalControlBounds.Count == 0) return;

            // Calculate scale factors
            float scaleX = (float)panelBorder1.Width / originalPanelBounds.Width;
            float scaleY = (float)panelBorder1.Height / originalPanelBounds.Height;

            panelBorder1.SuspendLayout();

            foreach (Control ctrl in panelBorder1.Controls)
            {
                if (originalControlBounds.ContainsKey(ctrl))
                {
                    Rectangle originalBounds = originalControlBounds[ctrl];

                    // Calculate new position and size
                    int newX = (int)(originalBounds.X * scaleX);
                    int newY = (int)(originalBounds.Y * scaleY);
                    int newWidth = (int)(originalBounds.Width * scaleX);
                    int newHeight = (int)(originalBounds.Height * scaleY);

                    // Apply new location
                    ctrl.Location = new Point(newX, newY);

                    // Special handling for custom ComboBox
                    if (ctrl is CustomControls.RJControls.RJComboBox comboBox)
                    {
                        // Force resize by setting both Size and MinimumSize
                        comboBox.MinimumSize = new Size(newWidth, newHeight);
                        comboBox.Size = new Size(newWidth, newHeight);
                        comboBox.MaximumSize = new Size(newWidth, newHeight);

                        // Force the control to update its layout
                        comboBox.Invalidate();
                        comboBox.Update();
                    }
                    else
                    {
                        // Regular control resizing
                        ctrl.Size = new Size(newWidth, newHeight);
                    }

                    // Adjust font size for labels
                    if (ctrl is Label)
                    {
                        float newFontSize = ctrl.Font.Size * Math.Min(scaleX, scaleY);
                        newFontSize = Math.Max(8, Math.Min(newFontSize, ctrl.Font.Size));
                        ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
                    }
                }
            }

            panelBorder1.ResumeLayout();
            panelBorder1.PerformLayout(); // Force layout recalculation
        }

        private void AdjustButtonPositions()
        {
            if (originalControlBounds.ContainsKey(btnClearInput) && originalControlBounds.ContainsKey(btnAddPatient))
            {
                Rectangle origClear = originalControlBounds[btnClearInput];
                Rectangle origAdd = originalControlBounds[btnAddPatient];

                int rightMargin = designResolution.Width - origClear.Right;
                int bottomMargin = designResolution.Height - origClear.Bottom;
                int buttonSpacing = origClear.Left - origAdd.Right;

                btnClearInput.Location = new Point(
                    this.Width - btnClearInput.Width - rightMargin,
                    this.Height - btnClearInput.Height - bottomMargin
                );

                btnAddPatient.Location = new Point(
                    btnClearInput.Left - btnAddPatient.Width - buttonSpacing,
                    this.Height - btnAddPatient.Height - bottomMargin
                );
            }
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
    }
}
