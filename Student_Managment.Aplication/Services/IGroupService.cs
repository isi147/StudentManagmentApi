using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication.Services;

public interface IGroupService
{
    Task<ApiResponse<Group>> CreateGroupAsync(CreateGroupDto groupDto);
    Task<ApiResponse<bool>> DeleteGroup(int id);
    Task<ApiResponse<Group>?> GetGroupByIdAsync(int id);
    Task<ApiResponse<Group>?> UpdateGroupAsync(UpdateGroupDto groupDto);
    Task<ApiResponse<ICollection<Group>>?> GetAllAsync();
}
