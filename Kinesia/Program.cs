using Kinesia.Components;
using Kinesia.Patients;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class PageObjects
    {
        public static DashboardPage dashboardPage;
        public static PatientsPage patientsPage;
        public static displayPatients displayPatients;
        public static AddPatient addPatient;
        public static PatientDetails patientDetails;
    }

    public class Connection
    {
        public static string connectionString = "server=localhost;port=3306;database=kinesia;uid=root;pwd=;";
        public static MySqlConnection conn = new MySqlConnection(connectionString);
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
    }

    public class Queries
    {

    }
}
