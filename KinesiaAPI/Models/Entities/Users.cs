using System.ComponentModel.DataAnnotations;

namespace KinesiaAPI.Models.Entities
{
    public class Users
    {
        [Key]
        public required string UserID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public required DateTime Birthdate { get; set; }
        public required string Gender { get; set; }
        public required string Contact { get; set; }
        public required string Address { get; set; }
        public required string Role { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Salt { get; set; }
        public required string Email { get; set; }
        public required DateTime DateAdded { get; set; }
        public DateTime? LastArchiveDate { get; set; }
        public int Status { get; set; }
    }
}
