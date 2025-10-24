using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.AssessmentDTOs
{
    public class DisplayPatientAssessmentsDTO
    {
        public string AssessmentID { get; set; }
        public string Extremity { get; set; }
        public string Joint { get; set; }
        public string AssessmentStatus { get; set; }
        public string AssessmentStartDate { get; set; }
        public string AssessmentEndDate { get; set; }
    }
}
