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
    public partial class DisplayPatients : UserControl
    {
        public DisplayPatients()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left| AnchorStyles.Top;
            this.Dock = DockStyle.Top;
     
            InitializeComponent();
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            await Queries.PatientQueries.GetPatientDetails(txtPatientID.Text);
        }

        public string PatientID { get { return txtPatientID.Text; } set { txtPatientID.Text = value; } }
        public string PatientName { get { return txtPatientName.Text; } set { txtPatientName.Text = value; } }
        public string Age { get { return txtAge.Text; } set { txtAge.Text = value; } }
        public string Gender { get { return txtGender.Text; } set { txtGender.Text = value; } } 
        public string Contact { get { return txtContact.Text; } set { txtContact.Text = value; } }
        public string Status { get { return txtStatus.Text; } set { txtStatus.Text = value; } }
        public CustomButton BtnArchive { get { return btnArchive; } }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataHolder.PatientDataHolder = new PatientDataHolder();
            Queries.PatientQueries.GetPatientDetails(txtPatientID.Text, DataHolder.PatientDataHolder);
            PageObjects.editPatient.PreviousPage = "Patients Page";
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if(btnArchive.Tag.ToString() == "Archive")
            {
                // will show message box for Archiving patient
                DialogResult archiveDiag = MessageBox.Show($"Are you sure you want to archive {txtPatientID.Text}?", "Archive Patient Notification",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (archiveDiag == DialogResult.Yes)
                {
                    Queries.PatientQueries.ArchivePatient(txtPatientID.Text);

                    // will add a log for archiving a patient
                    Queries.LogsQueries.AddLog($"Archived {txtPatientID.Text}", "Patients");

                    MessageBox.Show($"{txtPatientID.Text} has been successfully archived!", "Archive Patient Notification",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Queries.PatientQueries.DisplayPatients("", PageObjects.patientsPage.CurrentTab, "Default");
                }
            } 
            else
            {
                // will show message box for Unarchiving patient
                DialogResult unarchiveDiag = MessageBox.Show($"Are you sure you want to unarchive {txtPatientID.Text}?", "Unarchive Patient Notification",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (unarchiveDiag == DialogResult.Yes)
                {
                    Queries.PatientQueries.UnarchivePatient(txtPatientID.Text);

                    // will add a log for unarchiving a patient
                    Queries.LogsQueries.AddLog($"Unarchived {txtPatientID.Text}", "Patients");

                    MessageBox.Show($"{txtPatientID.Text} has been successfully unarchived!", "Unarchive Patient Notification",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Queries.PatientQueries.DisplayPatients("", PageObjects.patientsPage.CurrentTab, "Default");
                }
            }
        }
    }
}
