#nullable disable

namespace BlazorServer.Data
{
    public class DbInitializer
    {
        internal static async void Initialize(BlazorContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
            if (!context.Students.Any())
            {
                var lstStu = new List<Students>
                {
                    new Students() { Name = "Ngô Kiên",  Account  = "kien2810",Password  = "28102002",DOB = DateTime.Now, Gender = 1,Status = true},
                    new Students() { Name = "Ngô Kiên1", Account = "kien28101",Password = "28102002",DOB = DateTime.Now, Gender = 1,Status = true},
                    new Students() { Name = "Ngô Kiên2", Account = "kien28102",Password = "28102002",DOB = DateTime.Now, Gender = 1,Status = true}
                };
               await  context.Students.AddRangeAsync(lstStu);
            }

            if (!context.Subjects.Any())
            {
                var lstSub = new List<Subjects>
                {
                 new Subjects(){  Name = "Tin Hoc",   Status = true},
                 new Subjects(){ Name = "CNTT",      Status = true},
                 new Subjects(){ Name = "Lap trinh", Status = true},
                };
               await context.Subjects.AddRangeAsync(lstSub);
            }
            context.SaveChanges();
            if (!context.Marks.Any())
            {
                var stu = context.Students.ToList().FirstOrDefault();
                var sub = context.Subjects.ToList().FirstOrDefault();
                var lstMark = new List<Marks>
                {
                    new Marks(){ CreateDate = DateTime.Now ,Scores =8 ,StudentId  = stu.ID,SubjectId = sub.ID },
                };
              await  context.Marks.AddRangeAsync(lstMark);
            }
            context.SaveChanges();
        }
    }
}