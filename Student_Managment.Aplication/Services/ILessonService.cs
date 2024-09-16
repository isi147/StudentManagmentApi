using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication.Services;

public interface ILessonService
{
    Task<ApiResponse<Lesson>> CreateLessonAsync(CreateLessonDto lessonDto);
    Task<ApiResponse<bool>> DeleteLesson(int id);
    Task<ApiResponse<Lesson>?> GetLessonByIdAsync(int id);
    Task<ApiResponse<Lesson>?> UpdateLessonAsync(UpdateLessonDto lessonDto);
    Task<ApiResponse<ICollection<Lesson>>?> GetAllAsync();
}
