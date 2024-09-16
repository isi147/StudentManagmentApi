using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication.Services;

public interface IExamService
{
    Task<ApiResponse<Exam>> CreateExamAsync(CreateExamDto examDto);
    Task<ApiResponse<bool>> DeleteExam(int id);
    Task<ApiResponse<Exam>?> GetExamByIdAsync(int id);
    Task<ApiResponse<Exam>?> UpdateExamAsync(UpdateExamDto examDto);
    Task<ApiResponse<ICollection<Exam>>?> GetAllAsync();
}
