namespace BlazorServer.Services.IService;

public interface IStudentService
{
    public List<ViewStudentMark> Get(int? id);
    public string Add(ViewStu entity);
    public string Update(Students entity);
    public string Delete(int id);
    public List<ViewStudentMark> GetAll();
}