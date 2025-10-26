using KinesiaLibrary;
using KinesiaLibrary.DTOs.ROMDTOs;
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
    public partial class ManualAddROM : Form
    {
        public ManualAddROM()
        {
            InitializeComponent();
        }

        private void ManualAddROM_Load(object sender, EventArgs e)
        {
            cbMovement.Items.Clear();

            if (PageObjects.assessmentDetails.Joint == "Shoulder")
            {
                cbMovement.Items.Add("Flexion");
                cbMovement.Items.Add("Extension");
                cbMovement.Items.Add("Abduction");
                cbMovement.Items.Add("Adduction");
            }
            else if (PageObjects.assessmentDetails.Joint == "Elbow and Forearm")
            {
                cbMovement.Items.Add("Flexion");
                cbMovement.Items.Add("Extension");
            }
            else if (PageObjects.assessmentDetails.Joint == "Hip")
            {
                cbMovement.Items.Add("Flexion");
                cbMovement.Items.Add("Extension");
            }
            else if (PageObjects.assessmentDetails.Joint == "Knee")
            {
                cbMovement.Items.Add("Flexion");
                cbMovement.Items.Add("Extension");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // will remove extra white spaces at the beginning and end of inputs
            txtGoniometer.Texts = txtGoniometer.Texts.Trim();
            txtStartingPosition.Texts = txtStartingPosition.Texts.Trim();
            txtRom.Texts = txtRom.Texts.Trim();

            double initialROM, endROM;

            // will be triggered if txtInitialROM is null or empty
            if (!double.TryParse(txtStartingPosition.Texts, out initialROM))
            {
                CustomDialog.Show("ROM details was incomplete! \nPlease fill-out all details to add this ROM.", "Incomplete ROM Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return;
            }

            // will be triggered if txtEndROM is null or empty
            if (!double.TryParse(txtRom.Texts, out endROM))
            {
                CustomDialog.Show("ROM details was incomplete! \nPlease fill-out all details to add this ROM.", "Incomplete ROM Details",
                    CustomDialogButtons.OK, CustomDialogIcons.Error);
                return;
            }

            var newROM = new AddROMDTO();

            newROM.AssessmentID = PageObjects.assessmentDetails.AssessmentID;
            newROM.UserID = SessionManager.UserID;
            newROM.GoniometerType = txtGoniometer.Texts;
            newROM.StartingPosition = Convert.ToDouble(txtStartingPosition.Texts);
            newROM.Rom = Convert.ToDouble(txtRom.Texts);
            newROM.Movement = cbMovement.Texts;
            newROM.MotionType = cbMotionType.Texts;
            newROM.Date = DateTime.Now;


            if (Queries.ROMQueries.IsROMDetailsComplete(newROM))
            {
                // will continue to add ROM if ROM details is complete
                var success = await Queries.ROMQueries.AddROM(newROM);

                if (success)
                {
                    // if adding ROM was successful
                    // will add a log for adding a ROM
                    // will clear all inputs
                    // will show a success message
                    // will go back to Assessment details page and refresh the ROM table
                    await Queries.LogsQueries.AddLog($"Added ROM for {PageObjects.assessmentDetails.AssessmentID}", "ROM");
                    clearAllInputs();
                    CustomDialog.Show("ROM added successfully!", "Add ROM Notification", CustomDialogButtons.OK, CustomDialogIcons.Information);
                    await Queries.ROMQueries.DisplayROM(PageObjects.assessmentDetails.AssessmentID, "All");
                    this.Close();
                }
                else
                {
                    CustomDialog.Show("Failed to add ROM.", "Add ROM Notification", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult closeDiag = CustomDialog.Show("Are you sure you want to exit adding ROM?\n" +
                    "Any unsaved changes will be lost", "Exit add ROM", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                if (closeDiag != DialogResult.Yes)
                {
                    this.Close();
                }
            }

            // will directly close this form if there's no unsaved input
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (areInputsBlank())
            {
                // will only show dialog if there's an unsaved input
                DialogResult closeDiag = CustomDialog.Show("Are you sure you want to exit adding ROM?\n" +
                    "Any unsaved changes will be lost", "Exit add ROM", CustomDialogButtons.YesNo, CustomDialogIcons.Warning);

                if (closeDiag != DialogResult.Yes)
                {
                    this.Close();
                }
            }

            // will directly close this form if there's no unsaved input
            this.Close();
        }

        private bool areInputsBlank()
        {
            if (!txtStartingPosition.Texts.Equals("") || !txtRom.Texts.Equals("") || !cbMovement.Texts.Equals("") ||
                !cbMotionType.Texts.Equals(""))
            {
                return true;
            }

            return false;
        }

        private void clearAllInputs()
        {
            txtStartingPosition.Texts = "";
            txtRom.Texts = "";
            cbMovement.Texts = "";
            cbMotionType.Texts = "";
        }

        private void txtInitialROM_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.FloatingNumbersOnly(sender, e);
        }

        private void txtEndROM_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidation.FloatingNumbersOnly(sender, e);
        }

        private void cbMovement_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMovement.Texts != "")
            {
                lblNormalRom.Text = ROMHelper.GetNormalRange(PageObjects.assessmentDetails.Joint, cbMovement.Texts).ToString();
            }
        }

        private void txtRom__TextChanged(object sender, EventArgs e)
        {
            if(txtRom.Texts != "")
            {
                lblDeficit.Text = ROMHelper.CalculateDeficit(Convert.ToDouble(txtRom.Texts), PageObjects.assessmentDetails.Joint, cbMovement.Texts).ToString();
            }
            else if(txtRom.Texts == "")
            {
                lblDeficit.Text = "0";
            }
        }
    }
}
