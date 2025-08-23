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

            Connection.cmd = new MySqlCommand("SELECT L.LogID, U.FirstName, U.MiddleName, U.LastName, L.Description, L.LogDate " +
                "FROM Logs L JOIN Users U WHERE L.UserID = U.UserID", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                var displayLogs = new DisplayLogs();

                displayLogs.LogID = Connection.reader.GetString(0);
                displayLogs.UserName = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                displayLogs.Description = Connection.reader.GetString(4);
                var dateTime = Connection.reader.GetDateTime(5);
                displayLogs.LogDate = dateTime.ToString();

                PageObjects.logsPage.getLogHolder.Controls.Add(displayLogs);
            }

            Connection.reader.Close();
            Connection.conn.Close();
        }
    }
}
