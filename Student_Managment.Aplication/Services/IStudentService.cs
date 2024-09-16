using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication.Services;

public interface IStudentService
{
    Task<ApiResponse<Student>> CreateStudentAsync(CreateStudentDto studentDto);
    Task<ApiResponse<bool>> DeleteStudent(int id);
    Task<ApiResponse<Student>?> GetStudentByIdAsync(int id);
    Task<ApiResponse<Student>?> UpdateStudentAsync(UpdateStudentDto studentDto);
    Task<ApiResponse<ICollection<Student>>?> GetAllAsync();
}
