using Kinesia.Patients;
using KinesiaLibrary.DTOs;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public class UserCRUD
    {
        public async Task DisplayUsers(string searchData, string currentTab, string sortColumn)
        {
            PageObjects.userPage.getUserHolder.Controls.Clear();

            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users?searchData={searchData}&currentTab={currentTab}&sortColumn={sortColumn}";

                var response = await client.GetStringAsync(url);
                var users = JsonConvert.DeserializeObject<List<UsersDTO>>(response);

                foreach(var user in users)
                {
                    // will create user control for every users
                    var displayUserControl = new DisplayUsers();

                    // will set the data of user to label
                    displayUserControl.UserID = user.UserID;
                    displayUserControl.Name = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                    displayUserControl.Role = user.Role;

                    // 0 = Inactive
                    // 1 = Active
                    if (user.Status == 0)
                    {
                        displayUserControl.BtnArchive.Image = Properties.Resources.Unarchive;
                        displayUserControl.BtnArchive.Tag = "Unarchive";
                    }
                    else
                    {
                        displayUserControl.BtnArchive.Tag = "Archive";
                    }

                    // will add the user control to UserHolder
                    PageObjects.userPage.getUserHolder.Controls.Add(displayUserControl);
                }
            }
        }

        public async Task GetUserDetails(string userID)
        {
            // GetUserDetails overload for User Details page
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users/{userID}";

                var response = await client.GetStringAsync(url);
                var user = JsonConvert.DeserializeObject<UsersDTO>(response);

                // will create user control for user details
                var userDetails = new UserDetails();

                // will set the data of the user to the labels
                userDetails.UserID = user.UserID;
                userDetails.SelectedUser = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                userDetails.Name = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                userDetails.Gender = user.Gender;
                userDetails.Contact = user.Contact;
                userDetails.Age = user.Age.ToString();
                userDetails.Address = user.Address;
                userDetails.Birthdate = user.Birthdate.ToString("yyyy-MM-dd");
                userDetails.Role = user.Role;
                userDetails.Email = user.Email;
                userDetails.DateAdded = user.DateAdded.ToString();
                userDetails.LastArchiveDate = user.LastArchiveDate;

                // 1 = Active
                // 0 = Inactive
                if (user.Status == 1)
                {
                    userDetails.Status = "Active";
                    userDetails.BtnArchive.Tag = "Archive";
                }
                else
                {
                    userDetails.Status = "Inactive";
                    userDetails.BtnArchive.Tag = "Unarchive";
                    userDetails.BtnArchive.Text = "Unarchive User";
                    userDetails.BtnArchive.Image = Properties.Resources.Unarchive;
                    userDetails.BtnArchive.ForeColor = Color.FromArgb(18, 90, 211);
                    userDetails.BtnArchive.BackColor = Color.FromArgb(223, 236, 250);
                    userDetails.BtnArchive.BorderColor = Color.FromArgb(18, 90, 211);
                }

                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(userDetails);
                PageObjects.CurrentControl = userDetails;
            }
        }

        public void GetUserDetails(string userID, UserDataHolder userData)
        {
            // GetUserDetails overload for Edit User page
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT UserID, FirstName, LastName, MiddleName, Birthdate, TIMESTAMPDIFF(Month, Birthdate, CURDATE()) AS Age, " +
                "Gender, Contact, Email, Address, Username, Password, Role FROM Users WHERE UserID = @userID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@userID", userID);
            Connection.reader = Connection.cmd.ExecuteReader();

            if (Connection.reader.Read())
            {
                userData.UserID = Connection.reader.GetString(0);
                userData.FirstName = Connection.reader.GetString(1);
                userData.LastName = Connection.reader.GetString(2);
                userData.MiddleName = Connection.reader.GetString(3);
                DateTime birthDate = Connection.reader.GetDateTime(4);
                userData.BirthDate = birthDate.ToString("yyyy-MM-dd");
                userData.Age = Connection.reader.GetInt32(5);
                userData.Gender = Connection.reader.GetString(6);
                userData.Contact = Connection.reader.GetString(7);
                userData.Email = Connection.reader.GetString(8);
                userData.Address = Connection.reader.GetString(9);
                userData.UserName = Connection.reader.GetString(10);
                userData.Password = Connection.reader.GetString(11);
                userData.Role = Connection.reader.GetString(12);

                PageObjects.editUser = new EditUser();
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.editUser);
                PageObjects.CurrentControl = PageObjects.editUser;
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

        public async Task<bool> AddUser(UserDataHolder userData)
        {
            using(var client = new HttpClient())
            {
                // will generate salt for hashing
                // salt will be unique for every user
                var salt = CustomSecurity.GenerateSalt();

                var newUser = new AddUserDTO
                {
                    UserID = userData.UserID,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    MiddleName = userData.MiddleName,
                    Birthdate = DateTime.Parse(userData.BirthDate),
                    Gender = userData.Gender,
                    Contact = ContactFormatter(userData.Contact),
                    Address = userData.Address,
                    Role = userData.Role,
                    Username = userData.UserName,
                    Password = CustomSecurity.HashPassword(userData.Password, salt),
                    Salt = salt,
                    Email = userData.Email,
                    DateAdded = DateTime.Now,
                    LastArchiveDate = null,
                    Status = 1
                };

                client.BaseAddress = new Uri("https://localhost:5001/api/");

                var json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("users", content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task <bool> UpdateUser(UserDataHolder userData)
        {
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users/{userData.UserID}";

                var updatedUser = new UpdateUserDTO();

                updatedUser.UserID = userData.UserID;
                updatedUser.FirstName = userData.FirstName;
                updatedUser.LastName = userData.LastName;
                updatedUser.MiddleName = userData.MiddleName;
                updatedUser.Birthdate = DateTime.Parse(userData.BirthDate);
                updatedUser.Gender = userData.Gender;
                updatedUser.Contact = ContactFormatter(userData.Contact);
                updatedUser.Email = userData.Email;
                updatedUser.Address = userData.Address;

                var json = JsonConvert.SerializeObject(updatedUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateUserStatus(string userID, int status)
        {
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users/{userID}/status";

                var updatedUser = new UserUpdateStatusDTO();

                updatedUser.UserID = userID;
                updatedUser.LastArchiveDate = DateTime.Now;
                updatedUser.Status = status;

                var json = JsonConvert.SerializeObject(updatedUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
        }
        //public void ArchiveUser(string userID)
        //{
        //    Connection.conn.Open();

        //    Connection.cmd = new MySqlCommand("UPDATE Users SET Status = 0, LastArchiveDate = @lastArchiveDate WHERE UserID = @userID", Connection.conn);
        //    Connection.cmd.Parameters.AddWithValue("@userID", userID);
        //    Connection.cmd.Parameters.AddWithValue("@lastArchiveDate", DateTime.Now);
        //    Connection.cmd.ExecuteNonQuery();

        //    Connection.conn.Close();
        //}

        //public void UnarchiveUser(string userID)
        //{
        //    Connection.conn.Open();

        //    Connection.cmd = new MySqlCommand("UPDATE Users SET Status = 1 WHERE UserID = @userID", Connection.conn);
        //    Connection.cmd.Parameters.AddWithValue("@userID", userID);
        //    Connection.cmd.ExecuteNonQuery();

        //    Connection.conn.Close();
        //}

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

        public string ContactFormatter(string contact)
        {
            if (contact[0] == '0')
            {
                contact = contact.Substring(1); // will remove the "0" in the contact
            }

            contact = "+63" + contact; // will insert '+63' at the start of contact

            return contact;
        }
    }
}
