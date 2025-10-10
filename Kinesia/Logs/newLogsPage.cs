using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.CustomButton;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinesia.Logs
{
    public partial class newLogsPage : UserControl
    {
        string searchData;
        string currentTab;
        public newLogsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public DataGridView GetLogsGrid { get { return GetLogsGrid; } }
        public string CurrentTab { get { return currentTab; } }

        private void newLogsPage_Load(object sender, EventArgs e)
        {

        }
    }
}
