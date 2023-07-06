using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
            var educations = await _educationService.GetEducationsAsync();
            if (educations == null)
            {
                return NotFound();
            }
            return educations;
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(Guid id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return education;
        }

        // PUT: api/Educations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(Guid id, Education education)
        {
            bool isUpdated = await _educationService.UpdateEducationAsync(id, education);
            if (!isUpdated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Educations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation(Education education)
        {
            var createdEducation = await _educationService.CreateEducationAsync(education);
            return CreatedAtAction(nameof(GetEducation), new { id = createdEducation.Id }, createdEducation);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(Guid id)
        {
            bool isDeleted = await _educationService.DeleteEducationAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
