using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Context;
using School.DTOs.ClassRoomDTO;
using School.Mapping;
using School.Models;
using School.Repo.Interface;
using System.Runtime.CompilerServices;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {

        private readonly IGenericRepo<ClassRoom> classRepo;
        private readonly IMapper mapper;
        public ClassRoomController(IGenericRepo<ClassRoom> classRepo)
        {
           this.classRepo =classRepo;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClassroomProfile>();
            });
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetClassrooms()
        {
            //var classroom = db.classRooms.ToList();
            //List<ClassRoomDTO> DTO = new List<ClassRoomDTO>();
            //foreach (var c in classroom)
            //{
            //    var dto = new ClassRoomDTO()
            //    {
            //        Name = c.Name,
            //        GradeLevel = c.GradeLevel,
            //        Id = c.Id
            //    };
            //    DTO.Add(dto);
            //}
            //if (DTO == null || DTO.Count == 0)
            //{
            //    return NotFound();
            //}
            //return Ok(DTO);

            var classroom = classRepo.GetAll();
            var DTO = mapper.Map<List<ClassRoomDTO>>(classroom);
            return Ok(DTO);


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = classRepo.GetById(id);
            if(classroom == null)
            { 
                return NotFound(); 
            }
            //var DTO = new ClassRoomDTO()
            //{
            //    Name = classroom.Name,
            //    GradeLevel = classroom.GradeLevel,
            //    Id = id
            //};
            //return Ok(DTO);
          var DTO=  mapper.Map<ClassRoomDTO>(classroom);
            return Ok(DTO);

        }
        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassRoomDTO createclassroomdto)
        {
            if (createclassroomdto == null)
            {
                return BadRequest();
            }
            //var classroom = new ClassRoom()
            //{
            //    Name = createclassroomdto.Name,
            //    GradeLevel = createclassroomdto.GradeLevel,
            //    Capacity = createclassroomdto.Capacity
            //};
            //db.classRooms.Add(classroom);
            //db.SaveChanges();
            //return Created();
            var DTO = mapper.Map<ClassRoom>(createclassroomdto);
            classRepo.Create(DTO);
          
            return Created();

        }
        [HttpPut]
        public IActionResult UpdateClassroom(int id,UpdateClassRoomDTO updateclassroomdto)
        {
            var classroom = classRepo.GetById(id);
            if(classroom == null)
            {
                return NotFound();
            }
            //classroom.Name= updateclassroomdto.Name;
            //classroom.GradeLevel= updateclassroomdto.GradeLevel;
            //classroom.Capacity= updateclassroomdto.Capacity;

            //db.SaveChanges();
            //return Ok(updateclassroomdto);

            mapper.Map(updateclassroomdto, classroom);
            classRepo.Update(classroom);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteClassroom(int id)
        {
            //var classroom =classRepo.GetById(id);
            //if( classroom == null)
            //{
            //    return NotFound();
            //}
           classRepo.Delete(id);
           
            return NoContent();
        }
    }
}