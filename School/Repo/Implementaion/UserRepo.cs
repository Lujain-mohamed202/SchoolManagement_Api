using School.Context;
using School.Models;
using School.Repo.Interface;

namespace School.Repo.Implementaion
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public User? GetByUserName(string userName)
        {
           return _context.users.FirstOrDefault(s=>s.Name== userName);
        }
    }
}
