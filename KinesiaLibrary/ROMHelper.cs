using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary
{
    public class ROMHelper
    {
        public static double CalculateDeficit(double rom, string joint, string movement)
        {
            if(joint == "Shoulder")
            {
                if(movement == "Flexion")
                {
                    return 180 - rom;
                }
                else if(movement == "Extension")
                {
                     return 60 - rom;
                }
            }
            else if(joint == "Elbow and Forearm")
            {
                if(movement == "Flexion")
                {
                    return 150 - rom;
                }
                else if(movement == "Extension")
                {
                    return 0 - rom;
                }
            }
            else if(joint == "Hip")
            {
                if(movement == "Flexion")
                {
                    return 120 - rom;
                }
                else if(movement == "Extension")
                {
                    return 30 - rom;
                }
            }
            else if(joint == "Knee")
            {
                if(movement == "Flexion")
                {
                    return 135 - rom;
                }
                else if(movement == "Extension")
                {
                    return 0 - rom;
                }
            }

            return 0;
        }

        public static double GetNormalRange(string joint, string movement)
        {
            if (joint == "Shoulder")
            {
                if (movement == "Flexion")
                {
                    return 180;
                }
                else if (movement == "Extension")
                {
                    return 60;
                }
            }
            else if (joint == "Elbow and Forearm")
            {
                if (movement == "Flexion")
                {
                    return 150;
                }
                else if (movement == "Extension")
                {
                    return 0;
                }
            }
            else if (joint == "Hip")
            {
                if (movement == "Flexion")
                {
                    return 120;
                }
                else if (movement == "Extension")
                {
                    return 30;
                }
            }
            else if (joint == "Knee")
            {
                if (movement == "Flexion")
                {
                    return 135;
                }
                else if (movement == "Extension")
                {
                    return 0;
                }
            }

            return 0;
        }
    }
}
