using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVBuilderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCV()
        {
            // Create a new CV
            return Ok();
        }
    }
}
