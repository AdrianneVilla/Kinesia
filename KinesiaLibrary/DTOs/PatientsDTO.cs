using System;

namespace KinesiaLibrary.DTOs
{
    public class PatientsDTO
    {
        public string PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? LastArchiveDate { get; set; }
        public int Status { get; set; }
    }
}
