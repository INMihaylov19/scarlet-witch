using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly CvdatabaseContext _context;

        public LanguageService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Language>> GetLanguagesAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetLanguageByIdAsync(Guid id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task<bool> UpdateLanguageAsync(Guid id, Language language)
        {
            if (id != language.Id)
            {
                return false;
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        public async Task<Language> CreateLanguageAsync(Language language)
        {
            language.Id = Guid.NewGuid();
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return language;
        }

        public async Task<bool> DeleteLanguageAsync(Guid id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return false;
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool LanguageExists(Guid id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
