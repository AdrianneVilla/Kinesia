using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Logs
{
    public partial class DisplayLogs : UserControl
    {
        public DisplayLogs()
        {
            InitializeComponent();
        }

        public string LogID { get { return lblLogID.Text; } set { lblLogID.Text = value; } }
        public string UserName { get { return lblUserName.Text; } set { lblUserName.Text = value; } }
        public string Description { get { return lblDescription.Text; } set { lblDescription.Text = value; } }
        public string LogDate { get { return lblDate.Text; } set { lblDate.Text = value; } }
    }
}
