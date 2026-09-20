using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Context;
using School.DTOs.DepartmentDTO;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext db;

        public DepartmentController()
        {
            db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var dept = db.Departments.ToList();
            List<DepartmentDTO > depDto=new List<DepartmentDTO>();
            foreach(var d in dept)
            {
                var dep = new DepartmentDTO() {
                    id = d.Id,
                    name = d.Name,
                  description = d.Description

                };
                depDto.Add(dep);
                
            }
            if (depDto.Count == 0 || depDto == null) 
            { 
                return NotFound();
            }
            return Ok(depDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartments(int id)
        {

            var dep = db.Departments.FirstOrDefault(t => t.Id == id);
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepatmentDTO createDepatmentDTO) 
        {
            if (createDepatmentDTO == null)
            {
                return BadRequest("Department not Created");
            }
            var Department = new Department()
            {
                Name = createDepatmentDTO.name,
                Description = createDepatmentDTO.description,
            };
            db.Departments.Add(Department);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO, int id) 
        {
            var i = db.Departments.FirstOrDefault(a => a.Id == id);
            if(i == null)
            {
                return NotFound();
            }

            i.Name = updateDepartmentDTO.name;
            i.Description= updateDepartmentDTO.description;
            
            db.SaveChanges();
            return Ok(updateDepartmentDTO);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteDepartment(int id) 
        { 
            var deb = db.Departments.FirstOrDefault(b => b.Id == id);
            if(deb == null)
            {
                return NotFound();
            }
            db.Departments.Remove(deb);
            db.SaveChanges();
            return Ok();
        }

    }
}