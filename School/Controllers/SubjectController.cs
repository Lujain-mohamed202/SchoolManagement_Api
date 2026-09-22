using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.SubjectDTO;
using School.Mapping;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public SubjectController()
        {
            db = new AppDbContext();

            var confg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SubjectProfile>();
            });
            mapper = confg.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var sub = db.subjects.Include(t => t.Teacher).ToList();
            var DTO = mapper.Map<List<SubjectDTO>>(sub);
            return Ok(DTO);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var sub = db.subjects.Include(t => t.Teacher).FirstOrDefault(t => t.Id == id);
            var DTO = mapper.Map<SubjectDTO>(sub);
            return Ok(DTO);
        }
        [HttpPost]
        public IActionResult Create(CreateSubjectDTO createsubjectDTO)
        {
            if (createsubjectDTO == null)
            {
                return BadRequest();
            }

            var DTO = mapper.Map<Subject>(createsubjectDTO);
            db.Add(DTO);
            db.SaveChanges();
            return Created();
        }
        [HttpPut]
        public IActionResult Edit(UpdateSubjectDTO updateSubjectDTO, int id)
        {
            var sub = db.subjects.Find(id);
            if (sub == null) return NotFound();
            mapper.Map(updateSubjectDTO, sub);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sub = db.subjects.Find(id);
            if (sub == null) return NotFound();
            db.Remove(sub);
            db.SaveChanges();
            return Ok();
        }
    } 
}
