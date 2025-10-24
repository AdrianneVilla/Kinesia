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
    public partial class LogsPage : UserControl
    {
        string searchData = "";
        string currentTab = "All";
        public LogsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public DataGridView LogsGrid { get { return dataGridLogs; } }
        public string CurrentTab { get { return currentTab; } }

        private void newLogsPage_Load(object sender, EventArgs e)
        {

        }

        private async void LogsPage_Paint(object sender, PaintEventArgs e)
        {
            await Queries.LogsQueries.DisplayLogs(searchData, currentTab, "Latest");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {

        }

        private void btnSessions_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnPatients_Click(object sender, EventArgs e)
        {

        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {

        }

        private void btnROM_Click(object sender, EventArgs e)
        {

        }
    }
}
