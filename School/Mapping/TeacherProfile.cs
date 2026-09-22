using AutoMapper;
using School.DTOs.TeacherDTO;
using School.Models;

namespace School.Mapping
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ForMember(dest=>dest.fullname,
                opt => opt.MapFrom(src => src.FirstName+" "+src.LastName)).
                ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.department.Name));

            CreateMap<CreateTeacherDTO, Teacher>().ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' })[0]))
                .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' })[1]));


            CreateMap<UpdateTeacherDTO, Teacher>().ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { ' ' })[0]))
                .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { ' ' })[1]));

        }
    }
}
