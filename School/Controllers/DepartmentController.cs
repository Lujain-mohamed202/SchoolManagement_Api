using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.Context;
using School.DTOs.DepartmentDTO;
using School.Mapping;
using School.Models;
using School.Repo.Interface;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
      //  private readonly AppDbContext db;

        private readonly IMapper mapper;

        private readonly IGenericRepo<Department> debRepo;


        public DepartmentController(IGenericRepo<Department> debRepo)
        {
           this.debRepo = debRepo;

            var confg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DepartmentProfile>();
            });
            mapper = confg.CreateMapper();


        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            //Manual Mapping 

            //var dept = db.Departments.ToList();
            //List<DepartmentDTO> depDto = new List<DepartmentDTO>();
            //foreach (var d in dept)
            //{
            //    var dep = new DepartmentDTO()
            //    {
            //        id = d.Id,
            //        name = d.Name,
            //        description = d.Description

            //    };
            //    depDto.Add(dep);

            //}
            //if (depDto.Count == 0 || depDto == null)
            //{
            //    return NotFound();
            //}
            //return Ok(depDto);


            //Auto Mapping
            //var dep = db.Departments.ToList();


            //var DTO = mapper.Map<List<DepartmentDTO>>(dep);
            //return Ok(DTO);



            return Ok(debRepo.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetDepartments(int id)
        {
            //Manual Mapping

            //var dep = db.Departments.FirstOrDefault(t => t.Id == id);
            //var DTO = new DepartmentDTO()
            //{
            //    name=  dep.Name,
            //    description=dep.Description,
            //    id=dep.Id

            //};
            //return Ok(DTO);

            //Auto Mapping
            //var dep = db.Departments.Find(id);
            //var DTO = mapper.Map<DepartmentDTO>(dep);
            //return Ok(DTO);

            return Ok(debRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepatmentDTO createDepatmentDTO )
        {
            //Manual Mappping
            //if (createDepatmentDTO == null)
            //{
            //    return BadRequest("Department not Created");
            //}
            //var Department = new Department()
            //{
            //    Name = createDepatmentDTO.name,
            //    Description = createDepatmentDTO.description,
            //};
            //db.Departments.Add(Department);
            //db.SaveChanges();
            //return Ok();

            ////Auto Mapping 
            //if (createDepatmentDTO == null)
            //{
            //    return BadRequest();
            //}
            var DTO = mapper.Map<Department>(createDepatmentDTO);
             debRepo.Create(DTO);
            return CreatedAtAction(nameof(GetDepartments), new { id = DTO.Id }, createDepatmentDTO);

            

        }
        [HttpPut("update")]
        public IActionResult UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO, int id) 
        {
            //Manual Mapping
            //var i = db.Departments.FirstOrDefault(a => a.Id == id);
            //if(i == null)
            //{
            //    return NotFound();
            //}

            //i.Name = updateDepartmentDTO.name;
            //i.Description= updateDepartmentDTO.description;

            //db.SaveChanges();
            //return Ok(updateDepartmentDTO);



            //Auto Mapping

            var dep = debRepo.GetById(id);
            if (dep == null)
            {
                NotFound();
            }
            dep = mapper.Map(updateDepartmentDTO, dep);
            debRepo.Update(dep);
           return Ok(dep);



        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id) 
        { 
            //var deb = db.Departments.FirstOrDefault(b => b.Id == id);
            //if(deb == null)
            //{
            //    return NotFound();
            //}
            //db.Departments.Remove(deb);
            //db.SaveChanges();
            debRepo.Delete(id);
            return Ok();
        }

    }
}