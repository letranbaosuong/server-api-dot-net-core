using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _db;
        public StudentController(IStudent db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Save([FromBody] Student data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            _db.Save(data);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudent(int? Id)
        {
            Student data = _db.GetStudent(Id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            IQueryable<Student> data = _db.GetStudents;
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            _db.Delete(Id);
            return Ok();
        }
    }
}
