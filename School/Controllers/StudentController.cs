using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.StudentDTO;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext db;
        public StudentController()
        {
            db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var st = db.students.Include(c => c.ClassRoom).ToList();
            List<StudentDTO> DTO = new List<StudentDTO>();
            foreach (var student in st)
            {
                var dto = new StudentDTO()
                {
                    fullname = student.FirstName + " " + student.LastName,
                    Email = student.Email,
                    ClassRoomName = student.ClassRoom.Name,
                    Id = student.Id


                };
                DTO.Add(dto);
            }
            db.Add(DTO);
            db.SaveChanges();
            return Ok(DTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var st = db.students.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            var dto = new StudentDTO()
            {
                fullname = st.FirstName + " " + st.LastName,
                Email = st.Email,
                ClassRoomName = st.ClassRoom.Name,
                Id = st.Id

            };
            return Ok(dto);

        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO createstudentdto)
        {
            if (createstudentdto == null)
            {
                return BadRequest();
            }
            var fullname = createstudentdto.fullname.Split(' ', 2);
            var st = new Student()
            {
                FirstName = fullname[0],
                LastName = fullname[1],
                Email = createstudentdto.Email,
                PhoneNumber = createstudentdto.phonenumber,
                ClassRoomId = createstudentdto.ClassroomId
            };

            db.Add(st);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = st.Id }, st);

        }
        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentDTO updatestudentdto, int id)
        {
            var student = db.students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            var fullname = updatestudentdto.fullname.Split(' ', 2);
            student.FirstName = fullname[0];
            student.LastName = fullname[1];

            student.Email = updatestudentdto.Email;
            student.ClassRoomId = updatestudentdto.ClassroomId;
            student.PhoneNumber = updatestudentdto.phonenumber;
            db.SaveChanges();
            return Ok(updatestudentdto);
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
