using Astra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class SelectTool : Form
    {
        public SelectTool()
        {
            InitializeComponent();
        }

        private void btnGoniometer_Click(object sender, EventArgs e)
        {
            var manualAddROMPage = new ManualAddROM();
            manualAddROMPage.ShowDialog();
            this.Close();
        }

        private void btnAstraProCamera_Click(object sender, EventArgs e)
        {
            if (IsCameraConnected())
            {
                var assessmentROMPage = new AssessmentROM();
                assessmentROMPage.ShowDialog();
                this.Close();
            }
            else
            {
                CustomDialog.Show("Astra pro plus camera is not connected!", "Astra", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
        }

        private bool IsCameraConnected()
        {
            Astra.StreamSet tempStreamSet = null;
            bool initialized = false; // Keep track if Initialize was called
            try
            {
                // Initialize the SDK context first
                Astra.Context.Initialize(); //
                initialized = true;

                // Now try to open the default device stream set
                tempStreamSet = Astra.StreamSet.Open(); //

                if (tempStreamSet != null && tempStreamSet.IsAvailable) //
                {
                    return true; // Camera found and available
                }
                else
                {
                    return false; // Camera opened but not available
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Camera check failed: {ex.Message}");
                return false; // Exception likely means no device or driver issue
            }
            finally
            {
                // Dispose the stream set if created
                tempStreamSet?.Dispose(); //
                                          // Terminate the SDK context if it was initialized
                if (initialized)
                {
                    Astra.Context.Terminate(); //
                }
            }
        }
    }
}
