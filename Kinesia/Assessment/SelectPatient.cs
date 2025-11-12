using Kinesia.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class SelectPatient : Form
    {
        string searchData = "";

        List<string> patientList = new List<string>();

        public SelectPatient()
        {
            InitializeComponent();
        }

        public DataGridView GetPatientSelectionGrid { get { return dataGridPatientSelection; } }
        public List<string> PatientList { get { return patientList; } }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void SelectPatient_Load(object sender, EventArgs e)
        {
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
                await Queries.PatientQueries.DisplayPatientSelection(txtSearchBar.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
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
            await Queries.PatientQueries.DisplayPatientSelection(txtSearchBar.Texts);
        }

        private async void dataGridPatientSelection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    await Queries.PatientQueries.GetPatientBasicDetails(patientList[e.RowIndex]);
                    this.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
