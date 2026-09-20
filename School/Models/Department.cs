using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace School.Models
{
    public class Department
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [AllowNull]
        [MaxLength(100)]
        public string? Description { get; set; }
       
        public ICollection<Teacher> Teachers { get; set; }=new List<Teacher>();
    }
}
