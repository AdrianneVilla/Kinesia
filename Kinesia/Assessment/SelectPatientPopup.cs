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
    public partial class SelectPatientPopup : UserControl
    {
        public SelectPatientPopup()
        {
            InitializeComponent();
        }

        private async void btnSelectPatient_Click(object sender, EventArgs e)
        {
            PageObjects.selectPatientPage = new SelectPatient();
            await Queries.PatientQueries.DisplayPatientSelection("");
            PageObjects.selectPatientPage.ShowDialog();
        }
    }
}
