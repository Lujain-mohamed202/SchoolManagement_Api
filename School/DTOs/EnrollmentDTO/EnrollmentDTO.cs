using School.Models;
using System.ComponentModel.DataAnnotations;

namespace School.DTOs.EnrollmentDTO
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }

       
        public string StudentName { get; set; }
       

        public string SubjectName { get; set; }
       
        public DateTime EnrollmentDate { get; set; }

        
        public decimal Grade { get; set; }
    }
}
