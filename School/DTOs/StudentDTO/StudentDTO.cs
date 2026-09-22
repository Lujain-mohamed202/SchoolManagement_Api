using School.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DTOs.StudentDTO
{
    public class StudentDTO
    {
        public int Id { get; set; }

       
        public string fullname { get; set; }

       
       

       
        public string Email { get; set; }

      
       


      
       
      

        public string ClassRoomName { get; set; }

    }
}
