using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class PatientAssessmentDetails : UserControl
    {
        private bool isInitialized = false;

        public PatientAssessmentDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;

            InitializeComponent();

            ConfigureResponsiveness();
        }

        public string PatientID
        {
            get { return lblPatientID.Text; }
            set { lblPatientID.Text = value; }
        }

        public string PatientName
        {
            get { return lblPatientName.Text; }
            set { lblPatientName.Text = value; }
        }

        public string Age
        {
            get { return lblAge.Text; }
            set { lblAge.Text = value; }
        }

        public string Gender
        {
            get { return lblGender.Text; }
            set { lblGender.Text = value; }
        }

        public string Extremity
        {
            get { return cbExtremity.Texts; }
        }

        public string Joint
        {
            get { return cbJoint.Texts; }
        }

        public string JointSide
        {
            get { return cbJointSide.Texts; }
        }

        private void ConfigureResponsiveness()
        {
            // Set panel to fill and resize
            panelPatientInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPatientInformation.AutoSize = false;

            // Configure FlowLayoutPanels for responsive behavior
            flowLayoutPanel3.AutoSize = false;
            flowLayoutPanel3.WrapContents = true;

            flowLayoutPanel6.AutoSize = false;
            flowLayoutPanel6.WrapContents = true;

            // Set up resize event
            this.Resize += PatientAssessmentDetails_Resize;

            isInitialized = true;

            // Initial resize
            PatientAssessmentDetails_Resize(this, EventArgs.Empty);
        }

        private void PatientAssessmentDetails_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int controlWidth = this.Width;
            int availableWidth = controlWidth - 100; // Account for padding

            // Resize main panel
            panelPatientInformation.Location = new Point(4, 10);
            panelPatientInformation.Width = Math.Max(controlWidth - 8, 800);

            // Header labels (fixed positions within panel)
            label12.Location = new Point(47, 28);
            lblPatientID.Location = new Point(288, 28);

            // Patient information row (flowLayoutPanel3)
            flowLayoutPanel3.Location = new Point(47, 97);
            flowLayoutPanel3.Width = Math.Max(availableWidth, 800);

            // Resize child panels in patient info row
            int patientInfoSpacing = 10;
            int patientInfoWidth = (availableWidth - (2 * patientInfoSpacing)) / 3;

            flowLayoutPanel2.Width = Math.Max(patientInfoWidth, 250); // Name
            flowLayoutPanel4.Width = Math.Max(patientInfoWidth, 150); // Age
            flowLayoutPanel5.Width = Math.Max(patientInfoWidth, 150); // Gender

            // Joint Information section
            label10.Location = new Point(53, 210);

            // Joint info row (flowLayoutPanel6)
            flowLayoutPanel6.Location = new Point(47, 266);
            flowLayoutPanel6.Width = Math.Max(availableWidth, 800);

            // Resize child panels in joint info row
            int jointSpacing = 20;
            int jointPanelWidth = (availableWidth - (2 * jointSpacing)) / 3;

            flowLayoutPanel7.Width = Math.Max(jointPanelWidth, 250); // Extremity
            flowLayoutPanel8.Width = Math.Max(jointPanelWidth, 250); // Joint
            flowLayoutPanel9.Width = Math.Max(jointPanelWidth, 250); // Joint Side

            // Resize comboboxes inside panels
            cbExtremity.Width = Math.Max(flowLayoutPanel7.Width - 20, 200);
            cbJoint.Width = Math.Max(flowLayoutPanel8.Width - 20, 200);
            cbJointSide.Width = Math.Max(flowLayoutPanel9.Width - 20, 200);

            // Force layout update
            this.PerformLayout();
            panelPatientInformation.PerformLayout();
        }

        private void cbExtremity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cbJoint.Items.Clear();
            cbJoint.Texts = "Select Joint";
            cbJointSide.Texts = "Select Joint Side";

            if (cbExtremity.Texts.Equals("Upper Extremity"))
            {
                cbJoint.Items.Add("Shoulder");
                cbJoint.Items.Add("Elbow and Forearm");
            }
            else if (cbExtremity.Texts.Equals("Lower Extremity"))
            {
                cbJoint.Items.Add("Hip");
                cbJoint.Items.Add("Knee");
            }
        }
    }
}
