namespace KinesiaLibrary.DTOs.AuthDTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public string UserLastName { get; set; }
        public string Role { get; set; }
    }
}
