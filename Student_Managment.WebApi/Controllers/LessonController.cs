using Microsoft.AspNetCore.Mvc;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Responses;
using Student_Managment.Aplication.Services;
using Student_Managment.Domain.Concretes;
using Student_Managment.Persistence.Services;

namespace Student_Managment.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _lessonService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateLessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _lessonService.CreateLessonAsync(lessonDto);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateLessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _lessonService.UpdateLessonAsync(lessonDto);
        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _lessonService.DeleteLesson(id);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _lessonService.GetLessonByIdAsync(id);
        return Ok(result);
    }
}
