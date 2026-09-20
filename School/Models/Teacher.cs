using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public int TeacheriD {  get; set; }
        [Required]
        [MaxLength(50)]
        public string  FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        [Range(0,int.MaxValue)]
        [Required]
        public decimal salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department department { get; set; }
    }
}
