using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuendetMS.Data;
using StuendetMS.Entity;
using System.Net;

namespace StuendetMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studetns = await _studentDbContext.Students.ToListAsync();
            return Ok(studetns);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            await _studentDbContext.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created, student);
        }
    }
}
