using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KinesiaLibrary.DTOs;
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
                    displayLogControl.UserName = log.FullName;
                    displayLogControl.Description = log.Description;
                    displayLogControl.LogDate = log.LogDate;

                    PageObjects.logsPage.getLogHolder.Controls.Add(displayLogControl);
                }
            }
        }
        
        public void AddLog(string description, string logType)
        {
            Connection.conn.Open();

            var logID = SetLogID();

            Connection.cmd = new MySqlCommand("INSERT INTO Logs VALUES(@logID, @userID, @description, @logType, @logDate)", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@logID", logID);
            Connection.cmd.Parameters.AddWithValue("@userID", SessionManager.UserID);
            Connection.cmd.Parameters.AddWithValue("@description", description);
            Connection.cmd.Parameters.AddWithValue("@logType", logType);
            Connection.cmd.Parameters.AddWithValue("@logDate", DateTime.Now);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public string SetLogID()
        {
            Connection.cmd = new MySqlCommand("SELECT COUNT(LogID) FROM Logs", Connection.conn);
            return $"LOG{Convert.ToInt32(Connection.cmd.ExecuteScalar()) + 1}";
        }
    }
}
