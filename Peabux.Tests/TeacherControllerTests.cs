using Microsoft.AspNetCore.Mvc;
using Moq;
using PeabuxAssessment.Controllers;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;
using PeabuxAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.Tests
{
    public class TeacherControllerTests
    {

        [Fact]
        public async Task AddTeacher_ValidRequest_ReturnsOk()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = new TeacherDTO {  };
            var response = new ResponseParam { Successful = true };

            TeacherServiceMock.Setup(s => s.AddTeacher(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.Create(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task AddTeacher_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = new TeacherDTO {  };
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            TeacherServiceMock.Setup(s => s.AddTeacher(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.Create(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(badRequestResult.Value);
            Assert.False(resultValue.Successful);
            Assert.Equal("Validation failed", resultValue.Message);
        }


        [Fact]
        public async Task GetAllTeacher_ValidRequest_ReturnsOk()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = new TeacherDTO {  };
            var response = new ResponseParam { Successful = true };

            TeacherServiceMock.Setup(s => s.GetAllTeachers())
                             .ReturnsAsync(response);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task GetAllTeacher_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = new TeacherDTO {  };
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            TeacherServiceMock.Setup(s => s.GetAllTeachers())
                             .ReturnsAsync(response);

            // Act
            var result = await controller.GetAll();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(badRequestResult.Value);
            Assert.False(resultValue.Successful);
            Assert.Equal("Validation failed", resultValue.Message);
        }


        [Fact]
        public async Task DeleteTeacher_ValidRequest_ReturnsOk()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = 1;
            var response = new ResponseParam { Successful = true };

            TeacherServiceMock.Setup(s => s.Delete(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.Delete(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task DeleteTeacher_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var TeacherServiceMock = new Mock<ITeacherService>();
            var controller = new TeacherController(TeacherServiceMock.Object);
            var request = 1;
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            TeacherServiceMock.Setup(s => s.Delete(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.Delete(request);

            // Assert
            var badRequestResult = Assert.IsType<NotFoundObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(badRequestResult.Value);
            Assert.False(resultValue.Successful);
            Assert.Equal("Validation failed", resultValue.Message);
        }
    }
}
