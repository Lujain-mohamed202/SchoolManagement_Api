using AutoMapper;
using School.DTOs.ClassRoomDTO;
using School.Models;

namespace School.Mapping
{
    public class ClassroomProfile:Profile
    {
        public ClassroomProfile()
        {
            CreateMap<ClassRoom,ClassRoomDTO>();
            CreateMap<CreateClassRoomDTO,ClassRoom>();
            CreateMap<UpdateClassRoomDTO,ClassRoom>();
            
        }
    }
}
