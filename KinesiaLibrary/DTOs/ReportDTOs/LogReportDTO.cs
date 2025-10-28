using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ReportDTOs
{
    public class LogReportDTO
    {
        public string LogID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string LogType { get; set; }
        public string LogDescription { get; set; }
        public DateTime LogDate { get; set; }
    }
}
