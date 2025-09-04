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
        string searchData;
        string currentTab;
        public LogsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public PanelBorder getLogHolder { get { return LogHolder; } }

        private void LogsPage_Load(object sender, EventArgs e)
        {
            currentTab = "All";

            Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);

            // will get the TextBox inside the RJTextBox
            TextBox innerTxtSearchBar = txtSearchBar.Controls.OfType<TextBox>().FirstOrDefault();

            if (innerTxtSearchBar != null)
            {
                innerTxtSearchBar.KeyDown += InnerTxtSearchBar_KeyDown; // will add KeyDown KeyEvent
            }
        }

        private void InnerTxtSearchBar_KeyDown(object sender, KeyEventArgs e)
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
                Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
        }

        private void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for User name or Log ID")
            {
                txtSearchBar.Texts = "";
            }
        }

        private void txtSearchBar_Leave(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "")
            {
                txtSearchBar.Texts = "Search for User name or Log ID";
                searchData = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
        }

        private void txtSearchBar__TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for User name or Log ID")
            {
                searchData = "";
            }
            else
            {
                searchData = txtSearchBar.Texts;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            // will only refresh the logs list if the currentTab was not already All
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or Log ID";
                searchData = "";
                Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            // will only refresh the logs list if the currentTab was not already Sessions
            if (currentTab != "Sessions")
            {
                currentTab = "Sessions";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or Log ID";
                searchData = "";
                Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // will only refresh the logs list if the currentTab was not already Users
            if (currentTab != "Users")
            {
                currentTab = "Users";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or Log ID";
                searchData = "";
                Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            // will only refresh the logs list if the currentTab was not already Patients
            if (currentTab != "Patients")
            {
                currentTab = "Patients";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or Log ID";
                searchData = "";
                Queries.LogsQueries.DisplayLogs(searchData, currentTab, cbSort.Texts);
            }
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
                    break;

                case "Sessions":
                    btnSessions.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnSessions.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;
                    break;

                case "Users":
                    btnUsers.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnUsers.ForeColor = Color.White;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnPatients.BackgroundColor = Color.Gainsboro;
                    btnPatients.ForeColor = Color.Gray;
                    break;

                case "Patients":
                    btnPatients.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnPatients.ForeColor = Color.White;

                    btnSessions.BackgroundColor = Color.Gainsboro;
                    btnSessions.ForeColor = Color.Gray;

                    btnUsers.BackgroundColor = Color.Gainsboro;
                    btnUsers.ForeColor = Color.Gray;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;
                    break;
            }
        }
    }
}
