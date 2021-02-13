using Data;
using Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SampleContext _context;
        private readonly IValidator<Student> _studentsValidation;
        public StudentsController(SampleContext context, IValidator<Student> studentsValidation)
        {
            _context = context;
            _studentsValidation = studentsValidation;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetSudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var result = _studentsValidation.Validate(student);
            if (!result.IsValid)
                return BadRequest(
                result.Errors.Select(x => new
                {
                    property = x.PropertyName,
                    error = x.ErrorMessage
                }));
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

    }
}
