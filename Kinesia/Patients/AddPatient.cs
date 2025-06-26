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
        public AddPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult backDialog = MessageBox.Show("Are you sure you want to go back to Patient page?\n" +
                    "Any unsaved changes will be lost!", "Add Patient Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if(backDialog == DialogResult.Yes)
                {
                    PageObjects.RemoveResources(PageObjects.CurrentControl);
                    PageObjects.patientsPage = new PatientsPage();
                    PageObjects.dashboard.ContentsPanel.Controls.Clear();
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
                    PageObjects.CurrentControl = PageObjects.patientsPage;
                }
            } 
            else
            {
                // will directly go back to Patient page if there's no unsaved input    
                PageObjects.RemoveResources(PageObjects.CurrentControl);
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
            if(areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult clearDialog = MessageBox.Show("Are you sure you want to clear inputs?\n" +
                "Any unsaved changes will be lost!", "Add Patient Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

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

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            DialogResult addPatientDialog = MessageBox.Show("Are you sure you want to add this patient?", "Add Patient Notification",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(addPatientDialog == DialogResult.Yes)
            {
                txtFirstName.Texts.Trim();
                txtLastName.Texts.Trim();
                txtMiddleName.Texts.Trim();
                txtContact.Texts.Trim();
                txtOccupation.Texts.Trim();
                txtAddress.Texts.Trim();

                PatientDataHolder patientData = new PatientDataHolder
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

                if(Queries.PatientQueries.IsPatientDetailsComplete(patientData) && !Queries.PatientQueries.CheckExistingPatient(patientData) && Queries.PatientQueries.IsAgeValid(patientData))
                {
                    Queries.PatientQueries.GetPatientIDCount();
                    Queries.PatientQueries.AddPatient(patientData);

                    clearAllInputs();
                    patientData = null;
                    MessageBox.Show("Patient added successfully!", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
