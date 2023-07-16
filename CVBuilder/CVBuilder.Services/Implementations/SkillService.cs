using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly CvdatabaseContext _context;

        public SkillService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(Guid id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<bool> UpdateSkillAsync(Guid id, Skill skill)
        {
            if (id != skill.Id)
            {
                return false;
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            skill.Id = Guid.NewGuid();
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<bool> DeleteSkillAsync(Guid id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return false;
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool SkillExists(Guid id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
