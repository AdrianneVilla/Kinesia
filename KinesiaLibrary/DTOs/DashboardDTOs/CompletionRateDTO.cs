using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.DashboardDTOs
{
    public class CompletionRateDTO
    {
        public string Month { get; set; }
        public int Completed { get; set; }
        public double CompletionRate { get; set; }
        public int Ongoing { get; set; }
    }
}
