using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Template>>> GetTemplates()
        {
            var templates = await _templateService.GetTemplatesAsync();
            if (templates == null)
            {
                return NotFound();
            }
            return templates;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplate(Guid id)
        {
            var template = await _templateService.GetTemplateByIdAsync(id);
            if (template == null)
            {
                return NotFound();
            }
            return template;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplate(Guid id, Template template)
        {
            bool isUpdated = await _templateService.UpdateTemplateAsync(id, template);
            if (!isUpdated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate(Template template)
        {
            var createdTemplate = await _templateService.CreateTemplateAsync(template);
            return CreatedAtAction(nameof(GetTemplate), new { id = createdTemplate.Id }, createdTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(Guid id)
        {
            bool isDeleted = await _templateService.DeleteTemplateAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
