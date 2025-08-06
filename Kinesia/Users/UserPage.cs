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

namespace Kinesia.Users
{
    public partial class UserPage : UserControl
    {
        string searchData = "";
        string currentTab = "All";

        public PanelBorder getUserHolder { get { return UserHolder; } }
        public string CurrentTab { get { return currentTab; } }
        public UserPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            txtSearchBar.Texts = "Search for User name or UserID";

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
                Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addUser = new AddUser();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addUser);
            PageObjects.CurrentControl = PageObjects.addUser;
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for User name or UserID")
            {
                txtSearchBar.Texts = "";
            }
        }

        private void txtSearchBar_Leave(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "")
            {
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
            }
        }

        private void txtSearchBar__TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for User name or UserID")
            {
                searchData = "";
            } 
            else
            {
                searchData = txtSearchBar.Texts;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts); // will do search query
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already All
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already Active
            if (currentTab != "Active")
            {
                currentTab = "Active";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            }
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already Inactive
            if(currentTab != "Inactive")
            {
                currentTab = "Inactive";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            }
        }

        private void switchTab(string currentTab)
        {
            switch (currentTab)
            {
                case "All":
                    btnAll.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnAll.ForeColor = Color.White;

                    btnActive.BackgroundColor = Color.Gainsboro;
                    btnActive.ForeColor = Color.Gray;

                    btnInactive.BackgroundColor = Color.Gainsboro;
                    btnInactive.ForeColor = Color.Gray;

                    dataGridUsers.Columns[dataGridUsers.Columns.Count - 1].HeaderText = "Archive / Unarchive";
                    break;

                case "Active":
                    btnActive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnActive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnInactive.BackgroundColor = Color.Gainsboro;
                    btnInactive.ForeColor = Color.Gray;

                    dataGridUsers.Columns[dataGridUsers.Columns.Count - 1].HeaderText = "Archive";
                    break;

                case "Inactive":
                    btnInactive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnInactive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnActive.BackgroundColor = Color.Gainsboro;
                    btnActive.ForeColor = Color.Gray;

                    dataGridUsers.Columns[dataGridUsers.Columns.Count - 1].HeaderText = "Unarchive";
                    break;
            }
        }

        private void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh users list every time the sort value was changed
            Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
        }
    }
}
