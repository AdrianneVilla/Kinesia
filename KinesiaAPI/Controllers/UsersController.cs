using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary.DTOs;

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

            return await query
                .Select(u => UsersToDisplayUsersDTO(u))
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> GetUsers(string id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return UsersToDTO(users);
        }

        // POST: api/users/check-existing
        [HttpPost("check-existing")]
        public async Task<IActionResult> CheckExistingUser(CheckExistingUserDTO existingUser)
        {
            if (existingUser == null)
            {
                return BadRequest("Invalid user data.");
            }

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
                return BadRequest("Patient ID is required and must match the URL parameter");
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsers", new { id = users.UserID }, users);
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
                DateAdded = users.DateAdded,
                LastArchiveDate = users.LastArchiveDate.HasValue ? users.LastArchiveDate.Value.ToString() : "N/A",
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
    }
}
