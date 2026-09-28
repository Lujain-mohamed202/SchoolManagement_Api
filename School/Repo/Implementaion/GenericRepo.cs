using Microsoft.EntityFrameworkCore;
using School.Context;
using School.Repo.Interface;

namespace School.Repo.Implementaion
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;

        private readonly DbSet<T> db;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            db = context.Set<T>();  // context.entityName
            
        }



        public void Create(T entity)
        {
           db.Add(entity);
           _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var i = db.Find(id);
            db.Remove(i);
            _context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {

            return db.ToList();
        }

        public T GetById(int id)
        {
            return db.Find(id);
        }

        public void Update(T entity)
        {
            db.Update(entity);
            _context.SaveChanges();
        }
    }
}
