using Kinesia.Patients;
using Kinesia.Users;
using Kinesia.Assessment;
using Kinesia.Logs;
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
    public partial class Sidebar : UserControl
    {
        static String tags;
        public Sidebar()
        {
            InitializeComponent();
        }

        private void dashboardModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboardPage = new DashboardPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
            PageObjects.CurrentControl = PageObjects.dashboardPage;
        }

        private void patientModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.patientsPage = new PatientsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
            PageObjects.CurrentControl = PageObjects.patientsPage;
        }

        private void usersModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.userPage = new UserPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            PageObjects.CurrentControl = PageObjects.userPage;

        }

        private void assessmentModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.assessmentPage = new AssessmentPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentPage);
            PageObjects.CurrentControl = PageObjects.assessmentPage;
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.logsPage = new LogsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.logsPage);
            PageObjects.CurrentControl = PageObjects.logsPage;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult logoutDiag = CustomDialog.Show("Are you sure you want to logout?", "Logout Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (logoutDiag == DialogResult.Yes)
            {
                SessionManager.Logout();
                PageObjects.dashboard.Close();
                PageObjects.loginPage.Show();
            }
        }

        private void Sidebar_Load(object sender, EventArgs e)
        {
            if(SessionManager.Role != "Admin")
            {
                btnLogs.Visible = false;
                usersModule.Visible = false;
            }
        }
    }
}
