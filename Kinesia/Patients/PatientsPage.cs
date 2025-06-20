using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Patients
{
    public partial class PatientsPage : UserControl
    {
        public PatientsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void PatientsPage_Load(object sender, EventArgs e)
        {
            PageObjects.displayPatients = new displayPatients();
            PatientHolder.Controls.Add(PageObjects.displayPatients);
            PageObjects.displayPatients = new displayPatients();
            PatientHolder.Controls.Add(PageObjects.displayPatients);
            PageObjects.displayPatients = new displayPatients();
            PatientHolder.Controls.Add(PageObjects.displayPatients);
            PageObjects.displayPatients = new displayPatients();
            PatientHolder.Controls.Add(PageObjects.displayPatients);

        }

        private void addPatientBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            PageObjects.addPatient = new AddPatient();
            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.addPatient);
        }
    }
}
