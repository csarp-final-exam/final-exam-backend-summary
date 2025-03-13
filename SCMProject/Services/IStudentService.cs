using SCMProject.Models;

namespace SCMProject.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
    }
}
