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
    public partial class PatientAssessmentDetails : UserControl
    {
        public PatientAssessmentDetails()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public string PatientID { get { return lblPatientID.Text; } set { lblPatientID.Text = value; } }
        public string PatientName { get { return lblPatientName.Text; } set { lblPatientName.Text = value; } }
        public string Age { get { return lblAge.Text; } set { lblAge.Text = value; } }
        public string Gender { get { return lblGender.Text; } set { lblGender.Text = value; } }
        public string Extremity { get { return cbExtremity.Texts; } }
        public string Joint { get { return cbJoint.Texts; } }
        public string JointSide { get { return cbJointSide.Texts; } }

        private void cbExtremity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cbJoint.Items.Clear();

            cbJoint.Texts = "Select Joint";
            cbJointSide.Texts = "Select Joint Side";

            if(cbExtremity.Texts.Equals("Upper Extremity"))
            {
                cbJoint.Items.Add("Shoulder");
                cbJoint.Items.Add("Elbow and Forearm");
            }
            else if(cbExtremity.Texts.Equals("Lower Extremity"))
            {
                cbJoint.Items.Add("Hip");
                cbJoint.Items.Add("Knee");
            }
        }
    }
}
