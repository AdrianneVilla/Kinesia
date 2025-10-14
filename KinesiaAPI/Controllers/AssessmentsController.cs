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
        public async Task<ActionResult<Assessments>> GetAssessments(string id)
        {
            var assessments = await _context.Assessments.FindAsync(id);

            if (assessments == null)
            {
                return NotFound();
            }

            return assessments;
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
