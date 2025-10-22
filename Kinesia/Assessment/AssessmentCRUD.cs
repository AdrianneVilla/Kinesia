using KinesiaLibrary.DTOs.AssessmentDTOs;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                    Name = "Status",
                    DataPropertyName = "Status",
                    HeaderText = "Status"
                });


                PageObjects.assessmentPage.AssessmentGrid.DataSource = assessments;
                PageObjects.assessmentPage.AssessmentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
    }
}
