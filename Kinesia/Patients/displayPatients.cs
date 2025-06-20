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
    public partial class displayPatients : UserControl
    {
        public displayPatients()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left| AnchorStyles.Top;
            this.Dock = DockStyle.Top;
     
            InitializeComponent();
        }
    }
}
