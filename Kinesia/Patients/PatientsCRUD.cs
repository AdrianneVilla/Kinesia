﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kinesia.Patients
{
    public class PatientsCRUD
    {
        private int patientIDCount;
        public void DisplayPatients(string searchData)
        {
            PageObjects.patientsPage.getPatientHolder.Controls.Clear();
            Connection.conn.Open();

            if(searchData == "")
            {
                // will display all patients
                Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Gender, Contact, Status FROM Patients", Connection.conn);
            } else
            {
                // will only do searching and display specific patient/s if there's a searchData value
                Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Gender, Contact, Status" +
                " FROM Patients WHERE PatientID LIKE CONCAT('%', @searchData, '%') OR FirstName LIKE CONCAT('%', @searchData, '%') OR MiddleName LIKE CONCAT('%', @searchData, '%') OR LastName LIKE CONCAT('%', @searchData, '%')", Connection.conn);
                Connection.cmd.Parameters.AddWithValue("@searchData", searchData);
            }
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
            Connection.cmd.Parameters.AddWithValue("@patientID", $"PATIENT{patientIDCount + 1}");
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
