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
    public class TeacherServiceTests
    {
        [Fact]
        public async Task AddTeacher_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddTeacher")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new TeacherService(context);
                var request = new TeacherDTO { Name = "John", Surname = "Doe", DateOfBirth = DateTime.Now.Date.AddYears(-22).Date, NationalIDNumber = "4256282782", TeacherNumber = "678798477384" };

                // Act
                var response = await service.AddTeacher(request);

                // Assert
                Assert.True(response.Successful);
                Assert.Equal("Successful", response.Message);

            }
        }

        [Fact]
        public async Task Delete_InvalidTeacherId_ReturnsErrorResponse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_DeleteTeacher")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new TeacherService(context);

                // Act
                var response = await service.Delete(0);

                // Assert
                Assert.False(response.Successful);
                Assert.Equal("Invalid Teacher ID", response.Message);
            }
        }


        [Fact]
        public async Task GetAllTeachers_ReturnsListOfTeachers()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new AppDbContext(options))
            {
                var Teachers = new List<Teacher>
                {
                    new Teacher { ID = 1, Name = "Teacher1" },
                    new Teacher { ID = 2, Name = "Teacher2" },
                };

                context.Teachers.AddRange(Teachers);
                context.SaveChanges();

                var service = new TeacherService(context);

                // Act
                var response = await service.GetAllTeachers();

                // Assert
                Assert.True(response.Successful);
                Assert.Equal("Successful", response.Message);

                var TeacherDtoList = Assert.IsType<List<TeacherDTO>>(response.Data);
                Assert.Equal(Teachers.Count, TeacherDtoList.Count);
            }
        }

        private AppDbContext CreateMockDbContextWithData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            var Teachers = new List<Teacher>
            {
                new Teacher { ID = 1, Name = "Teacher1" },
                new Teacher { ID = 2, Name = "Teacher2" },
            };

            context.Teachers.AddRange(Teachers);
            context.SaveChanges();

            return context;
        }
    }
}
