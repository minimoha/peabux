using PeabuxAssessment;
using PeabuxAssessment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peabux.Tests
{
    public class StudentMockData
    {
        public static List<StudentDTO> GetAll()
        {
            return new List<StudentDTO> { new StudentDTO() { Name = "John" }, new StudentDTO() { Name = "Jane" } };
        }
        
        public static ResponseParam GetAllStudent()
        {
            return new ResponseParam { 
                Successful = true,
                Data = new List<StudentDTO>() { new StudentDTO() { Name = "John" }, new StudentDTO() { Name = "Jane" } },
                Message = "Successful",
                ResponseCode = ResponseCodes.SUCCESS
        };
        }

        public static ResponseParam NewStudent()
        {
            return new ResponseParam
            {
                Successful = true,
                Data = new List<StudentDTO>(),
                Message = "Successful",
                ResponseCode = ResponseCodes.SUCCESS
            };
        }

        public static StudentDTO NewData()
        {
            var data = new StudentDTO { Name = "John", Surname = "Doe", DateOfBirth = DateTime.Now.Date.AddYears(-11), NationalIDNumber = "4256282782", StudentNumber = "678798477384" };
            return data;
        }
    }
}
