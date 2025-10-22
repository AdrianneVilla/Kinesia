using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.PatientDTOs
{
    public class DisplayPatientsDTO
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
    }
}
