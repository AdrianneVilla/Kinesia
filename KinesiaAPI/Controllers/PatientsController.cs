using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using System.Data.Common;
using KinesiaLibrary.DTOs.PatientDTOs;
using KinesiaLibrary.DTOs.ReportDTOs;

namespace KinesiaAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }   

        // GET: api/patients?searchData={}&currentTab={}&sortColumn={}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayPatientsDTO>>> GetPatients(
            string? searchData = null,
            string? currentTab = null,
            string? sortColumn = "PatientID")
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                // will filter by Active / Inactive
                if (currentTab == "Active")
                {
                    query = query.Where(p => p.Status == 1);
                }
                else if (currentTab == "Inactive")
                {
                    query = query.Where(p => p.Status == 0);
                }

                // search
                if (!string.IsNullOrEmpty(searchData))
                {
                    query = query.Where(p =>
                    p.PatientID.Contains(searchData) ||
                    p.FirstName.Contains(searchData) ||
                    p.LastName.Contains(searchData) ||
                    p.MiddleName.Contains(searchData));
                }

                // sorting
                bool desc = true;
                switch (sortColumn)
                {
                    case "Alphabetic (Name)":
                        query = query.OrderBy(p => p.FirstName);
                        break;
                    case "Earliest (Date Added)":
                        query = query.OrderBy(p => p.DateAdded);
                        break;
                    case "Latest (Date Added)":
                        query = query.OrderByDescending(p => p.DateAdded);
                        desc = false;
                        break;
                    default:
                        query = query.OrderBy(p => p.PatientID);
                        break;
                }

                var patients = await query
                    .Select(p => PatientToDisplayPatientsDTO(p))
                    .ToListAsync();

                return Ok(patients);
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

        // GET: api/patients/selection?searchData{}
        [HttpGet("selection")]
        public async Task<ActionResult<DisplayPatientSelectionDTO>> GetPatientSelection(string? searchData = null)
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                // search
                if (!string.IsNullOrEmpty(searchData))
                {
                    query = query.Where(p =>
                    p.PatientID.Contains(searchData) ||
                    p.FirstName.Contains(searchData) ||
                    p.LastName.Contains(searchData) ||
                    p.MiddleName.Contains(searchData));
                }

                var patients = await query
                        .Select(p => PatientToDisplayPatientSelectionDTO(p))
                        .ToListAsync();

                return Ok(patients);
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

        // GET: api/patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientsDTO>> GetPatients(string id)
        {
            try
            {
                var patients = await _context.Patients.FindAsync(id);

                if (patients == null)
                {
                    return NotFound();
                }

                return Ok(PatientToDTO(patients));
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

        // GET: api/patients/basic?patientID={}
        [HttpGet("basic")]
        public async Task<ActionResult<PatientBasicDTO>> GetPatientBasicDetails(string patientID)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(patientID);

                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(PatientToPatientBasicDTO(patient));
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

        // GET: api/patients/total-patients?status={}
        [HttpGet("total-patients")]
        public async Task<ActionResult<int>> GetTotalPatientsByStatus(int? status)
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                if (status == 0)
                {
                    query = query.Where(p => p.Status == 0);
                }
                else if (status == 1)
                {
                    query = query.Where(p => p.Status == 1);
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

        // GET: api/patients/most-field-of-work
        [HttpGet("most-field-of-work")]
        public async Task<ActionResult<string>> GetMostFieldOfWork()
        {
            try
            {
                var mostField = await _context.Patients
                .GroupBy(p => p.Occupation)
                .Select(g => new
                {
                    Occupation = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .FirstOrDefaultAsync();

                if (mostField == null)
                    return Ok("N/A");

                return Ok(mostField.Occupation);
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

        // GET: api/patients/generate-today-report
        [HttpGet("generate-today-report")]
        public async Task<ActionResult<IEnumerable<PatientReportDTO>>> GenerateTodayReport()
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                query = query.Where(p => p.DateAdded == DateTime.Today);

                var patients = await query
                               .Select(p => PatientToPatientReportDTO(p))
                               .ToListAsync();

                return Ok(patients);
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

        // GET: api/patients/generate-weekly-report?startDate={}&endDate={}
        [HttpGet("generate-weekly-report")]
        public async Task<ActionResult<IEnumerable<PatientReportDTO>>> GenerateWeeklyReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                var weekStart = startDate.Date;
                var weekEnd = endDate.Date.AddDays(1);

                query = query.Where(p => p.DateAdded >= weekStart && p.DateAdded < weekEnd);

                var patients = await query
                               .Select(p => PatientToPatientReportDTO(p))
                               .ToListAsync();

                return Ok(patients);
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

        // GET: api/patients/generate-monthly-report?month={}&year={}
        [HttpGet("generate-monthly-report")]
        public async Task<ActionResult<IEnumerable<PatientReportDTO>>> GenerateMonthReport(int month, int year)
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                query = query.Where(p => p.DateAdded.Month == month && p.DateAdded.Year == year);

                var patients = await query
                              .Select(p => PatientToPatientReportDTO(p))
                              .ToListAsync();

                return Ok(patients);
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

        // GET: api/patients/generate-yearly-report?year={}
        [HttpGet("generate-yearly-report")]
        public async Task<ActionResult<IEnumerable<PatientReportDTO>>> GenerateYearlyReport(int year)
        {
            try
            {
                var query = _context.Patients.AsQueryable();

                query = query.Where(p => p.DateAdded.Year == year);

                var patients = await query
                               .Select(p => PatientToPatientReportDTO(p))
                               .ToListAsync();

                return Ok(patients);
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

        // POST: api/patients/check-existing
        [HttpPost("check-existing")]
        public async Task<IActionResult> CheckExistingPatient(CheckExistingPatientDTO existingPatient)
        {
            try
            {
                if (existingPatient == null)
                {
                    return BadRequest("Invalid patient data.");
                }

                bool exist = await _context.Patients.AnyAsync(p =>
                    p.FirstName == existingPatient.FirstName &&
                    p.LastName == existingPatient.LastName &&
                    p.MiddleName == existingPatient.MiddleName);

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


        // PUT: api/patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatients(string id, UpdatedPatientDTO updatedPatient)
        {
            if (string.IsNullOrEmpty(updatedPatient.PatientID) || id != updatedPatient.PatientID)
            {
                return BadRequest("Patient ID is required and must match the URL parameter");
            }

            try
            {
                var existingPatient = await _context.Patients.FindAsync(id);

                if (existingPatient == null)
                {
                    return NotFound("Patient data not found.\nPlease try again");
                }

                // will only overwrite/update if a new value was sent
                if (!string.IsNullOrEmpty(updatedPatient.FirstName))
                    existingPatient.FirstName = updatedPatient.FirstName;

                if (!string.IsNullOrEmpty(updatedPatient.LastName))
                    existingPatient.LastName = updatedPatient.LastName;

                if (!string.IsNullOrEmpty(updatedPatient.MiddleName))
                    existingPatient.MiddleName = updatedPatient.MiddleName;

                if (!string.IsNullOrEmpty(updatedPatient.Contact))
                    existingPatient.Contact = updatedPatient.Contact;

                if (updatedPatient.Birthdate.HasValue)
                    existingPatient.Birthdate = updatedPatient.Birthdate.Value;

                if (!string.IsNullOrEmpty(updatedPatient.Gender))
                    existingPatient.Gender = updatedPatient.Gender;

                if (!string.IsNullOrEmpty(updatedPatient.Address))
                    existingPatient.Address = updatedPatient.Address;

                if (!string.IsNullOrEmpty(updatedPatient.Occupation))
                    existingPatient.Occupation = updatedPatient.Occupation;

                if (updatedPatient.DateAdded.HasValue)
                    existingPatient.DateAdded = updatedPatient.DateAdded.Value;

                if (updatedPatient.LastArchiveDate != default(DateTime))
                    existingPatient.LastArchiveDate = updatedPatient.LastArchiveDate;

                if (updatedPatient.Status.HasValue)
                    existingPatient.Status = updatedPatient.Status.Value;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while updating the patient data." +
                    "\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // PUT: api/patients/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdatePatientStatus(string id, PatientUpdateStatusDTO updatedPatient)
        {
            if (string.IsNullOrEmpty(updatedPatient.PatientID) || id != updatedPatient.PatientID)
            {
                return BadRequest("Patient ID is required and must match the URL parameter");
            }

            try
            {
                var existingPatient = await _context.Patients.FindAsync(id);

                if (existingPatient == null)
                {
                    return NotFound();
                }

                existingPatient.Status = updatedPatient.Status;
                existingPatient.LastArchiveDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while updated patient's status." +
                    "\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // POST: api/patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patients>> PostPatients(AddPatientDTO addPatient)
        {
            if (addPatient == null)
                return BadRequest("Patient data cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var nextCount = await _context.Database
                    .SqlQueryRaw<long>("SELECT NEXTVAL(patient_id_seq) as value")
                    .FirstAsync();

                string newPatientID = $"PATIENT{nextCount}";

                var newPatient = new Patients
                {
                    PatientID = newPatientID,
                    FirstName = addPatient.FirstName,
                    LastName = addPatient.LastName,
                    MiddleName = addPatient.MiddleName,
                    Contact = addPatient.Contact,
                    Birthdate = addPatient.Birthdate,
                    Gender = addPatient.Gender,
                    Address = addPatient.Address,
                    Occupation = addPatient.Occupation,
                    DateAdded = DateTime.Now,
                    LastArchiveDate = null,
                    Status = 1
                };

                _context.Patients.Add(newPatient);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return CreatedAtAction("GetPatients", new { id = newPatient.PatientID }, newPatient);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"An error occured while saving the patient data.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"An unexpected error occured.\nPlease try again.");
            }
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatients(string id)
        {
            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patients);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientsExists(string id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
        }

        public static PatientsDTO PatientToDTO(Patients patients) =>
            new PatientsDTO
            {
                PatientID = patients.PatientID,
                FirstName = patients.FirstName,
                LastName = patients.LastName,
                MiddleName = patients.MiddleName,
                Contact = patients.Contact,
                Age = (int)((DateTime.Now - patients.Birthdate).TotalDays / 365.25),
                Birthdate = patients.Birthdate,
                Gender = patients.Gender,
                Address = patients.Address,
                Occupation = patients.Occupation,
                DateAdded = patients.DateAdded,
                LastArchiveDate = patients.LastArchiveDate.HasValue ? patients.LastArchiveDate.Value.ToString() : "--",
                Status = patients.Status
            };

        public static DisplayPatientsDTO PatientToDisplayPatientsDTO(Patients patients) =>
            new DisplayPatientsDTO
            {
                PatientID = patients.PatientID,
                PatientName = $"{patients.FirstName} {patients.MiddleName} {patients.LastName}",
                Age = (int)((DateTime.Now - patients.Birthdate).TotalDays / 365.25),
                Contact = patients.Contact,
                Status = patients.Status == 1 ? "Active" : "Inactive"
            };

        public static DisplayPatientSelectionDTO PatientToDisplayPatientSelectionDTO(Patients patients) =>
            new DisplayPatientSelectionDTO
            {
                PatientID = patients.PatientID,
                PatientName = $"{patients.FirstName} {patients.MiddleName} {patients.LastName}",
                Age = (int)((DateTime.Now - patients.Birthdate).TotalDays / 365.25),
                Gender = patients.Gender
            };

        public static PatientBasicDTO PatientToPatientBasicDTO(Patients patient) =>
            new PatientBasicDTO
            {
                PatientID = patient.PatientID,
                PatientName = $"{patient.FirstName} {patient.MiddleName} {patient.LastName}",
                Age = (int)((DateTime.Now - patient.Birthdate).TotalDays / 365.25),
                Gender = patient.Gender
            };

        public static PatientReportDTO PatientToPatientReportDTO(Patients patients) =>
            new PatientReportDTO
            {
                PatientID = patients.PatientID,
                PatientName = $"{patients.FirstName} {patients.MiddleName} {patients.LastName}",
                Contact = patients.Contact,
                Age = (int)((DateTime.Now - patients.Birthdate).TotalDays / 365.25),
                Birthdate = patients.Birthdate,
                Gender = patients.Gender,
                Occupation = patients.Occupation,
                DateAdded = patients.DateAdded.ToString("yyyy-MM-dd"),
                LastArchiveDate = patients.LastArchiveDate.HasValue ? patients.LastArchiveDate.Value.ToString("yyyy-MM-dd") : "--",
                Status = patients.Status == 1 ? "Active" : "Inactive"
            };
    }
}
