using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using CVBuilder.Data.DTO;
using Microsoft.CodeAnalysis;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly IWorkExperienceService _workExperienceService;

        public WorkExperiencesController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }

        // GET: api/WorkExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkExperience>>> GetWorkExperiences()
        {
            var workExperiences = await _workExperienceService.GetWorkExperiencesAsync();
            return Ok(workExperiences);
        }

        // GET: api/WorkExperiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperience>> GetWorkExperience(Guid id)
        {
            var workExperience = await _workExperienceService.GetWorkExperienceByIdAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            return Ok(workExperience);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience(Guid id, WorkExperienceDTO workExperienceTransfer)
        {
            if (id != workExperienceTransfer.Id)
            {
                return BadRequest();
            }

            WorkExperience workExperience = new WorkExperience()
            {
                Id = workExperienceTransfer.Id,
                Company = workExperienceTransfer.Company,
                Position = workExperienceTransfer.Position,
                StartDate = workExperienceTransfer.StartDate,
                EndDate = workExperienceTransfer.EndDate,
                Description = workExperienceTransfer.Description
            };
            var isUpdated = await _workExperienceService.UpdateWorkExperienceAsync(id, workExperience);
            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkExperience>> PostWorkExperience(WorkExperienceDTO workExperienceTransfer)
        {
            WorkExperience workExperience = new WorkExperience()
            {
                Company = workExperienceTransfer.Company,
                Position = workExperienceTransfer.Position,
                StartDate = workExperienceTransfer.StartDate,
                EndDate = workExperienceTransfer.EndDate,
                Description = workExperienceTransfer.Description
            };

            var createdWorkExperience = await _workExperienceService.CreateWorkExperienceAsync(workExperience);
            return CreatedAtAction(nameof(GetWorkExperience), new { id = createdWorkExperience.Id }, createdWorkExperience);
        }

        // DELETE: api/WorkExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkExperience(Guid id)
        {
            var isDeleted = await _workExperienceService.DeleteWorkExperienceAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
