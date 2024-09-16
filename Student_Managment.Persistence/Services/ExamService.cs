using AutoMapper;
using Microsoft.AspNetCore.Http;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Aplication.Services;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Services;

public class ExamService : IExamService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Exam>> CreateExamAsync(CreateExamDto examDto)
    {
        var exam = _mapper.Map<Exam>(examDto);
        await _unitOfWork.Exams.AddAsync(exam);

        var student = await _unitOfWork.Students.GetByIdAsync(exam.StudentId);

        if (student is null)
        {
            return new ApiResponse<Exam>()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Student Not Found",
                Data = null!,
                Success = true
            };
        }
        else
            student.Exams.Add(exam);


        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Exam>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Created",
            Data = exam,
            Success = true
        };
    }

    public async Task<ApiResponse<bool>> DeleteExam(int id)
    {
        var result = await _unitOfWork.Exams.GetByIdAsync(id);
        if (result is not null) _unitOfWork.Exams.Remove(result);

        if (result is null)
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Exam not Deleted",
                Data = false,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Exam Deleted",
                Data = true,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<ICollection<Exam>>?> GetAllAsync()
    {
        var result = _unitOfWork.Exams.GetAll();
        return new ApiResponse<ICollection<Exam>>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Deleted",
            Data = result.ToList(),
            Success = true
        };
    }

    public async Task<ApiResponse<Exam>?> GetExamByIdAsync(int id)
    {
        var result = await _unitOfWork.Exams.GetByIdAsync(id);

        if (result is null)
        {
            return new ApiResponse<Exam>()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Exam Not Found",
                Data = null!,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<Exam>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "",
                Data = result,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<Exam>?> UpdateExamAsync(UpdateExamDto examDto)
    {
        var exam = _mapper.Map<Exam>(examDto);
        _unitOfWork.Exams.Update(exam);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Exam>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Updated",
            Data = exam,
            Success = true
        };
    }
}
