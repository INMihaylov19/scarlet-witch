using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using CVBuilder.Data.DTO;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            var languages = await _languageService.GetLanguagesAsync();
            if (languages == null)
            {
                return NotFound();
            }
            return languages;
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(Guid id)
        {
            var language = await _languageService.GetLanguageByIdAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return language;
        }

        // PUT: api/Languages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, LanguageDTO languageTransfer)
        {
            Language language = new Language
            {
                Name = languageTransfer.Name,
                Proficiency = languageTransfer.Proficiency
            };

            bool isUpdated = await _languageService.UpdateLanguageAsync(id, language);
            if (!isUpdated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(LanguageDTO languageTransfer)
        {
            Language language = new Language
            {
                Name = languageTransfer.Name,
                Proficiency = languageTransfer.Proficiency
            };
            var createdLanguage = await _languageService.CreateLanguageAsync(language);
            return CreatedAtAction(nameof(GetLanguage), new { id = createdLanguage.Id }, createdLanguage);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            bool isDeleted = await _languageService.DeleteLanguageAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
