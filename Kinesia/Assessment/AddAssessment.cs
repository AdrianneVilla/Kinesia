using KinesiaLibrary.DTOs.AssessmentDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.CustomButton;

namespace Kinesia.Assessment
{
    public partial class AddAssessment : UserControl
    {
        private static bool isPatientSelected;

        public bool IsPatientSelected { get { return isPatientSelected; } set { isPatientSelected = value; } }
        public PanelBorder PatientInformationPanel { get { return panelPatientInformation; } }

        public AddAssessment()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void AddAssessment_Load(object sender, EventArgs e)
        {
            panelPatientInformation.Controls.Clear();
            var selectPatientPopup = new SelectPatientPopup();
            panelPatientInformation.Controls.Add(selectPatientPopup);

            // will calculate the centered position
            int x = (panelPatientInformation.Width - selectPatientPopup.Width) / 2;
            int y = (panelPatientInformation.Height - selectPatientPopup.Height) / 2;

            // will set the location
            selectPatientPopup.Location = new Point(x, y);
        }

        private async void btnSaveAssessment_Click(object sender, EventArgs e)
        {
            if (isPatientSelected)
            {
                var newAssessment = new AddAssessmentDTO
                {
                    AssessmentID = await Queries.AssessmentQueries.SetAssessmentID(),
                    PatientID = PageObjects.patientAssessmentDetails.PatientID,
                    Extremity = PageObjects.patientAssessmentDetails.Extremity,
                    Joint = PageObjects.patientAssessmentDetails.Joint,
                    JointSide = PageObjects.patientAssessmentDetails.JointSide
                };

                string newAssessmentID = await Queries.AssessmentQueries.AddAssessment(newAssessment);

                if (!string.IsNullOrEmpty(newAssessmentID))
                {
                    await Queries.LogsQueries.AddLog($"Added {newAssessmentID}", "Assessment");

                    CustomDialog.Show("Assessment added successfully!", "Add Assessment Notification", CustomDialogButtons.OK, CustomDialogIcons.Information);

                    await Queries.AssessmentQueries.GetAssessmentDetails(newAssessmentID);
                }
            }
        }
    }
}
