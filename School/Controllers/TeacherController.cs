using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.TeacherDTO;
using School.Mapping;
using School.Models;
using School.Repo.Implementaion;
using School.Repo.Interface;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

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


            var teach = unitOfWork.teachers.GetAll();
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

            var teach = unitOfWork.teachers.GetById(id);
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
            unitOfWork.teachers.Create(DTO);
            return Created();



        }

        [HttpPut]
        public IActionResult UpdateTeacher(int id, UpdateTeacherDTO updateTeacherDTO)
        {
            var tech = unitOfWork.teachers.GetById(id);
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
           
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
           
            unitOfWork.teachers.Delete(id);
            
            return Ok();
        }
    

    [HttpGet("GetById")]
    public IActionResult GetByDepartment(int id,int salary)
        {
            return Ok(unitOfWork.teachers.Filter(id, salary));
        }
        [HttpGet("ByEmail")]
        public IActionResult GetByEmail(string email)
        {
            return Ok(unitOfWork.teachers.GetByEmail(email));
        }
        

}

}