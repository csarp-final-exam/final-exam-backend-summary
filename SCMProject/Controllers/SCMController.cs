using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMProject.Models;

namespace SCMProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SCMController : ControllerBase
    {
        private readonly ScmContext _context = new();

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students);
        }
    }
}
