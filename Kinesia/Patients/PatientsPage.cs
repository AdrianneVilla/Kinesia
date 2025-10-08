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

        public DataGridView GetPatientGrid { get { return dataGridPatients; } }
        public string CurrentTab { get { return currentTab; } }


        private async void PatientsPage_Load(object sender, EventArgs e)
        {
            await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
            txtSearchBar.Texts = "Search for Patient name or Patient ID";

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

        private async void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh patients list every time the sort value was changed
            await Queries.PatientQueries.DisplayPatients(searchData, currentTab, cbSort.Texts);
        }

        private void PatientHolder_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //DITO MAG START PRE, NAGPATULONG LANG AKO KAY KUMPARENG PERPLIXITY


        //private async Task LoadDataAsync()
        //{
        //    try
        //    {
        //        string apiUrl = "https://localhost:5001/api/patients";
        //        using (HttpClient client = new HttpClient())
        //        {
        //            HttpResponseMessage response = await client.GetAsync(apiUrl);
        //            response.EnsureSuccessStatusCode();
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            var data = JsonConvert.DeserializeObject<List<KinesiaAPI.Models.Entities.Patients>>(responseBody);
        //            dataGridPatients.DataSource = data;
        //            dataGridPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }
        //}


        //private void dataGridPatients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // Check if it's the Status column
        //    if (dataGridPatients.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
        //    {
        //        // Convert numeric status to text
        //        if (e.Value.ToString() == "1")
        //        {
        //            e.Value = "Active";
        //            e.FormattingApplied = true;
        //        }
        //        else if (e.Value.ToString() == "0")
        //        {
        //            e.Value = "Inactive";
        //            e.FormattingApplied = true;
        //        }
        //    }
        //}


        //public class MyDataModel
        //{
        //    public string PatientID { get; set; }
        //    [JsonProperty("status")]
        //    [Browsable(false)]
        //    public string StatusCode { get; set; }

        //    [JsonIgnore]
        //    public string Status
        //    {
        //        get
        //        {
        //            return StatusCode == "1" ? "Active" : "Inactive";
        //        }
        //    }
        //    [JsonProperty("firstName")]
        //    [Browsable(false)]
        //    public string firstName { get; set; }
        //    [Browsable(false)]
        //    [JsonProperty("lastName")]
        //    public string lastName { get; set; }
        //    [Browsable(false)]
        //    [JsonProperty("middleName")]
        //    public string middleName { get; set; }
        //    public string PatientName
        //    {
        //        get
        //        {
        //            // Combine firstName + middleName + lastName with spaces
        //            return $"{firstName} {middleName} {lastName}".Trim();

        //            // OR if you want to handle null/empty values more gracefully:
        //            // var names = new[] { firstName, middleName, lastName }
        //            //     .Where(n => !string.IsNullOrWhiteSpace(n));
        //            // return string.Join(" ", names);
        //        }
        //        set { }
        //    }

        //    public string Age { get; set; }
        //    public string Gender { get; set; }
        //    public string Contact { get; set; }


        //}
    }
}

