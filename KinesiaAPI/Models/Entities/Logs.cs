using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class Logs
    {
        [Key]
        public required string LogID { get; set; }
        public required string UserID { get; set; }
        public required string LogType { get; set; }
        public required string Description { get; set; }
        public required DateTime LogDate { get; set; }
    }
}
