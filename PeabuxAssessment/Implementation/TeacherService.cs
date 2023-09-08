using PeabuxAssessment.Data;
using PeabuxAssessment.DTO;
using PeabuxAssessment.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace PeabuxAssessment.Implementation
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;
        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseParam> AddTeacher(TeacherDTO request)
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

                var validateSalary = request.ValidateSalary();

                if (!validateSalary.Successful)
                {
                    response = validateSalary;
                    return response;
                }

                var teacher = TeacherDTO.ToTeacher(request);

                _context.Teachers.Add(teacher);
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
                    response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, "Invalid Teacher ID");
                    return response;
                }
                var teacher = await _context.Teachers.FindAsync(id);
                if (teacher == null)
                {
                    response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, "Invalid Teacher ID");
                    return response;
                }
                _context.Teachers.Remove(teacher); await _context.SaveChangesAsync();
                response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful");
            }
            catch (Exception ex)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, ex.Message);
            }
            return response;
        }

        public async Task<ResponseParam> GetAllTeachers()
        {
            var response = UResponseHandler.InitializeResponse();
            try
            {
                var teachers  = await _context.Teachers.ToListAsync();
                var teacherDtoList = TeacherDTO.FromTeacherToDTOList(teachers);
                response = new UResponseHandler().CommitResponse(ResponseCodes.SUCCESS, "Successful", teacherDtoList);
            }
            catch (Exception ex)
            {
                response = new UResponseHandler().CommitResponse(ResponseCodes.ERROR, ex.Message);
            }
            return response;
        }

    }

}
