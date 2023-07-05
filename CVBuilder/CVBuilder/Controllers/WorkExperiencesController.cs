using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilder.Models;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly CvdatabaseContext _context;

        public WorkExperiencesController(CvdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WorkExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkExperience>>> GetWorkExperiences()
        {
          if (_context.WorkExperiences == null)
          {
              return NotFound();
          }
            return await _context.WorkExperiences.ToListAsync();
        }

        // GET: api/WorkExperiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperience>> GetWorkExperience(int id)
        {
          if (_context.WorkExperiences == null)
          {
              return NotFound();
          }
            var workExperience = await _context.WorkExperiences.FindAsync(id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return workExperience;
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience(int id, WorkExperience workExperience)
        {
            if (id != workExperience.Id)
            {
                return BadRequest();
            }

            _context.Entry(workExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExperienceExists(id))
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

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkExperience>> PostWorkExperience(WorkExperience workExperience)
        {
          if (_context.WorkExperiences == null)
          {
              return Problem("Entity set 'CvdatabaseContext.WorkExperiences'  is null.");
          }
            _context.WorkExperiences.Add(workExperience);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkExperienceExists(workExperience.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkExperience", new { id = workExperience.Id }, workExperience);
        }

        // DELETE: api/WorkExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkExperience(int id)
        {
            if (_context.WorkExperiences == null)
            {
                return NotFound();
            }
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExperienceExists(int id)
        {
            return (_context.WorkExperiences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
