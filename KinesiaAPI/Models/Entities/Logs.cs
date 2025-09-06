using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class Logs
    {
        [Key]
        public required string LogID { get; set; }
        public required string UserID { get; set; }
    }
}
