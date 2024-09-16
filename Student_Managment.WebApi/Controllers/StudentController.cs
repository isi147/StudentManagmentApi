using Microsoft.AspNetCore.Mvc;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Aplication.Services;
using Student_Managment.Persistence.Services;

namespace Student_Managment.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto studentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _studentService.CreateStudentAsync(studentDto);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateStudentDto studentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _studentService.UpdateStudentAsync(studentDto);
        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _studentService.DeleteStudent(id);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _studentService.GetStudentByIdAsync(id);
        return Ok(result);
    }
}
