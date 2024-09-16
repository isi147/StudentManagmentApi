using AutoMapper;
using Microsoft.AspNetCore.Http;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Aplication.Services;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Student>> CreateStudentAsync(CreateStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Student>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Student Created",
            Data = student,
            Success = true
        };
    }

    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        var result = await _unitOfWork.Students.GetByIdAsync(id);
        if (result is not null) _unitOfWork.Students.Remove(result);

        if (result is null)
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Student not Deleted",
                Data = false,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Student Deleted",
                Data = true,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<ICollection<Student>>?> GetAllAsync()
    {
        var result = _unitOfWork.Students.GetAll();
        return new ApiResponse<ICollection<Student>>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Deleted",
            Data = result.ToList(),
            Success = true
        };
    }

    public async Task<ApiResponse<Student>?> GetStudentByIdAsync(int id)
    {
        var result = await _unitOfWork.Students.GetByIdAsync(id);

        if (result is null)
        {
            return new ApiResponse<Student>()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Student Not Found",
                Data = null!,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<Student>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "",
                Data = result,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<Student>?> UpdateStudentAsync(UpdateStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        _unitOfWork.Students.Update(student);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Student>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Lesson Updated",
            Data = student,
            Success = true
        };
    }
}
