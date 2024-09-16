using AutoMapper;
using Microsoft.AspNetCore.Http;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Aplication.Services;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Services;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<Group>> CreateGroupAsync(CreateGroupDto groupDto)
    {
        var group = _mapper.Map<Group>(groupDto);
        await _unitOfWork.Groups.AddAsync(group);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Group>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Group Created",
            Data = group,
            Success = true
        };
    }

    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        var result = await _unitOfWork.Groups.GetByIdAsync(id);
        if (result is not null) _unitOfWork.Groups.Remove(result);

        if (result is null)
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Group not Deleted",
                Data = false,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<bool>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Group Deleted",
                Data = true,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<ICollection<Group>>?> GetAllAsync()
    {
        var result = _unitOfWork.Groups.GetAll();
        return new ApiResponse<ICollection<Group>>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Exam Deleted",
            Data = result.ToList(),
            Success = true
        };
    }

    public async Task<ApiResponse<Group>?> GetGroupByIdAsync(int id)
    {
        var result = await _unitOfWork.Groups.GetByIdAsync(id);

        if (result is null)
        {
            return new ApiResponse<Group>()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Group Not Found",
                Data = null!,
                Success = false
            };
        }
        else
        {
            return new ApiResponse<Group>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "",
                Data = result,
                Success = true
            };
        }
    }

    public async Task<ApiResponse<Group>?> UpdateGroupAsync(UpdateGroupDto groupDto)
    {
        var group = _mapper.Map<Group>(groupDto);
        _unitOfWork.Groups.Update(group);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse<Group>()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Group Updated",
            Data = group,
            Success = true
        };
    }
}
