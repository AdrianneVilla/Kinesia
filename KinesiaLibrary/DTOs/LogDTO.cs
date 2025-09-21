using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary.DTOs
{
    public class LogDTO
    {
        public string LogID { get; set; }
        public string LogType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime LogDate { get; set; }
    }
}
