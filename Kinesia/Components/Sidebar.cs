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
    public partial class Sidebar : UserControl
    {
       static String tags;
        public Sidebar()
        {
            InitializeComponent();
        }

        private void dashboardModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(PageObjects.CurrentControl);
            PageObjects.dashboardPage = new DashboardPage();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
            PageObjects.CurrentControl = PageObjects.dashboardPage;
        }

        private void patientModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(PageObjects.CurrentControl);
            PageObjects.patientsPage = new PatientsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
            PageObjects.CurrentControl = PageObjects.patientsPage;
        }

        private void usersModule_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(PageObjects.CurrentControl);
            PageObjects.userPage = new UserPage();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            PageObjects.CurrentControl = PageObjects.userPage;
            
        }

    }
}
