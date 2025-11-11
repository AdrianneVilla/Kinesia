using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinesia.Properties
{
    public class ROMConfiguration
    {
        public static double ShoulderFlexion { 
            get { return Properties.Settings.Default.ShoulderFlexion; }
            set { Properties.Settings.Default.ShoulderFlexion = value; }
        }
        public static double ShoulderExtension { 
            get { return Properties.Settings.Default.ShoulderExtension; }
            set { Properties.Settings.Default.ShoulderExtension = value; }
        }
        public static double ElbowFlexion { 
            get { return Properties.Settings.Default.ElbowFlexion; }
            set { Properties.Settings.Default.ElbowFlexion = value; }
        }
        public static double ElbowExtension { 
            get { return Properties.Settings.Default.ElbowExtension; }
            set { Properties.Settings.Default.ElbowExtension = value; }
        }
        public static double HipFlexion { 
            get { return Properties.Settings.Default.HipFlexion; }
            set { Properties.Settings.Default.HipFlexion = value; }
        }
        public static double HipExtension { 
            get { return Properties.Settings.Default.HipExtension; }
            set { Properties.Settings.Default.HipExtension = value; }
        }
        public static double KneeFlexion { 
            get { return Properties.Settings.Default.KneeFlexion; }
            set { Properties.Settings.Default.KneeFlexion = value; }
        }
        public static double KneeExtension { 
            get { return Properties.Settings.Default.KneeExtension; } 
            set { Properties.Settings.Default.KneeExtension = value; }
        }

        public static event Action? OnConfigurationChanged;

        public static void NotifyChange()
        {
            // will notify subscribers
            OnConfigurationChanged?.Invoke();
        }

        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
