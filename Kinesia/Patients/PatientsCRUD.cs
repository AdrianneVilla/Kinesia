using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            PageObjects.patientsPage.getPatientHolder.Controls.Clear();

            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/patients?searchData={searchData}&currentTab={currentTab}&sortColumn={sortColumn}";

                var response = await client.GetStringAsync(url);
                var patients = JsonConvert.DeserializeObject<List<PatientsDTO>>(response);

                foreach(var patient in patients)
                {
                    // will set the data of every patient to the labels
                    var displayPatientControl = new DisplayPatients
                    {
                        PatientID = patient.PatientID,
                        PatientName = $"{patient.FirstName} {patient.MiddleName} {patient.LastName}",
                        Age = patient.Age.ToString(),
                        Gender = patient.Gender,
                        Contact = patient.Contact
                    };

                    // 1 = Active
                    // 2 = Inactive
                    if (patient.Status == 1)
                    {
                        displayPatientControl.Status = "Active";
                        displayPatientControl.BtnArchive.Tag = "Archive";
                    } 
                    else
                    {
                        displayPatientControl.Status = "Inactive";
                        displayPatientControl.BtnArchive.BackgroundImage = Properties.Resources.Unarchive;
                        displayPatientControl.BtnArchive.Tag = "Unarchive";
                    }

                    PageObjects.patientsPage.getPatientHolder.Controls.Add(displayPatientControl);
                }
            }
        }

        public async Task GetPatientDetails(string patientID)
        {
            // GetPatientDetails overload for Patient Details page
            using (var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/patients/{patientID}";

                var response = await client.GetStringAsync(url);
                var patient = JsonConvert.DeserializeObject<PatientsDTO>(response);

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
                if(patient.Status == 1)
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
        }
        
        public void GetPatientDetails(string patientID, PatientDataHolder patientData)
        {
            // GetPatientDetails overload for Edit Patient page
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT FirstName, LastName, MiddleName, BirthDate, TIMESTAMPDIFF(MONTH, BirthDate, CURDATE()) AS Age, Gender, Contact, Occupation, Address " +
                "FROM Patients WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientID);
            Connection.reader = Connection.cmd.ExecuteReader();

            if(Connection.reader.Read())
            {
                patientData.PatientID = patientID;
                patientData.FirstName = Connection.reader.GetString(0);
                patientData.LastName = Connection.reader.GetString(1);
                patientData.MiddleName = Connection.reader.GetString(2);
                DateTime birthDate = Connection.reader.GetDateTime(3);
                patientData.Birthdate = birthDate.ToString("yyyy-MM-dd");
                patientData.Age = Connection.reader.GetInt32(4) / 12;
                patientData.Gender = Connection.reader.GetString(5);
                patientData.Contact = Connection.reader.GetString(6);
                patientData.Occupation = Connection.reader.GetString(7);
                patientData.Address = Connection.reader.GetString(8);

                PageObjects.editPatient = new EditPatient();
                PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.editPatient);
                PageObjects.CurrentControl = PageObjects.editPatient;
            }

            Connection.reader.Close();
            Connection.conn.Close();
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
            using (var client = new HttpClient())
            {
                var newPatient = new PatientsDTO
                {
                    PatientID = patientData.PatientID,
                    FirstName = patientData.FirstName,
                    LastName = patientData.LastName,
                    MiddleName = patientData.MiddleName,
                    Contact = ContactFormater(patientData.Contact),
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

                return response.IsSuccessStatusCode;
            }
        }

        public void UpdatePatient(PatientDataHolder patientData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("UPDATE Patients SET FirstName = @firstName, LastName = @lastName, MiddleName = @middleName, Birthdate = @birthDate, " +
                "Gender = @gender, Contact = @contact, Occupation = @occupation, Address = @address WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientData.PatientID);
            Connection.cmd.Parameters.AddWithValue("@firstName", patientData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@lastName", patientData.LastName);
            Connection.cmd.Parameters.AddWithValue("@middleName", patientData.MiddleName);
            Connection.cmd.Parameters.AddWithValue("@birthDate", patientData.Birthdate);
            Connection.cmd.Parameters.AddWithValue("@gender", patientData.Gender);

            if (patientData.Contact[0] == '0')
            {
                patientData.Contact = patientData.Contact.Substring(1); // will remove the "0" in the contact
            }
            patientData.Contact = "+63" + patientData.Contact; // will insert '+63' at the start of contact

            Connection.cmd.Parameters.AddWithValue("@contact", patientData.Contact);
            Connection.cmd.Parameters.AddWithValue("@occupation", patientData.Occupation);
            Connection.cmd.Parameters.AddWithValue("@address", patientData.Address);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public void ArchivePatient(string patientID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("UPDATE Patients SET Status = 0, LastArchiveDate = @lastArchiveDate WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientID);
            Connection.cmd.Parameters.AddWithValue("@lastArchiveDate", DateTime.Now);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public void UnarchivePatient(string patientID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("UPDATE Patients SET Status = 1 WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientID);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public bool CheckExistingPatient(PatientDataHolder patientData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT FirstName, MiddleName, LastName FROM Patients WHERE FirstName = @firstName AND MiddleName = @middleName AND LastName = @lastName", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@firstName", patientData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@middleName", patientData.MiddleName);
            Connection.cmd.Parameters.AddWithValue("@lastName", patientData.LastName);
            Connection.reader = Connection.cmd.ExecuteReader();

            // will return true if the patient was already existing
            // will return false if the patient was not already existing
            if (Connection.reader.Read())
            {
                Connection.reader.Close();
                Connection.conn.Close();
                MessageBox.Show("Patient was already existing", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            Connection.reader.Close();
            Connection.conn.Close();
            return false;
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
            if(patientData.Age <= 0)
            {
                MessageBox.Show("Patient age was invalid!", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool IsContactValid(PatientDataHolder patientData)
        {
            if(patientData.Contact.Length > 11 || patientData.Contact.Length < 10)
            {
                // will show an error if the length of contact number is not 10 or 11 (PH contact number)
                MessageBox.Show("Invalid contact number! Contact number length should be 10 or 11", "Add Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (patientData.Contact.Substring(0,2) != "09" && patientData.Contact[0] != '9')
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
    }
}
