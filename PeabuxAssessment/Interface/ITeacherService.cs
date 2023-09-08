using PeabuxAssessment.DTO;

namespace PeabuxAssessment.Interface
{
    public interface ITeacherService
    {
        Task<ResponseParam> AddTeacher(TeacherDTO request);
        Task<ResponseParam> GetAllTeachers();
        Task<ResponseParam> Delete(long id);
    }
}
