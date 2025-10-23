using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary.DTOs.ROMDTOs
{
    public class DisplayROMsDTO
    {
        public string TherapistName { get; set; }
        public double StartingPosition { get; set; }
        public double Rom { get; set; }
        public double NormalRange { get; set; }
        public double Deficit { get; set; }
        public string Movement { get; set; }
        public string Date { get; set; }
    }
}
