using KinesiaLibrary.DTOs;
using KinesiaLibrary.DTOs.ROMDTOs;
using Newtonsoft.Json;
using ScottPlot.ArrowShapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task DisplayROM(string assessmentID, string movement)
        {
            try
            {
                var url = $"http://localhost:5000/api/rom?assessmentID={assessmentID}&movement={movement}";
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
                        Name = "StartingPosition",
                        DataPropertyName = "StartingPosition",
                        HeaderText = "Starting Position"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Rom",
                        DataPropertyName = "Rom",
                        HeaderText = "ROM"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "NormalRange",
                        DataPropertyName = "NormalRange",
                        HeaderText = "Normal Range"
                    });

                    PageObjects.assessmentDetails.GetROMGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Deficit",
                        DataPropertyName = "Deficit",
                        HeaderText = "Deficit"
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

        public async Task GenerateROMGraph(string assessmentID, string movement)
        {
            PageObjects.assessmentDetails.RomPlot.Plot.Clear();
            var assessmentDatesList = new List<DateTime>();
            var romValuesList = new List<double>();

            var url = $"http://localhost:5000/api/rom/generate-graph?assessmentID={assessmentID}&movement={movement}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var roms = JsonConvert.DeserializeObject<List<ROMGraphDTO>>(json);

                foreach(var rom in roms)
                {
                    assessmentDatesList.Add(rom.Date);
                    romValuesList.Add(rom.Rom);
                    Debug.WriteLine(rom.Date);
                    Debug.WriteLine(rom.Rom);
                }

                double[] dateDoubles = assessmentDatesList.Select(date => date.ToOADate()).ToArray();
                double[] romValues = romValuesList.ToArray();

                PageObjects.assessmentDetails.RomPlot.Plot.Add.Scatter(dateDoubles, romValues);

                // will use the automatic DateTime generator (my previous suggestion)
                PageObjects.assessmentDetails.RomPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();
                PageObjects.assessmentDetails.RomPlot.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;

                PageObjects.assessmentDetails.RomPlot.Plot.Title($"{movement} Progress");
                PageObjects.assessmentDetails.RomPlot.Plot.XLabel("Date of Tracking");
                PageObjects.assessmentDetails.RomPlot.Plot.YLabel("Range of Motion (degrees)");

                // will re-scale the axes to fit the new data
                PageObjects.assessmentDetails.RomPlot.Plot.Axes.AutoScale();

                PageObjects.assessmentDetails.RomPlot.Refresh();
            }
        }

        public bool IsROMDetailsComplete(AddROMDTO newROM)
        {
            // will return true if the ROM details was complete
            // will return false if the ROM details was incomplete
            if (newROM.Rom == 0.0 || newROM.Movement.Equals("") || newROM.MotionType.Equals(""))
            {
                CustomDialog.Show("ROM details was incomplete! \nPlease fill-out all details to add this ROM.", "Incomplete ROM Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            return true;
        }
    }
}
