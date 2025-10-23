using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class ROM
    {
        [Key]
        public int ROMID { get; set; }
        public required string AssessmentID { get; set; }
        public required string UserID { get; set; }
        public required string GoniometerType { get; set; }
        public required double StartingPosition { get; set; }
        public required double Rom { get; set; }
        public required string Movement { get; set; }
        public required string MotionType { get; set; }
        public required DateTime Date { get; set; }
    }
}
