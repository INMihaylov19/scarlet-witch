using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class EducationService : IEducationService
    {
        private readonly CvdatabaseContext _context;

        public EducationService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Education>> GetEducationsAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetEducationByIdAsync(Guid id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task<bool> UpdateEducationAsync(Guid id, Education education)
        {
            if (id != education.Id)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Education> CreateEducationAsync(Education education)
        {
            education.Id = new Guid();
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();

            return education;
        }

        public async Task<bool> DeleteEducationAsync(Guid id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return false;
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool EducationExists(Guid id)
        {
            return _context.Educations.Any(e => e.Id == id);
        }
    }
}
