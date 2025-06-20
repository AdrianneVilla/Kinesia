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
    public partial class DisplayPatients : UserControl
    {
        public DisplayPatients()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left| AnchorStyles.Top;
            this.Dock = DockStyle.Top;
     
            InitializeComponent();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            dashboard.ContentsPanel.Controls.Clear();
            PageObjects.patientDetails = new PatientDetails();
            dashboard.ContentsPanel.Controls.Add(PageObjects.patientDetails);
        }

        public string PatientName { get { return txtPatientName.Text; } set { txtPatientName.Text = value; } }
        public string Age { get { return txtAge.Text; } set { txtAge.Text = value; } }
        public string Gender { get { return txtGender.Text; } set { txtGender.Text = value; } } 
        public string Contact { get { return txtContact.Text; } set { txtContact.Text = value; } }
        public string Status { get { return txtStatus.Text; } set { txtStatus.Text = value; } }
    }
}
