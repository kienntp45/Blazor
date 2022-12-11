#nullable disable

namespace BlazorServer.Services.Service;

public class MarkService : IMarkService
{
    private readonly IGennericReponsitory<Marks> _markService;
    public MarkService(IGennericReponsitory<Marks> markService)
    {
        _markService = markService;
    }

    public string Add(Marks entity)
    {
        if (entity == null) return "error";
        _markService.Add(entity);
        return "success";
    }

    public string Delete(int id)
    {
        var lstMa = _markService.Get();
        var mark = lstMa.FirstOrDefault(p => p.Equals(id));
        if (mark == null) return "error";
        _markService.Delete(mark);
        return "success";
    }

    public List<Marks> Get(int? id)
    {
        var lstMark = _markService.Get();
        if (id == null)
        {
            return lstMark;
        }
        else
        {
            var lstMarkById = lstMark.Where(p => p.SubjectId.Equals(id)).ToList();
            return lstMarkById;
        }
    }

    public string Update(Marks entity)
    {
        if (entity == null) return "error";
        _markService.Update(entity);
        return "success";
    }
}