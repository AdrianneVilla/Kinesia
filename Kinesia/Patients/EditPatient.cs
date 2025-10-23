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

        public string PreviousPage { get { return previousPage; } set { previousPage = value; } }

        public EditPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            // will set the value of the textboxes to the values of the patient
            lblPatientID.Text = DataHolder.PatientDataHolder.PatientID + " Personal Information";
            txtFirstName.Texts = DataHolder.PatientDataHolder.FirstName;
            txtLastName.Texts = DataHolder.PatientDataHolder.LastName;
            txtMiddleName.Texts = DataHolder.PatientDataHolder.MiddleName;
            dpBirthDate.Value = DateTime.Parse(DataHolder.PatientDataHolder.Birthdate);
            
            if(DataHolder.PatientDataHolder.Gender == "Male")
            {
                cbGender.SelectedIndex = 0; // will set the cbGender value to Male
            } 
            else
            {
                cbGender.SelectedIndex = 1; // will set the cbGender value to Female
            }

            txtContact.Texts = DataHolder.PatientDataHolder.Contact.Remove(0,3); // will remove the "+63" from the contact
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
            if(previousPage == "Patients Page")
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
                    if(DataHolder.PatientDataHolder.FirstName !=  patientData.FirstName || DataHolder.PatientDataHolder.LastName != patientData.LastName 
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
    }
}
