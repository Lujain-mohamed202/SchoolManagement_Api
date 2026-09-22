using School.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DTOs.TeacherDTO
{
    public class CreateTeacherDTO
    {
       
        public string FullName { get; set; }
       
       
        
        public string? PhoneNumber { get; set; }
      
        public string Email { get; set; }
        
        public decimal salary { get; set; }
       
        public int DepartmentId { get; set; }

    }
}
