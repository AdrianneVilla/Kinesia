using Kinesia.Assessment;
using Kinesia.Patients;
using Kinesia.Users;
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
    public partial class DashboardPage : UserControl
    {
        private bool isInitialized = false;
        private Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, Font> originalFonts = new Dictionary<Control, Font>();
        private Size originalSize = new Size(1195, 1046); // From designer
        public DashboardPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            this.MinimumSize = new Size(800, 600);
            InitializeComponent();
        }

        private void SetupResponsiveLayout()
        {
            // Store original positions and sizes
            StoreOriginalBounds();

            // Subscribe to resize event
            this.Resize += DashboardPage_Resize;
        }

        private void StoreOriginalBounds()
        {
            // Store stat panels
            originalBounds[panelBorder2] = panelBorder2.Bounds;
            originalBounds[panelBorder3] = panelBorder3.Bounds;
            originalBounds[panelBorder5] = panelBorder5.Bounds;

            // Store controls inside stat panels
            foreach (Control ctrl in panelBorder2.Controls)
            {
                originalBounds[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
            }
            foreach (Control ctrl in panelBorder3.Controls)
            {
                originalBounds[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
            }
            foreach (Control ctrl in panelBorder5.Controls)
            {
                originalBounds[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
            }

            // Store quick action buttons
            originalBounds[btnQuickAddPatient] = btnQuickAddPatient.Bounds;
            originalBounds[btnQuickNewAssessment] = btnQuickNewAssessment.Bounds;
            originalBounds[btnQuickAddUser] = btnQuickAddUser.Bounds;

            // Store labels
            originalBounds[label3] = label3.Bounds;
            originalBounds[lblMonth] = lblMonth.Bounds;
            originalBounds[lblRecentActivities] = lblRecentActivities.Bounds;

            // Store recent activities panel
            originalBounds[panelRecentActivities] = panelRecentActivities.Bounds;

            // Store fonts - MAIN HEADERS
            originalFonts[label1] = (Font)label1.Font.Clone();
            originalFonts[lblName] = (Font)lblName.Font.Clone();
            originalFonts[label3] = (Font)label3.Font.Clone();
            originalFonts[lblMonth] = (Font)lblMonth.Font.Clone();
            originalFonts[lblRecentActivities] = (Font)lblRecentActivities.Font.Clone();

            // Store fonts for stat panel labels
            originalFonts[lblTotalOngoingAssessments] = (Font)lblTotalOngoingAssessments.Font.Clone();
            originalFonts[label2] = (Font)label2.Font.Clone();
            originalFonts[lblMostJointTracked] = (Font)lblMostJointTracked.Font.Clone();
            originalFonts[label7] = (Font)label7.Font.Clone();
            originalFonts[lblTotalAssessments] = (Font)lblTotalAssessments.Font.Clone();
            originalFonts[label432] = (Font)label432.Font.Clone();

            // ADD: Store fonts for quick action buttons
            originalFonts[btnQuickAddPatient] = (Font)btnQuickAddPatient.Font.Clone();
            originalFonts[btnQuickNewAssessment] = (Font)btnQuickNewAssessment.Font.Clone();
            originalFonts[btnQuickAddUser] = (Font)btnQuickAddUser.Font.Clone();

            // Store original sizes for icons
            originalBounds[pictureBox1] = pictureBox1.Bounds;
            originalBounds[pictureBox2] = pictureBox2.Bounds;
            originalBounds[pictureBox3] = pictureBox3.Bounds;

        }

        private void DashboardPage_Resize(object sender, EventArgs e)
        {
            if (!isInitialized || originalSize.Width == 0) return;

            ResizeControls();
        }

        private void ResizeControls()
        {
            float scaleX = (float)this.Width / originalSize.Width;
            float scaleY = (float)this.Height / originalSize.Height;

            this.SuspendLayout();

            // Resize stat panels (first row)
            ResizeControl(panelBorder2, scaleX, scaleY);
            ResizeControl(panelBorder3, scaleX, scaleY);
            ResizeControl(panelBorder5, scaleX, scaleY);

            // Resize contents of stat panels
            ResizeStatPanelContents(panelBorder2, scaleX, scaleY);
            ResizeStatPanelContents(panelBorder3, scaleX, scaleY);
            ResizeStatPanelContents(panelBorder5, scaleX, scaleY);

            // Resize quick action buttons (second row)
            ResizeControl(btnQuickAddPatient, scaleX, scaleY);
            ResizeControl(btnQuickNewAssessment, scaleX, scaleY);
            ResizeControl(btnQuickAddUser, scaleX, scaleY);

            // ADD: Scale quick action button fonts and images
            ScaleButtonContent(btnQuickAddPatient, scaleX, scaleY);
            ScaleButtonContent(btnQuickNewAssessment, scaleX, scaleY);
            ScaleButtonContent(btnQuickAddUser, scaleX, scaleY);

            // Resize labels
            ResizeControl(label3, scaleX, scaleY, true);
            ResizeControl(lblMonth, scaleX, scaleY, true);
            ResizeControl(lblRecentActivities, scaleX, scaleY, true);

            // Resize recent activities panel
            if (originalBounds.ContainsKey(panelRecentActivities))
            {
                Rectangle orig = originalBounds[panelRecentActivities];
                int newX = (int)(orig.X * scaleX);
                int newY = (int)(orig.Y * scaleY);
                int newWidth = (int)(orig.Width * scaleX);
                int newHeight = (int)(orig.Height * scaleY);

                panelRecentActivities.Location = new Point(newX, newY);
                panelRecentActivities.Size = new Size(newWidth, newHeight);
            }

            // Scale header fonts
            ScaleFont(label1, scaleX, scaleY);
            ScaleFont(lblName, scaleX, scaleY);
            ScaleFont(label3, scaleX, scaleY);
            ScaleFont(lblMonth, scaleX, scaleY);
            ScaleFont(lblRecentActivities, scaleX, scaleY);

            // Scale stat panel fonts
            ScaleFont(lblTotalOngoingAssessments, scaleX, scaleY);
            ScaleFont(label2, scaleX, scaleY);
            ScaleFont(lblMostJointTracked, scaleX, scaleY);
            ScaleFont(label7, scaleX, scaleY);
            ScaleFont(lblTotalAssessments, scaleX, scaleY);
            ScaleFont(label432, scaleX, scaleY);

            // Resize stat panel icons
            ResizeIcon(pictureBox1, scaleX, scaleY);
            ResizeIcon(pictureBox2, scaleX, scaleY);
            ResizeIcon(pictureBox3, scaleX, scaleY);

            this.ResumeLayout();
        }

        private void ScaleButtonContent(Button btn, float scaleX, float scaleY)
        {
            // Scale font
            if (originalFonts.ContainsKey(btn))
            {
                Font origFont = originalFonts[btn];
                float scale = Math.Min(scaleX, scaleY);
                float newFontSize = origFont.Size * scale;

                // Limit font scaling for buttons
                newFontSize = Math.Max(8, Math.Min(newFontSize, origFont.Size * 1.0f));

                btn.Font = new Font(origFont.FontFamily, newFontSize, origFont.Style);
            }

            // Scale image if button has one
            if (btn.Image != null)
            {
                float scale = Math.Min(scaleX, scaleY);

                Image originalImage = null;

                if (btn == btnQuickAddPatient)
                    originalImage = Properties.Resources.patients_icon;
                else if (btn == btnQuickNewAssessment)
                    originalImage = Properties.Resources.assessment_icon;
                else if (btn == btnQuickAddUser)
                    originalImage = Properties.Resources.users_icon; 

                if (originalImage != null)
                {
                    int newWidth = (int)(originalImage.Width * scale);
                    int newHeight = (int)(originalImage.Height * scale);

                    // Create resized image
                    Bitmap resizedImage = new Bitmap(newWidth, newHeight);
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                    }

                    btn.Image = resizedImage;
                }
            }
        }

        private void ResizeStatPanelContents(Control panel, float scaleX, float scaleY)
        {
            panel.SuspendLayout();

            foreach (Control ctrl in panel.Controls)
            {
                if (originalBounds.ContainsKey(ctrl))
                {
                    Rectangle orig = originalBounds[ctrl];

                    // Scale position
                    int newX = (int)(orig.X * scaleX);
                    int newY = (int)(orig.Y * scaleY);

                    ctrl.Location = new Point(newX, newY);

                    // For PictureBoxes, also scale size
                    if (ctrl is PictureBox)
                    {
                        float scale = Math.Min(scaleX, scaleY);
                        int newSize = (int)(orig.Width * scale);
                        ctrl.Size = new Size(newSize, newSize);
                    }
                }
            }

            panel.ResumeLayout();
        }

        private void ResizeIcon(PictureBox icon, float scaleX, float scaleY)
        {
            if (!originalBounds.ContainsKey(icon)) return;

            Rectangle orig = originalBounds[icon];
            float scale = Math.Min(scaleX, scaleY); // Use uniform scaling for icons

            int newWidth = (int)(orig.Width * scale);
            int newHeight = (int)(orig.Height * scale);

            // Keep icon square
            int size = Math.Min(newWidth, newHeight);
            icon.Size = new Size(size, size);
        }

        private void ResizeControl(Control ctrl, float scaleX, float scaleY, bool isLabel = false)
        {
            if (!originalBounds.ContainsKey(ctrl)) return;

            Rectangle orig = originalBounds[ctrl];
            int newX = (int)(orig.X * scaleX);
            int newY = (int)(orig.Y * scaleY);
            int newWidth = (int)(orig.Width * scaleX);
            int newHeight = (int)(orig.Height * scaleY);

            ctrl.Location = new Point(newX, newY);

            if (!isLabel)
            {
                ctrl.Size = new Size(newWidth, newHeight);
            }
        }

        private void ScaleFont(Control ctrl, float scaleX, float scaleY)
        {
            if (!originalFonts.ContainsKey(ctrl)) return;

            Font origFont = originalFonts[ctrl];
            float scale = Math.Min(scaleX, scaleY);
            float newFontSize = origFont.Size * scale;

            // Limit font scaling
            newFontSize = Math.Max(8, Math.Min(newFontSize, origFont.Size * 1.1f));

            ctrl.Font = new Font(origFont.FontFamily, newFontSize, origFont.Style);
        }

        private async void DashboardPage_Load(object sender, EventArgs e)
        {
            SetupResponsiveLayout();
            isInitialized = true;

          
        }

        public DataGridView GetLogsGrid { get { return dataGridLogs; } }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void DashboardPage_Paint(object sender, PaintEventArgs e)
        {
            if (SessionManager.Role != "Admin")
            {
                btnQuickAddUser.Visible = false;
                lblRecentActivities.Visible = false;
                panelRecentActivities.Visible = false;
            }
            lblName.Text = SessionManager.UserLastName + "!";
            lblMonth.Text = DateTime.Now.ToString("MMMM yyyy");
            lblTotalAssessments.Text = (await Queries.AssessmentQueries.GetTotalAssessments(DateTime.Now.Month, DateTime.Now.Year)).ToString();
            lblTotalOngoingAssessments.Text = (await Queries.AssessmentQueries.GetTotalOngoingAssessments(DateTime.Now.Month, DateTime.Now.Year)).ToString();
            lblMostJointTracked.Text = await Queries.AssessmentQueries.GetMostTrackedJoint(DateTime.Now.Month, DateTime.Now.Year);
            await Queries.LogsQueries.DisplayDashboardLogs();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnQuickAddPatient_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addPatient = new AddPatient();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addPatient);
            PageObjects.CurrentControl = PageObjects.addPatient;
            PageObjects.addPatient.PreviousPage = "Dashboard Page";
        }

        private void btnQuickAddUser_Click(object sender, EventArgs e)
        {
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.addUser = new AddUser();
            PageObjects.dashboard.ContentsPanel.Controls.Clear();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addUser);
            PageObjects.CurrentControl = PageObjects.addUser;
        }

        private void btnQuickNewAssessment_Click(object sender, EventArgs e)
        {
            PageObjects.addAssessment = new AddAssessment();
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
            PageObjects.CurrentControl = PageObjects.addAssessment;
        }
    }
}
