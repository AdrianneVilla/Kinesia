using KinesiaLibrary.DTOs.AssessmentDTOs;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public class AssessmentCRUD
    {
        private readonly HttpClient client = ApiClient.Instance;

        public async Task DisplayAssessments(string searchData, string currentExtremityTab, string currentStatusTab, string sortColumn)
        {
            var url = $"http://localhost:5000/api/assessment?searchData={searchData}&currentExtremityTab={currentExtremityTab}&currentStatusTab={currentStatusTab}&sortColumn={sortColumn}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var assessments = JsonConvert.DeserializeObject<List<DisplayAssessmentsDTO>>(json);

                // prevent from flickering the icon buttons
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.SetProperty, null, PageObjects.assessmentPage.AssessmentGrid, new object[] {true}
                    );

                CustomDataGrid.SetDoubleBuffering(PageObjects.assessmentPage, true);
                PageObjects.assessmentPage.AssessmentGrid.SuspendLayout();
                PageObjects.assessmentPage.AssessmentGrid.AutoGenerateColumns = false;
                PageObjects.assessmentPage.AssessmentGrid.Columns.Clear();

                PageObjects.assessmentPage.AssessmentGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "AssessmentID",
                    DataPropertyName = "AssessmentID",
                    HeaderText = "Assessment ID"
                });

                PageObjects.assessmentPage.AssessmentGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PatientID",
                    DataPropertyName = "PatientID",
                    HeaderText = "Patient ID"
                });

                PageObjects.assessmentPage.AssessmentGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Extremity",
                    DataPropertyName = "Extremity",
                    HeaderText = "Extremity"
                });

                PageObjects.assessmentPage.AssessmentGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Joint",
                    DataPropertyName = "Joint",
                    HeaderText = "Joint"
                });

                PageObjects.assessmentPage.AssessmentGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "AssessmentStatus",
                    DataPropertyName = "AssessmentStatus",
                    HeaderText = "Status"
                });


                PageObjects.assessmentPage.AssessmentGrid.DataSource = assessments;
                PageObjects.assessmentPage.AssessmentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                AddActionButtons(PageObjects.assessmentPage.AssessmentGrid, currentStatusTab);

                CustomDataGrid.StyleDataGridWithSpacing(PageObjects.assessmentPage.AssessmentGrid);
                PageObjects.assessmentPage.AssessmentGrid.ResumeLayout();
            }
        }

        public async Task GetAssessmentDetails(string assessmentID)
        {
            try
            {
                var url = $"http://localhost:5000/api/assessment/{assessmentID}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var assessment = JsonConvert.DeserializeObject<AssessmentDTO>(json);

                    PageObjects.assessmentDetails = new AssessmentDetails();

                    PageObjects.assessmentDetails.AssessmentID = assessment.AssessmentID;
                    PageObjects.assessmentDetails.PatientID = assessment.PatientID;
                    PageObjects.assessmentDetails.Age = assessment.Age.ToString();
                    PageObjects.assessmentDetails.Gender = assessment.Gender;
                    PageObjects.assessmentDetails.Extremity = assessment.Extremity;
                    PageObjects.assessmentDetails.Joint = assessment.Joint;
                    PageObjects.assessmentDetails.JointSide = assessment.JointSide;
                    PageObjects.assessmentDetails.AssessmentStatus = assessment.AssessmentStatus;
                    PageObjects.assessmentDetails.AssessmentDate = assessment.AssessmentDate;

                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                    PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentDetails);
                    PageObjects.CurrentControl = PageObjects.assessmentDetails;
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                        "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        public async Task<int> GetTotalOngoingAssessments(int month, int year)
        {
            try
            {
                var url = $"http://localhost:5000/api/assessment/total-ongoing-assessments?month={month}&year={year}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(content, out int totalCount))
                    {
                        return totalCount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                        "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return 0;
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return 0;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return 0;
            }
        }

        public async Task<int> GetTotalAssessments(int month, int year)
        {
            try
            {
                var url = $"http://localhost:5000/api/assessment/total-assessments?month={month}&year={year}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(content, out int totalCount))
                    {
                        return totalCount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                        "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return 0;
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return 0;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return 0;
            }
        }

        public async Task<string> GetMostTrackedJoint(int month, int year)
        {
            try
            {
                var url = $"http://localhost:5000/api/assessment/most-tracked-joint?month={month}&year={year}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "N/A";
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return "N/A";
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return "N/A";
            }
        }

        public async Task<string> AddAssessment(AddAssessmentDTO newAssessment)
        {
            try
            {
                var json = JsonConvert.SerializeObject(newAssessment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5000/api/assessment", content);

                if (response.IsSuccessStatusCode)
                {
                    return newAssessment.AssessmentID;
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API-side.
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
        }

        public async Task<string> SetAssessmentID()
        {
            try
            {
                var url = "http://localhost:5000/api/assessment/generate-assessmentid";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API-side.
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
        }

        private Point hoveredCell = new Point(-1, -1);

        // for cell button
        public void AddActionButtons(DataGridView dataGrid, string currentStatusTab)
        {
            dataGrid.SuspendLayout();

            //Add Select Button

            if (dataGrid.Columns["SelectButton"] == null)
            {
                DataGridViewButtonColumn selectBtn = new DataGridViewButtonColumn();
                selectBtn.Name = "SelectButton";
                selectBtn.HeaderText = "View";
                selectBtn.UseColumnTextForButtonValue = true;
                selectBtn.Width = 80;
                selectBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(selectBtn);
            }

            //Edit button

            if (dataGrid.Columns["EditButton"] == null)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "EditButton";
                editBtn.HeaderText = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 80;
                editBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(editBtn);
            }

            // Archive/Unarchive button
            if (dataGrid.Columns["ArchiveButton"] == null)
            {
                DataGridViewButtonColumn archiveBtn = new DataGridViewButtonColumn();
                archiveBtn.Name = "ArchiveButton";
                archiveBtn.HeaderText = GetArchiveHeaderText(currentStatusTab);
                archiveBtn.UseColumnTextForButtonValue = true;
                archiveBtn.Width = 190;
                archiveBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(archiveBtn);
            }
            else
            {
                // Update header text based on current tab
                dataGrid.Columns["ArchiveButton"].HeaderText = GetArchiveHeaderText(currentStatusTab);
            }

            dataGrid.ResumeLayout();

            // Wire up events (remove existing handlers first to avoid duplicates)
            dataGrid.CellPainting -= DataGrid_CellPainting;
            dataGrid.CellPainting += DataGrid_CellPainting;

            dataGrid.CellMouseEnter -= DataGrid_CellMouseEnter;
            dataGrid.CellMouseEnter += DataGrid_CellMouseEnter;

            dataGrid.CellMouseLeave -= DataGrid_CellMouseLeave;
            dataGrid.CellMouseLeave += DataGrid_CellMouseLeave;
        }

        private string GetArchiveHeaderText(string currentStatusTab)
        {
            switch (currentStatusTab)
            {
                case "Ongoing":
                case "Finished":
                    return "Archive";
                case "Archived":
                    return "Unarchive";
                default:
                    return "Archive/Unarchive";
            }
        }

        private void DataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dataGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "SelectButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    bool isHovered = (hoveredCell.X == e.ColumnIndex && hoveredCell.Y == e.RowIndex);
                    Color backgroundColor = isHovered ? Color.FromArgb(220, 220, 220) : Color.White;

                    e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.CellBounds);
                   

                    Image icon = null;
                    if (columnName == "SelectButton")
                        icon = Properties.Resources.newSelect;
                    else if (columnName == "EditButton")
                        icon = Properties.Resources.newEdit;
                    else if (columnName == "ArchiveButton")
                    {
                        // Check status from the Status column
                        var statusCell = dataGrid.Rows[e.RowIndex].Cells["AssessmentStatus"]?.Value;
                        string status = statusCell?.ToString() ?? "";

                        if (status == "Ongoing" || status == "Finished")
                        {
                            icon = Properties.Resources.newArchive;
                        }
                        else if (status == "Archived")
                        {
                            icon = Properties.Resources.Unarchive;
                        }
                    }

                    if (icon != null)
                    {
                        int iconWidth = 20;
                        int iconHeight = 20;
                        int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                        e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    }
                    e.Handled = true;
                }
            }
        }

        private void DataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGrid = (DataGridView)sender;
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "SelectButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    hoveredCell = new Point(e.ColumnIndex, e.RowIndex);
                    dataGrid.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGrid = (DataGridView)sender;
                hoveredCell = new Point(-1, -1);
                dataGrid.InvalidateCell(e.ColumnIndex, e.RowIndex);
            }
        }

        public static void SetDoubleBuffered(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, dgv, new object[] { true });
        }
    }

}
