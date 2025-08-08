using Kinesia.Patients;
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

            string query = "SELECT UserID, FirstName, MiddleName, LastName, Role, Status FROM Users";

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


                // will set the data of every users to the labels
                displayUserControl.UserID = Connection.reader.GetString(0);
                displayUserControl.Name = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                displayUserControl.Role = Connection.reader.GetString(4);

                if (Connection.reader.GetInt64(5) == 0)
                {
                    displayUserControl.BtnArchive.Image = Properties.Resources.Unarchive;
                    displayUserControl.BtnArchive.Tag = "Unarchive";
                } 
                else
                {
                    displayUserControl.BtnArchive.Tag = "Archive";
                }

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

        public void SetUserID(UserDataHolder userData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT COUNT(UserID) FROM Users", Connection.conn);
            userData.UserID = $"USER{Convert.ToInt32(Connection.cmd.ExecuteScalar()) + 1}";

            Connection.conn.Close();
        }

        public void AddUser(UserDataHolder userData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("INSERT INTO Users VALUES (@userID, @firstName, @lastName, @middleName, @birthDate, @gender, " +
                "@contact, @address, @role, @username, @password, @email, @dateAdded, @lastArchiveDate, @status)", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@userID", userData.UserID);
            Connection.cmd.Parameters.AddWithValue("@firstName", userData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@lastName", userData.LastName);
            Connection.cmd.Parameters.AddWithValue("@middleName", userData.MiddleName);
            Connection.cmd.Parameters.AddWithValue("@birthDate", userData.BirthDate);
            Connection.cmd.Parameters.AddWithValue("@gender", userData.Gender);

            if (userData.Contact[0] == '0')
            {
                userData.Contact = userData.Contact.Substring(1); // will remove the "0" in the contact
            }
            userData.Contact = "+63" + userData.Contact; // will insert '+63' at the start of contact

            Connection.cmd.Parameters.AddWithValue("@contact", userData.Contact);
            Connection.cmd.Parameters.AddWithValue("@address", userData.Address);
            Connection.cmd.Parameters.AddWithValue("@role", userData.Role);
            Connection.cmd.Parameters.AddWithValue("@username", userData.UserName);
            Connection.cmd.Parameters.AddWithValue("@password", userData.Password);
            Connection.cmd.Parameters.AddWithValue("@email", userData.Email);
            Connection.cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
            Connection.cmd.Parameters.AddWithValue("@lastArchiveDate", null);
            Connection.cmd.Parameters.AddWithValue("@status", 1);
            Connection.cmd.ExecuteNonQuery();

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

        public bool CheckExistingUser(UserDataHolder userData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT FirstName, LastName, MiddleName FROM Users WHERE FirstName = @firstName AND LastName = @lastName AND " +
                "MiddleName = @middleName", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@firstName", userData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@lastName", userData.LastName);
            Connection.cmd.Parameters.AddWithValue("@middleName", userData.MiddleName);
            Connection.reader = Connection.cmd.ExecuteReader();

            // will return true if the user was already existing
            // will return false if the user was not already existing
            if (Connection.reader.Read())
            {
                CustomDialog.Show("User was already existing!", "Existing User", CustomDialogButtons.OK, CustomDialogIcons.Error);
                Connection.reader.Close();
                Connection.conn.Close();
                return true;
            }

            Connection.reader.Close();
            Connection.conn.Close();
            return false;
        }

        public bool IsUserDetailsComplete(UserDataHolder userData)
        {
            // will return true if the user details on Add User page was complete
            // will return false if the user details on Add User page was incomplete
            if (userData.FirstName.Equals("") || userData.LastName.Equals("") ||
                userData.Gender.Equals("") || userData.Contact.Equals("") || userData.Email.Equals("") || userData.Address.Equals("") ||
                userData.UserName.Equals("") || userData.Password.Equals("") || userData.Role.Equals(""))
            {
                CustomDialog.Show("User details was incomplete! \nPlease fill-out all details to add this user.", "Incomplete User Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            return true;
        }

        public bool IsContactValid(UserDataHolder userData)
        {
            if (userData.Contact.Length > 11 || userData.Contact.Length < 10)
            {
                // will show an error if the length of contact number is not 10 or 11 (PH contact number)
                CustomDialog.Show("Invalid contact number! \nContact number length should be 10 or 11", 
                    "Invalid Contact Number", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            if (userData.Contact.Substring(0, 2) != "09" && userData.Contact[0] != '9')
            {
                // will show an error if the contact number does not start on 09 or 9 (PH contact number)
                CustomDialog.Show("Invalid contact number! Contact number should start with 09 or 9",
                    "Invalid Contact Number", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }

            return true;
        }

        public bool IsEmailValid(UserDataHolder userData)
        {
            // will return false if the email address does not contains '.' and '@'
            if(!userData.Email.Contains(".") || !userData.Email.Contains("@"))
            {
                CustomDialog.Show("Invalid email address! \nPlease enter a valid email address",
                    "Invalid Email Address", CustomDialogButtons.OK, CustomDialogIcons.Error);

                return false;
            }

            return true;
        }

        public DateTime GetLegalDate()
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT DATE_ADD(CURDATE(), INTERVAL -18 YEAR)", Connection.conn);
            var legalDate = Convert.ToDateTime(Connection.cmd.ExecuteScalar());

            Connection.conn.Close();
            return legalDate;
        }
    }
}
