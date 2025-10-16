using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary.DTOs.UserDTOs
{
    public class UserUpdateStatusDTO
    {
        public string UserID { get; set; }
        public DateTime LastArchiveDate { get; set; }
        public int Status { get; set; }
    }
}
