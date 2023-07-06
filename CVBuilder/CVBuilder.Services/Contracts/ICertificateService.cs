using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface ICertificateService
    {
        public Task<List<Certificate>> GetCertificatesAsync();

        public Task<Certificate> GetCertificateByIdAsync(Guid id);
        public Task<bool> UpdateCertificateAsync(Guid id, Certificate certificate);

        public Task<Certificate> CreateCertificateAsync(Certificate certificate);

        public Task<bool> DeleteCertificateAsync(Guid id);

        public bool CertificateExists(Guid id);
    }
}
