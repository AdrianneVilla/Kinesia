using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.AssessmentDTOs
{
    public class DisplayAssessmentsDTO
    {
        public string AssessmentID { get; set; }
        public string PatientName { get; set; }
        public string PatientID { get; set; }
        public string Extremity { get; set; }
        public string Joint { get; set; }
        public string AssessmentStatus { get; set; }
    }
}
