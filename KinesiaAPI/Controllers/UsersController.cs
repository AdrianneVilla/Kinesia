using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.ReportDTOs;
using KinesiaLibrary.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KinesiaAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/users?searchData={}&currentTab={}&sortColumn={}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayUsersDTO>>> GetUsers(
            string? searchData = null,
            string? currentTab = null,
            string? sortColumn = "UserID")
        {
            try
            {
                var query = _context.Users.AsQueryable();

                // will filter by Active / Inactive
                if (currentTab == "Active")
                {
                    query = query.Where(u => u.Status == 1);
                }
                else if (currentTab == "Inactive")
                {
                    query = query.Where(u => u.Status == 0);
                }

                // search
                if (!string.IsNullOrEmpty(searchData))
                {
                    query = query.Where(u =>
                    u.UserID.Contains(searchData) ||
                    u.FirstName.Contains(searchData) ||
                    u.LastName.Contains(searchData) ||
                    u.MiddleName.Contains(searchData));
                }

                // sorting
                bool desc = true;
                switch (sortColumn)
                {
                    case "Alphabetic (Name)":
                        query = query.OrderBy(u => u.FirstName);
                        break;
                    case "Earliest (Date Added)":
                        query = query.OrderByDescending(u => u.DateAdded);
                        break;
                    case "Latest (Date Added)":
                        query = query.OrderBy(u => u.DateAdded);
                        desc = false;
                        break;
                    default:
                        query = query.OrderByDescending(u => u.UserID);
                        break;
                }

                var users = await query
                    .Select(u => UsersToDisplayUsersDTO(u))
                    .ToListAsync();

                return Ok(users);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> GetUsers(string id)
        {
            try
            {
                var users = await _context.Users.FindAsync(id);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(UsersToDTO(users));
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/edit?userID={}
        [HttpGet("edit")]
        public async Task<ActionResult<UserToEditDTO>> GetUserToEdit(string userID)
        {
            try
            {
                var user = await _context.Users.FindAsync(userID);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/total-users?status={}
        [HttpGet("total-users")]
        public async Task<ActionResult<int>> GetTotalUsersByStatus(int? status)
        {
            try
            {
                var query = _context.Users.AsQueryable();

                if (status == 0)
                {
                    query = query.Where(u => u.Status == 0);
                }
                else if (status == 1)
                {
                    query = query.Where(u => u.Status == 1);
                }

                var totalCount = await query.CountAsync();

                return Ok(totalCount);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/generate-today-report
        [HttpGet("generate-today-report")]
        public async Task<ActionResult<IEnumerable<UsersReportDTO>>> GenerateTodayReport()
        {
            try
            {
                var query = _context.Users.AsQueryable();

                query = query.Where(u => u.DateAdded == DateTime.Now);

                var users = await query
                                .Select(u => UsersToUsersReportDTO(u))
                                .ToListAsync();

                return Ok(users);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/generate-weekly-report?startDate={}&endDate={}
        [HttpGet("generate-weekly-report")]
        public async Task<ActionResult<IEnumerable<UsersReportDTO>>> GenerateWeeklyReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                var query = _context.Users.AsQueryable();

                var weekStart = startDate.Date;
                var weekEnd = endDate.Date.AddDays(1);

                query = query.Where(u => u.DateAdded >= weekStart && u.DateAdded < weekEnd);

                var users = await query
                                    .Select(u => UsersToUsersReportDTO(u))
                                    .ToListAsync();

                return Ok(users);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/generate-monthly-report?month={}&year={}
        [HttpGet("generate-monthly-report")]
        public async Task<ActionResult<IEnumerable<UsersReportDTO>>> GenerateMonthlyReport(int month, int year)
        {
            try
            {
                var query = _context.Users.AsQueryable();

                query = query.Where(u => u.DateAdded.Month == month && u.DateAdded.Year == year);

                var users = await query
                            .Select(u => UsersToUsersReportDTO(u))
                            .ToListAsync();

                return Ok(users);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // GET: api/users/generate-yearly-report?year={}
        [HttpGet("generate-yearly-report")]
        public async Task<ActionResult<IEnumerable<UsersReportDTO>>> GenerateYearlyReport(int year)
        {
            try
            {
                var query = _context.Users.AsQueryable();

                query = query.Where(u => u.DateAdded.Year == year);

                var users = await query
                        .Select(u => UsersToUsersReportDTO(u))
                        .ToListAsync();

                return Ok(users);
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // POST: api/users/check-existing
        [HttpPost("check-existing")]
        public async Task<IActionResult> CheckExistingUser(CheckExistingUserDTO existingUser)
        {
            if (existingUser == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                bool exist = await _context.Users.AnyAsync(u =>
                u.FirstName == existingUser.FirstName &&
                u.LastName == existingUser.LastName &&
                u.MiddleName == existingUser.MiddleName);

                if (exist)
                {
                    return Conflict();
                }

                return Ok();
            }
            catch(DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // POST: api/users/check-existing-account?username={}
        [HttpGet("check-existing-account")]
        public async Task<IActionResult> CheckExistingAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Invalid username.");
            }

            try
            {
                bool exist = await _context.Users.AnyAsync(u => u.Username == username);

                if (exist)
                {
                    return Conflict();
                }

                return Ok();
            }
            catch (DbException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured on database.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        } 

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, UpdateUserDTO updatedUser)
        {
            if (string.IsNullOrEmpty(updatedUser.UserID) || id != updatedUser.UserID)
            {
                return BadRequest("Patient ID is required and must match the URL parameter");
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (!string.IsNullOrEmpty(updatedUser.FirstName))
                existingUser.FirstName = updatedUser.FirstName;

            if (!string.IsNullOrEmpty(updatedUser.LastName))
                existingUser.LastName = updatedUser.LastName;

            if (!string.IsNullOrEmpty(updatedUser.MiddleName))
                existingUser.MiddleName = updatedUser.MiddleName;

            if (updatedUser.Birthdate.HasValue)
                existingUser.Birthdate = updatedUser.Birthdate.Value;

            if (!string.IsNullOrEmpty(updatedUser.Gender))
                existingUser.Gender = updatedUser.Gender;

            if (!string.IsNullOrEmpty(updatedUser.Contact))
                existingUser.Contact = updatedUser.Contact;

            if (!string.IsNullOrEmpty(updatedUser.Role))
                existingUser.Role = updatedUser.Role;

            if (!string.IsNullOrEmpty(updatedUser.Username))
                existingUser.Username = updatedUser.Username;

            if (!string.IsNullOrEmpty(updatedUser.Password))
                existingUser.Password = updatedUser.Password;

            if (!string.IsNullOrEmpty(updatedUser.Salt))
                existingUser.Salt = updatedUser.Salt;

            if (!string.IsNullOrEmpty(updatedUser.Email))
                existingUser.Email = updatedUser.Email;

            if (!string.IsNullOrEmpty(updatedUser.Address))
                existingUser.Address = updatedUser.Address;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/users/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(string id, UserUpdateStatusDTO updatedUser)
        {
            if (string.IsNullOrEmpty(updatedUser.UserID) || id != updatedUser.UserID)
            {
                return BadRequest("User ID is required and must match the URL parameter");
            }

            var existingUser = await _context.Users.FindAsync(id);

            existingUser.LastArchiveDate = updatedUser.LastArchiveDate;
            existingUser.Status = updatedUser.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/users/reset-password?userID={}
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID is required and must match the URL parameter");
            }

            var existingUser = await _context.Users.FindAsync(id);

            string salt = CustomSecurity.GenerateSalt();
            string newPassword = $"{existingUser.Username}.{existingUser.Birthdate.ToString("yyyyMMdd")}";
            existingUser.Password = CustomSecurity.HashPassword(newPassword, salt);
            existingUser.Salt = salt;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/users/change-password?userID={}
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(string id, string password, string oldPassword)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID is required and must match the URL parameter");
            }

            var existingUser = await _context.Users.FindAsync(id);

            if(existingUser.Password != CustomSecurity.HashPassword(oldPassword, existingUser.Salt))
            {
                return BadRequest("Invalid old password");
            }

            string salt = CustomSecurity.GenerateSalt();
            string newPassword = CustomSecurity.HashPassword(password, salt);
            existingUser.Password = newPassword;
            existingUser.Salt = salt;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(AddUserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("User data cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var nextCount = await _context.Database
                    .SqlQueryRaw<long>("SELECT NEXTVAL(user_id_seq) as value")
                    .FirstAsync();

                string newUserID = $"USER{nextCount}";

                // will generate salt for hashing
                // salt will be unique for every user
                var salt = CustomSecurity.GenerateSalt();
                var hashedPassword = CustomSecurity.HashPassword(userDTO.Password, salt);

                var newUser = new Users
                {
                    UserID = newUserID,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    MiddleName = userDTO.MiddleName,
                    Birthdate = userDTO.Birthdate,
                    Gender = userDTO.Gender,
                    Contact = ContactHelper.ContactFormatter(userDTO.Contact),
                    Address = userDTO.Address,
                    Role = userDTO.Role,
                    Username = userDTO.Username,
                    Email = userDTO.Email,
                    Password = hashedPassword,
                    Salt = salt,
                    DateAdded = DateTime.Now,
                    LastArchiveDate = null,
                    Status = 1
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return CreatedAtAction("GetUsers", new { id = newUser.UserID }, newUser);
            }
            catch (DbUpdateException)
            {
                if (UsersExists(userDTO.UserID))
                {
                    return Conflict("User already exists.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while saving the user data.\n" +
                        "Please try again.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            } 
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        private static UsersDTO UsersToDTO(Users users) =>
            new UsersDTO
            {
                UserID = users.UserID,
                FirstName = users.FirstName,
                LastName = users.LastName,
                MiddleName = users.MiddleName,
                Birthdate = users.Birthdate,
                Age = (int)((DateTime.Now - users.Birthdate).TotalDays / 365.25),
                Gender = users.Gender,
                Contact = users.Contact,
                Address = users.Address,
                Role = users.Role,
                Email = users.Email,
                Username = users.Username,
                DateAdded = users.DateAdded,
                LastArchiveDate = users.LastArchiveDate.HasValue ? users.LastArchiveDate.Value.ToString() : "--",
                Status = users.Status
            };

        public static DisplayUsersDTO UsersToDisplayUsersDTO(Users users) =>
            new DisplayUsersDTO
            {
                UserID = users.UserID,
                UserName = $"{users.FirstName} {users.MiddleName} {users.LastName}",
                Role = users.Role,
                Status = users.Status == 1 ? "Active" : "Inactive"
            };

        public static UsersReportDTO UsersToUsersReportDTO(Users users) =>
            new UsersReportDTO
            {
                UserID = users.UserID,
                Name = $"{users.FirstName} {users.MiddleName} {users.LastName}",
                Contact = users.Contact,
                Role = users.Role,
                DateAdded = users.DateAdded.ToString("yyyy-MM-dd"),
                LastArchiveDate = users.LastArchiveDate.HasValue ? users.LastArchiveDate.Value.ToString("yyyy-MM-dd") : "--",
                Status = users.Status == 1 ? "Active" : "Inactive"
            };
    }
}
