using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.PatientDTOs
{
    public class PatientBasicDTO
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
