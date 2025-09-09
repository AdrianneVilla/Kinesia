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
        public async Task<ActionResult<IEnumerable<PatientsDTO>>> GetPatients(
            string? searchData = null,
            string? currentTab = null,
            string? sortColumn = "PatientID")
        {
            var query = _context.Patients.AsQueryable();

            // will filter by Active / Inactive
            if(currentTab == "Active")
            {
                query = query.Where(p => p.Status == 1);
            }
            else if(currentTab == "Inactive")
            {
                query = query.Where(p => p.Status == 0);
            }

            // search
            if(!string.IsNullOrEmpty(searchData))
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

            return await query
                .Select(p => PatientToDTO(p))
                .ToListAsync();
        }

        // GET: api/patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientsDTO>> GetPatients(string id)
        {
            var patients = await _context.Patients.FindAsync(id);

            if (patients == null)
            {
                return NotFound();
            }

            return PatientToDTO(patients);
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatients(string id, Patients patients)
        {
            if (id != patients.PatientID)
            {
                return BadRequest();
            }

            _context.Entry(patients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientsExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patients>> PostPatients(Patients patients)
        {
            _context.Patients.Add(patients);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientsExists(patients.PatientID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatients", new { id = patients.PatientID }, patients);
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
    }
}
