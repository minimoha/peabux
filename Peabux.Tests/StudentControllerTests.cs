using Microsoft.AspNetCore.Mvc;
using Moq;
using PeabuxAssessment;
using PeabuxAssessment.Controllers;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.Tests
{
    public class StudentControllerTests
    {

        [Fact]
        public async Task AddStudent_ValidRequest_ReturnsOk()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = new StudentDTO {  };
            var response = new ResponseParam { Successful = true };

            studentServiceMock.Setup(s => s.AddStudent(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.AddStudent(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task AddStudent_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = new StudentDTO {  };
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            studentServiceMock.Setup(s => s.AddStudent(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.AddStudent(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(badRequestResult.Value);
            Assert.False(resultValue.Successful);
            Assert.Equal("Validation failed", resultValue.Message);
        }


        [Fact]
        public async Task GetAllStudent_ValidRequest_ReturnsOk()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = new StudentDTO {  };
            var response = new ResponseParam { Successful = true };

            studentServiceMock.Setup(s => s.GetAllStudents())
                             .ReturnsAsync(response);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task GetAllStudent_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = new StudentDTO {  };
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            studentServiceMock.Setup(s => s.GetAllStudents())
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
        public async Task DeleteStudent_ValidRequest_ReturnsOk()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = 1;
            var response = new ResponseParam { Successful = true };

            studentServiceMock.Setup(s => s.Delete(request))
                             .ReturnsAsync(response);

            // Act
            var result = await controller.Delete(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ResponseParam>(okResult.Value);
            Assert.True(resultValue.Successful);
        }


        [Fact]
        public async Task DeleteStudent_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var studentServiceMock = new Mock<IStudentService>();
            var controller = new StudentController(studentServiceMock.Object);
            var request = 1;
            var response = new ResponseParam { Successful = false, Message = "Validation failed" };

            studentServiceMock.Setup(s => s.Delete(request))
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
