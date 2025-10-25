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
        private bool isInitialized = false;

        public bool IsPatientSelected
        {
            get { return isPatientSelected; }
            set { isPatientSelected = value; }
        }

        public PanelBorder PatientInformationPanel
        {
            get { return panelPatientInformation; }
        }

        public AddAssessment()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;

            InitializeComponent();

            ConfigureResponsiveness();
        }

        private void ConfigureResponsiveness()
        {
            // Set up anchors
            titleNav.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblSelectedUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPatientInformation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Set up resize event
            this.Resize += AddAssessment_Resize;

            isInitialized = true;

            // Initial resize
            AddAssessment_Resize(this, EventArgs.Empty);
        }

        private void AddAssessment_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int formWidth = this.Width;
            int formHeight = this.Height;

            // Header labels (fixed positions)
            titleNav.Location = new Point(71, 44);
            lblSelectedUser.Location = new Point(240, 35);
            label1.Location = new Point(76, 83);

            // Back button (top right with fixed margin)
            int backButtonX = formWidth - 145 - 46; // button width + margin
            btnBack.Location = new Point(backButtonX, 19);

            // Button panel (flowLayoutPanel1) - full width with margins
            int buttonPanelY = 132;
            int buttonPanelWidth = formWidth - 178; // 89px left margin + 89px right margin
            flowLayoutPanel1.Location = new Point(89, buttonPanelY);
            flowLayoutPanel1.Width = buttonPanelWidth;

            // Patient information panel - fills remaining space
            int panelY = buttonPanelY + 107; // Button panel Y + button panel height + gap
            int panelHeight = Math.Max(formHeight - panelY - 28, 300);
            int panelWidth = formWidth - 152; // 76px margins on each side

            panelPatientInformation.Location = new Point(76, panelY);
            panelPatientInformation.Size = new Size(panelWidth, panelHeight);

            // If SelectPatientPopup is already in the panel, recenter it
            if (panelPatientInformation.Controls.Count > 0)
            {
                var popup = panelPatientInformation.Controls[0];
                if (popup != null)
                {
                    int x = (panelPatientInformation.Width - popup.Width) / 2;
                    int y = (panelPatientInformation.Height - popup.Height) / 2;
                    popup.Location = new Point(Math.Max(x, 10), Math.Max(y, 10));
                }
            }

            // Force layout update
            this.PerformLayout();
        }

        private void AddAssessment_Load(object sender, EventArgs e)
        {
            panelPatientInformation.Controls.Clear();
            var selectPatientPopup = new SelectPatientPopup();
            panelPatientInformation.Controls.Add(selectPatientPopup);

            //will calculate the centered position
            int x = (panelPatientInformation.Width - selectPatientPopup.Width) / 2;
            int y = (panelPatientInformation.Height - selectPatientPopup.Height) / 2;

            //will set the location
            selectPatientPopup.Location = new Point(x, y);
        }

        private async void btnSaveAssessment_Click(object sender, EventArgs e)
        {
            if (isPatientSelected)
            {
                var newAssessment = new AddAssessmentDTO
                {
                    PatientID = PageObjects.patientAssessmentDetails.PatientID,
                    Extremity = PageObjects.patientAssessmentDetails.Extremity,
                    Joint = PageObjects.patientAssessmentDetails.Joint,
                    JointSide = PageObjects.patientAssessmentDetails.JointSide
                };

                if (Queries.AssessmentQueries.IsAssessmentDetailsComplete(newAssessment) && !await Queries.AssessmentQueries.HasOngoingAssessment(newAssessment.PatientID, newAssessment.Joint, newAssessment.JointSide))
                {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.assessmentPage = new AssessmentPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentPage);
            PageObjects.CurrentControl = PageObjects.assessmentPage;
        }

        private async void btnChangePatient_Click(object sender, EventArgs e)
        {
            using (Form shadow = new Form())
            {
                FormAnimation.ShowFocus(shadow);
                PageObjects.selectPatientPage = new SelectPatient();
                await Queries.PatientQueries.DisplayPatientSelection("");
                PageObjects.selectPatientPage.Owner = shadow;
                PageObjects.selectPatientPage.ShowDialog();
            }
        }
    }
}
