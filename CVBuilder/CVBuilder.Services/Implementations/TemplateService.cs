using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class TemplateService : ITemplateService
    {
        private readonly CvdatabaseContext _context;

        public TemplateService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Template>> GetTemplatesAsync()
        {
            return await _context.Templates.ToListAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid id)
        {
            return await _context.Templates.FindAsync(id);
        }

        public async Task<bool> UpdateTemplateAsync(Guid id, Template template)
        {
            if (id != template.Id)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Template> CreateTemplateAsync(Template template)
        {
            _context.Templates.Add(template);
            await _context.SaveChangesAsync();

            return template;
        }

        public async Task<bool> DeleteTemplateAsync(Guid id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template == null)
            {
                return false;
            }

            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool TemplateExists(Guid id)
        {
            return _context.Templates.Any(e => e.Id == id);
        }
    }
}
