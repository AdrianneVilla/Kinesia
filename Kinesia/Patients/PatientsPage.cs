using CustomControls.RJControls;
using KinesiaLibrary.DTOs.AuthDTOs;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

        List<string> patientList = new List<string>();

        public List<string> PatientList { get { return patientList; } }

        public PatientsPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;

            InitializeComponent();
        }

        public DataGridView GetPatientGrid { get { return dataGridPatients; } }
        public string CurrentTab { get { return currentTab; } }


        private void PatientsPage_Load(object sender, EventArgs e)
        {
            GetPatientList();

            txtSearchBar.Texts = "Search for Patient name or Patient ID";

            // will get the TextBox inside the RJTextBox
            TextBox innerTxtSearchBar = txtSearchBar.Controls.OfType<TextBox>().FirstOrDefault();

            if (innerTxtSearchBar != null)
            {
                innerTxtSearchBar.KeyDown += InnerTxtSearchBar_KeyDown; // will add KeyDown KeyEvent
            }
        }

        private async void GetPatientList()
        {
            await this.FindForm().RunTaskWithLoading("Fetching patients list...", async () =>
            {
                await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
            });
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
            PageObjects.addPatient.PreviousPage = "Patient Page";
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for Patient name or Patient ID")
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
            if (txtSearchBar.Texts == "Search for Patient name or Patient ID")
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
            GetPatientList(); // will do search query
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already All
            if (currentTab != "All")
            {
                currentTab = "All";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                GetPatientList();
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already Active
            if (currentTab != "Active")
            {
                currentTab = "Active";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                GetPatientList();
            }
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            // will only refresh the patients list if the currentTab was not already Inactive
            if (currentTab != "Inactive")
            {
                currentTab = "Inactive";
                switchTab(currentTab);
                txtSearchBar.Texts = "Search for Patient name or Patient ID";
                searchData = "";
                GetPatientList();
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
                    //dataGridPatients.Columns[-1].HeaderText = "Archive / Unarchive";
                    //actionLabel.Text = "Archive / Unarchive";
                    //actionLabel.ForeColor = Color.Black;
                    break;

                case "Active":
                    btnActive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnActive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnInactive.BackgroundColor = Color.Gainsboro;
                    btnInactive.ForeColor = Color.Gray;
                    //dataGridPatients.Columns[-1].HeaderText = "Archive";
                    //actionLabel.Text = "Archive";
                    //actionLabel.ForeColor = Color.Black;
                    break;

                case "Inactive":
                    btnInactive.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnInactive.ForeColor = Color.White;

                    btnAll.BackgroundColor = Color.Gainsboro;
                    btnAll.ForeColor = Color.Gray;

                    btnActive.BackgroundColor = Color.Gainsboro;
                    btnActive.ForeColor = Color.Gray;
                    //dataGridPatients.Columns[-1].HeaderText = "Unarchive";
                    //actionLabel.Text = "Unarchive";
                    //actionLabel.ForeColor = Color.Black;
                    break;
            }
        }

        private void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh patients list every time the sort value was changed
            GetPatientList();
        }

        private void PatientHolder_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void dataGridPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) // will check if it is a valid row (not header)
            {
                if(e.ColumnIndex == 5) // column 5 is for EMR button
                {
                    await this.FindForm().RunTaskWithLoading("Fetching patient's data...", async () =>
                    {
                        await Queries.PatientQueries.GetPatientDetails(patientList[e.RowIndex]);
                    });
                }
                else if(e.ColumnIndex == 6) // column 6 is for Edit button
                {
                    DataHolder.PatientDataHolder = new PatientDataHolder();
                    await this.FindForm().RunTaskWithLoading("Fetching patient's data to edit...", async () =>
                    {
                        await Queries.PatientQueries.GetPatientDetails(patientList[e.RowIndex], DataHolder.PatientDataHolder);
                    });
                    PageObjects.editPatient.PreviousPage = "Patients Page";
                }
                else if(e.ColumnIndex == 7) // column 7 is for Archive / Unarchive button
                {
                    if (dataGridPatients.Rows[e.RowIndex].Cells[4].Value.Equals("Active"))
                    {
                        // will show message box for Archiving patient
                        DialogResult archiveDiag = CustomDialog.Show($"Are you sure you want to archive {patientList[e.RowIndex]}?", "Archive Patient Notification",
                        CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                        if (archiveDiag == DialogResult.Yes)
                        {
                            var success = await this.FindForm().RunTaskWithLoading("Archiving patient's data...", async () =>
                            {
                                return await Queries.PatientQueries.UpdatePatientStatus(patientList[e.RowIndex], 0);
                            });

                            if (success)
                            {
                                // will add a log for archiving a patient
                                await Queries.LogsQueries.AddLog($"Archived {patientList[e.RowIndex]}", "Patients");

                                CustomDialog.Show($"{patientList[e.RowIndex]} has been successfully archived!", "Archive Patient Notification",
                                    CustomDialogButtons.OK, CustomDialogIcons.Information);

                                await this.FindForm().RunTaskWithLoading("Fetching patients list...", async () =>
                                {
                                    await Queries.PatientQueries.DisplayPatients("", PageObjects.patientsPage.CurrentTab, "Default");
                                });        
                            }
                        }
                    }
                    else if(dataGridPatients.Rows[e.RowIndex].Cells[4].Value.Equals("Inactive"))
                    {
                        // will show message box for Unarchiving patient
                        DialogResult unarchiveDiag = CustomDialog.Show($"Are you sure you want to unarchive {patientList[e.RowIndex]}?", "Unarchive Patient Notification",
                        CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                        if (unarchiveDiag == DialogResult.Yes)
                        {
                            var success = await this.FindForm().RunTaskWithLoading("Unarchiving patient's data...", async () =>
                            {
                                return await Queries.PatientQueries.UpdatePatientStatus(patientList[e.RowIndex], 1);
                            });

                            if (success)
                            {
                                // will add a log for unarchiving a patient
                                await Queries.LogsQueries.AddLog($"Unarchived {patientList[e.RowIndex]}", "Patients");

                                CustomDialog.Show($"{patientList[e.RowIndex]} has been successfully unarchived!", "Unarchive Patient Notification",
                                    CustomDialogButtons.OK, CustomDialogIcons.Information);

                                await this.FindForm().RunTaskWithLoading("Fetching patients list...", async () =>
                                {
                                    await Queries.PatientQueries.DisplayPatients("", PageObjects.patientsPage.CurrentTab, "Default");
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}

