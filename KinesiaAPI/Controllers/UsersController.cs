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
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers(
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
                .Select(u => UsersToDTO(u))
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

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, Users users)
        {
            if (id != users.UserID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

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
                Gender = users.Gender,
                Contact = users.Contact,
                Address = users.Address,
                Role = users.Role,
                DateAdded = users.DateAdded,
                LastArchiveDate = users.LastArchiveDate,
                Status = users.Status
            };
    }
}
