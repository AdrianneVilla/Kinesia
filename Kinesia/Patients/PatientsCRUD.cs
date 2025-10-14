using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinesiaLibrary.DTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Kinesia.Patients
{
    public class PatientsCRUD
    {
        public async Task DisplayPatients(string searchData, string currentTab, string sortColumn)
        {
            //PageObjects.patientsPage.getPatientHolder.Controls.Clear();

            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/patients?searchData={searchData}&currentTab={currentTab}&sortColumn={sortColumn}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // will continue if the status code is 200
                        var json = await response.Content.ReadAsStringAsync();
                        var patients = JsonConvert.DeserializeObject<List<DisplayPatientsDTO>>(json);
                        PageObjects.patientsPage.GetPatientGrid.DataSource = patients;
                        PageObjects.patientsPage.GetPatientGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        var dataGrid = PageObjects.patientsPage.GetPatientGrid;

                        CustomDataGrid.SetDoubleBuffering(dataGrid, true);
                        dataGrid.SuspendLayout();
                        dataGrid.AutoGenerateColumns = false;
                        dataGrid.Columns.Clear();

                        dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "PatienID",
                            DataPropertyName = "PatientID",
                            HeaderText = "Patient ID"
                        });
                        dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "PatienName",
                            DataPropertyName = "PatientName",
                            HeaderText = "Patient Name"
                        });

                        dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "Age",
                            DataPropertyName = "Age",
                            HeaderText = "Age"
                        });

                        dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "Contact",
                            DataPropertyName = "Contact",
                            HeaderText = "Contact"
                        });
                        dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "Status",
                            DataPropertyName = "Status",
                            HeaderText = "Status"

                        });
                        dataGrid.DataSource = patients;
                        dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Add button column if it doesn't exist
                        AddActionButtons();

                        // Add spacing on the datagridview for better visualization
                        CustomDataGrid.StyleDataGridWithSpacing(dataGrid);

                        dataGrid.ResumeLayout(true);
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                            "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        public async Task GetPatientDetails(string patientID)
        {
            // GetPatientDetails overload for Patient Details page
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/patients/{patientID}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var patient = JsonConvert.DeserializeObject<PatientsDTO>(json);

                        // will create PatientDetails user control
                        var patientDetails = new PatientDetails();

                        // will set the data of the patient to the labels
                        patientDetails.PatientID = patient.PatientID;
                        patientDetails.SelectedPatient = patient.PatientID;
                        patientDetails.PatientName = $"{patient.FirstName} {patient.MiddleName} {patient.LastName}";
                        patientDetails.Gender = patient.Gender;
                        patientDetails.Contact = patient.Contact;
                        patientDetails.Age = patient.Age.ToString();
                        patientDetails.Address = patient.Address;
                        patientDetails.Birthdate = patient.Birthdate.ToString("yyyy-MM-dd");

                        // 1 = Active
                        // 0 = Inactive
                        if (patient.Status == 1)
                        {
                            patientDetails.Status = "Active";
                            patientDetails.BtnArchive.Tag = "Archive";
                        }
                        else
                        {
                            patientDetails.Status = "Inactive";
                            patientDetails.BtnArchive.Tag = "Unarchive";
                            patientDetails.BtnArchive.Image = Properties.Resources.Unarchive;
                            patientDetails.BtnArchive.Text = "Unarchive Patient";
                            patientDetails.BtnArchive.ForeColor = Color.FromArgb(18, 90, 211);
                            patientDetails.BtnArchive.BackColor = Color.FromArgb(223, 236, 250);
                            patientDetails.BtnArchive.BorderColor = Color.FromArgb(18, 90, 211);
                        }

                        patientDetails.DateAdded = patient.DateAdded.ToString();
                        patientDetails.LastArchiveDate = patient.LastArchiveDate;

                        PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                        PageObjects.dashboard.ContentsPanel.Controls.Add(patientDetails);
                        PageObjects.CurrentControl = patientDetails;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                            "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        public async Task GetPatientDetails(string patientID, PatientDataHolder patientData)
        {
            // GetPatientDetails overload for Edit Patient page
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/patients/{patientID}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var patient = JsonConvert.DeserializeObject<PatientsDTO>(json);

                        patientData.PatientID = patient.PatientID;
                        patientData.FirstName = patient.FirstName;
                        patientData.LastName = patient.LastName;
                        patientData.MiddleName = patient.MiddleName;
                        patientData.Birthdate = patient.Birthdate.ToString("yyyy-MM-dd");
                        patientData.Age = patient.Age;
                        patientData.Gender = patient.Gender;
                        patientData.Contact = patient.Contact;
                        patientData.Occupation = patient.Occupation;
                        patientData.Address = patient.Address;

                        PageObjects.editPatient = new EditPatient();
                        PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                        PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.editPatient);
                        PageObjects.CurrentControl = PageObjects.editPatient;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                            "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        public void SetPatientID(PatientDataHolder patientData)
        {
            Connection.conn.Open();
            Connection.cmd = new MySqlCommand("SELECT COUNT(PatientID) FROM Patients", Connection.conn);
            patientData.PatientID = $"PATIENT{Convert.ToInt32(Connection.cmd.ExecuteScalar()) + 1}";
            Connection.conn.Close();
        }

        public async Task<bool> AddPatient(PatientDataHolder patientData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var newPatient = new PatientsDTO
                    {
                        PatientID = patientData.PatientID,
                        FirstName = patientData.FirstName,
                        LastName = patientData.LastName,
                        MiddleName = patientData.MiddleName,
                        Contact = ContactFormatter(patientData.Contact),
                        Birthdate = DateTime.Parse(patientData.Birthdate),
                        Gender = patientData.Gender,
                        Address = patientData.Address,
                        Occupation = patientData.Occupation,
                        DateAdded = DateTime.Now,
                        LastArchiveDate = null,
                        Status = 1
                    };

                    client.BaseAddress = new Uri("https://localhost:5001/api/");
                    var json = JsonConvert.SerializeObject(newPatient);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("patients", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API-side.
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                    "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }

        public async Task<bool> UpdatePatient(PatientDataHolder patientData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/patients/{patientData.PatientID}";

                    var updatedPatient = new UpdatedPatientDTO();

                    updatedPatient.PatientID = patientData.PatientID;
                    updatedPatient.FirstName = patientData.FirstName;
                    updatedPatient.LastName = patientData.LastName;
                    updatedPatient.MiddleName = patientData.MiddleName;
                    updatedPatient.Birthdate = DateTime.Parse(patientData.Birthdate);
                    updatedPatient.Gender = patientData.Gender;
                    updatedPatient.Contact = ContactFormatter(patientData.Contact);
                    updatedPatient.Occupation = patientData.Occupation;
                    updatedPatient.Address = patientData.Address;

                    var json = JsonConvert.SerializeObject(updatedPatient);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API-side.
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                    "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }

        public async Task<bool> UpdatePatientStatus(string patientID, int status)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:5001/api/patients/{patientID}/status";

                    var updatedPatient = new PatientUpdateStatusDTO();

                    updatedPatient.PatientID = patientID;
                    updatedPatient.Status = status;

                    var json = JsonConvert.SerializeObject(updatedPatient);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // will show an error dialog if it returns a badrequest from API-side.
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                    "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch(Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }

        public async Task<bool> CheckExistingPatient(PatientDataHolder patientData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5001/");

                    var existingPatient = new CheckExistingPatientDTO();

                    existingPatient.FirstName = patientData.FirstName;
                    existingPatient.LastName = patientData.LastName;
                    existingPatient.MiddleName = patientData.MiddleName;

                    var response = await client.PostAsJsonAsync("api/patients/check-existing", existingPatient);

                    if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        // will return true if patient exists
                        MessageBox.Show("Patient was already existing", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else if (response.IsSuccessStatusCode)
                    {
                        // will return false if patient does not exists
                        return false;
                    }
                    else
                    {
                        // will handle unexpected errors
                        // will show an error dialog if it returns a badrequest from API-side.
                        CustomDialog.Show(await response.Content.ReadAsStringAsync(),
                                    "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                        return true;
                    }
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side.
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                            "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                return false;
            }
        }

        public bool IsPatientDetailsComplete(PatientDataHolder patientData)
        {
            // will return true if the patient details on Add Patient page was complete
            // will return false if the patient details on Add Patient page was incomplete
            if (patientData.FirstName.Equals("") || patientData.LastName.Equals("") || patientData.Gender.Equals("") || patientData.Contact.Equals("") ||
                patientData.Occupation.Equals("") || patientData.Address.Equals(""))
            {
                MessageBox.Show("Patient details was incomplete!", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool IsAgeValid(PatientDataHolder patientData)
        {
            if (patientData.Age <= 0)
            {
                MessageBox.Show("Patient age was invalid!", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool IsContactValid(PatientDataHolder patientData)
        {
            if (patientData.Contact.Length > 11 || patientData.Contact.Length < 10)
            {
                // will show an error if the length of contact number is not 10 or 11 (PH contact number)
                MessageBox.Show("Invalid contact number! Contact number length should be 10 or 11", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (patientData.Contact.Substring(0, 2) != "09" && patientData.Contact[0] != '9')
            {
                // will show an error if the contact number does not start on 09 or 9 (PH contact number)
                MessageBox.Show("Invalid contact number! Contact number should start with 09 or 9", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        // MORE ON DESIGN AND MANIPULATION OF DATA GRID VIEW //

    
        private void AddActionButtons()
        {
            var dataGrid = PageObjects.patientsPage.GetPatientGrid;
            dataGrid.SuspendLayout();

            if (dataGrid.Columns["ViewButton"] == null)
            {
                // Create View Details button column
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.Name = "ViewButton";
                viewBtn.HeaderText = "EMR";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Width = 80;
                viewBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Add the button column
                dataGrid.Columns.Add(viewBtn);
            }

            // Add Edit button
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
                archiveBtn.HeaderText = "Archive/Unarchive";
                archiveBtn.UseColumnTextForButtonValue = true;
                archiveBtn.Width = 190;
                archiveBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGrid.Columns.Add(archiveBtn);
            }
            dataGrid.ResumeLayout();

            // wire up events
            dataGrid.CellPainting -= DataGrid_CellPainting;
            dataGrid.CellPainting += DataGrid_CellPainting;

            // hover events
            dataGrid.CellMouseEnter -= DataGrid_CellMouseEnter;
            dataGrid.CellMouseEnter += DataGrid_CellMouseEnter;

            dataGrid.CellMouseLeave -= DataGrid_CellMouseLeave;
            dataGrid.CellMouseLeave += DataGrid_CellMouseLeave;
        }

        Point hoveredCell = new Point(-1, -1);
        private void DataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dataGrid = PageObjects.patientsPage.GetPatientGrid;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                if (columnName == "ViewButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    bool isHovered = (hoveredCell.X == e.ColumnIndex && hoveredCell.Y == e.RowIndex);
                    Color backgroundColor = isHovered ? Color.FromArgb(220,220,220) : Color.White;

                        // Normal background
                        e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.CellBounds);
                    

                    Image icon = null;
                    if (columnName == "ViewButton")
                        icon = Properties.Resources.newEMR;
                    else if (columnName == "EditButton")
                        icon = Properties.Resources.newEdit;
                    else if (columnName == "ArchiveButton")
                    {
                        var statusCell = dataGrid.Rows[e.RowIndex].Cells["Status"]?.Value;
                        string status = statusCell.ToString() ?? "";

                        // from archive to unarchive button

                        if(status == "Active" || status== "1")
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

        private void DataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGrid = PageObjects.patientsPage.GetPatientGrid;
                string columnName = dataGrid.Columns[e.ColumnIndex].Name;

                // Only apply hover effect to button columns
                if (columnName == "ViewButton" || columnName == "EditButton" || columnName == "ArchiveButton")
                {
                    hoveredCell = new Point(e.ColumnIndex, e.RowIndex);
                    dataGrid.InvalidateCell(e.ColumnIndex, e.RowIndex); // Trigger repaint
                }
            }
        }

        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGrid = PageObjects.patientsPage.GetPatientGrid;
                hoveredCell = new Point(-1, -1);
                dataGrid.InvalidateCell(e.ColumnIndex, e.RowIndex); // Trigger repaint
            }
        }
    }
}
