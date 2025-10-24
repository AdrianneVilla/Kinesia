using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.AssessmentDTOs
{
    public class AssessmentUpdateStatusDTO
    {
        public string AssessmentID { get; set; }
        public DateTime? AssessmentEndDate { get; set; }
        public int AssessmentStatus { get; set; }
    }
}
