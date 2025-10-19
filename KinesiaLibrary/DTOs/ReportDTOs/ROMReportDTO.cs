using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class ROMReportDTO
    {
        public string TherapistName { get; set; }
        public string GoniometerType { get; set; }
        public double InitialROM { get; set; }
        public double EndROM { get; set; }
        public string Movement { get; set; }
        public string MotionType { get; set; }
        public string Subjective { get; set; }
        public string Objective { get; set; }
        public string Deviation { get; set; }
        public DateTime Date { get; set; }
    }
}
