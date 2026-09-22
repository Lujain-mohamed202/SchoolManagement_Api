namespace School.DTOs.SubjectDTO
{
    public class UpdateSubjectDTO
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int MaxGrade { get; set; }

        public int TeacherId { get; set; }
    }
}
