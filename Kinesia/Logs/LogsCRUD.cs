using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KinesiaLibrary.DTOs.LogDTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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
        
        public async Task AddLog(string description, string logType)
        {
            using(var client = new HttpClient())
            {
                var newLog = new AddLogDTO();

                newLog.LogID = SetLogID();
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

            //Connection.conn.Open();

            //var logID = SetLogID();

            //Connection.cmd = new MySqlCommand("INSERT INTO Logs VALUES(@logID, @userID, @description, @logType, @logDate)", Connection.conn);
            //Connection.cmd.Parameters.AddWithValue("@logID", logID);
            //Connection.cmd.Parameters.AddWithValue("@userID", SessionManager.UserID);
            //Connection.cmd.Parameters.AddWithValue("@description", description);
            //Connection.cmd.Parameters.AddWithValue("@logType", logType);
            //Connection.cmd.Parameters.AddWithValue("@logDate", DateTime.Now);
            //Connection.cmd.ExecuteNonQuery();

            //Connection.conn.Close();
        }

        public string SetLogID()
        {
            Connection.conn.Open();
            Connection.cmd = new MySqlCommand("SELECT COUNT(LogID) FROM Logs", Connection.conn);
            string logID = $"LOG{Convert.ToInt32(Connection.cmd.ExecuteScalar()) + 1}";
            Connection.conn.Close();
            return logID;
        }
    }
}
