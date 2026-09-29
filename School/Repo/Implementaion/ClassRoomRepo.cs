using Microsoft.AspNetCore.Mvc;
using School.Context;
using School.Models;
using School.Repo.Interface;

namespace School.Repo.Implementaion
{
    public class ClassRoomRepo : GenericRepo<ClassRoom>, IClassRoom
    {
        private readonly AppDbContext _context;
        public ClassRoomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ClassRoom AtIndex(int index)
        {
            return _context.classRooms.OrderBy(e=>e.Id).ElementAt(index);

        }

        public ClassRoom GetByName(string name)
        {
          return _context.classRooms.SingleOrDefault(r => r.Name == name);
        }

       
        public ClassRoom GetFirstByCapacity(int capacity)
        {
            return _context.classRooms.FirstOrDefault(e => e.Capacity >= capacity);
        }
    }
}
