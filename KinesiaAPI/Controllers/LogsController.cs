using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary.DTOs.LogDTOs;
using KinesiaLibrary.DTOs.ReportDTOs;
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
            string? searchData = null,
            string? currentTab = null,
            string? sortColumn = null)
        {
            try
            {
                var query = from l in _context.Logs
                            join u in _context.Users on l.UserID equals u.UserID
                            select new LogDTO
                            {
                                LogID = l.LogID,
                                LogType = l.LogType,
                                Username = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                Description = l.Description,
                                LogDate = l.LogDate
                            };

                // will apply filters
                if (!string.IsNullOrEmpty(currentTab) && currentTab != "All")
                {
                    query = query.Where(x => x.LogType == currentTab);
                }

                if (!string.IsNullOrEmpty(searchData))
                {
                    query = query.Where(x =>
                            x.LogID.Contains(searchData));
                }

                // will apply sorting
                if (sortColumn == "Latest")
                {
                    query = query.OrderByDescending(x => x.LogDate);
                }
                else
                {
                    query = query.OrderBy(x => x.LogDate);
                }

                var logs =  await query.ToListAsync();

                return Ok(logs);
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

        // GET: api/logs/dashboard
        [HttpGet("dashboard")]
        public async Task<ActionResult<IEnumerable<DisplayDashboardLogsDTO>>> GetDashboardLogs()
        {
            var query = (from l in _context.Logs
                         join u in _context.Users on l.UserID equals u.UserID
                         orderby l.LogDate descending
                         select new DisplayDashboardLogsDTO
                         {
                             LogID = l.LogID,
                             LogType = l.LogType,
                             User = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                             LogDescription = l.Description,
                             LogDate = l.LogDate
                         }).Take(10);

            var logs = await query.ToListAsync();

            return Ok(logs);
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

        // GET: api/logs/generate-logid
        [HttpGet("generate-logid")]
        public async Task<ActionResult<string>> GenerateNewLogID()
        {
            try
            {
                var nextCount = await _context.Database
                    .SqlQueryRaw<long>("SELECT NEXTVAL(log_id_seq) AS value")
                    .FirstAsync();

                string newLogID = $"LOG{nextCount}";

                return Ok(newLogID);
            }
            catch (DbException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Unexpected error: {ex.Message}");
            }
        }

        // GET: api/logs/generate-today-report
        [HttpGet("generate-today-report")]
        public async Task<ActionResult<IEnumerable<LogReportDTO>>> GenerateTodayReport()
        {
            try
            {
                var query = from l in _context.Logs
                            join u in _context.Users on l.UserID equals u.UserID
                            where l.LogDate == DateTime.Today
                            orderby l.LogDate descending
                            select new LogReportDTO
                            {
                                LogID = l.LogID,
                                UserID = l.UserID,
                                UserName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                LogType = l.LogType,
                                LogDescription = l.Description,
                                LogDate = l.LogDate
                            };

                var logs = await query.ToListAsync();

                return Ok(logs);
            }
            catch (DbException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Unexpected error: {ex.Message}");
            }
        }

        // GET: api/logs/generate-weekly-report
        [HttpGet("generate-weekly-report")]
        public async Task<ActionResult<IEnumerable<LogReportDTO>>> GenerateWeeklyReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                var weekStart = startDate;
                var weekEnd = endDate.Date.AddDays(1);

                var query = from l in _context.Logs
                            join u in _context.Users on l.UserID equals u.UserID
                            where l.LogDate >= weekStart && l.LogDate < weekEnd
                            orderby l.LogDate descending
                            select new LogReportDTO
                            {
                                LogID = l.LogID,
                                UserID = l.UserID,
                                UserName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                LogType = l.LogType,
                                LogDescription = l.Description,
                                LogDate = l.LogDate
                            };

                var logs = await query.ToListAsync();

                return Ok(logs);
            }
            catch (DbException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Unexpected error: {ex.Message}");
            }
        }

        // GET: api/logs/generate-report?month={}&year={}
        [HttpGet("generate-monthly-report")]
        public async Task<ActionResult<IEnumerable<LogReportDTO>>> GenerateMonthlyReport(int month, int year)
        {
            try
            {
                var query = from l in _context.Logs
                            join u in _context.Users on l.UserID equals u.UserID
                            where l.LogDate.Month == month && l.LogDate.Year == year
                            orderby l.LogDate descending
                            select new LogReportDTO
                            {
                                LogID = l.LogID,
                                UserID = l.UserID,
                                UserName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                LogType = l.LogType,
                                LogDescription = l.Description,
                                LogDate = l.LogDate
                            };

                var logs = await query.ToListAsync();

                return Ok(logs);
            }
            catch (DbException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Unexpected error: {ex.Message}");
            }
        }

        // GET: api/logs/generate-yearly-report?year={}
        [HttpGet("generate-yearly-report")]
        public async Task<ActionResult<IEnumerable<LogReportDTO>>> GenerateYearlyReport(int year)
        {
            try
            {
                var query = from l in _context.Logs
                            join u in _context.Users on l.UserID equals u.UserID
                            where l.LogDate.Year == year
                            orderby l.LogDate descending
                            select new LogReportDTO
                            {
                                LogID = l.LogID,
                                UserID = l.UserID,
                                UserName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                LogType = l.LogType,
                                LogDescription = l.Description,
                                LogDate = l.LogDate
                            };

                var logs = await query.ToListAsync();

                return Ok(logs);
            }
            catch (DbException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Unexpected error: {ex.Message}");
            }
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
