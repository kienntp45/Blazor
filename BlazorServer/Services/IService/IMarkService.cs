namespace BlazorServer.Services.IService;

public interface IMarkService
{
    public List<Marks> Get(int? id);
    public string Add(Marks entity);
    public string Update(Marks entity);
    public string Delete(int id);
}