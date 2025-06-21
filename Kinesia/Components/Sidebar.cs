using Kinesia.Patients;
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
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
        }

        public void patientModule_Click(object sender, EventArgs e)
        {
         
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            PageObjects.patientsPage = new PatientsPage();
            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
         
            
        }

        private void usersModule_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            PageObjects.userPage = new Users.UserPage();
            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            
        }



    }
}
