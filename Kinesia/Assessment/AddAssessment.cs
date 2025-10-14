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
    public partial class AddAssessment : UserControl
    {
        private static bool isPatientSelected;

        public static bool IsPatientSelected { get { return isPatientSelected; } set { isPatientSelected = value; } }

        public AddAssessment()
        {
            InitializeComponent();
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {

        }
    }
}
