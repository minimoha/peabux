using PeabuxAssessment.Models;
using System.ComponentModel.DataAnnotations;

namespace PeabuxAssessment.DTO
{
    public class StudentDTO
    {
        public long ID { get; set; }
        [Required]
        public string NationalIDNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string StudentNumber { get; set; }

        public ResponseParam Validate()
        {
            var response = UResponseHandler.InitializeResponse();
            response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");

            var age = DateTime.Now.Date.Year - DateOfBirth.Date.Year;

            if (age > 22)
            {
                DateOfBirth = DateOfBirth.Date;
                response = new UResponseHandler().CommitResponse(ResponseCodes.UNSUCCESSFUL, "Age cannot be more than 22");
            }
            return response;
        }

        public static StudentDTO FromStudent(Student student)
        {
            return new StudentDTO
            {
                ID = student.ID,
                NationalIDNumber = student.NationalIDNumber,
                Name = student.Name,
                Surname = student.Surname,
                DateOfBirth = student.DateOfBirth.Date,
                StudentNumber = student.StudentNumber
            };
        }

        public static Student ToStudent(StudentDTO student)
        {
            return new Student
            {
                ID = student.ID,
                NationalIDNumber = student.NationalIDNumber,
                Name = student.Name,
                Surname = student.Surname,
                DateOfBirth = student.DateOfBirth.Date,
                StudentNumber = student.StudentNumber
            };
        }

        public static List<StudentDTO> FromStudentToDTOList(List<Student> student)
        {

            var response = student.Select(x => new StudentDTO()
            {
                ID = x.ID,
                NationalIDNumber = x.NationalIDNumber,
                Name = x.Name,
                Surname = x.Surname,
                DateOfBirth = x.DateOfBirth.Date,
                StudentNumber = x.StudentNumber
            }).ToList();
            return response;
        }
    }
}
