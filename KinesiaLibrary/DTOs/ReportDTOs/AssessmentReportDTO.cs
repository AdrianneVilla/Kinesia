using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class AssessmentReportDTO
    {
        public string AssessmentID { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Extremity { get; set; }
        public string Joint { get; set; }
        public string JointSide { get; set; }
        public string AssessmentStatus { get; set; }
        public DateTime AssessmentDate { get; set; }
    }
}
