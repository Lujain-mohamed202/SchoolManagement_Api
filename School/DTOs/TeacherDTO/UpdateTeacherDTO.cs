using System.ComponentModel.DataAnnotations;

namespace School.DTOs.TeacherDTO
{
    public class UpdateTeacherDTO
    {
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string? PhoneNumber { get; set; }
       
        public string Email { get; set; }
       
        public decimal salary { get; set; }
 
    }
}
