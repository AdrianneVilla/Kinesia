using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Patients
{
    public partial class PatientDetails : UserControl
    {
        public PatientDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public string SelectedPatient { get { return lblSelectedPatient.Text; } set { lblSelectedPatient.Text = value; } }
        public string PatientName { get {  return lblPatientName.Text; } set { lblPatientName.Text = value; } }
        public string PatientID { get { return lblPatientID.Text; } set { lblPatientID.Text = value; } }
        public string Gender { get { return lblGender.Text; } set { lblGender.Text = value; } }
        public string Contact { get { return lblContact.Text; } set { lblContact.Text = value; } }
        public string Age { get { return lblAge.Text; } set { lblAge.Text = value; } }
        public string Address { get { return lblAddress.Text; } set { lblAddress.Text = value; } }
        public string Birthdate { get { return lblBirthdate.Text; } set { lblBirthdate.Text = value; } }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
           
        }
    }
}
