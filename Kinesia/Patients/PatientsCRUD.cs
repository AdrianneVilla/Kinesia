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
        
        public async Task GetPatientDetails(string patientID, PatientDataHolder patientData)
        {
            // GetPatientDetails overload for Edit Patient page
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/patients/{patientID}";

                var response = await client.GetStringAsync(url);
                var patient = JsonConvert.DeserializeObject<PatientsDTO>(response);

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

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdatePatient(PatientDataHolder patientData)
        {
            using(var client = new HttpClient())
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

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdatePatientStatus(string patientID, int status)
        {
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/patients/{patientID}/status";

                var updatedPatient = new PatientUpdateStatusDTO();

                updatedPatient.PatientID = patientID;
                updatedPatient.Status = status;

                var json = JsonConvert.SerializeObject(updatedPatient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
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
