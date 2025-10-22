using KinesiaLibrary.DTOs;
using KinesiaLibrary.DTOs.ROMDTOs;
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
    public class ROMCRUD
    {
        private readonly HttpClient client = ApiClient.Instance;

        public async Task DisplayROM(string assessmentID)
        {
            try
            {
                var url = $"http://localhost:5000/api/rom?assessmentID={assessmentID}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var ROMs = JsonConvert.DeserializeObject<List<DisplayROMsDTO>>(json);

                    CustomDataGrid.SetDoubleBuffering(PageObjects.assessmentDetails.GetROMGrid, true);
                    PageObjects.assessmentDetails.GetROMGrid.SuspendLayout();
                    PageObjects.assessmentDetails.GetROMGrid.AutoGenerateColumns = false;
                    PageObjects.assessmentDetails.GetROMGrid.Columns.Clear();

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "TherapistName",
                        DataPropertyName = "TherapistName",
                        HeaderText = "Therapist Name"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "InitialROM",
                        DataPropertyName = "InitialROM",
                        HeaderText = "Initial ROM"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "EndROM",
                        DataPropertyName = "EndROM",
                        HeaderText = "End ROM"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Movement",
                        DataPropertyName = "Movement",
                        HeaderText = "Movement Type"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Date",
                        DataPropertyName = "Date",
                        HeaderText = "Date"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.DataSource = ROMs;
                    PageObjects.assessmentDetails.GetROMGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    CustomDataGrid.StyleDataGridWithSpacing(PageObjects.assessmentDetails.GetROMGrid);
                    PageObjects.assessmentDetails.GetROMGrid.ResumeLayout();
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API-side.
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }
        public async Task<bool> AddROM(AddROMDTO newROM)
        {
            try
            {
                var json = JsonConvert.SerializeObject(newROM);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5000/api/rom", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // will show an error dialog if it returns a badrequest from API-side.
                    CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }
        public bool IsROMDetailsComplete(AddROMDTO newROM)
        {
            // will return true if the ROM details was complete
            // will return false if the ROM details was incomplete
            if (newROM.EndROM == 0.0 || newROM.Movement.Equals("") || newROM.MotionType.Equals("") || newROM.Deviation.Equals(""))
            {
                CustomDialog.Show("ROM details was incomplete! \nPlease fill-out all details to add this ROM.", "Incomplete ROM Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            return true;
        }
    }
}
