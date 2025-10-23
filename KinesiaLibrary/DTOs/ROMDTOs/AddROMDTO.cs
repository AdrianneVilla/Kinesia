using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ROMDTOs
{
    public class AddROMDTO
    {
        public string AssessmentID { get; set; }
        public string UserID { get; set; }
        public string GoniometerType { get; set; }
        public double StartingPosition { get; set; }
        public double Rom { get; set; }
        public string Movement { get; set; }
        public string MotionType { get; set; }
        public DateTime Date { get; set; }
    }
}
