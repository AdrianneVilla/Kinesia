using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kinesia.Patients
{
    public class PatientsCRUD
    {
        private int patientIDCount;
        public void DisplayPatients()
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Gender, Contact, Status FROM Patients", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                PageObjects.displayPatients = new DisplayPatients(); // will create user control for every patient
                
                // will set the tag of every button to patientID
                PageObjects.displayPatients.BtnView.Tag = Connection.reader.GetString(0);
                PageObjects.displayPatients.BtnEdit.Tag = Connection.reader.GetString(0);
                PageObjects.displayPatients.BtnArchive.Tag = Connection.reader.GetString(0);

                // will set the data of every patient to the labels
                PageObjects.displayPatients.PatientID = Connection.reader.GetString(0);
                PageObjects.displayPatients.PatientName = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.displayPatients.Age = (Connection.reader.GetInt64(4) / 12).ToString();
                PageObjects.displayPatients.Gender = Connection.reader.GetString(5);
                PageObjects.displayPatients.Contact = Connection.reader.GetString(6);

                // 1 = Active
                // 2 = Inactive
                if(Connection.reader.GetInt64(7) == 1)
                {
                    PageObjects.displayPatients.Status = "Active";
                } else
                {
                    PageObjects.displayPatients.Status = "Inactive";
                }
                PageObjects.patientsPage.getPatientHolder.Controls.Add(PageObjects.displayPatients);
            }
            Connection.reader.Close();
            Connection.conn.Close();
            GC.Collect();
        }

        public void GetPatientDetails(string PatientID)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, Gender, Contact, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS Age, Address, Birthdate " +
                "FROM Patients WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", PatientID);
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
            }

            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientDetails);

            Connection.reader.Close();
            Connection.conn.Close();
        }
        
        public void GetPatientIDCount()
        {
            Connection.conn.Open();
            Connection.cmd = new MySqlCommand("SELECT COUNT(PatientID) FROM Patients", Connection.conn);
            patientIDCount = Convert.ToInt32(Connection.cmd.ExecuteScalar());
            Connection.conn.Close();
        }

        public void AddPatient(PatientDataHolder patientData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("INSERT INTO Patients VALUES (@patientID, @firstName, @lastName, @middleName, @contact, @birthdate, @gender, @address, @occupation, @status)", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", $"PATIENT{patientIDCount++}");
            Connection.cmd.Parameters.AddWithValue("@firstname", patientData.FirstName);
            Connection.cmd.Parameters.AddWithValue("@lastName", patientData.LastName);
            Connection.cmd.Parameters.AddWithValue("@middleName", patientData.MiddleName);
            Connection.cmd.Parameters.AddWithValue("@contact", patientData.Contact);
            Connection.cmd.Parameters.AddWithValue("@birthDate", patientData.Birthdate);
            Connection.cmd.Parameters.AddWithValue("@gender", patientData.Gender);
            Connection.cmd.Parameters.AddWithValue("@address", patientData.Address);
            Connection.cmd.Parameters.AddWithValue("@occupation", patientData.Occupation);
            Connection.cmd.Parameters.AddWithValue("@status", 1);
            Connection.cmd.ExecuteNonQuery();

            Connection.conn.Close();
        }

        public bool CheckExistingPatient(PatientDataHolder patientData)
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT FirstName, MiddleName, LastName FROM Patients", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            if (Connection.reader.Read())
            {
                Connection.reader.Close();
                Connection.conn.Close();
                return true;
            }

            Connection.reader.Close();
            Connection.conn.Close();
            return false;
        }

        public bool isPatientDetailsComplete(PatientDataHolder patientData)
        {
            if (patientData.FirstName.Equals("") || patientData.LastName.Equals("") || patientData.Gender.Equals("") || patientData.Contact.Equals("") ||
                patientData.Occupation.Equals("") || patientData.Address.Equals("") || patientData.Age <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
