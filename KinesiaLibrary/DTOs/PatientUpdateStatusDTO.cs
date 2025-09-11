using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary.DTOs
{
    public class PatientUpdateStatusDTO
    {
        public string PatientID { get; set; }
        public int Status { get; set; }
    }
}
