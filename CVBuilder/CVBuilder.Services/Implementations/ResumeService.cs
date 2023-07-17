//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CVBuilder.Models;
//using CVBuilder.Services.Contracts;
//using Microsoft.EntityFrameworkCore;

//namespace CVBuilder.Services.Implementations
//{
//    public class ResumeService : IResumeService
//    {
//        private readonly CvdatabaseContext _context;

//        public ResumeService(CvdatabaseContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Resume>> GetResumesAsync()
//        {
//            return await _context.Resumes.ToListAsync();
//        }

//        public async Task<Resume> GetResumeByIdAsync(Guid id)
//        {
//            return await _context.Resumes.FindAsync(id);
//        }

//        public async Task<bool> UpdateResumeAsync(Guid id, Resume resume)
//        {
//            if (id != resume.Id)
//            {
//                return false;
//            }

//            _context.Entry(resume).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ResumeExists(id))
//                {
//                    return false;
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return true;
//        }

//        public async Task<Resume> CreateResumeAsync(Resume resume)
//        {
//            resume.Id = new Guid();
//            _context.Resumes.Add(resume);
//            await _context.SaveChangesAsync();

//            return resume;
//        }

//        public async Task<bool> DeleteResumeAsync(Guid id)
//        {
//            var resume = await _context.Resumes.FindAsync(id);
//            if (resume == null)
//            {
//                return false;
//            }

//            _context.Resumes.Remove(resume);
//            await _context.SaveChangesAsync();

//            return true;
//        }

//        public bool ResumeExists(Guid id)
//        {
//            return _context.Resumes.Any(e => e.Id == id);
//        }
//    }
//}
