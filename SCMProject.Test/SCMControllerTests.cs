using SCMProject.Models;
using Moq;
using SCMProject.Controllers;
using SCMProject.Services;
using Microsoft.AspNetCore.Mvc;


namespace SCMProject.Test
{
    public class SCMControllerTests
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly SCMController _controller;

        public SCMControllerTests()
        {
            _mockService = new Mock<IStudentService>();
            _controller = new SCMController(_mockService.Object);
        }

        public static IEnumerable<object[]> GetStudentsData()
        {
            yield return new object[] { new List<Student> { new Student { Id = 1, FirstName = "John" }, new Student { Id = 2, FirstName = "Jane" } } };
            yield return new object[] { new List<Student> { new Student { Id = 3, FirstName = "Alice" } } };
            yield return new object[] { new List<Student>() }; // Üres lista tesztelése
        }

        [Theory]
        [MemberData(nameof(GetStudentsData))]
        public void GetAllStudent_ReturnsExpectedStudents(List<Student> students)
        {
            // Arrange
            _mockService.Setup(s => s.GetAllStudents()).ReturnsAsync(students);

            // Act
            var result = _controller.GetAllStudent() as OkObjectResult;
            var actualStudents = result?.Value as List<Student>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(actualStudents);
            Assert.Equal(students.Count, actualStudents.Count);
            Assert.True(students.SequenceEqual(actualStudents, new StudentComparer()));
        }
    }

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Id == y.Id && x.FirstName == y.FirstName;
        }

        public int GetHashCode(Student obj)
        {
            return obj.Id.GetHashCode() ^ obj.FirstName.GetHashCode();
        }
    }

}