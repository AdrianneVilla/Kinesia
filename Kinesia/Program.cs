using CustomControls.RJControls;
using Kinesia.Assessment;
using Kinesia.Components;
using Kinesia.Components.Custom_Dialog_Boxes;
using Kinesia.Logs;
using Kinesia.Offline;
using Kinesia.Patients;
using Kinesia.Properties;
using Kinesia.Reports;
using Kinesia.Users;
using KinesiaLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.CustomButton;

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

            ROMHelper.InitializeFromConfig(
                () => ROMConfiguration.ShoulderFlexion,
                () => ROMConfiguration.ShoulderExtension,
                () => ROMConfiguration.ElbowFlexion,
                () => ROMConfiguration.ElbowExtension,
                () => ROMConfiguration.HipFlexion,
                () => ROMConfiguration.HipExtension,
                () => ROMConfiguration.KneeFlexion,
                () => ROMConfiguration.KneeExtension
            );

            // will subscribe to runtime updates
            ROMConfiguration.OnConfigurationChanged += () =>
            {
                ROMHelper.ReloadFrom(name => (double)Properties.Settings.Default[name]);
            };

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
        public static AddAssessment addAssessment;
        public static SelectPatient selectPatientPage;
        public static PatientAssessmentDetails patientAssessmentDetails;
        public static oldLogsPage newlogsPage;
        public static LogsPage LogsPage;

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

    public class FormAnimation
    {
        public static void ShowFocus(Form form)
        {
            if (form == null)
            {
                // Throwing an exception is better for debugging.
                // It tells you exactly where the problem started.
                throw new ArgumentNullException(nameof(form), "The form provided to ShowFocus cannot be null.");
            }

            // will try to find the currently active form.
            // If 'owner' is null, the shadow will use default settings.
            Form owner = Form.ActiveForm;

            // will calls the ShowFocus overload method,
            // passing along the owner it found.
            ShowFocus(form, owner);
        }

        public static void ShowFocus(Form formToStyle, Form owner)
        {
            if (formToStyle == null)
            {
                throw new ArgumentNullException(nameof(formToStyle), "The form to be styled cannot be null.");
            }

            // will set and create a background to help show a focus for message dialogs
            formToStyle.FormBorderStyle = FormBorderStyle.None;
            formToStyle.Opacity = .80;
            formToStyle.BackColor = Color.Black;
            formToStyle.ShowInTaskbar = false;

            if (owner != null)
            {
                // will set window state based on the owner's state
                if (owner.WindowState == FormWindowState.Maximized)
                {
                    formToStyle.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    // will make the shadow match the owner's exact size and location
                    formToStyle.WindowState = FormWindowState.Normal;
                    formToStyle.StartPosition = FormStartPosition.Manual;
                    formToStyle.Bounds = owner.Bounds; // will sets both Location and Size
                }

                // will set the owner of the shadow form
                formToStyle.Owner = owner;
            }
            else
            {
                // will fallback behavior if no active form is found
                formToStyle.StartPosition = FormStartPosition.CenterScreen;
                formToStyle.Size = new Size(1280, 800); // the original default size
                formToStyle.WindowState = FormWindowState.Normal;
            }

            formToStyle.Show();
        }
    }

    public class LoadingContext : IDisposable
    {
        private Form _shadowForm;
        private LoadingScreen _loadingForm;

        public LoadingContext(Form owner, string actionText)
        {
            // will create the shadow
            _shadowForm = new Form();
            FormAnimation.ShowFocus(_shadowForm, owner);

            // will create your loading form, passing the text
            _loadingForm = new LoadingScreen(actionText); // will uses the new constructor

            // will show the forms
            _loadingForm.Owner = _shadowForm;
            _loadingForm.StartPosition = FormStartPosition.CenterScreen;
            _loadingForm.Show();
            _loadingForm.Update();
        }

        // it will just calls the other constructor with a default one
        public LoadingContext(Form owner) : this(owner, "Please wait...")
        {
            // This constructor is now empty
            // It just chains to the one above.
        }

        public void Dispose()
        {
            _loadingForm.Close();
            _shadowForm.Close();
        }
    }

    public static class FormHelpers
    {
        public static async Task RunTaskWithLoading(this Form owner, string actionText, Func<Task> taskToRun)
        {
            try
            {
                // will pass the actionText to the LoadingContext
                using (new LoadingContext(owner, actionText))
                {
                    await taskToRun();
                }
            }
            catch (HttpRequestException)
            {
                // will show an error dialog if it catches a http request error from client-side
                CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                    "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            catch (Exception)
            {
                // will show an error dialog if it catches an unexpected error from client-side.
                CustomDialog.Show("An unexpected error occured.\nPlease try again.",
                            "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        // will just calls the new one with a default message
        public static async Task RunTaskWithLoading(this Form owner, Func<Task> taskToRun)
        {
            await owner.RunTaskWithLoading("Please wait...", taskToRun);
        }

        public static async Task<T> RunTaskWithLoading<T>(this Form owner, string actionText, Func<Task<T>> taskToRun)
        {
            // will store any exceptions here.
            Exception caughtException = null;

            T result = default(T);

            // the 'using' block handles the loading form.
            using (new LoadingContext(owner, actionText))
            {
                try
                {
                    // will run the task
                    result = await taskToRun();
                }
                catch (HttpRequestException httpEx)
                {
                    // If it fails, will just SAVE the exception.
                    // will not show a dialog here.
                    caughtException = httpEx;
                }
                catch (Exception ex)
                {
                    caughtException = ex;
                }
            }

            if (caughtException != null)
            {
                if (caughtException is HttpRequestException)
                {
                    // will handle the network error
                    CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                        "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
                else
                {
                    // will handle all other logic errors
                    CustomDialog.Show("An error occurred: " + caughtException.Message,
                        "Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }

                // will return the default value (null) because an error happened
                return default(T);
            }

            // If no exception, will return the successful result
            return result;
        }
    }

    public static class ApiClient
    {
        public static readonly HttpClient Instance = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };
    }

    // Contains custom dialog methods
    public static class CustomDialog
    {
        public static DialogResult Show(string description, string title, CustomDialogButtons button, CustomDialogIcons icon)
        {
            // will create a new Form to act as the shadow
            using (Form shadow = new Form())
            {
                // will apply the focus/shadow effect from the FormAnimation class
                // This method also calls shadow.Show()
                FormAnimation.ShowFocus(shadow);

                // will create the actual dialog
                using (var dialog = CreateDialog(button))
                {
                    if (dialog is ICustomDialog customDialog)
                    {
                        customDialog.Title = title;
                        customDialog.Description = description;
                        switchIcon(customDialog.DialogIcon, icon);
                    }

                    // will set the shadow form as the owner of the dialog
                    // This ensures the dialog stays on top of the shadow.
                    dialog.Owner = shadow;

                    // will show the dialog modally and the execution will pause here
                    // until the user closes the dialog
                    DialogResult result = dialog.ShowDialog();

                    // when the dialog is closed, 'ShowDialog()' returns.
                    // The 'using' blocks will automatically close and dispose
                    // of both the 'dialog' and the 'shadow' forms.
                    return result;
                }
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
        public static string Role;

        public static void Logout()
        {
            UserID = null;
            UserLastName = null;
            Role = null;
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
