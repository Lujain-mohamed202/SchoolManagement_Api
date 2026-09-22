using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.TeacherDTO;
using School.Mapping;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext db;

        private readonly IMapper mapper;

        public TeacherController()
        {
            db = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TeacherProfile>();
            });
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            //var tech = db.Teachers.Include(e => e.department).ToList();

            //List<TeacherDTO> tDTO = new List<TeacherDTO>();
            //foreach (var t in tech)
            //{
            //    var td = new TeacherDTO()
            //    {
            //        name = t.FirstName + " " + t.LastName,
            //        id = t.TeacheriD,
            //        Email = t.Email,
            //        Name = t.department.Name
            //    };
            //    tDTO.Add(td);

            //}
            //if (tDTO == null || tDTO.Count() == 0)
            //{
            //    return NotFound();
            //}
            //return Ok(tDTO);


            var teach = db.Teachers.Include(d=>d.department).ToList();
            var DTO = mapper.Map<List<TeacherDTO>>(teach);
            return Ok(DTO);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var teacher = db.Teachers.Include(e => e.department).FirstOrDefault(e => e.TeacheriD == id);
            //if (teacher == null)
            //{
            //    return NotFound();
            //}
            //var y = new TeacherDTO()
            //{
            //    id = teacher.TeacheriD,
            //    name = teacher.FirstName + " " + teacher.LastName,
            //    Email = teacher.Email,
            //    Name = teacher.department.Name
            //};
            //return Ok(y);

            var teach = db.Teachers.Include(d => d.department).FirstOrDefault(t=>t.TeacheriD==id);
            var DTO = mapper.Map<TeacherDTO>(teach);
            return Ok(DTO);

        }
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO createTeacherDTO)
        {
            if (createTeacherDTO == null)
            {
                return NotFound();
            }

            //var fullname = createTeacherDTO.FullName.Split(' ', 2);
            //var t = new Teacher()
            //{
            //    FirstName = fullname[0],
            //    LastName = fullname[1],
            //    Email = createTeacherDTO.Email,
            //    PhoneNumber = createTeacherDTO.PhoneNumber,
            //    DepartmentId = createTeacherDTO.DepartmentId,
            //    salary = createTeacherDTO.salary


            //};
            //db.Add(t);
            //db.SaveChanges();
            //return CreatedAtAction(nameof(GetById), new { id = t.TeacheriD }, t);

            var DTO = mapper.Map<Teacher>(createTeacherDTO);
            db.Add(DTO);
            db.SaveChanges();
            return Created();



        }

        [HttpPut]
        public IActionResult UpdateTeacher(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            var tech = db.Teachers.Find(id);
            if (tech == null)
            {
                return NotFound();
            }


            //tech.PhoneNumber = updateTeacherDTO.PhoneNumber;
            //tech.Email = updateTeacherDTO.Email;
            //tech.salary = updateTeacherDTO.salary;
            //tech.DepartmentId = updateTeacherDTO.DeaprtmentID;


            //var fullname = updateTeacherDTO.fullname.Split(' ', 2);
            //tech.FirstName = fullname[0];
            //tech.LastName = fullname[1];

            //db.SaveChanges();
            //return Ok(updateTeacherDTO);


            mapper.Map(updateTeacherDTO, tech);
            db.SaveChanges();
            return Ok();

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