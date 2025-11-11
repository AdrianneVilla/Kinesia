using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary
{
    public class ROMHelper
    {
        private static double ShoulderFlexion, ShoulderExtension,
                               ElbowFlexion, ElbowExtension,
                               HipFlexion, HipExtension,
                               KneeFlexion, KneeExtension;

        public static void InitializeFromConfig(
            Func<double> getShoulderFlexion,
            Func<double> getShoulderExtension,
            Func<double> getElbowFlexion,
            Func<double> getElbowExtension,
            Func<double> getHipFlexion,
            Func<double> getHipExtension,
            Func<double> getKneeFlexion,
            Func<double> getKneeExtension)
        {
            ShoulderFlexion = getShoulderFlexion();
            ShoulderExtension = getShoulderExtension();
            ElbowFlexion = getElbowFlexion();
            ElbowExtension = getElbowExtension();
            HipFlexion = getHipFlexion();
            HipExtension = getHipExtension();
            KneeFlexion = getKneeFlexion();
            KneeExtension = getKneeExtension();
        }

        public static void ReloadFrom(Func<string, double> getValue)
        {
            ShoulderFlexion = getValue("ShoulderFlexion");
            ShoulderExtension = getValue("ShoulderExtension");
            ElbowFlexion = getValue("ElbowFlexion");
            ElbowExtension = getValue("ElbowExtension");
            HipFlexion = getValue("HipFlexion");
            HipExtension = getValue("HipExtension");
            KneeFlexion = getValue("KneeFlexion");
            KneeExtension = getValue("KneeExtension");
        }
        public static double CalculateDeficit(double rom, string joint, string movement)
        {
            double normalROM = GetNormalRange(joint, movement);

            return normalROM - rom;
        }

        public static double GetNormalRange(string joint, string movement)
        {
            if (joint == "Shoulder")
            {
                if (movement == "Flexion")
                {
                    return ShoulderFlexion;
                }
                else if (movement == "Extension")
                {
                    return ShoulderExtension;
                }
            }
            else if (joint == "Elbow and Forearm")
            {
                if (movement == "Flexion")
                {
                    return ElbowFlexion;
                }
                else if (movement == "Extension")
                {
                    return ElbowExtension;
                }
            }
            else if (joint == "Hip")
            {
                if (movement == "Flexion")
                {
                    return HipFlexion;
                }
                else if (movement == "Extension")
                {
                    return HipExtension;
                }
            }
            else if (joint == "Knee")
            {
                if (movement == "Flexion")
                {
                    return KneeFlexion;
                }
                else if (movement == "Extension")
                {
                    return KneeExtension;
                }
            }

            return 0;
        }
    }
}
