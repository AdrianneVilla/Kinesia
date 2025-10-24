using Kinesia.Patients;
using Kinesia.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class AssessmentDetails : UserControl
    {
        public AssessmentDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public string AssessmentID { get { return lblSelectedAssessment.Text; } set { lblSelectedAssessment.Text = value; } }
        public string PatientID { get { return lblPatientID.Text; } set { lblPatientID.Text = value; } }
        public string Age { get { return lblAge.Text; } set { lblAge.Text = value; } }
        public string Gender { get { return lblGender.Text; } set { lblGender.Text = value; } }
        public string Extremity { get { return lblExtremity.Text; } set { lblExtremity.Text = value; } }
        public string Joint { get { return lblJoint.Text; } set { lblJoint.Text = value; } }
        public string JointSide { get { return lblJointSide.Text; } set { lblJointSide.Text = value; } }
        public string AssessmentStatus { get { return lblAssessmentStatus.Text; } set { lblAssessmentStatus.Text = value; } }
        public string AssessmentDate { get { return lblAssessmentDate.Text; } set { lblAssessmentDate.Text = value; } }
        public string AssessmentEndDate { get { return lblAssessmentEndDate.Text; } set { lblAssessmentEndDate.Text = value; } }
        public DataGridView GetROMGrid { get { return dataGridROM; } set { dataGridROM = value; } }

        private void btnAddRom_Click(object sender, EventArgs e)
        {
            using (Form shadow = new Form())
            {
                FormAnimation.ShowFocus(shadow);
                var toolSelectionPage = new SelectTool();
                toolSelectionPage.Owner = shadow;
                toolSelectionPage.ShowDialog();
            }
        }

        private void AssessmentDetails_Load(object sender, EventArgs e)
        {
            if (lblAssessmentStatus.Text == "Archived")
            {
                btnArchive.Visible = false;
                btnEdit.Visible = false;
                btnFinishAssessment.Visible = false;
                btnAddRom.Enabled = false;
            }

            if(lblAssessmentStatus.Text == "Finished")
            {
                btnEdit.Visible = false;
                btnFinishAssessment.Visible = false;
                btnAddRom.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (Form shadow = new Form())
            {
                FormAnimation.ShowFocus(shadow);
                var printReportPage = new PrintReport();
                printReportPage.Owner = shadow;
                printReportPage.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.assessmentPage = new AssessmentPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentPage);
            PageObjects.CurrentControl = PageObjects.assessmentPage;
        }

        private async void AssessmentDetails_Paint(object sender, PaintEventArgs e)
        {
            await Queries.ROMQueries.DisplayROM(AssessmentID);

            if (dataGridROM.Rows.Count <= 0)
            {
                btnPrint.Enabled = false;
            }
        }

        private async void btnFinishAssessment_Click(object sender, EventArgs e)
        {
            int status = 2;

            DialogResult finishDiag = CustomDialog.Show("Are you sure you want to set this assessment as Finished?", "Finish Assessment Alert",
                CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if(finishDiag == DialogResult.Yes)
            {
                if(dataGridROM.Rows.Count <= 0)
                {
                    DialogResult confirmFinishDiag = CustomDialog.Show("This assessment has no ROM records. Finishing this assessment will set it to Archived.\n" +
                        "Do you really want to continue?", "Finish Assessment Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                    if(confirmFinishDiag == DialogResult.Yes)
                    {
                        status = 0;
                    }
                    else
                    {
                        return;
                    }
                }

                var success = await Queries.AssessmentQueries.UpdateAssessmentStatus(lblSelectedAssessment.Text, status);

                if (success)
                {
                    if(status == 0)
                    {
                        // will add a log for archiving an assessment
                        await Queries.LogsQueries.AddLog($"Archived {lblSelectedAssessment.Text}", "Assessment");

                        CustomDialog.Show($"{lblSelectedAssessment.Text} has been archived successfully!", "Finish Assessment Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);
                    }
                    else
                    {
                        // will add a log for archiving an assessment
                        await Queries.LogsQueries.AddLog($"Finished {lblSelectedAssessment.Text}", "Assessment");

                        CustomDialog.Show($"{lblSelectedAssessment.Text} has set to Finished successfully!", "Finish Assessment Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);
                    }

                        await Queries.AssessmentQueries.GetAssessmentDetails(lblSelectedAssessment.Text);
                }
            }
        }
    }
}
