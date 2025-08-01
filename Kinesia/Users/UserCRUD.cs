using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public class UserCRUD
    {
        public void DisplayUsers(string searchData)
        {
            PageObjects.DisposeHolderControls(PageObjects.userPage.getUserHolder);
            Connection.conn.Open();

            string query = "SELECT UserID, FirstName, MiddleName, LastName, Role FROM Users";

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(searchData))
            {
                string searchCondition = @"(UserID LIKE CONCAT('%', @searchData, '%') 
                                        OR FirstName LIKE CONCAT('%', @searchData, '%') 
                                        OR MiddleName LIKE CONCAT('%', @searchData, '%') 
                                        OR LastName LIKE CONCAT('%', @searchData, '%'))";
                conditions.Add(searchCondition);
            }

            if(conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            Connection.cmd = new MySqlCommand(query, Connection.conn);

            if (!string.IsNullOrEmpty(searchData))
            {
                Connection.cmd.Parameters.AddWithValue("@searchData", searchData);
            }

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

        public void GetUserDetails(string userID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT UserID, FirstName, MiddleName, LastName, Gender, Contact, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()), Address, Birthdate, Role " +
                "FROM Users WHERE UserID = @userID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@userID", userID);
            Connection.reader = Connection.cmd.ExecuteReader();

            if (Connection.reader.Read())
            {
                PageObjects.userDetails = new UserDetails();

                PageObjects.userDetails.UserID = Connection.reader.GetString(0);
                PageObjects.userDetails.SelectedUser = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.userDetails.Name = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.userDetails.Gender = Connection.reader.GetString(4);
                PageObjects.userDetails.Contact = Connection.reader.GetString(5);
                PageObjects.userDetails.Age = (Connection.reader.GetInt64(6) / 12).ToString();
                PageObjects.userDetails.Address = Connection.reader.GetString(7);
                DateTime birthDate = Connection.reader.GetDateTime(8);
                PageObjects.userDetails.Birthdate = birthDate.ToString("yyyy-MM-dd");
                PageObjects.userDetails.Role = Connection.reader.GetString(9);

                // will only display User Details if fetched successfully by the system
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userDetails);
                PageObjects.CurrentControl = PageObjects.userPage;
            } else
            {
                MessageBox.Show("User details not found.", "User Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Connection.reader.Close();
            Connection.conn.Close();
        }
    }
}
