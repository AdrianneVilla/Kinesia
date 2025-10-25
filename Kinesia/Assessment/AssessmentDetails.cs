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
using ScottPlot;
using ScottPlot.WinForms;

namespace Kinesia.Assessment
{
    public partial class AssessmentDetails : UserControl
    {
        string currentMovement = "All";
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
        public FormsPlot RomPlot { get { return romPlot; } }

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
               
                btnFinishAssessment.Visible = false;
                btnAddRom.Enabled = false;
            }

            if (lblAssessmentStatus.Text == "Finished")
            {
         
                btnFinishAssessment.Visible = false;
                btnAddRom.Enabled = false;
            }

            if (lblJoint.Text != "Shoulder")
            {
                btnAdduction.Visible = false;
                btnAbduction.Visible = false;
            }

            romPlot.Plot.Clear();
            romPlot.Plot.Title("No selected movement");
            romPlot.Plot.XLabel("Date of Tracking");
            romPlot.Plot.YLabel("Range of Motion (degrees)");
            romPlot.Refresh();
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
            await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
        }

        private async void btnFinishAssessment_Click(object sender, EventArgs e)
        {
            int status = 2;

            DialogResult finishDiag = CustomDialog.Show("Are you sure you want to set this assessment as Finished?", "Finish Assessment Alert",
                CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (finishDiag == DialogResult.Yes)
            {
                if (dataGridROM.Rows.Count <= 0)
                {
                    DialogResult confirmFinishDiag = CustomDialog.Show("This assessment has no ROM records. Finishing this assessment will set it to Archived.\n" +
                        "Do you really want to continue?", "Finish Assessment Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                    if (confirmFinishDiag == DialogResult.Yes)
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
                    if (status == 0)
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

        private void dataGridROM_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridROM.Rows.Count > 1 || (dataGridROM.Rows.Count == 1 && !dataGridROM.Rows[0].IsNewRow))
            {
                btnPrint.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            if (lblAssessmentStatus.Text == "Ongoing")
            {
                CustomDialog.Show("You cannot archive an ongoing assessment!\nYou need to set the status of assessment as Finished.", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            else
            {
                DialogResult archiveDiag = CustomDialog.Show($"Are you sure you want to archive {lblSelectedAssessment.Text}?",
                            "Archive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                if (archiveDiag == DialogResult.Yes)
                {
                    var success = await Queries.AssessmentQueries.UpdateAssessmentStatus(lblSelectedAssessment.Text, 0);

                    if (success)
                    {
                        // will add a log for archiving an assessment
                        await Queries.LogsQueries.AddLog($"Archived {lblSelectedAssessment.Text}", "Assessment");

                        CustomDialog.Show($"{lblSelectedAssessment.Text} has been archived successfully!", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                        await Queries.AssessmentQueries.GetAssessmentDetails(lblSelectedAssessment.Text);
                    }
                }
            }
        }

        private async void btnAll_Click(object sender, EventArgs e)
        {
            if(currentMovement != "All")
            {
                currentMovement = "All";
                switchMovement(currentMovement);
                romPlot.Plot.Clear();
                romPlot.Plot.Title("No selected movement");
                romPlot.Plot.XLabel("Date of Tracking");
                romPlot.Plot.YLabel("Range of Motion (degrees)");
                romPlot.Refresh();
                await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
            }
        }

        private async void btnFlexion_Click(object sender, EventArgs e)
        {
            if(currentMovement != "Flexion")
            {
                currentMovement = "Flexion";
                switchMovement(currentMovement);
                await Queries.ROMQueries.GenerateROMGraph(lblSelectedAssessment.Text, "Flexion");
                await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
            }
           
        }

        private async void btnExtension_Click(object sender, EventArgs e)
        {
            if (currentMovement != "Extension")
            {
                currentMovement = "Extension";
                switchMovement(currentMovement);
                await Queries.ROMQueries.GenerateROMGraph(lblSelectedAssessment.Text, "Extension");
                await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
            }
        }

        private async void btnAbduction_Click(object sender, EventArgs e)
        {
            if (currentMovement != "Abduction")
            {
                currentMovement = "Abduction";
                switchMovement(currentMovement);
                await Queries.ROMQueries.GenerateROMGraph(lblSelectedAssessment.Text, "Abduction");
                await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
            }
        }

        private async void btnAdduction_Click(object sender, EventArgs e)
        {
            if (currentMovement != "Adduction")
            {
                currentMovement = "Adduction";
                switchMovement(currentMovement);
                await Queries.ROMQueries.GenerateROMGraph(lblSelectedAssessment.Text, "Adduction");
                await Queries.ROMQueries.DisplayROM(AssessmentID, currentMovement);
            }
        }

        private void switchMovement(string movement)
        {
            switch (movement)
            {
                case "All":
                    btnAll.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
                    btnAll.ForeColor = System.Drawing.Color.White;

                    btnFlexion.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnFlexion.ForeColor = System.Drawing.Color.Gray;

                    btnExtension.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnExtension.ForeColor = System.Drawing.Color.Gray;

                    btnAbduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAbduction.ForeColor = System.Drawing.Color.Gray;

                    btnAdduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAdduction.ForeColor = System.Drawing.Color.Gray;
                    break;
                case "Flexion":
                    btnAll.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAll.ForeColor = System.Drawing.Color.Gray;

                    btnFlexion.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
                    btnFlexion.ForeColor = System.Drawing.Color.White;

                    btnExtension.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnExtension.ForeColor = System.Drawing.Color.Gray;

                    btnAbduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAbduction.ForeColor = System.Drawing.Color.Gray;

                    btnAdduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAdduction.ForeColor = System.Drawing.Color.Gray;
                    break;
                case "Extension":
                    btnAll.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAll.ForeColor = System.Drawing.Color.Gray;

                    btnFlexion.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnFlexion.ForeColor = System.Drawing.Color.Gray;

                    btnExtension.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
                    btnExtension.ForeColor = System.Drawing.Color.White;

                    btnAbduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAbduction.ForeColor = System.Drawing.Color.Gray;

                    btnAdduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAdduction.ForeColor = System.Drawing.Color.Gray;
                    break;
                case "Abduction":
                    btnAll.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAll.ForeColor = System.Drawing.Color.Gray;

                    btnFlexion.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnFlexion.ForeColor = System.Drawing.Color.Gray;

                    btnExtension.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnExtension.ForeColor = System.Drawing.Color.Gray;

                    btnAbduction.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
                    btnAbduction.ForeColor = System.Drawing.Color.White;

                    btnAdduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAdduction.ForeColor = System.Drawing.Color.Gray;
                    break;
                case "Adduction":
                    btnAll.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAll.ForeColor = System.Drawing.Color.Gray;

                    btnFlexion.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnFlexion.ForeColor = System.Drawing.Color.Gray;

                    btnExtension.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnExtension.ForeColor = System.Drawing.Color.Gray;

                    btnAbduction.BackgroundColor = System.Drawing.Color.Gainsboro;
                    btnAbduction.ForeColor = System.Drawing.Color.Gray;

                    btnAdduction.BackgroundColor = System.Drawing.Color.FromArgb(18, 90, 211);
                    btnAdduction.ForeColor = System.Drawing.Color.White;
                    break;
            }
        }
    }
}
