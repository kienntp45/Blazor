#nullable disable

namespace BlazorServer.Reponsitories.Implement;

public class GennericReponsitory<T> : IGennericReponsitory<T> where T : class
{
    private readonly BlazorContext _context;
    public GennericReponsitory(BlazorContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(T entity)
    {
        _context.Add<T>(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove<T>(entity);
        _context.SaveChanges();
    }

    public List<T> Get()
    {
        try
        {
            var data = _context.Set<T>().AsNoTracking().ToList();
            return data;
        }
        catch (Exception )
        {
            return null;
        }
        finally
        {

        }
    }

    public void Update(T entity)
    {
        _context.Update<T>(entity);
        _context.SaveChanges();
    }
}

