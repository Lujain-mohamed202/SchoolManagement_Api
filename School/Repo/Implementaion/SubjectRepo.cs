using Microsoft.EntityFrameworkCore;
using School.Context;
using School.Migrations;
using School.Models;
using School.Repo.Interface;
using System.Security.Policy;

namespace School.Repo.Implementaion
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        private readonly AppDbContext _context;
        public SubjectRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Subject GetFirst(int id)
        {
          
            var e = _context.subjects.Include(e=>e.Teacher).OrderBy(e=>e.Name).FirstOrDefault(e=>e.TeacherId==id);
            return e;
        }
//        Get the latest subject taught by the specified teacher
//based on the highest subject ID, or return 404 if none
//exists.

        public Subject GetLast(int id)
        {
            var i = _context.subjects.OrderBy(e => e.Id).Where(e => e.TeacherId == id).Last();
            return i;
        }
    }
}
