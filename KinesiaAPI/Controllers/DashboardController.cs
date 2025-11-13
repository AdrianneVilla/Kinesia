using KinesiaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using KinesiaLibrary.DTOs.DashboardDTOs;
using KinesiaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/dashboard/completion-rate?month={}&year={}
        [HttpGet("completion-rate")]
        public async Task<ActionResult<IEnumerable<CompletionRateDTO>>> GetCompletionRate(int month, int year)
        {
            var targetMonthStart = new DateTime(year, month, 1);
            var startDateInclusive = targetMonthStart.AddMonths(-5);
            var endDateExclusive = targetMonthStart.AddMonths(1);

            var allMonths = new List<DateTime>();
            var monthIterator = startDateInclusive;

            while (monthIterator <= targetMonthStart)
            {
                allMonths.Add(monthIterator);
                monthIterator = monthIterator.AddMonths(1);
            }

            var dbData = await _context.Assessments
                .Where(a =>
                    a.AssessmentDate >= startDateInclusive &&
                    a.AssessmentDate < endDateExclusive
                )
                .GroupBy(a => new { a.AssessmentDate.Year, a.AssessmentDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Completed = g.Count(a => a.AssessmentStatus == 2),
                    Ongoing = g.Count(a => a.AssessmentStatus == 1)
                })
                .ToListAsync();

            var result = allMonths.Select(monthDate =>
            {
                var dataForThisMonth = dbData.FirstOrDefault(d =>
                    d.Year == monthDate.Year &&
                    d.Month == monthDate.Month);

                int completed = dataForThisMonth?.Completed ?? 0;
                int ongoing = dataForThisMonth?.Ongoing ?? 0;
                int totalRelevant = completed + ongoing;

                return new CompletionRateDTO
                {
                    Month = monthDate.ToString("MMM"),
                    Completed = completed,
                    Ongoing = ongoing,
                    CompletionRate = (totalRelevant == 0) ? 0 : Math.Round((((double)completed / totalRelevant) * 100), 2)
                };
            });

            return Ok(result);
        }

        // GET: api/dashboard/joint-distribution?month={}&year={}
        [HttpGet("joint-distribution")]
        public async Task<ActionResult<IEnumerable<JointDTO>>> GetJointDistribution(int month, int year)
        {
            var jointCounts = await _context.Assessments
                .Where(a =>
                    a.AssessmentDate.Month == month && a.AssessmentDate.Year == year)
                .GroupBy(a => a.Joint)
                .Select(g => new
                {
                    Joint = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            double totalAssessments = jointCounts.Sum(j => j.Count);

            if (totalAssessments == 0)
            {
                return Ok(new List<JointDTO>());
            }

            var result = jointCounts.Select(data => new JointDTO
            {
                Joint = data.Joint,

                Percentage = Math.Round(((data.Count / totalAssessments) * 100), 2)
            })
            .OrderByDescending(j => j.Percentage)
            .ToList();

            return Ok(result);
        }

        // GET: api/dashboard/extremity-comparison?month={}&year={}
        [HttpGet("extremity-comparison")]
        public async Task<ActionResult<IEnumerable<ExtremityDTO>>> GetExtremityComparison(int month, int year)
        {
            var extremityData = await _context.Assessments
                .Where(a =>
                    a.AssessmentDate.Month == month && a.AssessmentDate.Year == year)
                .GroupBy(a => a.Extremity)
                .Select(g => new
                {
                    Extremity = g.Key,
                    Finished = g.Count(a => a.AssessmentStatus == 2),
                    Ongoing = g.Count(a => a.AssessmentStatus == 1)
                }).ToListAsync();

            var result = extremityData.Select(data => new ExtremityDTO
            {
                Extremity = data.Extremity,
                Finished = data.Finished,
                Ongoing = data.Ongoing,
                Total = data.Finished + data.Ongoing
            }).ToList();

            return Ok(result);
        }

        // GET: api/dashboard/activity-count
        [HttpGet("activity-count")]
        public async Task<ActionResult<IEnumerable<LogActivityDTO>>> GetActivityCount()
        {
            var today = DateTime.Now.Date;

            var endDateExclusive = today.AddDays(1);

            var startDateInclusive = today.AddDays(-6);

            var activityCounts = await _context.Logs
                .Where(log =>
                    log.LogDate >= startDateInclusive &&
                    log.LogDate < endDateExclusive)
                .GroupBy(log => log.LogType)
                .Select(g => new LogActivityDTO
                {
                    LogType = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(dto => dto.Count)
                .ToListAsync();

            return Ok(activityCounts);
        }
    }
}
