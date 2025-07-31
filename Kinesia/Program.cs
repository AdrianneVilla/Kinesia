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
using System.Text.RegularExpressions;
using WindowsFormsApp2.CustomButton;
using Kinesia.Assessment;
using Kinesia.Components.Custom_Dialog_Boxes;
using System.Drawing;
using System.Runtime.InteropServices;

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
        public static EditPatient editPatient;
        public static DisplayUsers displayUsers;
        public static UserPage userPage;    
        public static UserDetails userDetails;
        public static AddUser addUser;
        public static AssessmentPage assessmentPage;

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
        OK, // 0
        YesNo // 1
    }

    public enum CustomDialogIcons
    {
        None, // 0
        Question, // 1
        Information, // 2
        Error, // 3
        Warning // 4
    }

    public class DataHolder
    {
        public static PatientDataHolder PatientDataHolder;
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
        public static UserCRUD UserQueries = new UserCRUD();
    }

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
            // will only allow whole numbers and a dot on textboxes
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // will only allow one dot on textboxes
            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // will not allow dot as first character on a textbox
            if (((sender as TextBox).Text.Length == 0) && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
    }
}
