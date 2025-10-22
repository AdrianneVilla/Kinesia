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

        // GET: api/assessment?search={}&currentExtremityTab={}&currentStatusTab={}&sortColumn={}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayAssessmentsDTO>>> GetAssessments(
            string? searchData = null,
            string? currentExtremityTab = null,
            string? currentStatusTab = null,
            string? sortColumn = null)
        {
            try
            {
                var query = _context.Assessments.AsQueryable();

                // will filter by Extremity
                if (currentExtremityTab == "Upper Extremity")
                    query = query.Where(a => a.Extremity == "Upper Extremity");
                else if (currentExtremityTab == "Lower Extremity")
                    query = query.Where(a => a.Extremity == "Lower Extremity");

                switch (currentStatusTab)
                {
                    case "Archived":
                        query = query.Where(a => a.AssessmentStatus == 0);
                        break;
                    case "Ongoing":
                        query = query.Where(a => a.AssessmentStatus == 1);
                        break;
                    case "Finished":
                        query = query.Where(a => a.AssessmentStatus == 2);
                        break;
                }

                if (!string.IsNullOrEmpty(searchData))
                {
                    query = query.Where(a =>
                    a.AssessmentID.Contains(searchData) ||
                    a.PatientID.Contains(searchData));
                }

                switch (sortColumn)
                {
                    case "Alphabetic (Name)":
                        query = query.OrderBy(a => a.AssessmentID);
                        break;
                    case "Earliest (Date Added)":
                        query = query.OrderBy(a => a.AssessmentDate);
                        break;
                    case "Latest (Date Added)":
                        query = query.OrderByDescending(a => a.AssessmentDate);
                        break;
                    default:
                        query = query.OrderBy(a => a.AssessmentID);
                        break;
                }

                var assessments = await query
                    .Select(a => AssessmentToDisplayAssessmentsDTO(a))
                    .ToListAsync();

                return Ok(assessments);
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
                    AssessmentStatus = result.AssessmentStatus switch
                    {
                        0 => "Archived",
                        1 => "Ongoing",
                        2 => "Finished",
                    },
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

        // GET: api/assessment/generate-assessmentid
        [HttpGet("generate-assessmentid")]
        public async Task<ActionResult<string>> GenerateNewAssessmentID()
        {
            try
            {
                var nextCount = await _context.Database
                    .SqlQueryRaw<long>("SELECT NEXTVAL(assessment_id_seq) AS value")
                    .FirstAsync();

                string newAssessmentID = $"ASSESSMENT{nextCount}";

                return Ok(newAssessmentID);
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
        public async Task<ActionResult<Assessments>> PostAssessments(AddAssessmentDTO assessmentDTO)
        {
            if(assessmentDTO == null)
                return BadRequest("ROM data cannot be null.");

            var newAssessment = new Assessments
            {
                AssessmentID = assessmentDTO.AssessmentID,
                PatientID = assessmentDTO.PatientID,
                Extremity = assessmentDTO.Extremity,
                Joint = assessmentDTO.Joint,
                JointSide = assessmentDTO.JointSide,
                AssessmentStatus = 1,
                AssessmentDate = DateTime.Now
            };

            try
            {
                _context.Assessments.Add(newAssessment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAssessments", new { id = newAssessment.AssessmentID }, newAssessment);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while saving the assessment data.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
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

        public static DisplayAssessmentsDTO AssessmentToDisplayAssessmentsDTO(Assessments assessment) =>
            new DisplayAssessmentsDTO
            {
                AssessmentID = assessment.AssessmentID,
                PatientID = assessment.PatientID,
                Extremity = assessment.Extremity,
                Joint = assessment.Joint,
                AssessmentStatus = assessment.AssessmentStatus switch
                {
                    0 => "Archived",
                    1 => "Ongoing",
                    2 => "Finished",
                }
            };
    }
}
