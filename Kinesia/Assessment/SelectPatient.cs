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
        public SelectPatient()
        {
            InitializeComponent();
        }

        public DataGridView GetPatientSelectionGrid { get { return dataGridPatientSelection; } }
    }
}
