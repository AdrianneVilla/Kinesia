using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary.DTOs
{
    public class AddLogDTO
    {
        public string LogID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public string LogType { get; set; }
        public DateTime LogDate { get; set; }
    }
}
