using School.Models;

namespace School.Repo.Interface
{
    public interface ITeacherRepo:IGenericRepo<Teacher>
    {
        ICollection<Teacher> Filter(int id,int salary);
        Teacher GetByEmail(string email);

       // ICollection<Teacher> GetByDepartment(int id);
    }
}
