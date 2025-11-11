using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.ReportDTOs;
using KinesiaLibrary.DTOs.ROMDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace KinesiaAPI.Controllers
{
    [Route("api/rom")]
    [ApiController]
    public class ROMsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ROMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/rom?assessmentID={}&movement={}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayROMsDTO>>> GetROM(string assessmentID, string movement)
        {
            try
            {
                var query = from r in _context.ROM
                            join u in _context.Users on r.UserID equals u.UserID
                            join a in _context.Assessments on r.AssessmentID equals a.AssessmentID
                            where r.AssessmentID == assessmentID
                            select new DisplayROMsDTO
                            {
                                TherapistName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                                StartingPosition = r.StartingPosition,
                                Rom = r.Rom,
                                Movement = r.Movement,
                                NormalRange = r.NormalRom,
                                Deficit = r.Deficit,
                                Date = r.Date.ToString("yyyy-MM-dd hh:mm")
                            };

                if (movement == "Flexion")
                {
                    query = query.Where(r => r.Movement == "Flexion");
                }
                else if(movement == "Extension")
                {
                    query = query.Where(r => r.Movement == "Extension");
                }
                else if(movement == "Abduction")
                {
                    query = query.Where(r => r.Movement == "Abduction");
                }
                else if(movement == "Adduction")
                {
                    query = query.Where(r => r.Movement == "Adduction");
                }

                var ROMs = await query.ToListAsync();

                return Ok(ROMs);
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

        // GET: api/ROMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ROM>> GetROM(int id)
        {
            var rOM = await _context.ROM.FindAsync(id);

            if (rOM == null)
            {
                return NotFound();
            }

            return rOM;
        }

        // GET: api/rom/generate-report?assessmentID={}
        [HttpGet("generate-report")]
        public async Task<ActionResult<ROMReportDTO>> GenerateROMReport(string assessmentID)
        {
            var query = from r in _context.ROM
                        join u in _context.Users on r.UserID equals u.UserID
                        join a in _context.Assessments on r.AssessmentID equals a.AssessmentID
                        where r.AssessmentID == assessmentID
                        orderby r.Movement, r.Date ascending
                        select new ROMReportDTO
                        {
                            TherapistName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                            GoniometerType = r.GoniometerType,
                            StartingPosition = r.StartingPosition,
                            Rom = r.Rom,
                            NormalRom = r.NormalRom,
                            Deficit = r.Deficit,
                            Movement = r.Movement,
                            MotionType = r.MotionType,
                            Date = r.Date.ToString("yyyy-MM-dd hh:mm tt")
                        };

            var ROMs = await query.ToListAsync();

            return Ok(ROMs);
        }

        // GET: api/rom/generate-graph?assessmentID={}&movement={}
        [HttpGet("generate-graph")]
        public async Task<ActionResult<IEnumerable<ROMGraphDTO>>> GenerateROMGraph(string assessmentID, string movement)
        {
            var result = await (from r in _context.ROM
                         join a in _context.Assessments on r.AssessmentID equals a.AssessmentID
                         where a.AssessmentID == assessmentID && r.Movement == movement
                         orderby r.Date
                         select new ROMGraphDTO
                         {
                             Rom = r.Rom,
                             Date = r.Date
                         }).ToListAsync();

            return Ok(result);
        }

        // PUT: api/ROMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutROM(int id, ROM rOM)
        {
            if (id != rOM.ROMID)
            {
                return BadRequest();
            }

            _context.Entry(rOM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ROMExists(id))
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

        // POST: api/rom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ROM>> PostROM(AddROMDTO romDTO)
        {
            if (romDTO == null)
                return BadRequest("ROM data cannot be null.");

            var newROM = new ROM
            {
                AssessmentID = romDTO.AssessmentID,
                UserID = romDTO.UserID,
                GoniometerType = romDTO.GoniometerType,
                StartingPosition = romDTO.StartingPosition,
                Rom = romDTO.Rom,
                NormalRom = romDTO.NormalRom,
                Deficit = romDTO.Deficit,
                Movement = romDTO.Movement,
                MotionType = romDTO.MotionType,
                Date = DateTime.Now
            };

            try
            {
                _context.ROM.Add(newROM);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetROM", new { id = newROM.ROMID }, newROM);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while saving the ROM data.\nPlease try again.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.\nPlease try again.");
            }
        }

        // DELETE: api/ROMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteROM(int id)
        {
            var rOM = await _context.ROM.FindAsync(id);
            if (rOM == null)
            {
                return NotFound();
            }

            _context.ROM.Remove(rOM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ROMExists(int id)
        {
            return _context.ROM.Any(e => e.ROMID == id);
        }
    }
}
