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
        public EditPatient()
        {
            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            // will set the value of the textboxes to the values of the patient
            txtFirstName.Texts = DataHolder.PatientDataHolder.FirstName;
            txtLastName.Texts = DataHolder.PatientDataHolder.LastName;
            txtMiddleName.Texts = DataHolder.PatientDataHolder.MiddleName;
            dpBirthDate.Value = DateTime.Parse(DataHolder.PatientDataHolder.Birthdate);
            
            if(DataHolder.PatientDataHolder.Gender == "Male")
            {
                cbGender.SelectedIndex = 0; // will set the cbGender to Male
            } 
            else
            {
                cbGender.SelectedIndex = 1; // will set the cbGender to Female
            }

            txtContact.Texts = DataHolder.PatientDataHolder.Contact.Remove(0,3); // will remove the "+63" of the contact
            txtOccupation.Texts = DataHolder.PatientDataHolder.Occupation;
            txtAddress.Texts = DataHolder.PatientDataHolder.Address;
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

        public bool hasChanged()
        {
            if (txtFirstName.Texts != DataHolder.PatientDataHolder.FirstName) return true;

            if (txtLastName.Texts != DataHolder.PatientDataHolder.LastName) return true;

            if (txtMiddleName.Texts != DataHolder.PatientDataHolder.MiddleName) return true;

            if (dpBirthDate.Value.ToString("yyyy-MM-dd") != DataHolder.PatientDataHolder.Birthdate) return true;

            if (cbGender.Texts != DataHolder.PatientDataHolder.Gender) return true;

            if (txtContact.Texts != DataHolder.PatientDataHolder.Contact.Remove(0, 3)) return true;

            if (txtOccupation.Texts != DataHolder.PatientDataHolder.Occupation) return true;

            if (txtAddress.Texts != DataHolder.PatientDataHolder.Address) return true;

            return false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                // will only show dialog if there's an unsaved input
                DialogResult backDialog = MessageBox.Show("Are you sure you want to go back to Patient page?\n" +
                    "Any unsaved changes will be lost!", "Edit Patient Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

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
