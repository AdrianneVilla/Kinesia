using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.DashboardDTOs
{
    public class ExtremityDTO
    {
        public string Extremity { get; set; }
        public int Finished { get; set; }
        public int Ongoing { get; set; }
        public int Total { get; set; }
    }
}
