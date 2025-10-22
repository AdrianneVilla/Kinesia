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

        private async void AssessmentDetails_Load(object sender, EventArgs e)
        {
            await Queries.ROMQueries.DisplayROM(AssessmentID);

            if (dataGridROM.Rows.Count <= 0)
            {
                btnPrint.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using(Form shadow = new Form())
            {
                FormAnimation.ShowFocus(shadow);
                var printReportPage = new PrintReport();
                printReportPage.Owner = shadow;
                printReportPage.ShowDialog();
            }
        }
    }
}
