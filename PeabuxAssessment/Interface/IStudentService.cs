using PeabuxAssessment.DTO;

namespace PeabuxAssessment.Interface
{
    public interface IStudentService
    {
        Task<ResponseParam> AddStudent(StudentDTO request);
        Task<ResponseParam> GetAllStudents();
        Task<ResponseParam> Delete(long id);
    }
}
