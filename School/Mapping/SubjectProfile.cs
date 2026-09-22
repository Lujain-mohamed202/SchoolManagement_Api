using AutoMapper;
using School.DTOs.SubjectDTO;
using School.Models;

namespace School.Mapping
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject,SubjectDTO>().ForMember(dest=>dest.TeacherName,
                opt=>opt.MapFrom(src=>src.Teacher.FirstName+" "+src.Teacher.LastName));


            CreateMap<CreateSubjectDTO,Subject>().ForMember(dest=>dest.TeacherId,
                opt=>opt.MapFrom(src=>src.TeacherId));

            CreateMap<UpdateSubjectDTO,Subject>().ForMember(dest=>dest.TeacherId,
                opt=>opt.MapFrom(src=>src.TeacherId));
        }
    }
}
