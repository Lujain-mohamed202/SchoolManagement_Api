using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Context;
using School.DTOs.ClassRoomDTO;
using School.Models;
using System.Runtime.CompilerServices;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly AppDbContext db;
        public ClassRoomController()
        {
            db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var classroom = db.classRooms.ToList();
            List<ClassRoomDTO> DTO = new List<ClassRoomDTO>();
            foreach (var c in classroom)
            {
                var dto = new ClassRoomDTO()
                {
                    Name = c.Name,
                    GradeLevel = c.GradeLevel,
                    Id = c.Id
                };
                DTO.Add(dto);
            }
            if (DTO == null || DTO.Count == 0)
            {
                return NotFound();
            }
            return Ok(DTO);


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = db.classRooms.Find(id);
            if(classroom == null)
            { 
                return NotFound(); 
            }
            var DTO = new ClassRoomDTO()
            {
                Name = classroom.Name,
                GradeLevel = classroom.GradeLevel,
                Id = id
            };
            return Ok(DTO);

        }
        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassRoomDTO createclassroomdto)
        {
            if (createclassroomdto == null)
            {
                return BadRequest();
            }
            var classroom = new ClassRoom()
            {
                Name = createclassroomdto.Name,
                GradeLevel = createclassroomdto.GradeLevel,
                Capacity = createclassroomdto.Capacity
            };
            db.classRooms.Add(classroom);
            db.SaveChanges();
            return Created();

        }
        [HttpPut]
        public IActionResult UpdateClassroom(int id,UpdateClassRoomDTO updateclassroomdto)
        {
            var classroom = db.classRooms.Find(id);
            if(classroom == null)
            {
                return NotFound();
            }
            classroom.Name= updateclassroomdto.Name;
            classroom.GradeLevel= updateclassroomdto.GradeLevel;
            classroom.Capacity= updateclassroomdto.Capacity;

            db.SaveChanges();
            return Ok(updateclassroomdto);
        }
        [HttpDelete]
        public IActionResult DeleteClassroom(int id)
        {
            var classroom = db.classRooms.Find(id);
            if( classroom == null)
            {
                return NotFound();
            }
            db.classRooms.Remove(classroom);
            db.SaveChanges();
            return NoContent();
        }
    }
}