using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface ILanguageService
    {
        public Task<List<Language>> GetLanguagesAsync();   

        public Task<Language> GetLanguageByIdAsync(Guid id);

        public Task<bool> UpdateLanguageAsync(Guid id, Language language);

        public Task<Language> CreateLanguageAsync(Language language);

        public Task<bool> DeleteLanguageAsync(Guid id);

        public bool LanguageExists(Guid id);
    }
}
