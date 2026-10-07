using School.Models;

namespace School.Repo.Interface
{
    public interface IUserRepo : IGenericRepo<User>
    {
        User? GetByUserName(string userName);
    }
}
