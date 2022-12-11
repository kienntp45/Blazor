namespace BlazorServer.Services.IService;

public interface ISubjectService
{
    public List<ViewSubStuMark> Get(int id);
    public string Add(ViewSub entity);
    public string Update(Subjects entity);
    public string Delete(int id);
    public List<ViewSubStuMark> GetAll();
}