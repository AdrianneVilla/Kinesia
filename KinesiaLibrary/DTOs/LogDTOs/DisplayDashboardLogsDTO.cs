using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.LogDTOs
{
    public class DisplayDashboardLogsDTO
    {
        public string LogID { get; set; }
        public string LogType { get; set; }
        public string User { get; set; }
        public string LogDescription { get; set; }
        public DateTime LogDate { get; set; }
    }
}
