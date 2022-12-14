namespace BlazorWeb.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<ViewStudentMark>> viewStudents();
    }
}
