using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IPersonalInfoService
    {
        public Task<List<PersonalInfo>> GetPersonalInfosAsync();

        public Task<PersonalInfo> GetPersonalInfoByIdAsync(Guid id);

        public Task<bool> UpdatePersonalInfoAsync(Guid id, PersonalInfo personalInfo);

        public Task<PersonalInfo> CreatePersonalInfoAsync(PersonalInfo personalInfo);

        public Task<bool> DeletePersonalInfoAsync(Guid id);

        public bool PersonalInfoExists(Guid id);
    }
}
