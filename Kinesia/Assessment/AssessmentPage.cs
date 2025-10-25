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
        List<string> assessmentList = new List<string>();

        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Size originalSize;
        private bool isInitialized = false;
        public AssessmentPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            ConfigureResponsiveness();
        }

        public DataGridView AssessmentGrid { get { return dataGridAssessments; } }
        public List<string> AssessmentList { get { return assessmentList; } }
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

        private void ConfigureResponsiveness()
        {
            // Configure DataGridView for responsiveness
            dataGridAssessments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAssessments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Set up anchors
            nameHolder.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelBorder2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PatientHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Set up resize event
            this.Resize += AssessmentPage_Resize;

            isInitialized = true;

            // Initial resize
            AssessmentPage_Resize(this, EventArgs.Empty);
        }


        private void SetupResponsiveLayout()
        {
            this.Resize += AssessmentPage_Resize;
        }

        private void AssessmentPage_Resize(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            int formWidth = this.Width;
            int formHeight = this.Height;

            // Header section (fixed positions)
            nameHolder.Location = new Point(71, 37);
            label1.Location = new Point(76, 83);

            // Search bar panel - anchored to right with fixed margin
            int searchBarWidth = 582;
            int rightMargin = 60;
            int searchBarX = formWidth - searchBarWidth - rightMargin;
            panelBorder1.Location = new Point(searchBarX, 51);
            panelBorder1.Width = searchBarWidth;

            // Search elements stay at fixed positions inside panel
            txtSearchBar.Location = new Point(56, 9);
            txtSearchBar.Width = 388;
            btnSearch.Location = new Point(453, 8);
            pictureBox1.Location = new Point(16, 17);

            // Filter panel (panelBorder2) - full width with margins
            int filterPanelY = 163;
            int filterPanelWidth = formWidth - 144; // 72px margin on each side
            panelBorder2.Location = new Point(72, filterPanelY);
            panelBorder2.Width = filterPanelWidth;

            // Position elements inside panelBorder2
            // Row 1: Extremity filters (left side)
            btnAllExtremity.Location = new Point(14, 10);
            btnUpperExtremities.Location = new Point(112, 10);
            btnLowerExtremities.Location = new Point(273, 10);

            // Row 1: Add Assessment button (right side)
            int addAssessmentX = filterPanelWidth - 214;
            btnAddAssessment.Location = new Point(Math.Max(addAssessmentX, 440), 7);

            // Row 1: Sort dropdown (right of separator, left of Add Assessment)
            int sortX = Math.Max(addAssessmentX - 310, 440);
            cbSort.Location = new Point(sortX, 8);
            cbSort.Width = Math.Min(284, addAssessmentX - sortX - 20);

            // Separator
            panelBorder3.Location = new Point(sortX - 20, 8);

            // Patient holder panel (contains grid and status buttons)
            int patientPanelY = filterPanelY + 73;
            int patientPanelHeight = Math.Max(formHeight - patientPanelY - 11, 300);
            PatientHolder.Location = new Point(72, patientPanelY);
            PatientHolder.Size = new Size(filterPanelWidth, patientPanelHeight);

            // FlowLayoutPanel1 - status filters at top right of PatientHolder
            int flowPanelX = filterPanelWidth - 579 - 16; // 16px margin from right
            flowLayoutPanel1.Location = new Point(Math.Max(flowPanelX, 400), 18);

            // DataGridView - fills remaining space
            int gridMargin = 16;
            int gridTop = 56; // Below flowLayoutPanel1
            dataGridAssessments.Location = new Point(gridMargin, gridTop);
            dataGridAssessments.Size = new Size(
                Math.Max(filterPanelWidth - (gridMargin * 2), 200),
                Math.Max(patientPanelHeight - gridTop - gridMargin, 200)
            );

            // Force layout update
            this.PerformLayout();
            PatientHolder.PerformLayout();
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
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == 5) // column 5 is for viewing assessment
                {
                    await Queries.AssessmentQueries.GetAssessmentDetails(assessmentList[e.RowIndex]);
                }
                else if(e.ColumnIndex == 7) // column 7 is for archive / unarcive assessment
                {
                    if (dataGridAssessments.Rows[e.RowIndex].Cells[4].Value.Equals("Ongoing"))
                    {
                        CustomDialog.Show("You cannot archive an ongoing assessment!\nYou need to set the status of assessment as Finished.", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return;
                    }

                    if (dataGridAssessments.Rows[e.RowIndex].Cells[4].Value.Equals("Finished"))
                    {
                        DialogResult archiveDiag = CustomDialog.Show($"Are you sure you want to archive {assessmentList[e.RowIndex]}?",
                            "Archive Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

                        if(archiveDiag == DialogResult.Yes)
                        {
                            var success = await Queries.AssessmentQueries.UpdateAssessmentStatus(assessmentList[e.RowIndex], 0);

                            if (success)
                            {
                                // will add a log for archiving an assessment
                                await Queries.LogsQueries.AddLog($"Archived {assessmentList[e.RowIndex]}", "Assessment");

                                CustomDialog.Show($"{assessmentList[e.RowIndex]} has been archived successfully!", "Archive Alert", CustomDialogButtons.OK, CustomDialogIcons.Information);

                                await Queries.AssessmentQueries.DisplayAssessments(searchData, currentExtremityTab, currentStatusTab, cbSort.Texts);
                            }
                        }
                    }

                }
            }
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
