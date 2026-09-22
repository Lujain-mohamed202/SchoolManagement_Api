using AutoMapper;
using School.DTOs.EnrollmentDTO;
using School.Models;

namespace School.Mapping
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>().ForMember(dest => dest.StudentName,
                opt => opt.MapFrom(src => src.Student.FirstName)).ForMember(dest => dest.SubjectName,
                opt => opt.MapFrom(src => src.Subject.Name));


            CreateMap<CreateEnrollmentDTO, Enrollment>().ForMember(dest => dest.StudentId,
                opt => opt.MapFrom(src => src.StudentId)).ForMember(dest => dest.SubjectId,
                opt => opt.MapFrom(src => src.SubjectId));

            CreateMap<UpdateEnrollmentDTO, Enrollment>().ForMember(dest => dest.StudentId,
                opt => opt.MapFrom(src => src.StudentId)).ForMember(dest => dest.SubjectId,
                opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}
