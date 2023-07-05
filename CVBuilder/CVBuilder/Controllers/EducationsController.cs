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
    public class EducationsController : ControllerBase
    {
        private readonly CvdatabaseContext _context;

        public EducationsController(CvdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
          if (_context.Educations == null)
          {
              return NotFound();
          }
            return await _context.Educations.ToListAsync();
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
          if (_context.Educations == null)
          {
              return NotFound();
          }
            var education = await _context.Educations.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return education;
        }

        // PUT: api/Educations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(Guid id, Education education)
        {
            if (id != education.Id)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation(Education education)
        {
          if (_context.Educations == null)
          {
              return Problem("Entity set 'CvdatabaseContext.Educations'  is null.");
          }
            _context.Educations.Add(education);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EducationExists(education.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEducation", new { id = education.Id }, education);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            if (_context.Educations == null)
            {
                return NotFound();
            }
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationExists(Guid id)
        {
            return (_context.Educations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
