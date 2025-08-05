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
        public void DisplayUsers(string searchData, string currentTab, string sortColumn)
        {
            PageObjects.DisposeHolderControls(PageObjects.userPage.getUserHolder);
            Connection.conn.Open();

            string query = "SELECT UserID, FirstName, MiddleName, LastName, Role FROM Users";

            // Collection of all conditions for the query
            List<string> conditions = new List<string>();

            // 1 = Active Patients
            // 2 = Inactive Patients
            // Else = All Patients
            if (currentTab == "Active")
            {
                conditions.Add("Status = 1");
            }
            else if (currentTab == "Inactive")
            {
                conditions.Add("Status = 0");
            }

            if (!string.IsNullOrEmpty(searchData))
            {
                string searchCondition = @"(UserID LIKE CONCAT('%', @searchData, '%') 
                                        OR FirstName LIKE CONCAT('%', @searchData, '%') 
                                        OR MiddleName LIKE CONCAT('%', @searchData, '%') 
                                        OR LastName LIKE CONCAT('%', @searchData, '%'))";
                conditions.Add(searchCondition);
            }

            // will set the sort order based on sortColumn
            string sortCondition = "DESC";

            if (sortColumn == "Default")
            {
                sortColumn = "UserID";
            }
            else if (sortColumn == "Alphabetical (Name)")
            {
                sortColumn = "FirstName";
            }
            else if (sortColumn == "Earliest (Date Added)")
            {
                sortColumn = "DateAdded";
            }
            else if (sortColumn == "Latest (Date Added)")
            {
                sortColumn = "DateAdded";
                sortCondition = "ASC";
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            query += $" ORDER BY {sortColumn} {sortCondition}";

            Connection.cmd = new MySqlCommand(query, Connection.conn);

            if (!string.IsNullOrEmpty(searchData))
            {
                Connection.cmd.Parameters.AddWithValue("@searchData", searchData);
            }

            Connection.reader = Connection.cmd.ExecuteReader();

            while (Connection.reader.Read())
            {
                var displayUserControl = new DisplayUsers(); // will create user control for every users

                if(currentTab == "Inactive")
                {
                    displayUserControl.BtnArchive.Image = Properties.Resources.Unarchive;
                    displayUserControl.BtnArchive.Tag = "Unarchive";
                } 
                else
                {
                    displayUserControl.BtnArchive.Tag = "Archive";
                }

                // will set the data of every users to the labels
                displayUserControl.UserID = Connection.reader.GetString(0);
                displayUserControl.Name = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                displayUserControl.Role = Connection.reader.GetString(4);

                PageObjects.userPage.getUserHolder.Controls.Add(displayUserControl);
            }

            Connection.reader.Close();
            Connection.conn.Close();
        }

        public void GetUserDetails(string userID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT UserID, FirstName, MiddleName, LastName, Gender, Contact, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()), Address, Birthdate, Role, " +
                "Email, DateAdded, LastArchiveDate FROM Users WHERE UserID = @userID", Connection.conn);
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
                PageObjects.userDetails.Email = Connection.reader.GetString(10);

                DateTime dateAdded = Connection.reader.GetDateTime(11);
                PageObjects.userDetails.DateAdded = dateAdded.ToString();

                if (Connection.reader.IsDBNull(12))
                {
                    PageObjects.userDetails.LastArchiveDate = null;
                } 
                else
                {
                    DateTime lastArchiveDate = Connection.reader.GetDateTime(12);
                    PageObjects.userDetails.LastArchiveDate = lastArchiveDate.ToString();
                }

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

        public void ArchiveUser(string userID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("UPDATE Users SET Status = 0 WHERE UserID = @userID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@userID", userID);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public void UnarchiveUser(string userID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("UPDATE Users SET Status = 1 WHERE UserID = @userID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@userID", userID);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }
    }
}
