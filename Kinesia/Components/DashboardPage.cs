using Kinesia.Assessment;
using Kinesia.Patients;
using Kinesia.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Components
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public DataGridView GetLogsGrid { get { return dataGridLogs; } }

        private void DashboardPage_Load(object sender, EventArgs e)
        {
            if(SessionManager.Role != "Admin")
            {
                btnQuickAddUser.Visible = false;
                lblRecentActivities.Visible = false;
                panelRecentActivities.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void DashboardPage_Paint(object sender, PaintEventArgs e)
        {
            lblName.Text = SessionManager.UserLastName + "!";
            lblMonth.Text = DateTime.Now.ToString("MMMM yyyy");
            lblTotalAssessments.Text = (await Queries.AssessmentQueries.GetTotalAssessments(DateTime.Now.Month, DateTime.Now.Year)).ToString();
            lblTotalOngoingAssessments.Text = (await Queries.AssessmentQueries.GetTotalOngoingAssessments(DateTime.Now.Month, DateTime.Now.Year)).ToString();
            lblMostJointTracked.Text = await Queries.AssessmentQueries.GetMostTrackedJoint(DateTime.Now.Month, DateTime.Now.Year);
            await Queries.LogsQueries.DisplayDashboardLogs();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnQuickAddPatient_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addPatient = new AddPatient();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addPatient);
            PageObjects.CurrentControl = PageObjects.addPatient;
        }

        private void btnQuickAddUser_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addUser = new AddUser();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addUser);
            PageObjects.CurrentControl = PageObjects.addUser;
        }

        private void btnQuickNewAssessment_Click(object sender, EventArgs e)
        {
            PageObjects.addAssessment = new AddAssessment();
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
            PageObjects.CurrentControl = PageObjects.addAssessment;
        }
    }
}
