using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.StudentDTO;
using School.Mapping;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public StudentController()
        {
            db = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
            });
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            //var st = db.students.Include(c => c.ClassRoom).ToList();
            //List<StudentDTO> DTO = new List<StudentDTO>();
            //foreach (var student in st)
            //{
            //    var dto = new StudentDTO()
            //    {
            //        fullname = student.FirstName + " " + student.LastName,
            //        Email = student.Email,
            //        ClassRoomName = student.ClassRoom.Name,
            //        Id = student.Id


            //    };
            //    DTO.Add(dto);
            //}
            //db.Add(DTO);
            //db.SaveChanges();
            //return Ok(DTO);

            var st = db.students.Include(c=>c.ClassRoom).ToList();
            var DTO = mapper.Map<List<StudentDTO>>(st);
            return Ok(DTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var st = db.students.Find(id);
            //if (st == null)
            //{
            //    return NotFound();
            //}
            //var dto = new StudentDTO()
            //{
            //    fullname = st.FirstName + " " + st.LastName,
            //    Email = st.Email,
            //    ClassRoomName = st.ClassRoom.Name,
            //    Id = st.Id

            //};
            //return Ok(dto);

            var st = db.students.Include(c => c.ClassRoom).FirstOrDefault(s=>s.Id==id);
            var DTO = mapper.Map<StudentDTO>(st);
            return Ok(DTO);


        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO createstudentdto)
        {
            if (createstudentdto == null)
            {
                return BadRequest();
            }
            //var fullname = createstudentdto.fullname.Split(' ', 2);
            //var st = new Student()
            //{
            //    FirstName = fullname[0],
            //    LastName = fullname[1],
            //    Email = createstudentdto.Email,
            //    PhoneNumber = createstudentdto.phonenumber,
            //    ClassRoomId = createstudentdto.Id
            //};

            //db.Add(st);
            //db.SaveChanges();
            //return CreatedAtAction(nameof(GetById), new { id = st.Id }, st);

            var DTO = mapper.Map<Student>(createstudentdto);
            db.Add(DTO);
            db.SaveChanges();
            return Created();

        }
        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentDTO updatestudentdto, int id)
        {
            var student = db.students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            //var fullname = updatestudentdto.fullname.Split(' ', 2);
            //student.FirstName = fullname[0];
            //student.LastName = fullname[1];

            //student.Email = updatestudentdto.Email;
            //student.ClassRoomId = updatestudentdto.Id;
            //student.PhoneNumber = updatestudentdto.phonenumber;
            //db.SaveChanges();
            //return Ok(updatestudentdto);

            mapper.Map(updatestudentdto, student);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var st = db.students.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            db.students.Remove(st);
            db.SaveChanges();
            return NoContent();
        }
    }
}
