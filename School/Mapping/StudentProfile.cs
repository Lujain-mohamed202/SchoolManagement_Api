using AutoMapper;
using School.DTOs.StudentDTO;
using School.Models;

namespace School.Mapping
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ForMember(dest => dest.fullname,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).
                ForMember(dest => dest.ClassRoomName,
                opt => opt.MapFrom(src => src.ClassRoom.Name));


            CreateMap<CreateStudentDTO, Student>().ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { (' ') })[0])).
                ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { (' ') })[1])).
                ForMember(dest=>dest.ClassRoomId,opt=>opt.MapFrom(src=>src.ClassroomId));


            CreateMap<UpdateStudentDTO, Student>().ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { (' ') })[0])).
                ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.fullname.Split(new[] { (' ') })[1])).
                 ForMember(dest => dest.ClassRoomId, opt => opt.MapFrom(src => src.ClassroomId));

        }
    }
}
