using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kinesia.Users
{
    public class UserCRUD
    {
        public void DisplayUsers()
        {
            PageObjects.userPage.getUserHolder.Controls.Clear();
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT UserID, FirstName, MiddleName, LastName, Role FROM Users", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while (Connection.reader.Read())
            {
                PageObjects.displayUsers = new DisplayUsers(); // will create user control for every users

                // will set the tag of every button to UserID
                PageObjects.displayUsers.BtnView.Tag = Connection.reader.GetString(0);
                PageObjects.displayUsers.BtnEdit.Tag = Connection.reader.GetString(0);
                PageObjects.displayUsers.BtnArchive.Tag = Connection.reader.GetString(0);

                // will set the data of every users to the labels
                PageObjects.displayUsers.UserID = Connection.reader.GetString(0);
                PageObjects.displayUsers.Name = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.displayUsers.Role = Connection.reader.GetString(4);

                PageObjects.userPage.getUserHolder.Controls.Add(PageObjects.displayUsers);
            }

            Connection.reader.Close();
            Connection.conn.Close();
        }
    }
}
