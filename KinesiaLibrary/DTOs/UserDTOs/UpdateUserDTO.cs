using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public string UserID { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; } = "";
        public string Contact { get; set; } = "";
        public string Role { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Salt { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
