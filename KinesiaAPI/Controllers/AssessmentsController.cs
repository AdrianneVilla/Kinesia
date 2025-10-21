using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary.DTOs.AssessmentDTOs;
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
    [Route("api/assessment")]
    [ApiController]
    public class AssessmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssessmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Assessments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assessments>>> GetAssessments()
        {
            return await _context.Assessments.ToListAsync();
        }

        // GET: api/Assessments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentDTO>> GetAssessments(string id)
        {
            try
            {
                var result = await (from a in _context.Assessments
                                    join p in _context.Patients on a.PatientID equals p.PatientID
                                    where a.AssessmentID == id
                                    select new
                                    {
                                        a.AssessmentID,
                                        p.PatientID,
                                        p.FirstName,
                                        p.MiddleName,
                                        p.LastName,
                                        p.Birthdate,
                                        p.Gender,
                                        a.Extremity,
                                        a.Joint,
                                        a.JointSide,
                                        a.AssessmentStatus,
                                        a.AssessmentDate
                                    }).FirstOrDefaultAsync();

                var assessment = new AssessmentDTO
                {
                    AssessmentID = result.AssessmentID,
                    PatientID = result.PatientID,
                    PatientName = $"{result.FirstName} {result.MiddleName} {result.LastName}",
                    Age = (int)((DateTime.Now - result.Birthdate).TotalDays / 365.25),
                    Gender = result.Gender,
                    Extremity = result.Extremity,
                    Joint = result.Joint,
                    JointSide = result.JointSide,
                    AssessmentStatus = result.AssessmentStatus == 1 ? "Ongoing" : "Finished",
                    AssessmentDate = result.AssessmentDate.ToString("yyyy-MM-dd hh:mm")
                };

                if (assessment == null)
                {
                    return NotFound();
                }

                return Ok(assessment);
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

        // GET: api/assessment/generate-report?assessmentID={}
        [HttpGet("generate-report")]
        public async Task<ActionResult<AssessmentReportDTO>> GenerateAssessmentReport(string assessmentID)
        {
            var result = await (from a in _context.Assessments
                                join p in _context.Patients on a.PatientID equals p.PatientID
                                where a.AssessmentID == assessmentID
                                select new
                                {
                                    a.AssessmentID,
                                    p.PatientID,
                                    p.FirstName,
                                    p.MiddleName,
                                    p.LastName,
                                    p.Birthdate,
                                    p.Gender,
                                    a.Extremity,
                                    a.Joint,
                                    a.JointSide,
                                    a.AssessmentStatus,
                                    a.AssessmentDate
                                }).FirstOrDefaultAsync();

            var assessment = new AssessmentReportDTO
            {
                AssessmentID = assessmentID,
                PatientName = $"{result.FirstName} {result.MiddleName} {result.LastName}",
                Age = (int)((DateTime.Now - result.Birthdate).TotalDays / 365.25),
                Gender = result.Gender,
                Extremity = result.Extremity,
                Joint = result.Joint,
                JointSide = result.JointSide,
                AssessmentStatus = result.AssessmentStatus == 1 ? "Ongoing" : "Finished",
                AssessmentDate = result.AssessmentDate
            };

            return Ok(assessment);
        }

        // GET: api/assessment/total-ongoing-assessments?month={}&year={}
        [HttpGet("total-ongoing-assessments")]
        public async Task<ActionResult<int>> GetTotalOngoingAssessments(int month, int year)
        {
            try
            {
                var totalCount = await _context.Assessments
                .CountAsync(a => a.AssessmentStatus == 1 &&
                            a.AssessmentDate.Year == year &&
                            a.AssessmentDate.Month == month);

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

        // GET: api/assessment/total-assessments?month={}&year={}
        [HttpGet("total-assessments")]
        public async Task<ActionResult<int>> GetTotalAssessments(int month, int year)
        {
            try
            {
                var totalCount = await _context.Assessments
                    .CountAsync(a => a.AssessmentDate.Year == year && a.AssessmentDate.Month == month);

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

        // GET: api/assessment/most-tracked-joint?month={}&year{}
        [HttpGet("most-tracked-joint")]
        public async Task<ActionResult<string>> GetMostTrackedJoint(int month, int year)
        {
            try
            {
                var mostTracked = await _context.Assessments
                .Where(a => a.AssessmentDate.Year == year && a.AssessmentDate.Month == month)
                .GroupBy(a => a.Joint)
                .Select(g => new
                {
                    Joint = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .FirstOrDefaultAsync();

                if (mostTracked == null)
                {
                    return Ok("N/A");
                }

                return Ok(mostTracked.Joint);
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

        // PUT: api/Assessments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessments(string id, Assessments assessments)
        {
            if (id != assessments.AssessmentID)
            {
                return BadRequest();
            }

            _context.Entry(assessments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentsExists(id))
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

        // POST: api/Assessments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assessments>> PostAssessments(Assessments assessments)
        {
            _context.Assessments.Add(assessments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssessmentsExists(assessments.AssessmentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssessments", new { id = assessments.AssessmentID }, assessments);
        }

        // DELETE: api/Assessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessments(string id)
        {
            var assessments = await _context.Assessments.FindAsync(id);
            if (assessments == null)
            {
                return NotFound();
            }

            _context.Assessments.Remove(assessments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssessmentsExists(string id)
        {
            return _context.Assessments.Any(e => e.AssessmentID == id);
        }
    }
}
