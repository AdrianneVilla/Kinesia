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
    public partial class SelectPatient : Form
    {
        List<string> patientList = new List<string>();

        public SelectPatient()
        {
            InitializeComponent();
        }

        public DataGridView GetPatientSelectionGrid { get { return dataGridPatientSelection; } }
        public List<string> PatientList { get { return patientList; } }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectPatient_Load(object sender, EventArgs e)
        {

        }

        private async void dataGridPatientSelection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == 4)
                {
                    await Queries.PatientQueries.GetPatientBasicDetails(patientList[e.RowIndex]);
                    this.Close();
                }
            }
        }
    }
}
