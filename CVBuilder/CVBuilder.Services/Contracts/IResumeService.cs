using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IResumeService
    {
        public Task<List<Resume>> GetResumesAsync();

        public Task<Resume> GetResumeByIdAsync(Guid id);

        public Task<bool> UpdateResumeAsync(Guid id, Resume resume);

        public Task<Resume> CreateResumeAsync(Resume resume);

        public Task<bool> DeleteResumeAsync(Guid id);

        public bool ResumeExists(Guid id);
    }
}
