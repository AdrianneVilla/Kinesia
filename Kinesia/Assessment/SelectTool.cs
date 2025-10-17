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
    public partial class SelectTool : Form
    {
        public SelectTool()
        {
            InitializeComponent();
        }

        private void btnGoniometer_Click(object sender, EventArgs e)
        {
            var manualAddROMPage = new ManualAddROM();
            manualAddROMPage.ShowDialog();
            this.Close();
        }
    }
}
