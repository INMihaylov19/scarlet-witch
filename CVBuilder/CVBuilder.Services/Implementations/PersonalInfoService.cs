using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Services.Implementations
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly CvdatabaseContext _context;

        public PersonalInfoService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalInfo>> GetPersonalInfosAsync()
        {
            return await _context.PersonalInfos.ToListAsync();
        }

        public async Task<PersonalInfo> GetPersonalInfoByIdAsync(Guid id)
        {
            return await _context.PersonalInfos.FindAsync(id);
        }

        public async Task<bool> UpdatePersonalInfoAsync(Guid id, PersonalInfo personalInfo)
        {
            if (id != personalInfo.Id)
            {
                return false;
            }

            _context.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        public async Task<PersonalInfo> CreatePersonalInfoAsync(PersonalInfo personalInfo)
        {
            _context.PersonalInfos.Add(personalInfo);
            await _context.SaveChangesAsync();

            return personalInfo;
        }

        public async Task<bool> DeletePersonalInfoAsync(Guid id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            if (personalInfo == null)
            {
                return false;
            }

            _context.PersonalInfos.Remove(personalInfo);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool PersonalInfoExists(Guid id)
        {
            return _context.PersonalInfos.Any(e => e.Id == id);
        }
    }
}