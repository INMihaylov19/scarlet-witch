using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly CvdatabaseContext _context;

        public WorkExperienceService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<WorkExperience>> GetWorkExperiencesAsync()
        {
            return await _context.WorkExperiences.ToListAsync();
        }

        public async Task<WorkExperience> GetWorkExperienceByIdAsync(Guid id)
        {
            return await _context.WorkExperiences.FindAsync(id);
        }

        public async Task<bool> UpdateWorkExperienceAsync(Guid id, WorkExperience workExperience)
        {
            if (id != workExperience.Id)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience)
        {
            workExperience.Id = Guid.NewGuid();
            _context.WorkExperiences.Add(workExperience);
            await _context.SaveChangesAsync();

            return workExperience;
        }

        public async Task<bool> DeleteWorkExperienceAsync(Guid id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return false;
            }

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool WorkExperienceExists(Guid id)
        {
            return _context.WorkExperiences.Any(e => e.Id == id);
        }
    }
}
