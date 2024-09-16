using Microsoft.AspNetCore.Mvc;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Services;
using Student_Managment.Persistence.Services;

namespace Student_Managment.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _groupService.GetAllAsync();
        return Ok(result);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateGroupDto groupDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _groupService.CreateGroupAsync(groupDto);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateGroupDto groupDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _groupService.UpdateGroupAsync(groupDto);
        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _groupService.DeleteGroup(id);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _groupService.GetGroupByIdAsync(id);
        return Ok(result);
    }
}
