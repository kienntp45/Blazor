#nullable disable


namespace BlazorServer.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IGennericReponsitory<Students> _studentService;
        private readonly IGennericReponsitory<Marks>    _markService;
        private readonly IMapper                        _mapper;

        public StudentService(IGennericReponsitory<Students> studentService, IGennericReponsitory<Marks> markService, IMapper mapper)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _markService    = markService ?? throw new ArgumentNullException(nameof(markService));
            _mapper         = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ViewStudentMark>> Get(int? id)
        {
            var lstStu  = _studentService.Get();
            var lstMark = _markService.Get();

            var data = (from a in lstStu
                        where a.ID == id
                        join b in lstMark on a.ID equals b.StudentId into k
                        from b in k.DefaultIfEmpty()
                        select new ViewStudentMark
                        {
                            Student = a,
                            Mark = (b != null ? b : null)
                        }).ToList();
            return data;
        }

        public async Task<Students> FindStudnetByIdAsync(int? id)
        {
            var student = _studentService.Get().FirstOrDefault(c => c.ID == id);
            return student;
        }

        public async Task<List<ViewStudentMark>> GetAll(Paging page)
        {
            var lstStu = _studentService.Get();
            var lstMark = _markService.Get();
            if (page.Page < 1) page.Page = 1;
            var data = (from a in lstStu
                        join b in lstMark on a.ID equals b.StudentId into k
                        from b in k.DefaultIfEmpty()
                        select new ViewStudentMark
                        {
                            Student = a,
                            Mark = (b != null ? b : null)
                        }).ToList().OrderBy(x => !x.Student.Status ? 1 : 0);
            var rs = new List<ViewStudentMark>();
            if (page.Name != null)
            {
                  rs = data
                 .Where(n => n.Student.Name.Trim().Contains(page.Name) )
                .Skip((page.Page - 1) * 10)
                .Take(10).Select(c => c)
                .ToList();
            }
            else
            {
               rs = data
               .Skip((page.Page - 1) * 10)
               .Take(10).Select(c => c)
               .ToList();
            }
            return rs;
        }

        public string Add(ViewStu entity)
        {
            var stu = _mapper.Map<Students>(entity);
            stu.DOB = entity.Birthday;
            stu.Status = true;
            if (stu.Gender == 1) stu.Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-vWqC59iaOyq1jAeqkEaf0gXksGYCz6pCNQ&usqp=CAU";
            else stu.Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYEoUhZh-z9j6vsSb3tQQ-4eQC0FYv-Zcj4w&usqp=CAU";
            _studentService.Add(stu);
            return "success";
        }

        public string Update(Students entity)
        {
            if (entity.Gender == 1) entity.Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-vWqC59iaOyq1jAeqkEaf0gXksGYCz6pCNQ&usqp=CAU";
            else entity.Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYEoUhZh-z9j6vsSb3tQQ-4eQC0FYv-Zcj4w&usqp=CAU";
            _studentService.Update(entity);
            return "success";
        }

        public string Delete(int id)
        {
            var lstStu = _studentService.Get();
            var stu    = lstStu.FirstOrDefault(p => p.ID == id);

            if (stu == null) return "error";
            stu.Status = false;
            _studentService.Update(stu);
            return "success";
        }
    }
}
