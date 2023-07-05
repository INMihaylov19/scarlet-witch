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
    public class TemplatesController : ControllerBase
    {
        private readonly CvdatabaseContext _context;

        public TemplatesController(CvdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Template>>> GetTemplates()
        {
          if (_context.Templates == null)
          {
              return NotFound();
          }
            return await _context.Templates.ToListAsync();
        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplate(int id)
        {
          if (_context.Templates == null)
          {
              return NotFound();
          }
            var template = await _context.Templates.FindAsync(id);

            if (template == null)
            {
                return NotFound();
            }

            return template;
        }

        // PUT: api/Templates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplate(Guid id, Template template)
        {
            if (id != template.Id)
            {
                return BadRequest();
            }

            _context.Entry(template).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
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

        // POST: api/Templates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate(Template template)
        {
          if (_context.Templates == null)
          {
              return Problem("Entity set 'CvdatabaseContext.Templates'  is null.");
          }
            _context.Templates.Add(template);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TemplateExists(template.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTemplate", new { id = template.Id }, template);
        }

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            if (_context.Templates == null)
            {
                return NotFound();
            }
            var template = await _context.Templates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemplateExists(Guid id)
        {
            return (_context.Templates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
