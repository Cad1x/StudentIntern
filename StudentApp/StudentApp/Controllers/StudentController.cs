using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        public StudentController(IStudentServices studentService) 
        {
            _studentService = studentService;
        }

        [SwaggerOperation(Summary ="Pobiera wszystkich studentów")]
        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentService.GetAllStudent();
            return Ok(students);
        }

        [SwaggerOperation(Summary = "Pobiera określony produkt według unikatowego ID")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [SwaggerOperation(Summary = "Dodaje nowego studenta")]
        [HttpPost]
        public IActionResult Create(CreateStudentDto newStudent) 
        {
            var student = _studentService.CreateStudent(newStudent);
            return Created($"api/students/{student.Id}", student);
        }

        [SwaggerOperation(Summary = "Aktualizuje istniejącego studenta")]
        [HttpPut]
        public IActionResult Update(UpdateStudentDto updateStudent) 
        {
            _studentService.UpdateStudent(updateStudent);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Usuwa studenta po unikatowym ID")]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }


    }
}
