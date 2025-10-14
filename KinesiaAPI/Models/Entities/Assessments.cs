using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class Assessments
    {
        [Key]
        public required string AssessmentID { get; set; }
        public required string PatientID { get; set; }
        public required string Joint { get; set; }
        public required string JointType { get; set; }
        public required int Status { get; set; }
    }
}
