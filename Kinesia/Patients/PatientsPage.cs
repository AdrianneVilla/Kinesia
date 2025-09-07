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

namespace Kinesia.Patients
{
    public partial class PatientsPage : UserControl
    {
        string searchData = "";
        string currentTab = "All";
        public PatientsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public PanelBorder getPatientHolder { get { return PatientHolder; } }
        public string CurrentTab { get { return currentTab; } }

        private async void PatientsPage_Load(object sender, EventArgs e)
        {
            await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
            txtSearchBar.Texts = "Search for Patient name or Patient ID";

            // will get the TextBox inside the RJTextBox
            TextBox innerTxtSearchBar = txtSearchBar.Controls.OfType<TextBox>().FirstOrDefault();

            if(innerTxtSearchBar != null)
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
                await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addPatient = new AddPatient();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addPatient);
            PageObjects.CurrentControl = PageObjects.addPatient;
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if(txtSearchBar.Texts == "Search for Patient name or Patient ID")
            {
                txtSearchBar.Texts = "";
            }
        }

        private void txtSearchBar_Leave(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "")
            {
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
            }
        }

        private void txtSearchBar__TextChanged(object sender, EventArgs e)
        {
            if(txtSearchBar.Texts == "Search for Patient name or Patient ID")
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
            await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts); // will do search query
        }
        private async void btnAll_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already All
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnActive_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already Active
            if (currentTab != "Active")
            {
                currentTab = "Active";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
            }
        }

        private async void btnInactive_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already Inactive
            if (currentTab != "Inactive")
            {
                currentTab = "Inactive";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
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

                    dataGridPatients.Columns[dataGridPatients.Columns.Count - 1].HeaderText = "Archive / Unarchive";
                    break;

                case "Active":
                    btnActive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnActive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnInactive.BackgroundColor = Color.Gainsboro;
                    btnInactive.ForeColor = Color.Gray;

                    dataGridPatients.Columns[dataGridPatients.Columns.Count - 1].HeaderText = "Archive";
                    break;

                case "Inactive":
                    btnInactive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnInactive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnActive.BackgroundColor = Color.Gainsboro;
                    btnActive.ForeColor = Color.Gray;

                    dataGridPatients.Columns[dataGridPatients.Columns.Count - 1].HeaderText = "Unarchive";
                    break;
            }
        }

        private async void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh patients list every time the sort value was changed
            await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
        }
    }
}
