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

namespace Kinesia.Logs
{
    public partial class LogsPage : UserControl
    {
        public LogsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public PanelBorder getLogHolder { get { return LogHolder; } }

        private void LogsPage_Load(object sender, EventArgs e)
        {
            Queries.LogsQueries.DisplayLogs();
        }
    }
}
