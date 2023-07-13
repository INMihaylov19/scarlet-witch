using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly CvdatabaseContext _context;

        public CertificateService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Certificate>> GetCertificatesAsync()
        {
            return await _context.Certificates.ToListAsync();
        }

        public async Task<Certificate> GetCertificateByIdAsync(Guid id)
        {
            return await _context.Certificates.FindAsync(id);
        }

        public async Task<bool> UpdateCertificateAsync(Guid id, Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return false;
            }

            _context.Entry(certificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
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

        public async Task<Certificate> CreateCertificateAsync(Certificate certificate)
        {
            certificate.Id = new Guid();
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();

            return certificate;
        }

        public async Task<bool> DeleteCertificateAsync(Guid id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return false;
            }

            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool CertificateExists(Guid id)
        {
            return _context.Certificates.Any(e => e.Id == id);
        }
    }
}
