using AutoMapper;
using School.DTOs.DepartmentDTO;
using School.Models;

namespace School.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Department, CreateDepatmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();



        }

    }
}
