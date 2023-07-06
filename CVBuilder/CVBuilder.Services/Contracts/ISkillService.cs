using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface ISkillService
    {
        public Task<List<Skill>> GetSkillsAsync();

        public Task<Skill> GetSkillByIdAsync(Guid id);
        public Task<bool> UpdateSkillAsync(Guid id, Skill skill);
        public Task<Skill> CreateSkillAsync(Skill skill);
        public Task<bool> DeleteSkillAsync(Guid id);
        public bool SkillExists(Guid id);
    }
}
