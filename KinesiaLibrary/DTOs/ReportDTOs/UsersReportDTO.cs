using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class UsersReportDTO
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
        public string DateAdded { get; set; }
        public string LastArchiveDate { get; set; } = "";
        public string Status { get; set; }
    }
}
