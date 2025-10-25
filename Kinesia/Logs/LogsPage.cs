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

        private void LogsPage_Load(object sender, EventArgs e)
        {
            txtSearchBar.Texts = "Search for Log ID";

            // will get the TextBox inside the RJTextBox
            TextBox innerTxtSearchBar = txtSearchBar.Controls.OfType<TextBox>().FirstOrDefault();

            if (innerTxtSearchBar != null)
            {
                innerTxtSearchBar.KeyDown += InnerTxtSearchBar_KeyDown; // will add KeyDown KeyEvent
            }
        }


        private async void LogsPage_Paint(object sender, PaintEventArgs e)
        {
            await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
        }

        private async void InnerTxtSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lblHiddenForFocus.Focus(); // will move the focus away from the txtSearchBar

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "esc"
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // will do search query if "enter" was pressed
                // while txtSearchBar was being focused
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for Log ID")
            {
                txtSearchBar.Texts = "";
            }
        }

        private void txtSearchBar_Leave(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "")
            {
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
            }
        }

        private void txtSearchBar__TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for Log ID")
            {
                searchData = "";
            }
            else
            {
                searchData = txtSearchBar.Texts;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
        }

        private async void btnAll_Click(object sender, EventArgs e)
        {
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnSessions_Click(object sender, EventArgs e)
        {
            if (currentTab != "Sessions")
            {
                currentTab = "Sessions";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnUsers_Click(object sender, EventArgs e)
        {
            if (currentTab != "Users")
            {
                currentTab = "Users";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnPatients_Click(object sender, EventArgs e)
        {
            if (currentTab != "Patients")
            {
                currentTab = "Patients";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnAssessment_Click(object sender, EventArgs e)
        {
            if (currentTab != "Assessment")
            {
                currentTab = "Assessment";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnROM_Click(object sender, EventArgs e)
        {
            if (currentTab != "ROM")
            {
                currentTab = "ROM";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Log ID";
                searchData = "";
                await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            await Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
        }

        private void switchTab(string currentTab)
        {
            switch (currentTab)
            {
                case "All":
                    btnAll.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnAll.ForeColor = Color.White;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;

                    btnAssessment.BackgroundColor = Color.Gainsboro;
                    btnAssessment.ForeColor = Color.Gray;

                    btnROM.BackgroundColor = Color.Gainsboro;
                    btnROM.ForeColor = Color.Gray;
                    break;
                case "Sessions":
                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnSessions.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnSessions.ForeColor = Color.White;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;

                    btnAssessment.BackgroundColor = Color.Gainsboro;
                    btnAssessment.ForeColor = Color.Gray;

                    btnROM.BackgroundColor = Color.Gainsboro;
                    btnROM.ForeColor = Color.Gray;
                    break;
                case "Users":
                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnUsers.ForeColor = Color.White;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;

                    btnAssessment.BackgroundColor = Color.Gainsboro;
                    btnAssessment.ForeColor = Color.Gray;

                    btnROM.BackgroundColor = Color.Gainsboro;
                    btnROM.ForeColor = Color.Gray;
                    break;
                case "Patients":
                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnPatients.ForeColor = Color.White;

                    btnAssessment.BackgroundColor = Color.Gainsboro;
                    btnAssessment.ForeColor = Color.Gray;

                    btnROM.BackgroundColor = Color.Gainsboro;
                    btnROM.ForeColor = Color.Gray;
                    break;
                case "Assessment":
                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;

                    btnAssessment.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnAssessment.ForeColor = Color.White;

                    btnROM.BackgroundColor = Color.Gainsboro;
                    btnROM.ForeColor = Color.Gray;
                    break;
                case "ROM":
                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;

                    btnAssessment.BackgroundColor = Color.Gainsboro;
                    btnAssessment.ForeColor = Color.Gray;

                    btnROM.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnROM.ForeColor = Color.White;
                    break;
            }
        }

    }
}
