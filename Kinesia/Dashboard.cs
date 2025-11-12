using Kinesia.Assessment;
using Kinesia.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia
{
    public partial class Dashboard : Form
    {
        public string selectedButton;
        private bool isLaptopMode = false;
        private const int LAPTOP_WIDTH_THRESHOLD = 1600;
        private const int LAPTOP_HEIGHT_THRESHOLD = 900;

        // Original sizes for desktop
        private const int SIDEBAR_WIDTH_DESKTOP = 314;
        private const int HEADER_HEIGHT_DESKTOP = 80;

        // Reduced sizes for laptop
        private const int SIDEBAR_WIDTH_LAPTOP = 250;
        private const int HEADER_HEIGHT_LAPTOP = 65;

        public Dashboard()
        {
            InitializeComponent();
            SetupResponsiveLayout();
        }

        private void SetupResponsiveLayout()
        {
            // Form settings
            this.MinimumSize = new Size(1024, 768);
            this.WindowState = FormWindowState.Maximized;

            // Subscribe to resize event
            this.Resize += Dashboard_Resize;
            this.Load += Dashboard_LoadComplete;
        }

        private void Dashboard_LoadComplete(object sender, EventArgs e)
        {
            // Initial responsive adjustment
            AdjustLayoutForScreenSize();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForScreenSize();
        }

        private void AdjustLayoutForScreenSize()
        {
            // Detect screen size
            bool shouldBeLaptopMode = this.Width < LAPTOP_WIDTH_THRESHOLD || this.Height < LAPTOP_HEIGHT_THRESHOLD;

            // Only adjust if mode changed
            if (shouldBeLaptopMode != isLaptopMode)
            {
                isLaptopMode = shouldBeLaptopMode;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            PageObjects.assessmentPage = new AssessmentPage();
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.assessmentPage);
            PageObjects.CurrentControl = PageObjects.assessmentPage;
        }

        private void header1_Load(object sender, EventArgs e)
        {

        }
    }
}
