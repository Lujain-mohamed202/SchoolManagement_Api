using School.Context;
using School.Models;
using School.Repo.Interface;

namespace School.Repo.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context,ITeacherRepo teacherRepo, IGenericRepo<Department> debartments, ISubjectRepo subjectRepo, IClassRoom classRoomRepo ,IGenericRepo<Student> studendRepo, IGenericRepo<Enrollment> enrollmentRepo)

        {
            _context = context;
            this.subjects = subjectRepo;
            this.teachers = teacherRepo;
            this.classRooms = classRoomRepo;
            this.students = studendRepo;
            this.enrollments = enrollmentRepo;

        }
        public ITeacherRepo teachers { get; }

        public ISubjectRepo subjects { get; }

        public IClassRoom classRooms { get; }

        public IGenericRepo<Student> students { get; }

        public IGenericRepo<Enrollment> enrollments { get; }

        public IGenericRepo<Department> debartments { get; }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
