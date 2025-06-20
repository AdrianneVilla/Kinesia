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

            Connection.cmd = new MySqlCommand("SELECT FirstName, MiddleName, LastName, TIMESTAMPDIFF(MONTH, Birthdate, CURDATE()) AS totalMonths, Sex, Contact, Status FROM Patients", Connection.conn);
            Connection.reader = Connection.cmd.ExecuteReader();

            while(Connection.reader.Read())
            {
                PageObjects.displayPatients = new DisplayPatients();

                PageObjects.displayPatients.PatientName = $"{Connection.reader.GetString(0)} {Connection.reader.GetString(1)} {Connection.reader.GetString(2)}";
                PageObjects.displayPatients.Age = (Connection.reader.GetInt64(3) / 12).ToString();
                PageObjects.displayPatients.Gender = Connection.reader.GetString(4);
                PageObjects.displayPatients.Contact = Connection.reader.GetString(5);

                if(Connection.reader.GetInt64(6) == 1)
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
    }
}
