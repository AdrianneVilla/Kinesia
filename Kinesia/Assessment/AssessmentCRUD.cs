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
