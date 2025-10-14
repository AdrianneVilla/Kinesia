using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;

namespace KinesiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ROMsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ROMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ROMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ROM>>> GetROM()
        {
            return await _context.ROM.ToListAsync();
        }

        // GET: api/ROMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ROM>> GetROM(string id)
        {
            var rOM = await _context.ROM.FindAsync(id);

            if (rOM == null)
            {
                return NotFound();
            }

            return rOM;
        }

        // PUT: api/ROMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutROM(string id, ROM rOM)
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

        // POST: api/ROMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ROM>> PostROM(ROM rOM)
        {
            _context.ROM.Add(rOM);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ROMExists(rOM.ROMID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetROM", new { id = rOM.ROMID }, rOM);
        }

        // DELETE: api/ROMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteROM(string id)
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

        private bool ROMExists(string id)
        {
            return _context.ROM.Any(e => e.ROMID == id);
        }
    }
}
