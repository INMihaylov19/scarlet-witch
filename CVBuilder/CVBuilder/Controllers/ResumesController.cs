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
    public class ResumesController : ControllerBase
    {
        private readonly CvdatabaseContext _context;

        public ResumesController(CvdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Resumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resume>>> GetResumes()
        {
          if (_context.Resumes == null)
          {
              return NotFound();
          }
            return await _context.Resumes.ToListAsync();
        }

        // GET: api/Resumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> GetResume(int id)
        {
          if (_context.Resumes == null)
          {
              return NotFound();
          }
            var resume = await _context.Resumes.FindAsync(id);

            if (resume == null)
            {
                return NotFound();
            }

            return resume;
        }

        // PUT: api/Resumes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResume(Guid id, Resume resume)
        {
            if (id != resume.Id)
            {
                return BadRequest();
            }

            _context.Entry(resume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumeExists(id))
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

        // POST: api/Resumes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resume>> PostResume(Resume resume)
        {
          if (_context.Resumes == null)
          {
              return Problem("Entity set 'CvdatabaseContext.Resumes'  is null.");
          }
            _context.Resumes.Add(resume);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResumeExists(resume.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResume", new { id = resume.Id }, resume);
        }

        // DELETE: api/Resumes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResume(int id)
        {
            if (_context.Resumes == null)
            {
                return NotFound();
            }
            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null)
            {
                return NotFound();
            }

            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResumeExists(Guid id)
        {
            return (_context.Resumes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
