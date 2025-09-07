using KinesiaAPI.Data;
using KinesiaLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinesiaLibrary;

namespace KinesiaAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if(user == null)
            {
                return new LoginResponse { Success = false, Message = "Username cannot be found" };
            }

            // will check if the password and hashed + salted password input is the same
            var hashedInput = CustomSecurity.HashPassword(request.Password, user.Salt);

            if(hashedInput != user.Password)
            {
                return new LoginResponse { Success = false, Message = "Username or Password incorrect" };
            }

            return new LoginResponse { Success = true, Message = "Login Successful", UserID = user.UserID };
        }
    }
}
