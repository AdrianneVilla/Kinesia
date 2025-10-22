using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.AssessmentDTOs
{
    public class AddAssessmentDTO
    {
        public string AssessmentID { get; set; }
        public string PatientID { get; set; }
        public string Extremity { get; set; }
        public string Joint { get; set; }
        public string JointSide { get; set; }
        public int AssessmentStatus { get; set; }
        public DateTime AssessmentDate { get; set; }
    }
}
