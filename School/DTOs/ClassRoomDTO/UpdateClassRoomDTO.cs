using System.ComponentModel.DataAnnotations;

namespace School.DTOs.ClassRoomDTO
{
    public class UpdateClassRoomDTO
    {
      

        public string Name { get; set; }

        public int GradeLevel { get; set; }

        
        public int Capacity { get; set; }

    }
}
