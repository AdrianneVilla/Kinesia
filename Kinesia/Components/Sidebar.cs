using Kinesia.Patients;
using Kinesia.Users;
using Kinesia.Assessment;
using Kinesia.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Components
{
    public partial class Sidebar : UserControl
    {
        static String tags;
        private Button currentActiveButton = null;
        private Color activeColor = Color.FromArgb(18, 90, 211);
        private Color defaultColor = Color.White;
        private Color activeTextColor = Color.White;
        private Color defaultTextColor = Color.FromArgb(18, 90, 221);

        private Dictionary<Button, Image> defaultIcons = new Dictionary<Button, Image>();
        private Dictionary<Button, Image> activeIcons = new Dictionary<Button, Image>();

        public Sidebar()
        {
            InitializeComponent();

       
            SetButtonFlatStyle();
        }

      
        private void SetButtonFlatStyle()
        {
            dashboardModule.FlatStyle = FlatStyle.Flat;
            patientModule.FlatStyle = FlatStyle.Flat;
            usersModule.FlatStyle = FlatStyle.Flat;
            assessmentModule.FlatStyle = FlatStyle.Flat;
            btnLogs.FlatStyle = FlatStyle.Flat;

   
            SetInitialButtonColors();
        }

       
        private void SetInitialButtonColors()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn != btnLogout)
                {
                    btn.BackColor = defaultColor;
                    btn.ForeColor = defaultTextColor;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        // Store the default and active icons for each button
        private void InitializeButtonIcons()
        {

            defaultIcons[dashboardModule] = dashboardModule.Image;
            defaultIcons[patientModule] = patientModule.Image;
            defaultIcons[usersModule] = usersModule.Image;
            defaultIcons[assessmentModule] = assessmentModule.Image;
            defaultIcons[btnLogs] = btnLogs.Image;

            // active state
            activeIcons[dashboardModule] = Properties.Resources.dashboard_active;
            activeIcons[patientModule] = Properties.Resources.patients_active;
            activeIcons[usersModule] = Properties.Resources.users_active;
            activeIcons[assessmentModule] = Properties.Resources.assessment_active;
            activeIcons[btnLogs] = Properties.Resources.logs_active;
        }


        private void ResetButtonColors()
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = defaultColor;
                currentActiveButton.ForeColor = defaultTextColor;
                currentActiveButton.FlatAppearance.BorderSize = 0;

                // Reset icon to default
                if (defaultIcons.ContainsKey(currentActiveButton))
                {
                    currentActiveButton.Image = defaultIcons[currentActiveButton];
                }
            }
        }

        // Method to highlight the clicked button
        private void HighlightButton(Button button)
        {
            ResetButtonColors();
            currentActiveButton = button;
            button.BackColor = activeColor;
            button.ForeColor = activeTextColor;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.FromArgb(18, 90, 211);

            // Change icon to active version
            if (activeIcons.ContainsKey(button))
            {
                button.Image = activeIcons[button];
            }
        }

        private void dashboardModule_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboardPage = new DashboardPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.dashboardPage);
            PageObjects.CurrentControl = PageObjects.dashboardPage;
        }

        private void patientModule_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.patientsPage = new PatientsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.patientsPage);
            PageObjects.CurrentControl = PageObjects.patientsPage;
        }

        private void usersModule_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.userPage = new UserPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.userPage);
            PageObjects.CurrentControl = PageObjects.userPage;
        }

        private void assessmentModule_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.assessmentPage = new AssessmentPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentPage);
            PageObjects.CurrentControl = PageObjects.assessmentPage;
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.LogsPage = new LogsPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.LogsPage);
            PageObjects.CurrentControl = PageObjects.LogsPage;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult logoutDiag = CustomDialog.Show("Are you sure you want to logout?", "Logout Alert", CustomDialogButtons.YesNo, CustomDialogIcons.Question);

            if (logoutDiag == DialogResult.Yes)
            {
                SessionManager.Logout();
                PageObjects.dashboard.Close();
                PageObjects.loginPage.Show();
            }
        }

        private void Sidebar_Load(object sender, EventArgs e)
        {
            // Initialize icon dictionaries
            InitializeButtonIcons();

            // Set dashboard as default active button on load
            HighlightButton(dashboardModule);

        }

        private void btnLogs_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Check if SessionManager and Role are initialized
                if (SessionManager.Role != null && !SessionManager.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    btnLogs.Visible = false;
                    usersModule.Visible = false;
                }
            }
            catch (Exception)
            {
                // Silently ignore errors during paint
            }
        }
    }
}
