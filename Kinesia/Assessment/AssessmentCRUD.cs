using KinesiaLibrary.DTOs.AssessmentDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kinesia.Assessment
{
    public class AssessmentCRUD
    {
        public async Task GetAssessmentDetails(string assessmentID)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/assessment/{assessmentID}";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var assessment = JsonConvert.DeserializeObject<AssessmentDTO>(json);

                        var assessmentDetailsPage = new AssessmentDetails();

                        assessmentDetailsPage.AssessmentID = assessment.AssessmentID;
                        assessmentDetailsPage.PatientID = assessment.PatientID;
                        assessmentDetailsPage.Age = assessment.Age.ToString();
                        assessmentDetailsPage.Gender = assessment.Gender;
                        assessmentDetailsPage.Extremity = assessment.Extremity;
                        assessmentDetailsPage.Joint = assessment.Joint;
                        assessmentDetailsPage.JointSide = assessment.JointSide;
                        assessmentDetailsPage.AssessmentStatus = assessment.AssessmentStatus;

                        PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                        PageObjects.dashboard.ContentsPanel.Controls.Add(assessmentDetailsPage);
                        PageObjects.CurrentControl = assessmentDetailsPage;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                            "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
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
    }
}
