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
        public required double InitialROM { get; set; }
        public required double EndROM { get; set; }
        public required string Movement { get; set; }
        public required string MotionType { get; set; }
        public string? Subjective { get; set; }
        public string? Objective { get; set; }
        public required string Deviation { get; set; }
        public required DateTime Date { get; set; }
    }
}
