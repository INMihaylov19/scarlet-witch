//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using CVBuilder.Models;
//using CVBuilder.Services.Contracts;

//namespace CVBuilder.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ResumesController : ControllerBase
//    {
//        private readonly IResumeService _resumeService;

//        public ResumesController(IResumeService resumeService)
//        {
//            _resumeService = resumeService;
//        }

//        // GET: api/Resumes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Resume>>> GetResumes()
//        {
//            var resumes = await _resumeService.GetResumesAsync();
//            if (resumes == null)
//            {
//                return NotFound();
//            }
//            return resumes;
//        }

//        // GET: api/Resumes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Resume>> GetResume(Guid id)
//        {
//            var resume = await _resumeService.GetResumeByIdAsync(id);
//            if (resume == null)
//            {
//                return NotFound();
//            }
//            return resume;
//        }

//        // PUT: api/Resumes/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutResume(Guid id, Resume resume)
//        {
//            bool isUpdated = await _resumeService.UpdateResumeAsync(id, resume);
//            if (!isUpdated)
//            {
//                return BadRequest();
//            }
//            return NoContent();
//        }

//        // POST: api/Resumes
//        [HttpPost]
//        public async Task<ActionResult<Resume>> PostResume(Resume resume)
//        {
//            var createdResume = await _resumeService.CreateResumeAsync(resume);
//            return CreatedAtAction(nameof(GetResume), new { id = createdResume.Id }, createdResume);
//        }

//        // DELETE: api/Resumes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteResume(Guid id)
//        {
//            bool isDeleted = await _resumeService.DeleteResumeAsync(id);
//            if (!isDeleted)
//            {
//                return NotFound();
//            }
//            return NoContent();
//        }
//    }
//}
