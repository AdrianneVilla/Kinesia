using Kinesia.Components;
using Kinesia.Patients;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kinesia.Users;
using System.Text.RegularExpressions;
using WindowsFormsApp2.CustomButton;
using Kinesia.Assessment;
using Kinesia.Components.Custom_Dialog_Boxes;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Kinesia.Logs;
using CustomControls.RJControls;
using Kinesia.Reports;

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
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    // Contains PageObjects objects
    public class PageObjects
    {
        public static Login loginPage = Login.getLoginInstance();
        public static Dashboard dashboard;
        public static DashboardPage dashboardPage;
        public static PatientsPage patientsPage;
        public static DisplayPatients displayPatients;
        public static AddPatient addPatient;
        public static PatientDetails patientDetails;
        public static EditPatient editPatient;
        public static DisplayUsers displayUsers;
        public static UserPage userPage;    
        public static UserDetails userDetails;
        public static AddUser addUser;
        public static EditUser editUser;
        public static AssessmentPage assessmentPage;
        public static AssessmentDetails assessmentDetails;
        public static LogsPage logsPage;
        public static newLogsPage newLogsPage;

        public static Control CurrentControl;

        public static void RemoveResources(ref Control activeControl)
        {
            if (activeControl == null) return;

            activeControl.Dispose();
            activeControl = null;
        }

        public static void DisposeHolderControls(PanelBorder panelHolder)
        {
            foreach(Control control in panelHolder.Controls)
            {
                control.Dispose();
            }
            panelHolder.Controls.Clear();
        }
    }

    // Contains custom dialog methods
    public static class CustomDialog
    {
        public static DialogResult Show(string description, string title, CustomDialogButtons button, CustomDialogIcons icon)
        {
            using(var dialog = CreateDialog(button))
            {
                if (dialog is ICustomDialog customDialog)
                {
                    customDialog.Title = title;
                    customDialog.Description = description;
                    switchIcon(customDialog.DialogIcon, icon);
                }

                return dialog.ShowDialog();
            }  
        }

        private static Form CreateDialog(CustomDialogButtons button)
        {
            if( button == CustomDialogButtons.OK )
            {
                return new SingleBtnDialog();
            }
            return new DoubleBtnDialog();
        }

        private static void switchIcon(PictureBox pictureBox, CustomDialogIcons icon)
        {
            switch ((int)icon)
            {
                case 0: pictureBox.Image = null; break;
                case 1: pictureBox.Image = Properties.Resources.question_icon; break;
                case 2: pictureBox.Image = Properties.Resources.blue_information_icon; break;
                case 3: pictureBox.Image = Properties.Resources.error_icon; break;
                case 4: pictureBox.Image = Properties.Resources.yellow_triangle_warning_icon; break;
            }
        }
    }
    
    public enum CustomDialogButtons
    {
        // Numbers are indexes
        OK, // 0
        YesNo // 1
    }

    public enum CustomDialogIcons
    {
        // Numbers are indexes
        None, // 0
        Question, // 1
        Information, // 2
        Error, // 3
        Warning // 4
    }

    // Contains DataHolder/Model objects
    public class DataHolder
    {
        public static PatientDataHolder PatientDataHolder;
        public static UserDataHolder UserDataHolder;
    }

    public class SessionManager
    {
        public static string UserID;
        public static string UserLastName;

        public static void Logout()
        {
            UserID = null;
            UserLastName = null;
        }
    }

    // Contains quries objects intantiation
    public class Queries
    {
        public static PatientsCRUD PatientQueries = new PatientsCRUD();
        public static UserCRUD UserQueries = new UserCRUD();
        public static LogsCRUD LogsQueries = new LogsCRUD();
        public static AssessmentCRUD AssessmentQueries = new AssessmentCRUD();
        public static ROMCRUD ROMQueries = new ROMCRUD();
    }

    // Contains methods for customizing DataGridView
    public class CustomDataGrid
    {
        public static void SetDoubleBuffering(Control control, bool enable)
        {
            var propertyInfo = typeof(Control).GetProperty("DoubleBuffered",
             System.Reflection.BindingFlags.NonPublic |
             System.Reflection.BindingFlags.Instance);
            propertyInfo.SetValue(control, enable, null);
        }

        public static void StyleDataGridWithSpacing(DataGridView dataGrid)
        {

            dataGrid.DefaultCellStyle.Padding = new Padding(15, 10, 15, 10);

            // row height

            dataGrid.RowTemplate.Height = 50;

            dataGrid.BorderStyle = BorderStyle.None;
        }
    }

    // Contains custom security methods
    public class CustomSecurity
    {
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;

                // will hash the saltedPassword into 256-bit hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder builder = new StringBuilder();

                // will converts each byte into its 2-digit lowercase hexadecimal form
                // Example: "4b227777d4dd1fc61c6f884f48641d02..."
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltByes = new byte[16]; // will create a 16-byte array

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(saltByes); // will fills it with cryptographically random values
            }

            // will convert bytes into a Base64 Str
            // Example: "bZf34Gv2aF+5QZz9q3bXyA=="
            return Convert.ToBase64String(saltByes);
        }
    }

    // Contains Input Validation methods
    public class InputValidation
    {
        public static void CharactersOnly(object sender, KeyPressEventArgs e)
        {
            // will only allow characters on textboxes
            if(!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s\b]"))
            {
                e.Handled = true;
            }
        }

        public static void WholeNumbersOnly(object sender, KeyPressEventArgs e)
        {
            // will only allow whole numbers on textboxes
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void FloatingNumbersOnly(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as CustomControls.RJControls.RJTextBox;

            if (textBox == null)
                return;

            string text = textBox.Texts; // use the exposed property

            // Allow control keys (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits and dot only
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Allow only one dot
            if (e.KeyChar == '.' && text.Contains('.'))
            {
                e.Handled = true;
                return;
            }

            // Allow dot as first character but typing it will convert to 0.
            if (e.KeyChar == '.' && textBox.SelectionStart == 0)
            {
                textBox.Texts = "0.";
                textBox.SelectionStart = textBox.Texts.Length;
                e.Handled = true;
            }
        }


    }
}
