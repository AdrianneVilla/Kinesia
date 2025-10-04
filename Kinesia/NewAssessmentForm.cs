using Kinesia.Assessment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia
{
    public partial class NewAssessmentForm : Form
    {
        public NewAssessmentForm()
        {
            InitializeComponent();
        }

        private void NewAssessmentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            var AssessmentRom = new AssessmentROM();
            AssessmentRom.ShowDialog();
            this.Close();
        }
    }
}
