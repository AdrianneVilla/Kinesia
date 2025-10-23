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
    public partial class AssessmentPage : UserControl
    {
        string searchData = "";
        string currentExtremityTab = "All";
        string currentStatusTab = "All";

        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Size originalSize;
        private bool isInitialized = false;
        public AssessmentPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public DataGridView AssessmentGrid { get { return dataGridAssessments; } }
        private void StoreOriginalSizes()
        {
            if (isInitialized) return;

            originalSize = this.Size;

            // Store all controls recursively
            StoreControlBoundsRecursive(this);

            isInitialized = true;
        }

        private void StoreControlBoundsRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                {
                    originalControlBounds[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
                }

                // Recursively store child controls
                if (ctrl.HasChildren)
                {
                    StoreControlBoundsRecursive(ctrl);
                }
            }
        }

        private void SetupResponsiveLayout()
        {
            this.Resize += AssessmentPage_Resize;
        }

        private void AssessmentPage_Resize(object sender, EventArgs e)
        {
            if (!isInitialized || originalSize.Width == 0 || originalSize.Height == 0) return;

            ResizeControls();
        }

        private void ResizeControls()
        {
            float scaleX = (float)this.Width / originalSize.Width;
            float scaleY = (float)this.Height / originalSize.Height;

            this.SuspendLayout();

            // Resize panelBorder2 (contains buttons and cbSort)
            if (originalControlBounds.ContainsKey(panelBorder2))
            {
                Rectangle origBounds = originalControlBounds[panelBorder2];
                int newWidth = (int)(origBounds.Width * scaleX);
                panelBorder2.Size = new Size(newWidth, origBounds.Height);

                // Now resize controls inside panelBorder2
                panelBorder2.SuspendLayout();

                // Resize cbSort (ComboBox)
                if (originalControlBounds.ContainsKey(cbSort))
                {
                    Rectangle cbOrigBounds = originalControlBounds[cbSort];
                    int cbNewWidth = (int)(cbOrigBounds.Width * scaleX);
                    int cbNewX = (int)(cbOrigBounds.X * scaleX);

                    cbSort.Location = new Point(cbNewX, cbOrigBounds.Y);
                    cbSort.MinimumSize = new Size(cbNewWidth, cbOrigBounds.Height);
                    cbSort.Size = new Size(cbNewWidth, cbOrigBounds.Height);
                    cbSort.MaximumSize = new Size(cbNewWidth, cbOrigBounds.Height);
                }

                // Resize btnAddAssessment
                if (originalControlBounds.ContainsKey(btnAddAssessment))
                {
                    Rectangle btnOrigBounds = originalControlBounds[btnAddAssessment];
                    int btnNewX = (int)(btnOrigBounds.X * scaleX);
                    btnAddAssessment.Location = new Point(btnNewX, btnOrigBounds.Y);
                }

                panelBorder2.ResumeLayout();
            }

            // Resize panelBorder1 (search bar container)
            if (originalControlBounds.ContainsKey(panelBorder1))
            {
                Rectangle origBounds = originalControlBounds[panelBorder1];
                int newX = (int)(origBounds.X * scaleX);
                int newWidth = (int)(origBounds.Width * scaleX);

                // Resize the panel itself
                panelBorder1.Location = new Point(newX, origBounds.Y);
                panelBorder1.Size = new Size(newWidth, origBounds.Height);

                panelBorder1.SuspendLayout();

                // Resize txtSearchBar inside panelBorder1
                if (originalControlBounds.ContainsKey(txtSearchBar))
                {
                    Rectangle txtOrigBounds = originalControlBounds[txtSearchBar];
                    int txtNewWidth = (int)(txtOrigBounds.Width * scaleX);
                    txtSearchBar.Size = new Size(txtNewWidth, txtOrigBounds.Height);
                }

                // Reposition btnSearch
                if (originalControlBounds.ContainsKey(btnSearch))
                {
                    Rectangle btnOrigBounds = originalControlBounds[btnSearch];
                    int btnNewX = (int)(btnOrigBounds.X * scaleX);
                    btnSearch.Location = new Point(btnNewX, btnOrigBounds.Y);
                }

                // Reposition pictureBox1 (search icon) - keep at original position

                panelBorder1.ResumeLayout();
            }

            // Resize PatientHolder
            if (originalControlBounds.ContainsKey(PatientHolder))
            {
                Rectangle origBounds = originalControlBounds[PatientHolder];
                int newWidth = (int)(origBounds.Width * scaleX);
                int newHeight = (int)(origBounds.Height * scaleY);
                PatientHolder.Size = new Size(newWidth, newHeight);

                PatientHolder.SuspendLayout();

                // Resize dataGridAssessments
                if (originalControlBounds.ContainsKey(dataGridAssessments))
                {
                    Rectangle dgOrigBounds = originalControlBounds[dataGridAssessments];
                    int dgNewWidth = (int)(dgOrigBounds.Width * scaleX);
                    int dgNewHeight = (int)(dgOrigBounds.Height * scaleY);
                    dataGridAssessments.Size = new Size(dgNewWidth, dgNewHeight);
                }

                // Reposition flowLayoutPanel1
                if (originalControlBounds.ContainsKey(flowLayoutPanel1))
                {
                    Rectangle flowOrigBounds = originalControlBounds[flowLayoutPanel1];
                    int flowNewX = (int)(flowOrigBounds.X * scaleX);
                    flowLayoutPanel1.Location = new Point(flowNewX, flowOrigBounds.Y);
                }

                PatientHolder.ResumeLayout();
            }

            this.ResumeLayout();
            this.PerformLayout();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void AssessmentPage_Load(object sender, EventArgs e)
        {
            StoreOriginalSizes();
            SetupResponsiveLayout();
            await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            txtSearchBar.Texts = "Search for Assessment ID or Patient ID";

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
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);

                e.SuppressKeyPress = true; // will prevent windows from making the beep sounds when pressing "enter"
            }
        }

        private void txtSearchBar_Enter(object sender, EventArgs e)
        {
            if(txtSearchBar.Texts == "Search for Assessment ID or Patient ID")
            {
                txtSearchBar.Texts = "";
            }
        }

        private void txtSearchBar_Leave(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "")
            {
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
            }
        }

        private void txtSearchBar__TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Texts == "Search for Assessment ID or Patient ID")
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
            await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
        }

        private void btnAddAssessment_Click(object sender, EventArgs e)
        {
            PageObjects.addAssessment = new AddAssessment();
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
            PageObjects.CurrentControl = PageObjects.addAssessment;
        }

        private async void cbSort_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // will refresh assessment list every time the sort value was changed
            await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
        }

        private async void btnAllExtremity_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentExtremityTab was not already All
            if (currentExtremityTab != "All")
            {
                currentExtremityTab = "All";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnUpperExtremities_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentExtremityTab was not already Upper Extremity
            if (currentExtremityTab != "Upper Extremity")
            {
                currentExtremityTab = "Upper Extremity";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnLowerExtremities_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentExtremityTab was not already Lower Extremity
            if (currentExtremityTab != "Lower Extremity")
            {
                currentExtremityTab = "Lower Extremity";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnAllStatus_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentStatusTab was not already All
            if (currentStatusTab != "All")
            {
                currentStatusTab = "All";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnOngoing_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentStatusTab was not already Ongoing
            if (currentStatusTab != "Ongoing")
            {
                currentStatusTab = "Ongoing";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnFinished_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentStatusTab was not already Finished
            if (currentStatusTab != "Finished")
            {
                currentStatusTab = "Finished";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private async void btnArchived_Click(object sender, EventArgs e)
        {
            // will only refresh the assessment list if the currentStatusTab was not already Archived
            if (currentStatusTab != "Archived")
            {
                currentStatusTab = "Archived";
                switchTab(currentExtremityTab, currentStatusTab);
                txtSearchBar.Texts = "Search for Assessment ID or Patient ID";
                searchData = "";
                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
            }
        }

        private void switchTab(string currentExtremityTab, string currentStatusTab)
        {
            switch (currentExtremityTab)
            {
                case "All":
                    btnAllExtremity.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnAllExtremity.ForeColor = Color.White;

                    btnUpperExtremities.BackgroundColor = Color.Gainsboro;
                    btnUpperExtremities.ForeColor = Color.Gray;

                    btnLowerExtremities.BackgroundColor = Color.Gainsboro;
                    btnLowerExtremities.ForeColor = Color.Gray;
                    break;
                case "Upper Extremity":
                    btnUpperExtremities.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnUpperExtremities.ForeColor = Color.White;

                    btnAllExtremity.BackgroundColor = Color.Gainsboro;
                    btnAllExtremity.ForeColor = Color.Gray;

                    btnLowerExtremities.BackgroundColor = Color.Gainsboro;
                    btnLowerExtremities.ForeColor = Color.Gray;
                    break;
                case "Lower Extremity":
                    btnLowerExtremities.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnLowerExtremities.ForeColor = Color.White;

                    btnAllExtremity.BackgroundColor = Color.Gainsboro;
                    btnAllExtremity.ForeColor = Color.Gray;

                    btnUpperExtremities.BackgroundColor = Color.Gainsboro;
                    btnUpperExtremities.ForeColor = Color.Gray;
                    break;
            }

            switch (currentStatusTab)
            {
                case "All":
                    btnAllStatus.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnAllStatus.ForeColor = Color.White;

                    btnOngoing.BackgroundColor = Color.Gainsboro;
                    btnOngoing.ForeColor = Color.Gray;

                    btnFinished.BackgroundColor = Color.Gainsboro;
                    btnFinished.ForeColor = Color.Gray;

                    btnArchived.BackgroundColor = Color.Gainsboro;
                    btnArchived.ForeColor = Color.Gray;
                    break;
                case "Ongoing":
                    btnAllStatus.BackgroundColor = Color.Gainsboro;
                    btnAllStatus.ForeColor = Color.Gray;

                    btnOngoing.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnOngoing.ForeColor = Color.White;

                    btnFinished.BackgroundColor = Color.Gainsboro;
                    btnFinished.ForeColor = Color.Gray;

                    btnArchived.BackgroundColor = Color.Gainsboro;
                    btnArchived.ForeColor = Color.Gray;
                    break;
                case "Finished":
                    btnAllStatus.BackgroundColor = Color.Gainsboro;
                    btnAllStatus.ForeColor = Color.Gray;

                    btnOngoing.BackgroundColor = Color.Gainsboro;
                    btnOngoing.ForeColor = Color.Gray;

                    btnFinished.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnFinished.ForeColor = Color.White;

                    btnArchived.BackgroundColor = Color.Gainsboro;
                    btnArchived.ForeColor = Color.Gray;
                    break;
                case "Archived":
                    btnAllStatus.BackgroundColor = Color.Gainsboro;
                    btnAllStatus.ForeColor = Color.Gray;

                    btnOngoing.BackgroundColor = Color.Gainsboro;
                    btnOngoing.ForeColor = Color.Gray;

                    btnFinished.BackgroundColor = Color.Gainsboro;
                    btnFinished.ForeColor = Color.Gray;

                    btnArchived.BackgroundColor = Color.FromArgb(18, 90, 211);
                    btnArchived.ForeColor = Color.White;
                    break;
            }
        }
    }
}
