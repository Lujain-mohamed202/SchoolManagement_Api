using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.TeacherDTO;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext db;
        public TeacherController()
        {
            db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var tech = db.Teachers.Include(e => e.department).ToList();

            List<TeacherDTO> tDTO = new List<TeacherDTO>();
            foreach (var t in tech)
            {
                var td = new TeacherDTO()
                {
                    name = t.FirstName + " " + t.LastName,
                    id = t.TeacheriD,
                    Email = t.Email,
                    DepName = t.department.Name
                };
                tDTO.Add(td);

            }
            if (tDTO == null || tDTO.Count() == 0)
            {
                return NotFound();
            }
            return Ok(tDTO);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = db.Teachers.Include(e => e.department).FirstOrDefault(e => e.TeacheriD == id);
            if (teacher == null)
            {
                return NotFound();
            }
            var y = new TeacherDTO()
            {
                id = teacher.TeacheriD,
                name = teacher.FirstName + " " + teacher.LastName,
                Email = teacher.Email,
                DepName = teacher.department.Name
            };
            return Ok(y);
        }
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO createTeacherDTO)
        {
            if (createTeacherDTO == null)
            {
                return NotFound();
            }

            var fullname = createTeacherDTO.FullName.Split(' ', 2);
            var t = new Teacher()
            {
                FirstName = fullname[0],
                LastName = fullname[1],
                Email = createTeacherDTO.Email,
                PhoneNumber = createTeacherDTO.PhoneNumber,
                DepartmentId = createTeacherDTO.DepartmentId,
                salary = createTeacherDTO.salary


            };
            db.Add(t);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = t.TeacheriD }, t);





        }

        [HttpPut]
        public IActionResult UpdateTeacher(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            var tech = db.Teachers.Find(id);
            if (tech == null)
            {
                return NotFound();
            }


            tech.PhoneNumber = updateTeacherDTO.PhoneNumber;
            tech.Email = updateTeacherDTO.Email;
            tech.salary = updateTeacherDTO.salary;
            tech.DepartmentId = updateTeacherDTO.DeaprtmentID;


            var fullname = updateTeacherDTO.fullname.Split(' ', 2);
            tech.FirstName = fullname[0];
            tech.LastName = fullname[1];

            db.SaveChanges();
            return Ok(updateTeacherDTO);

        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            var tech = db.Teachers.Find(id);
            if(tech == null)
            {
                return NotFound();
            }
            db.Teachers.Remove(tech);
            db.SaveChanges();
            return Ok();
        }
    }

}