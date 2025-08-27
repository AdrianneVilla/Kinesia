using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kinesia.Logs
{
    public class LogsCRUD
    {
        public void DisplayLogs()
        {
            PageObjects.logsPage.getLogHolder.Controls.Clear();

            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT L.LogID, L.LogType, U.FirstName, U.MiddleName, U.LastName, L.Description, L.LogDate " +
                "FROM Logs L JOIN Users U WHERE L.UserID = U.UserID GROUP BY L.LogDate", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                var displayLogs = new DisplayLogs();

                displayLogs.LogID = Connection.reader.GetString(0);
                displayLogs.LogType = Connection.reader.GetString(1);
                displayLogs.UserName = $"{Connection.reader.GetString(2)} {Connection.reader.GetString(3)} {Connection.reader.GetString(4)}";
                displayLogs.Description = Connection.reader.GetString(5);
                var dateTime = Connection.reader.GetDateTime(6);
                displayLogs.LogDate = dateTime.ToString();

                PageObjects.logsPage.getLogHolder.Controls.Add(displayLogs);
            }

            Connection.reader.Close();
            Connection.conn.Close();
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
