using Kinesia.Components;
using Kinesia.Patients;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kinesia.Patients;
using Kinesia.Users;

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
        public static Dashboard dashboard;
        public static DashboardPage dashboardPage;
        public static PatientsPage patientsPage;
        public static DisplayPatients displayPatients;
        public static AddPatient addPatient;
        public static PatientDetails patientDetails;
        public static DisplayUsers displayUsers;
        public static UserPage userPage;    
        public static UserDetails userDetails;
        public static AddUser addUser;

        public static Control CurrentControl;

        public static void RemoveResources(Control activeControl)
        {
            activeControl.Dispose();
            activeControl = null;
        }
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
        public static PatientsCRUD PatientQueries = new PatientsCRUD();
    }
}
