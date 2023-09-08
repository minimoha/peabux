using Microsoft.AspNetCore.Mvc;
using Moq;
using PeabuxAssessment;
using PeabuxAssessment.Controllers;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;
using PeabuxAssessment.Models;

namespace Peabux.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetStudentsTests()
        {
            //// Arrange
            //int count = 5;
            //var fakeStudents = A.CollectionOfDummy<Student>(count).AsEnumerable();
            //var studentService = A.Fake<IStudentService>();
            //var studentResponse = new ResponseParam();
            //A.CallTo(() =>  studentService.GetAllStudents()).Returns(Task.FromResult(studentResponse));
            //var controller = new StudentController(studentService);

            ////Act
            //var actionResult = await controller.GetAll();

            //// Assert
            ////var result = actionResult.Value as OkObjectResult;
            //var returnObj = actionResult?.Value as ResponseParam;

            //Assert.True(returnObj?.Successful);

            var studentService = new Mock<IStudentService>();
            studentService.Setup(_ => _.GetAllStudents()).ReturnsAsync(StudentMockData.GetAllStudent());
            var sut = new StudentController(studentService.Object);

            var result = (OkObjectResult)await sut.GetAll();


            

            studentService.Verify(_ => _.GetAllStudents(), Times.Exactly(1));
            Assert.True((result?.Value as ResponseParam).Successful);

        }

    }
}