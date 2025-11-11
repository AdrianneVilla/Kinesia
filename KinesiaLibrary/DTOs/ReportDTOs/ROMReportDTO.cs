using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class ROMReportDTO
    {
        public string TherapistName { get; set; }
        public string GoniometerType { get; set; }
        public double StartingPosition{ get; set; }
        public double Rom { get; set; }
        public double NormalRom { get; set; }
        public double Deficit { get; set; }
        public string Movement { get; set; }
        public string MotionType { get; set; }
        public string Date { get; set; }
    }
}
