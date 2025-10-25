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
                ApplyLayoutChanges();
            }
        }

        private void ApplyLayoutChanges()
        {
            this.SuspendLayout();

            if (isLaptopMode)
            {
                // Laptop mode - reduce sizes
                sidebar1.Width = SIDEBAR_WIDTH_LAPTOP;
                header1.Height = HEADER_HEIGHT_LAPTOP;

                // Adjust sidebar font sizes if it has buttons
                AdjustSidebarForLaptop();

                // Adjust header elements if needed
                AdjustHeaderForLaptop();
            }
            else
            {
                // Desktop mode - full sizes
                sidebar1.Width = SIDEBAR_WIDTH_DESKTOP;
                header1.Height = HEADER_HEIGHT_DESKTOP;

                // Restore sidebar to desktop
                AdjustSidebarForDesktop();

                // Restore header to desktop
                AdjustHeaderForDesktop();
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void AdjustSidebarForLaptop()
        {
            // Adjust sidebar elements for laptop
            foreach (Control ctrl in sidebar1.Controls)
            {
                if (ctrl is Button btn)
                {
                    // Reduce button height
                    btn.Height = (int)(btn.Height * 0.85f);

                    // Reduce font size
                    if (btn.Font.Size > 9)
                    {
                        btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size * 0.85f, btn.Font.Style);
                    }
                }
                else if (ctrl is Label lbl)
                {
                    // Reduce label font size
                    if (lbl.Font.Size > 8)
                    {
                        lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size * 0.85f, lbl.Font.Style);
                    }
                }
                else if (ctrl is PictureBox pic)
                {
                    // Reduce logo/image size
                    pic.Height = (int)(pic.Height * 0.85f);
                    pic.Width = (int)(pic.Width * 0.85f);
                }
            }
        }

        private void AdjustSidebarForDesktop()
        {
            // Restore original sizes would require storing them
            // For simplicity, you might want to recreate or store original sizes
        }

        private void AdjustHeaderForLaptop()
        {
            // Adjust header elements for laptop
            foreach (Control ctrl in header1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    // Reduce font size
                    if (lbl.Font.Size > 10)
                    {
                        lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size * 0.85f, lbl.Font.Style);
                    }
                }
                else if (ctrl is Button btn)
                {
                    // Reduce button size
                    btn.Height = (int)(btn.Height * 0.85f);
                    btn.Width = (int)(btn.Width * 0.85f);
                }
                else if (ctrl is PictureBox pic)
                {
                    // Reduce image size
                    pic.Height = (int)(pic.Height * 0.85f);
                    pic.Width = (int)(pic.Width * 0.85f);
                }
            }
        }

        private void AdjustHeaderForDesktop()
        {
            // Restore original sizes
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            PageObjects.dashboardPage = new DashboardPage();
            ContentsPanel.Controls.Add(PageObjects.dashboardPage);
            PageObjects.CurrentControl = PageObjects.dashboardPage;
        }

        private void header1_Load(object sender, EventArgs e)
        {

        }
    }
}
