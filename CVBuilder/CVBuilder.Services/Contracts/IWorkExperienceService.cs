using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IWorkExperienceService
    {
        public Task<List<WorkExperience>> GetWorkExperiencesAsync();
        public Task<WorkExperience> GetWorkExperienceByIdAsync(Guid id);
        public Task<bool> UpdateWorkExperienceAsync(Guid id, WorkExperience workExperience);
        public  Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience);
        public Task<bool> DeleteWorkExperienceAsync(Guid id);
        public bool WorkExperienceExists(Guid id);
    }
}
