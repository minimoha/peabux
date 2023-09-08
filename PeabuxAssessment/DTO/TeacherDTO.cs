using PeabuxAssessment.Models;
using System.ComponentModel.DataAnnotations;

namespace PeabuxAssessment.DTO
{
    public class TeacherDTO
    {
        public long ID { get; set; }
        [Required]
        public string NationalIDNumber { get; set; }
        [Required]
        [AllowedTitle]
        public string Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }

        public ResponseParam Validate()
        {
            var response = UResponseHandler.InitializeResponse();
            response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");

            var age = DateTime.Now.Date.Year - DateOfBirth.Date.Year;

            if (21 > age)
            {
                DateOfBirth = DateOfBirth.Date;
                response = new UResponseHandler().CommitResponse(ResponseCodes.UNSUCCESSFUL, "Age cannot be less than 21");
            }

            return response;
        }
        
        public ResponseParam ValidateSalary()
        {
            var response = UResponseHandler.InitializeResponse();
            response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");
            if (Salary < 0)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.UNSUCCESSFUL, "Salary cannot be less than 0");
            }
            return response;
        }

        public static TeacherDTO FromTeacher(Teacher teacher)
        {
            return new TeacherDTO 
            { 
                ID = teacher.ID,
                NationalIDNumber = teacher.NationalIDNumber,
                Title = teacher.Title,
                Name = teacher.Name,
                Surname = teacher.Surname,
                DateOfBirth = teacher.DateOfBirth.Date,
                TeacherNumber = teacher.TeacherNumber,
                Salary = teacher.Salary
            };
        }
        
        public static List<TeacherDTO> FromTeacherToDTOList(List<Teacher> teacher)
        {

            var response = teacher.Select(x => new TeacherDTO()
                                      {
                                          ID = x.ID,
                                          NationalIDNumber = x.NationalIDNumber,
                                          Title = x.Title,
                                          Name = x.Name,
                                          Surname = x.Surname,
                                          DateOfBirth = x.DateOfBirth.Date,
                                          TeacherNumber = x.TeacherNumber,
                                          Salary = x.Salary
                                      }).ToList();
            return response;
        }
        
        public static Teacher ToTeacher(TeacherDTO teacher)
        {
            return new Teacher 
            { 
                ID = teacher.ID,
                NationalIDNumber = teacher.NationalIDNumber,
                Title = teacher.Title,
                Name = teacher.Name,
                Surname = teacher.Surname,
                DateOfBirth = teacher.DateOfBirth.Date,
                TeacherNumber = teacher.TeacherNumber,
                Salary = teacher.Salary
            };
        }
    }
}
