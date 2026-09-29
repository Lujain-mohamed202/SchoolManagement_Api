using Microsoft.EntityFrameworkCore;
using School.Context;
using School.Models;
using School.Repo.Interface;

namespace School.Repo.Implementaion
{
    public class TeacherRepo : GenericRepo<Teacher>, ITeacherRepo
    {
        private readonly AppDbContext _context;
        public TeacherRepo(AppDbContext context) : base(context)
        {
            _context=context;
        }

        public  ICollection<Teacher> Filter(int id,int salary)
        {

            return _context.Teachers.
                Where(e => e.DepartmentId == id&&e.salary>salary).ToList();
           
         
        }

        

        public Teacher GetByEmail(string email) 
        {
            return _context.Teachers.Where(e => e.Email.Contains(email)).FirstOrDefault();
        }



    }
}
