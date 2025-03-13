using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMProject.Models;
using SCMProject.Services;

namespace SCMProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SCMController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public SCMController(IStudentService studentService)
        {
            _studentService=studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(_studentService.GetAllStudents());
        }
    }
}
