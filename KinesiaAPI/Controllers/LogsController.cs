using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary.DTOs.LogDTOs;

namespace KinesiaAPI.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDTO>>> GetLogs(
            string? searchData,
            string? currentTab = "All",
            string? sortColumn = "Latest")
        {
            var query = from l in _context.Logs
                        join u in _context.Users on l.UserID equals u.UserID
                        select new LogDTO
                        {
                            LogID = l.LogID,
                            LogType = l.LogType,
                            FirstName = u.FirstName,
                            MiddleName = u.MiddleName,
                            LastName = u.LastName,
                            Description = l.Description,
                            LogDate = l.LogDate
                        };

            // will apply filters
            if(!string.IsNullOrEmpty(currentTab) && currentTab != "All")
            {
                query = query.Where(x => x.LogType == currentTab);
            }

            if (!string.IsNullOrEmpty(searchData))
            {
                query = query.Where(x =>
                        x.LogID.Contains(searchData) ||
                        x.FirstName.Contains(searchData) ||
                        x.MiddleName.Contains(searchData) ||
                        x.LastName.Contains(searchData));
            }

            // will apply sorting
            if(sortColumn == "Latest")
            {
                query = query.OrderBy(x => x.LogDate);
            }
            else
            {
                query = query.OrderByDescending(x => x.LogDate);
            }

            return await query.ToListAsync();
        }

        // GET: api/Logs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logs>> GetLogs(string id)
        {
            var logs = await _context.Logs.FindAsync(id);

            if (logs == null)
            {
                return NotFound();
            }

            return logs;
        }

        // PUT: api/Logs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogs(string id, Logs logs)
        {
            if (id != logs.LogID)
            {
                return BadRequest();
            }

            _context.Entry(logs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogsExists(id))
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

        // POST: api/Logs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Logs>> PostLogs(Logs logs)
        {
            _context.Logs.Add(logs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogsExists(logs.LogID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogs", new { id = logs.LogID }, logs);
        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogs(string id)
        {
            var logs = await _context.Logs.FindAsync(id);
            if (logs == null)
            {
                return NotFound();
            }

            _context.Logs.Remove(logs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogsExists(string id)
        {
            return _context.Logs.Any(e => e.LogID == id);
        }
    }
}
