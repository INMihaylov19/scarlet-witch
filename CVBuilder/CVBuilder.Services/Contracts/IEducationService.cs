using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IEducationService
    {
        public Task<List<Education>> GetEducationsAsync();

        public Task<Education> GetEducationByIdAsync(Guid id);

        public Task<bool> UpdateEducationAsync(Guid id, Education education);

        public Task<Education> CreateEducationAsync(Education education);

        public Task<bool> DeleteEducationAsync(Guid id);

        public bool EducationExists(Guid id);
    }
}
