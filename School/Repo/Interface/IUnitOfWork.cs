using School.Models;

namespace School.Repo.Interface
{
    public interface IUnitOfWork 
    {
       ITeacherRepo teachers { get; }
        ISubjectRepo subjects { get; }
        IClassRoom classRooms { get; }
        
        IGenericRepo<Student>students { get; }
        IGenericRepo<Enrollment> enrollments { get; }
        IGenericRepo<Department> debartments { get; }

        void Save();
    }
}
