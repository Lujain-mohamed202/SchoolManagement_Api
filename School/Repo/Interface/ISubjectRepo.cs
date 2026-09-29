using School.Models;
using System.Buffers.Text;
using System.Security.Policy;

namespace School.Repo.Interface
{
    public interface ISubjectRepo:IGenericRepo<Subject>
    {
        Subject GetFirst(int id);
        Subject GetLast(int id);
    }


}
