using Microsoft.EntityFrameworkCore;
using PeabuxAssessment.Data;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;

namespace PeabuxAssessment.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseParam> AddStudent(StudentDTO request)
        {
            var response = UResponseHandler.InitializeResponse();
            try
            {
                var validateDate = request.Validate();

                if (!validateDate.Successful)
                {
                    response = validateDate;
                    return response;
                }

                var student = StudentDTO.ToStudent(request);

                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");
            }
            catch (Exception ex)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, ex.Message);
            }
            return response;
        }

        public async Task<ResponseParam> Delete(long id)
        {
            var response = UResponseHandler.InitializeResponse();
            try
            {
                if (id <= 0)
                {
                    response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, "Invalid Student ID");
                    return response;
                }
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, "Invalid Student ID");
                    return response;
                }
                _context.Students.Remove(student); await _context.SaveChangesAsync();
                response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");
            }
            catch (Exception ex)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, ex.Message);
            }
            return response;
        }

        public async Task<ResponseParam> GetAllStudents()
        {
            var response = UResponseHandler.InitializeResponse();
            try
            {
                var students = await _context.Students.ToListAsync();
                var studentDtoList = StudentDTO.FromStudentToDTOList(students);
                response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful", studentDtoList);
            }
            catch (Exception ex)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, ex.Message);
            }
            return response;
        }

    }
}
