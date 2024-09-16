using AutoMapper;
using Microsoft.AspNetCore.Http;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Aplication.Services;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Services;

public class LessonService : ILessonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Lesson>> CreateLessonAsync(CreateLessonDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        await _unitOfWork.Lessons.AddAsync(lesson);
        await _unitOfWork.CompleteAsync();

        var group = await _unitOfWork.Groups.GetByIdWithLessonsAsync(lessonDto.GroupId);

        if (group is null)
        {
            return new ApiResponse<Lesson>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Group Not Found",
                Data = null!,
                Success = true
            };
        }
        else
            group.Lessons.Add(lesson);

        await _unitOfWork.CompleteAsync();


        return new ApiResponse<Lesson>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Lesson Created",
            Data = lesson,
            Success = true
        };
    }

    public async Task<ApiResponse<bool>> DeleteLesson(int id)
    {
        var result = await _unitOfWork.Lessons.GetByIdAsync(id);
        if (result is not null) _unitOfWork.Lessons.Remove(result);

        if (result is null)
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Lesson not Deleted",
                Data = false,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Lesson Deleted",
                Data = true,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<ICollection<Lesson>>?> GetAllAsync()
    {
        var result = _unitOfWork.Lessons.GetAll();
        return new ApiResponse<ICollection<Lesson>>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Deleted",
            Data = result.ToList(),
            Success = true
        };
    }

    public async Task<ApiResponse<Lesson>?> GetLessonByIdAsync(int id)
    {
        var result = await _unitOfWork.Lessons.GetByIdAsync(id);

        if (result is null)
        {
            return new ApiResponse<Lesson>()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Lesson Not Found",
                Data = null!,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<Lesson>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "",
                Data = result,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<Lesson>?> UpdateLessonAsync(UpdateLessonDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        _unitOfWork.Lessons.Update(lesson);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Lesson>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Lesson Updated",
            Data = lesson,
            Success = true
        };
    }
}
