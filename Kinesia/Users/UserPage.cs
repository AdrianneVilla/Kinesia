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

        List<string> userList = new List<string>();

        private bool isInitialized = false;

        //public PanelBorder getUserHolder { get { return UserHolder; } }
        public DataGridView GetUserGrid { get { return dataGridUsers; } }
        public string CurrentTab { get { return currentTab; } }
        public List<string> UserList { get { return userList; } }
        public UserPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            ConfigureResponsiveness();

        }

        private void ConfigureResponsiveness()
        {
            // Configure DataGridView for responsiveness
            dataGridUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // KEY CHANGE
            dataGridUsers.Dock = DockStyle.None; // Don't dock, we'll position manually

            // Set up anchors for responsive behavior
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelBorder2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBorder3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Set up resize event
            this.Resize += UserPage_Resize;

            isInitialized = true;

            // Initial resize
            UserPage_Resize(this, EventArgs.Empty);
        }

        private void UserPage_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int formWidth = this.Width;
            int formHeight = this.Height;

            // Header section (fixed positions)
            nameHolder.Location = new Point(69, 36);
            label1.Location = new Point(74, 82);

            // Search bar panel - FIXED: Properly anchored to right with fixed margin
            int searchBarWidth = 582;
            int rightMargin = 60;
            int searchBarX = formWidth - searchBarWidth - rightMargin;
            panelBorder1.Location = new Point(searchBarX, 51);
            panelBorder1.Width = searchBarWidth;

            // Search textbox and button stay at fixed positions inside panel
            txtSearchBar.Width = 388;
            txtSearchBar.Location = new Point(40, 9);
            btnSearch.Location = new Point(453, 8);

            // Filter panel (panelBorder2) - full width with margins
            int filterPanelY = 163;
            int filterPanelWidth = formWidth - 144; // 72px margin on each side
            panelBorder2.Location = new Point(72, filterPanelY);
            panelBorder2.Width = filterPanelWidth;

            // Position elements inside panelBorder2
            btnAll.Location = new Point(14, 10);
            btnActive.Location = new Point(112, 10);
            btnInactive.Location = new Point(210, 10);

            // Position Add User button on the right
            int addUserX = filterPanelWidth - 185;
            btnAddPatient.Location = new Point(Math.Max(addUserX, 320), 6);

            // Position Sort dropdown next to Add User button
            int sortX = Math.Max(addUserX - 310, 310);
            cbSort.Location = new Point(sortX, 6);
            cbSort.Width = Math.Min(284, addUserX - sortX - 20);

            // Data grid panel (panelBorder3)
            int gridPanelY = filterPanelY + 73;
            int gridPanelHeight = Math.Max(formHeight - gridPanelY - 11, 200);
            panelBorder3.Location = new Point(74, gridPanelY);
            panelBorder3.Size = new Size(filterPanelWidth - 4, gridPanelHeight);

            // DataGridView inside panel - with margins
            int gridMargin = 10;
            dataGridUsers.Location = new Point(gridMargin, gridMargin);
            dataGridUsers.Size = new Size(
                Math.Max(panelBorder3.Width - (gridMargin * 2), 100),
                Math.Max(panelBorder3.Height - (gridMargin * 2), 100)
            );

            // Force layout update
            this.PerformLayout();
            panelBorder3.PerformLayout();
        }
        private async void UserPage_Load(object sender, EventArgs e)
        {
            await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            txtSearchBar.Texts = "Search for User name or UserID";

            // will get the TextBox inside the RJTextBox
            TextBox innerTxtSearchBar = txtSearchBar.Controls.OfType<TextBox>().FirstOrDefault();

            if (innerTxtSearchBar != null)
            {
                innerTxtSearchBar.KeyDown += InnerTxtSearchBar_KeyDown; // will add KeyDown KeyEvent
            }
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
                await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);

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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts); // will do search query
        }

        private async void btnAll_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already All
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnActive_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already Active
            if (currentTab != "Active")
            {
                currentTab = "Active";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnInactive_Click(object sender, EventArgs e)
        {
            // will only refresh the users list if the currentTab was not already Inactive
            if (currentTab != "Inactive")
            {
                currentTab = "Inactive";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for User name or UserID";
                searchData = "";
                await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
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

        private async void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh users list every time the sort value was changed
            await Queries.UserQueries.DisplayUsers(searchData, currentTab, cbSort.Texts);
        }

        private void UserHolder_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // will check if it is a valid row (not header)
            {
                if (e.ColumnIndex == 4) // column 4 is for View button
                {
                    await Queries.UserQueries.GetUserDetails(userList[e.RowIndex]);
                }
                else if (e.ColumnIndex == 5) // column 5 is for Edit button
                {
                    DataHolder.UserDataHolder = new UserDataHolder();
                    await Queries.UserQueries.GetUserDetails(userList[e.RowIndex], DataHolder.UserDataHolder);
                    PageObjects.editUser.PreviousPage = "Users Page";
                }
                else if (e.ColumnIndex == 6) // column 6 is for Archive / Unarchive button
                {
                    if (userList[e.RowIndex] == SessionManager.UserID)
                    {
                        CustomDialog.Show("You cannot archive your own data.",
                            "Archive error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                    else
                    {
                        if (dataGridUsers.Rows[e.RowIndex].Cells[3].Value.Equals("Active"))
                        {
                            var archiveDiag = CustomDialog.Show($"Are you sure you want to archive {userList[e.RowIndex]}?", "Archive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                            if (archiveDiag == DialogResult.Yes)
                            {
                                var success = await Queries.UserQueries.UpdateUserStatus(userList[e.RowIndex], 0);

                                if (success)
                                {
                                    // will add a log for archiving user
                                    await Queries.LogsQueries.AddLog($"Archived {userList[e.RowIndex]}", "Users");

                                    CustomDialog.Show($"{userList[e.RowIndex]} has been archived successfully!", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                                    await Queries.UserQueries.DisplayUsers("", PageObjects.userPage.CurrentTab, "Default");
                                }
                                else
                                {
                                    CustomDialog.Show($"Failed to archive {userList[e.RowIndex]}", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                                }
                            }
                        }
                        else if (dataGridUsers.Rows[e.RowIndex].Cells[3].Value.Equals("Inactive"))
                        {
                            var unarchiveDiag = CustomDialog.Show($"Are you sure you want to unarchive {userList[e.RowIndex]}?", "Unarchive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                            if (unarchiveDiag == DialogResult.Yes)
                            {
                                var success = await Queries.UserQueries.UpdateUserStatus(userList[e.RowIndex], 1);

                                if (success)
                                {
                                    // will add a log for unarchiving user
                                    await Queries.LogsQueries.AddLog($"Unarchived {userList[e.RowIndex]}", "Users");

                                    CustomDialog.Show($"{userList[e.RowIndex]} has been unarchived successfully!", "Unarchive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                                    await Queries.UserQueries.DisplayUsers("", PageObjects.userPage.CurrentTab, "Default");
                                }
                                else
                                {
                                    CustomDialog.Show($"Failed to unarchive {userList[e.RowIndex]}", "Unarchive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
