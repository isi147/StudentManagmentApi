using Microsoft.AspNetCore.Mvc;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Services;

namespace Student_Managment.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _examService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateExamDto examDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _examService.CreateExamAsync(examDto);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateExamDto examDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _examService.UpdateExamAsync(examDto);
        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _examService.DeleteExam(id);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _examService.GetExamByIdAsync(id);
        return Ok(result);
    }
}
