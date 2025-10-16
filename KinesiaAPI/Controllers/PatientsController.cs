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
                        query = query.OrderByDescending(p => p.DateAdded);
                        break;
                    case "Latest (Date Added)":
                        query = query.OrderBy(p => p.DateAdded);
                        desc = false;
                        break;
                    default:
                        query = query.OrderByDescending(p => p.PatientID);
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
        public async Task<ActionResult<Patients>> PostPatients(Patients patients)
        {
            if (patients == null)
                return BadRequest("Patient data cannot be null.");

            try
            {
                _context.Patients.Add(patients);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPatients", new { id = patients.PatientID }, patients);
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
                LastArchiveDate = patients.LastArchiveDate.HasValue ? patients.LastArchiveDate.Value.ToString() : "N/A",
                Status = patients.Status
            };

        public static DisplayPatientsDTO PatientToDisplayPatientsDTO(Patients patients) =>
            new DisplayPatientsDTO
            {
                PatientID = patients.PatientID,
                PatientName = $"{patients.FirstName} {patients.MiddleName} {patients.LastName}",
                Age = (int)((DateTime.Now - patients.Birthdate).TotalDays / 365.25),
                Gender = patients.Gender,
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
    }
}
