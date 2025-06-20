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
    public partial class AddPatient : UserControl
    {
        public AddPatient()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = Application.OpenForms["Dashboard"] as Dashboard;
            PageObjects.patientsPage = new PatientsPage();
            dashboard.ContentsPanel.Controls.Clear();
            dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
        }
    }
}
