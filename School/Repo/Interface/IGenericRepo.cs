namespace School.Repo.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        public ICollection<T> GetAll();
       public T GetById (int id);
       public void Create (T entity);
       public  void Update (T entity);
       public void Delete (int id);

    }
}
