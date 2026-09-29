using School.Models;

namespace School.Repo.Interface
{
    public interface IClassRoom:IGenericRepo<ClassRoom>
    {
        ClassRoom GetFirstByCapacity(int capacity);
        ClassRoom GetByName(string name);
        ClassRoom AtIndex(int index);
    }
}
