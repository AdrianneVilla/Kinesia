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
        public void DisplayPatients()
        {
            Connection.conn.Open();

            Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Sex, Contact, Status FROM Patients", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                PageObjects.displayPatients = new DisplayPatients();

                PageObjects.displayPatients.BtnView.Tag = Connection.reader.GetString(0);
                PageObjects.displayPatients.BtnEdit.Tag = Connection.reader.GetString(0);
                PageObjects.displayPatients.BtnArchive.Tag = Connection.reader.GetString(0);

                PageObjects.displayPatients.PatientName = $"{Connection.reader.GetString(1)} {Connection.reader.GetString(2)} {Connection.reader.GetString(3)}";
                PageObjects.displayPatients.Age = (Connection.reader.GetInt64(4) / 12).ToString();
                PageObjects.displayPatients.Gender = Connection.reader.GetString(5);
                PageObjects.displayPatients.Contact = Connection.reader.GetString(6);

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

            Connection.cmd = new MySqlCommand("SELECT PatientID, FirstName, MiddleName, LastName, Sex, Contact, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS Age, Address, Birthdate " +
                "FROM Patients WHERE PatientID = @patientID", Connection.conn);
            Connection.cmd.Parameters.AddWithValue("@patientID", PatientID);
            Connection.reader = Connection.cmd.ExecuteReader();

            if(Connection.reader.Read())
            {
                PageObjects.patientDetails = new PatientDetails();
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
            GC.Collect();
        }
    }
}
