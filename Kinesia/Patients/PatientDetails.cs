using OrganizationProfile;
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
    public partial class PatientDetails : UserControl
    {
        public PatientDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public string SelectedPatient { get { return lblSelectedPatient.Text; } set { lblSelectedPatient.Text = value; } }
        public string PatientName { get {  return lblPatientName.Text; } set { lblPatientName.Text = value; } }
        public string PatientID { get { return lblPatientID.Text; } set { lblPatientID.Text = value; } }
        public string Status { get { return lblStatus.Text; } set { lblStatus.Text = value; } }
        public string DateAdded { get { return lblDateAdded.Text; } set { lblDateAdded.Text = value; } }
        public string LastArchiveDate { get { return lblArchiveDate.Text; } set { lblArchiveDate.Text = value; } }
        public string Gender { get { return lblGender.Text; } set { lblGender.Text = value; } }
        public string Contact { get { return lblContact.Text; } set { lblContact.Text = value; } }
        public string Age { get { return lblAge.Text; } set { lblAge.Text = value; } }
        public string Address { get { return lblAddress.Text; } set { lblAddress.Text = value; } }
        public string Birthdate { get { return lblBirthdate.Text; } set { lblBirthdate.Text = value; } }
        public CustomButton BtnArchive { get { return btnArchive; } }
        private async void btnEditInfo_Click(object sender, EventArgs e)
        {
            DataHolder.PatientDataHolder = new PatientDataHolder();
            await Queries.PatientQueries.GetPatientDetails(lblPatientID.Text, DataHolder.PatientDataHolder);
            PageObjects.editPatient.PreviousPage = "Patient Details Page";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.patientsPage = new PatientsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
            PageObjects.CurrentControl = PageObjects.patientsPage;
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Active")
            {
                // will show message box for Archiving patient
                DialogResult archiveDiag = MessageBox.Show($"Are you sure you want to archive {lblPatientID.Text}?", "Archive Patient Notification",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (archiveDiag == DialogResult.Yes)
                {
                    Queries.PatientQueries.ArchivePatient(lblPatientID.Text);

                    // will add a log for archiving a patient;
                    Queries.LogsQueries.AddLog($"Archived {lblPatientID.Text}", "Patients");

                    MessageBox.Show($"{lblPatientID.Text} has been successfully archived!", "Archive Patient Notification",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Queries.PatientQueries.GetPatientDetails(lblPatientID.Text);
                }
            }
            else
            {
                // will show message box for Unarchiving patient
                DialogResult unarchiveDiag = MessageBox.Show($"Are you sure you want to unarchive {lblPatientID.Text}?", "Unarchive Patient Notification",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (unarchiveDiag == DialogResult.Yes)
                {
                    Queries.PatientQueries.UnarchivePatient(lblPatientID.Text);

                    // will add a log for unarchiving a patient
                    Queries.LogsQueries.AddLog($"Unarchived {lblPatientID.Text}", "Patients");

                    MessageBox.Show($"{lblPatientID.Text} has been successfully unarchived!", "Unarchive Patient Notification",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Queries.PatientQueries.GetPatientDetails(lblPatientID.Text);
                }
            }
        }
    }
}
