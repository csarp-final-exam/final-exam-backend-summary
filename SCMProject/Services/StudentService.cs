using Microsoft.EntityFrameworkCore;
using SCMProject.Models;

namespace SCMProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly ScmContext _context = new();
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
