using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class PatientReportDTO
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string DateAdded { get; set; }
        public string LastArchiveDate { get; set; } = "";
        public int Status { get; set; }
    }
}
