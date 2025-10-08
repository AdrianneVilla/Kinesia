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
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Users
{
    public class UserCRUD
    {
        public async Task DisplayUsers(string searchData, string currentTab, string sortColumn)
        {
            //PageObjects.userPage.getUserHolder.Controls.Clear();

            using (var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users?searchData={searchData}&currentTab={currentTab}&sortColumn={sortColumn}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<UsersDTO>>(json);
                    PageObjects.userPage.GetUserGrid.DataSource = users;
                    PageObjects.userPage.GetUserGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    var dataGrid = PageObjects.userPage.dataGridUsers;
                    dataGrid.DataSource = users;
                    dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Add button column if it doesn't exist
                    AddActionButtons();

                    // Add spacing on the datagridview for better visualization
                    StyleDataGridWithSpacing(dataGrid);


           
                }


                //foreach(var user in users)
                //{
                //    // will create user control for every users
                //    var displayUserControl = new DisplayUsers();

                //    // will set the data of user to label
                //    displayUserControl.UserID = user.UserID;
                //    displayUserControl.Name = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                //    displayUserControl.Role = user.Role;

                //    // 0 = Inactive
                //    // 1 = Active
                //    if (user.Status == 0)
                //    {
                //        displayUserControl.BtnArchive.Image = Properties.Resources.Unarchive;
                //        displayUserControl.BtnArchive.Tag = "Unarchive";
                //    }
                //    else
                //    {
                //        displayUserControl.BtnArchive.Tag = "Archive";
                //    }

                //    // will add the user control to UserHolder
                //    //PageObjects.userPage.getUserHolder.Controls.Add(displayUserControl);
                //}
            }
        }

        public async Task GetUserDetails(string userID)
        {
            // GetUserDetails overload for User Details page

            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/users/{userID}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<UsersDTO>(json);


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


            }
            catch (Exception ex)
            {
                // will show an error dialog if it catches a client-side error.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        public async Task GetUserDetails(string userID, UserDataHolder userData)
        {
            // GetUserDetails overload for Edit User page
            using (var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/users/{userID}";

                var response = await client.GetStringAsync(url);
                var user = JsonConvert.DeserializeObject<UsersDTO>(response);

                userData.UserID = user.UserID;
                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                userData.MiddleName = user.MiddleName;
                userData.BirthDate = user.Birthdate.ToString("yyyy-MM-dd");
                userData.Age = user.Age;
                userData.Gender = user.Gender;
                userData.Contact = user.Contact;
                userData.Email = user.Email;
                userData.Address = user.Address;

                PageObjects.editUser = new EditUser();
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.editUser);
                PageObjects.CurrentControl = PageObjects.editUser;
            }
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
            using (var client = new HttpClient())
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

        public async Task<bool> UpdateUser(UserDataHolder userData)
        {
            using (var client = new HttpClient())
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
            using (var client = new HttpClient())
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

        public async Task<bool> CheckExistingUser(UserDataHolder userData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                var existingUser = new CheckExistingUserDTO();

                existingUser.FirstName = userData.FirstName;
                existingUser.LastName = userData.LastName;
                existingUser.MiddleName = userData.MiddleName;

                var response = await client.PostAsJsonAsync("api/users/check-existing", existingUser);

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    // will return true if user already exist
                    CustomDialog.Show("User was already existing!", "Existing User", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    return true;
                }
                else if (response.IsSuccessStatusCode)
                {
                    // will return false if user do not exist
                    return false;
                }
                else
                {
                    // will handle unexpected errors
                    string error = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
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
            if (!userData.Email.Contains(".") || !userData.Email.Contains("@"))
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


        private void AddActionButtons()
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            dataGrid.CellMouseEnter -= DataGrid_CellMouseEnter;
            dataGrid.CellMouseLeave -= DataGrid_CellMouseLeave;
            dataGrid.CellMouseMove -= DataGrid_CellMouseMove;
            dataGrid.ColumnHeaderMouseClick -= DataGrid_ColumnHeaderMouseClick;
            dataGrid.CellPainting -= DataGrid_CellPainting;



            dataGrid.CellMouseEnter += DataGrid_CellMouseEnter;
            dataGrid.CellMouseLeave += DataGrid_CellMouseLeave;
            dataGrid.CellMouseMove += DataGrid_CellMouseMove;
            dataGrid.ColumnHeaderMouseClick += DataGrid_ColumnHeaderMouseClick;
            dataGrid.CellPainting += DataGrid_CellPainting;



            if (dataGrid.Columns["Select"] == null)
            {
                DataGridViewButtonColumn selectBtn = new DataGridViewButtonColumn();
                selectBtn.Name = "SelectButton";
                selectBtn.HeaderText = "Select";
                selectBtn.UseColumnTextForButtonValue = true;
                selectBtn.Width = 80;
                selectBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dataGrid.Columns.Add(selectBtn);
            }

            if (dataGrid.Columns["EditButton"] == null)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "EditButton";
                editBtn.HeaderText = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Width = 80;
                editBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(editBtn);
            }

            // Add Archive/Unarchive button
            if (dataGrid.Columns["ArchiveButton"] == null)
            {
                DataGridViewButtonColumn archiveBtn = new DataGridViewButtonColumn();
                archiveBtn.Name = "ArchiveButton";
                archiveBtn.HeaderText = "Status";
                archiveBtn.UseColumnTextForButtonValue = true;
                archiveBtn.Width = 90;
                archiveBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(archiveBtn);
            }
            dataGrid.CellPainting -= DataGrid_CellPainting;
            dataGrid.CellPainting += DataGrid_CellPainting;
        }

        private Point hoveredCell = new Point(-1, -1);
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "SelectButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    Point newHoveredCell = new Point(e.ColumnIndex, e.RowIndex);

                    // Only update if hovering over a different cell
                    if (hoveredCell != newHoveredCell)
                    {
                        hoveredCell = newHoveredCell;
                        dataGrid.Cursor = Cursors.Hand;

                        // Invalidate the entire grid for reliable repaint
                        dataGrid.Invalidate();
                    }
                }

                else
                {
                    // not hoverring over a button column

                    if (hoveredCell.X != -1)
                    {
                        hoveredCell = new Point(-1, -1);
                        dataGrid.Cursor = Cursors.Default;
                        dataGrid.Invalidate();
                    }
                }
            }
        }

        private void DataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "SelectButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    hoveredCell = new Point(e.ColumnIndex, e.RowIndex);
                    dataGrid.Cursor = Cursors.Hand;

                    // Use Invalidate() instead of InvalidateCell()
                    dataGrid.Invalidate();
                }
            }

        }

        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "SelectButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    dataGrid.Cursor = Cursors.Default;
                    hoveredCell = new Point(-1, -1);

                    // Use Invalidate() instead of InvalidateCell()
                    dataGrid.Invalidate();
                }
            }
        }

        private async void DataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            // Get the clicked column
            if (e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                // Don't sort on button columns
                if (columnName == "Select" || columnName == "EditButton" || columnName == "ArchiveButton")
                    return;

                // Get current sort order
                string sortColumn = columnName;

                // Toggle sort direction
                if (dataGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {
                    sortColumn += " DESC";
                    dataGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
                else
                {
                    sortColumn += " ASC";
                    dataGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }


            }
        }

        private void DataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dataGrid = PageObjects.userPage.GetUserGrid;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "Select" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    bool isHovered = (hoveredCell.X == e.ColumnIndex && hoveredCell.Y == e.RowIndex);

                    if (isHovered)
                    {
                        // hovered background
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(248, 245, 250)), e.CellBounds);
                    }

                    else
                    {
                        // Normal background
                        e.Graphics.FillRectangle(new SolidBrush(dataGrid.DefaultCellStyle.BackColor), e.CellBounds);
                    }

                    Image icon = null;
                    if (columnName == "SelectButton")
                        icon = Properties.Resources.newSelect;
                    else if (columnName == "EditButton")
                        icon = Properties.Resources.newEdit;
                    else if (columnName == "ArchiveButton")
                    {
                        var statusCell = dataGrid.Rows[e.RowIndex].Cells["Status"]?.Value;
                        string status = statusCell.ToString() ?? "";

                        // from archive to unarchive button

                        if (status == "Active" || status == "1")
                        {
                            icon = Properties.Resources.newArchive;
                        }
                        else
                        {
                            icon = Properties.Resources.Unarchive;
                        }
                    }



                    if (icon != null)
                    {
                        int iconWidth = 20;
                        int iconHeight = 20;
                        int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                        // Draw the icon
                        e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    }
                    e.Handled = true;
                }
            }

        }

        private void StyleDataGridWithSpacing(DataGridView dataGrid)
        {
            //cell styling with padding

            dataGrid.DefaultCellStyle.Padding = new Padding(15, 10, 15, 10);

            // row height

            dataGrid.RowTemplate.Height = 50;

            dataGrid.BorderStyle = BorderStyle.None;
        }

    }
}
