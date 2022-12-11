namespace BlazorServer.Reponsitories.Interface;

public interface IGennericReponsitory<T> where T : class
{
    public List<T> Get();
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}