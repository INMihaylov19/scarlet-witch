using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using CVBuilder.Services.Implementations;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoesController : ControllerBase
    {
        private readonly IPersonalInfoService _personalInfoService;

        public PersonalInfoesController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        // GET: api/PersonalInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfo>>> GetPersonalInfos()
        {
            var personalInfos = await _personalInfoService.GetPersonalInfosAsync();
            if (personalInfos == null)
            {
                return NotFound();
            }
            return personalInfos;
        }

        // GET: api/PersonalInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfo>> GetPersonalInfo(Guid id)
        {
            var personalInfo = await _personalInfoService.GetPersonalInfoByIdAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return personalInfo;
        }

        // PUT: api/PersonalInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfo(Guid id, PersonalInfo personalInfo)
        {
            bool isUpdated = await _personalInfoService.UpdatePersonalInfoAsync(id, personalInfo);
            if (!isUpdated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/PersonalInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalInfo>> PostPersonalInfo(PersonalInfo personalInfo)
        {
            var createdPersonalInfo = await _personalInfoService.CreatePersonalInfoAsync(personalInfo);
            return CreatedAtAction(nameof(GetPersonalInfo), new { id = createdPersonalInfo.Id }, createdPersonalInfo);
        }

        // DELETE: api/PersonalInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalInfo(Guid id)
        {
            bool isDeleted = await _personalInfoService.DeletePersonalInfoAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
