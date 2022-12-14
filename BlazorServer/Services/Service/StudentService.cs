﻿#nullable disable

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

        public async Task<List<ViewStudentMark>> GetAll()
        {
            var lstStu  = _studentService.Get();
            var lstMark = _markService.Get();

            var data = (from a in lstStu
                        join b in lstMark on a.ID equals b.StudentId into k
                        from b in k.DefaultIfEmpty()
                        select new ViewStudentMark
                        {
                            Student = a,
                            Mark = (b != null ? b : null)
                        }).ToList();

            return data;
        }

        public string Add(ViewStu entity)
        {
            var stu = _mapper.Map<Students>(entity);
            _studentService.Add(stu);
            return "success";
        }

        public string Update(Students entity)
        {
            _studentService.Update(entity);
            return "success";
        }

        public string Delete(int id)
        {
            var lstStu = _studentService.Get();
            var stu    = lstStu.FirstOrDefault(p => p.ID == id);

            if (stu == null) return "error";
            _studentService.Delete(stu);
            return "success";
        }
    }
}
