using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kinesia.Patients
{
    public class PatientsCRUD
    {
        public void DisplayPatients(string searchData, string currentTab, string sortColumn)
        {
            PageObjects.patientsPage.getPatientHolder.Controls.Clear();
            Connection.conn.Open();

            string query = "SELECT PatientID, FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Gender, Contact, Status " +
                "FROM Patients";
            
            // collections of all conditions for the query
            List<string> conditions = new List<string>();

            // 1 = Active Patients
            // 2 = Inactive Patients
            // Else = All Patients
            if(currentTab == "Active")
            {
                conditions.Add("Status = 1");
            } 
            else if(currentTab == "Inactive")
            {
                conditions.Add("Status = 0");
            }

            // will only add this condition to the query if searchData is not empty
            if(!string.IsNullOrEmpty(searchData))
            {
                string searchCondition = @"(PatientID LIKE CONCAT('%', @searchData, '%') 
                                        OR FirstName LIKE CONCAT('%', @searchData, '%') 
                                        OR MiddleName LIKE CONCAT('%', @searchData, '%') 
                                        OR LastName LIKE CONCAT('%', @searchData, '%'))";
                conditions.Add(searchCondition);
            }

            // will add all conditions to the query (if there's any condition added)
            if(conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            // will set the sort order based on sortColumn
            string sortCondition = "DESC";

            if(sortColumn == "Default")
            {
                sortColumn = "PatientID";
            } 
            else if(sortColumn == "Alphabetical (Name)")
            {
                sortColumn = "FirstName";
            } 
            else if(sortColumn == "Earliest (Date Added)")
            {
                sortColumn = "DateAdded";
            } 
            else if(sortColumn == "Latest (Date Added)")
            {
                sortColumn = "DateAdded";
                sortCondition = "ASC";
            }

            query += $" ORDER BY {sortColumn} {sortCondition}";

            Connection.cmd = new MySqlCommand(query, Connection.conn);

            // will only add parameter if searchData is not empty
            if(!string.IsNullOrEmpty(searchData))
            {
                Connection.cmd.Parameters.AddWithValue("@searchData", searchData);
            }
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                var displayPatientControl = new DisplayPatients(); // will create user control for every patients

                // will set the data of every patient to the labels
                displayPatientControl.PatientID = Connection.reader.GetString(0);
                displayPatientControl.PatientName = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                displayPatientControl.Age = (Connection.reader.GetInt64(4) / 12).ToString();
                displayPatientControl.Gender = Connection.reader.GetString(5);
                displayPatientControl.Contact = Connection.reader.GetString(6);

                // 1 = Active
                // 2 = Inactive
                if(Connection.reader.GetInt64(7) == 1)
                {
                    displayPatientControl.Status = "Active";
                    displayPatientControl.BtnArchive.Tag = "Archive";

                } else
                {
                    displayPatientControl.Status = "Inactive";
                    displayPatientControl.BtnArchive.BackgroundImage = Properties.Resources.Unarchive;
                    displayPatientControl.BtnArchive.Tag = "Unarchive";
                }

                PageObjects.patientsPage.getPatientHolder.Controls.Add(displayPatientControl);
            }
            Connection.reader.Close();
            Connection.conn.Close();
        }

        public void GetPatientDetails(string patientID)
        {
            // GetPatientDetails overload for Patient Details page
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, Gender, Contact, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS Age, Address, Birthdate, " +
                "Status, DateAdded, LastArchiveDate FROM Patients WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientID);
            Connection.reader = Connection.cmd.ExecuteReader();

            if(Connection.reader.Read())
            {
                PageObjects.patientDetails = new PatientDetails(); // will create PatientDetails user control

                // will set the data of the patient to the labels
                PageObjects.patientDetails.PatientID = Connection.reader.GetString(0);
                PageObjects.patientDetails.SelectedPatient = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.patientDetails.PatientName = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.patientDetails.Gender = Connection.reader.GetString(4);
                PageObjects.patientDetails.Contact = Connection.reader.GetString(5);
                PageObjects.patientDetails.Age = (Connection.reader.GetInt64(6) / 12).ToString();
                PageObjects.patientDetails.Address = Connection.reader.GetString(7);
                DateTime birthDate = Connection.reader.GetDateTime(8);
                PageObjects.patientDetails.Birthdate = birthDate.ToString("yyyy-MM-dd");
                
                // 1 = Active
                // 0 = Inactive
                if(Connection.reader.GetInt64(9) == 1)
                {
                    PageObjects.patientDetails.Status = "Active";
                } 
                else
                {
                    PageObjects.patientDetails.Status = "Inactive";
                }

                DateTime dateAdded = Connection.reader.GetDateTime(10);
                PageObjects.patientDetails.DateAdded = dateAdded.ToString();

                // Null = Data has not been archived even once
                if(Connection.reader.IsDBNull(11))
                {
                    PageObjects.patientDetails.LastArchiveDate = "N/A";
                } 
                else
                {
                    DateTime lastArchiveDate = Connection.reader.GetDateTime(11);
                    PageObjects.patientDetails.LastArchiveDate = lastArchiveDate.ToString();
                }
                    // will only display Patient Details if fetched successfully by the system
                    PageObjects.RemoveResources(ref PageObjects.CurrentControl);
                PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientDetails);
                PageObjects.CurrentControl = PageObjects.patientDetails;
            }
            else
            {
                MessageBox.Show("Patient details not found.", "Patient Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Connection.reader.Close();
            Connection.conn.Close();
        }
        
        public void GetPatientDetails(string patientID, PatientDataHolder patientData)
        {
            // GetPatientDetails overload for Edit Patient page
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT FirstName, LastName, MiddleName, BirthDate, TIMESTAMPDIFF(MONTH, BirthDate, CURDATE()), Gender, Contact, Occupation, Address " +
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

        public void AddPatient(PatientDataHolder patientData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("INSERT INTO Patients VALUES (@patientID, @firstName, @lastName, @middleName, @contact, @birthdate, @gender, @address, @occupation, @status, @dateAdded, @lastArchiveDate)", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientData.PatientID);
            Connection.cmd.Parameters.AddWithValue("@firstname", patientData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@lastName", patientData.LastName);
            Connection.cmd.Parameters.AddWithValue("@middleName", patientData.MiddleName);

            if (patientData.Contact[0] == '0')
            {
                patientData.Contact = patientData.Contact.Substring(1); // will remove the "0" in the contact
            }
            patientData.Contact = "+63" + patientData.Contact; // will insert '+63' at the start of contact

            Connection.cmd.Parameters.AddWithValue("@contact", patientData.Contact);
            Connection.cmd.Parameters.AddWithValue("@birthDate", patientData.Birthdate);
            Connection.cmd.Parameters.AddWithValue("@gender", patientData.Gender);
            Connection.cmd.Parameters.AddWithValue("@address", patientData.Address);
            Connection.cmd.Parameters.AddWithValue("@occupation", patientData.Occupation);
            Connection.cmd.Parameters.AddWithValue("@status", 1);
            Connection.cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
            Connection.cmd.Parameters.AddWithValue("@lastArchiveDate", null);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
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

            Connection.cmd = new MySqlCommand("UPDATE Patients SET Status = 0 WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", patientID);
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
    }
}
