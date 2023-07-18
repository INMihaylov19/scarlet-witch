using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using CVBuilder.Services.Implementations;
using CVBuilder.Data.DTO;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificatesController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetCertificates()
        {
            var certificates = await _certificateService.GetCertificatesAsync();
            if (certificates == null)
            {
                return NotFound();
            }
            return certificates;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCertificate(Guid id)
        {
            var certificate = await _certificateService.GetCertificateByIdAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return certificate;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(Guid id, CertificateDTO certificateTransfer)
        {
            Certificate certificate = new Certificate
            {
                Id = id,
                Name = certificateTransfer.Name,
                IssueDate = certificateTransfer.IssueDate,
                ExpirationDate = certificateTransfer.ExpirationDate,
                Organization = certificateTransfer.Organization,

            };

            bool isUpdated = await _certificateService.UpdateCertificateAsync(id, certificate);
            if (!isUpdated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> PostCertificate(CertificateDTO certificateTransfer)
        {
            Certificate certificate = new Certificate
            {
                Name = certificateTransfer.Name,
                IssueDate = certificateTransfer.IssueDate,
                ExpirationDate = certificateTransfer.ExpirationDate,
                Organization = certificateTransfer.Organization,

            };

            var createdCertificate = await _certificateService.CreateCertificateAsync(certificate);
            return CreatedAtAction(nameof(GetCertificate), new { id = createdCertificate.Id }, createdCertificate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(Guid id)
        {
            bool isDeleted = await _certificateService.DeleteCertificateAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
