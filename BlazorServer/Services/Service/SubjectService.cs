#nullable disable

namespace BlazorServer.Services.Service;

public class SubjectService : ISubjectService
{
    private readonly IGennericReponsitory<Subjects> _subjectService;
    private readonly IGennericReponsitory<Marks> _markService;
    private readonly IGennericReponsitory<Students> _studentService;
    private readonly IMapper _mapper;

    public SubjectService(IGennericReponsitory<Subjects> subjectService, IGennericReponsitory<Marks> markService, IGennericReponsitory<Students> studentService, IMapper mapper)
    {
        _subjectService = subjectService;
        _markService = markService;
        _studentService = studentService;
        _mapper = mapper;
    }

    public string Add(ViewSub entity)
    {
        if (entity == null) return "error";
        var sub = _mapper.Map<Subjects>(entity);
        _subjectService.Add(sub);
        return "success";
    }

    public string Delete(int id)
    {
        var lstSub = _subjectService.Get();
        var sub = lstSub.FirstOrDefault(p => p.ID.Equals(id));
        if (sub == null) return "error";
        _subjectService.Delete(sub);
        return "success";
    }

    public List<ViewSubStuMark> Get(int id)
    {
        var lstSub = _subjectService.Get();
        var lstMark = _markService.Get();
        var lstStu = _studentService.Get();
        var data = (from a in lstSub
                    where a.ID.Equals(id)
                    join b in lstMark on a.ID equals b.SubjectId
                    join c in lstStu on b.StudentId equals c.ID into y
                    from l in y.DefaultIfEmpty()
                    select new ViewSubStuMark
                    {
                        Subject = a,
                        Mark = (b == null ? null : b),
                        Student = (l == null ? null : l),
                    }).ToList();
        return data;
    }

    public List<ViewSubStuMark> GetAll()
    {
        var lstSub = _subjectService.Get();
        var lstMark = _markService.Get();
        var lstStu = _studentService.Get();
        var data = (from a in lstSub
                    join b in lstMark on a.ID equals b.SubjectId
                    join c in lstStu on b.StudentId equals c.ID into y
                    from l in y.DefaultIfEmpty()
                    select new ViewSubStuMark
                    {
                        Subject = a,
                        Mark = (b == null ? null : b),
                        Student = (l == null ? null : l),
                    }).ToList();
        return data;
    }

    public string Update(Subjects entity)
    {
        _subjectService.Update(entity);
        return "success";
    }
}

