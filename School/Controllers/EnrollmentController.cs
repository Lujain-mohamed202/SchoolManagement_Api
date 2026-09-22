using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.EnrollmentDTO;
using School.Mapping;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public EnrollmentController()
        {
            db = new AppDbContext();

            var confg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EnrollmentProfile>();
            });
            mapper = confg.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var en = db.enrollments.Include(x => x.Student).Include(x => x.Subject).ToList();
            var DTO = mapper.Map<List<EnrollmentDTO>>(en);
            return Ok(DTO);
        }
        [HttpGet("ID")]
        public IActionResult GetEnrollments(int id)
        {
            var en = db.enrollments.Include(x => x.Student).Include(x => x.Subject).FirstOrDefault();
            var DTO = mapper.Map<EnrollmentDTO>(en);
            return Ok(DTO);
        }
        [HttpPost]
        public IActionResult Create(CreateEnrollmentDTO createEnrollmentDTO)
        {
            if (createEnrollmentDTO == null) return BadRequest();
            var DTO = mapper.Map<Enrollment>(createEnrollmentDTO);
            db.Add(DTO);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(UpdateEnrollmentDTO updateEnrollmentDTO, int id)
        {
            var en = db.enrollments.Find(id);
            if (en == null) return BadRequest();
            mapper.Map(updateEnrollmentDTO, en);
            db.SaveChanges();
            return Ok();
        }
    }
}
