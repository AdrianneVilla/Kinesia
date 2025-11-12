using Kinesia.Properties;
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
    public partial class ConfigureROM : Form
    {
        public ConfigureROM()
        {
            InitializeComponent();
        }

        private void ConfigureROM_Load(object sender, EventArgs e)
        {
            txtShoulderFlexion.Texts = ROMConfiguration.ShoulderFlexion.ToString();
            txtShoulderExtension.Texts = ROMConfiguration.ShoulderExtension.ToString();
            txtElbowFlexion.Texts = ROMConfiguration.ElbowFlexion.ToString();
            txtElbowExtension.Texts = ROMConfiguration.ElbowExtension.ToString();
            txtKneeFlexion.Texts = ROMConfiguration.KneeFlexion.ToString();
            txtKneeExtension.Texts = ROMConfiguration.KneeExtension.ToString();
            txtHipFlexion.Texts = ROMConfiguration.HipFlexion.ToString();
            txtHipExtension.Texts = ROMConfiguration.HipExtension.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ROMConfiguration.ShoulderFlexion = Convert.ToDouble(txtShoulderFlexion.Texts);
            ROMConfiguration.ShoulderExtension = Convert.ToDouble(txtElbowExtension.Texts);
            ROMConfiguration.ElbowFlexion = Convert.ToDouble(txtElbowFlexion.Texts);
            ROMConfiguration.ElbowExtension = Convert.ToDouble(txtElbowExtension.Texts);
            ROMConfiguration.KneeFlexion = Convert.ToDouble(txtKneeFlexion.Texts);
            ROMConfiguration.KneeExtension = Convert.ToDouble(txtKneeExtension.Texts);
            ROMConfiguration.HipFlexion = Convert.ToDouble(txtHipFlexion.Texts);
            ROMConfiguration.HipExtension = Convert.ToDouble(txtHipExtension.Texts);
            ROMConfiguration.NotifyChange();
            ROMConfiguration.Save();

            this.Close();
        }
    }
}
