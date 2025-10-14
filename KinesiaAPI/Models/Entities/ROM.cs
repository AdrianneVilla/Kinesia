using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class ROM
    {
        [Key]
        public required string ROMID { get; set; }
        public required string AssessmentID { get; set; }
        public required string UserID { get; set; }
        public required int InitialROM { get; set; }
        public required int EndROM { get; set; }
        public required string Movement { get; set; }
        public required string MotionType { get; set; }
        public string? Subjective { get; set; }
        public string? Objective { get; set; }
        public required string Deviation { get; set; }
        public required DateTime Date { get; set; }
    }
}
