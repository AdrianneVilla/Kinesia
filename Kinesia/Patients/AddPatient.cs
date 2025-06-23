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
            PageObjects.RemoveResources(PageObjects.CurrentControl);
            PageObjects.patientsPage = new PatientsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
            PageObjects.CurrentControl = PageObjects.patientsPage;
        }

        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
