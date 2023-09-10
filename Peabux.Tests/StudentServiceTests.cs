using Microsoft.EntityFrameworkCore;
using PeabuxAssessment.Data;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Implementation;
using PeabuxAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.Tests
{
    public class StudentServiceTests
    {
        [Fact]
        public async Task AddStudent_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddStudent")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new StudentService(context);
                var request = new StudentDTO { Name = "John", Surname = "Doe", DateOfBirth = DateTime.Now.Date.AddYears(-14).Date, NationalIDNumber = "4256282782", StudentNumber = "678798477384" };

                // Act
                var response = await service.AddStudent(request);

                // Assert
                Assert.True(response.Successful);
                Assert.Equal("Successful", response.Message);

            }
        }

        [Fact]
        public async Task Delete_InvalidStudentId_ReturnsErrorResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_DeleteStudent")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new StudentService(context);

                // Act
                var response = await service.Delete(0);

                // Assert
                Assert.False(response.Successful);
                Assert.Equal("Invalid Student ID", response.Message);
            }
        }


        [Fact]
        public async Task GetAllStudents_ReturnsListOfStudents()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new AppDbContext(options))
            {
                var students = new List<Student>
                {
                    new Student { ID = 1, Name = "Student1" },
                    new Student { ID = 2, Name = "Student2" },
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                var service = new StudentService(context);

                // Act
                var response = await service.GetAllStudents();

                // Assert
                Assert.True(response.Successful);
                Assert.Equal("Successful", response.Message);

                var studentDtoList = Assert.IsType<List<StudentDTO>>(response.Data);
                Assert.Equal(students.Count, studentDtoList.Count);
            }
        }

        private AppDbContext CreateMockDbContextWithData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            var students = new List<Student>
            {
                new Student { ID = 1, Name = "Student1" },
                new Student { ID = 2, Name = "Student2" },
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            return context;
        }
    }
}
