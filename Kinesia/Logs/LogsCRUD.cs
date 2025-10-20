using KinesiaLibrary.DTOs.LogDTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Logs
{
    public class LogsCRUD
    {
        public async Task DisplayLogs(string searchData, string currentTab, string sortColumn)
        {
            PageObjects.logsPage.getLogHolder.Controls.Clear();
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/logs?searchData={searchData}&currentTab={currentTab}&sortColumn={sortColumn}";

                var response = await client.GetStringAsync(url);
                var logs = JsonConvert.DeserializeObject<List<LogDTO>>(response);

                foreach(var log in logs)
                {
                    var displayLogControl = new DisplayLogs();

                    displayLogControl.LogID = log.LogID;
                    displayLogControl.LogType = log.LogType;
                    displayLogControl.UserName = $"{log.FirstName} {log.MiddleName} {log.LastName}";
                    displayLogControl.Description = log.Description;
                    displayLogControl.LogDate = log.LogDate.ToString();

                    PageObjects.logsPage.getLogHolder.Controls.Add(displayLogControl);
                }
            }
        }

        public async Task DisplayDashboardLogs()
        {
            using(var client = new HttpClient())
            {
                var url = "https://localhost:5001/api/logs/dashboard";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var logs = JsonConvert.DeserializeObject<List<DisplayDashboardLogsDTO>>(json);

                    CustomDataGrid.SetDoubleBuffering(PageObjects.dashboardPage.GetLogsGrid, true);
                    PageObjects.dashboardPage.GetLogsGrid.AutoGenerateColumns = false;
                    PageObjects.dashboardPage.GetLogsGrid.Columns.Clear();

                    PageObjects.dashboardPage.GetLogsGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LogID",
                        DataPropertyName = "LogID",
                        HeaderText = "Log ID"
                    });

                    PageObjects.dashboardPage.GetLogsGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LogType",
                        DataPropertyName = "logType",
                        HeaderText = "Log Type"
                    });

                    PageObjects.dashboardPage.GetLogsGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "User",
                        DataPropertyName = "user",
                        HeaderText = "User"
                    });

                    PageObjects.dashboardPage.GetLogsGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LogDescription",
                        DataPropertyName = "logDescription",
                        HeaderText = "Log Description"
                    });

                    PageObjects.dashboardPage.GetLogsGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LogDate",
                        DataPropertyName = "logDate",
                        HeaderText = "Log Date"
                    });

                    PageObjects.dashboardPage.GetLogsGrid.DataSource = logs;
                    PageObjects.dashboardPage.GetLogsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    CustomDataGrid.StyleDataGridWithSpacing(PageObjects.dashboardPage.GetLogsGrid);
                    PageObjects.dashboardPage.GetLogsGrid.Refresh();
                }
            }
        }
        
        public async Task AddLog(string description, string logType)
        {
            using(var client = new HttpClient())
            {
                var newLog = new AddLogDTO();

                newLog.LogID = await GetLogID();

                if (string.IsNullOrEmpty(newLog.LogID))
                {
                    return;
                }

                newLog.UserID = SessionManager.UserID;
                newLog.Description = description;
                newLog.LogType = logType;
                newLog.LogDate = DateTime.Now;

                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var json = JsonConvert.SerializeObject(newLog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("logs", content);

                if(!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.StatusCode);
                }
            }
        }

        public async Task<string> GetLogID()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://localhost:5001/api/logs/generate-logid";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                            "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return null;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return null;
            }
        }
    }
}
