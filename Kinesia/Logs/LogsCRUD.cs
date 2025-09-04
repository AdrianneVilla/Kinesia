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
        public void DisplayLogs(string searchData, string currentTab, string sortColumn)
        {
            PageObjects.logsPage.getLogHolder.Controls.Clear();
            Connection.conn.Open();

            string query = "SELECT L.LogID, L.LogType, U.FirstName, U.MiddleName, U.LastName, L.Description, L.LogDate " +
                "FROM Logs L JOIN Users U WHERE L.UserID = U.UserID";

            // collections of all conditions for the query
            List<string> conditions = new List<string>();

            // will only display specific logs
            if(currentTab != "All")
            {
                conditions.Add("LogType = @logType");
            }

            // will only add this condition to the query if searchData is not empty
            if (!string.IsNullOrEmpty(searchData))
            {
                string searchCondition = @"(L.LogID LIKE CONCAT('%', @searchData, '%') 
                                        OR U.FirstName LIKE CONCAT('%', @searchData, '%') 
                                        OR U.MiddleName LIKE CONCAT('%', @searchData, '%') 
                                        OR U.LastName LIKE CONCAT('%', @searchData, '%'))";
                conditions.Add(searchCondition);
            }

            // will add all conditions to the query (if there's any condition added)
            if (conditions.Count > 0)
            {
                query += " AND " + string.Join(" AND ", conditions);
            }

            string sortCondition = "ASC";

            if(sortColumn == "Earliest")
            {
                sortCondition = "DESC";
            }

            query += $" ORDER BY L.LogDate {sortCondition}";

            Connection.cmd = new MySqlCommand(query, Connection.conn);

            // will only add parameter if searchData is not empty
            if (!string.IsNullOrEmpty(searchData))
            {
                Connection.cmd.Parameters.AddWithValue("@searchData", searchData);
            }

            Connection.cmd.Parameters.AddWithValue("logType", currentTab);

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
