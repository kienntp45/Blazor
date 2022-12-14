#nullable disable 

namespace BlazorWeb.Services.StudentService
{
    public class StudentService : IStudentService
    { 
        readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ViewStudentMark>> viewStudents()
        {
            var rs = new List<ViewStudentMark>();
            rs = await _httpClient.GetFromJsonAsync<List<ViewStudentMark>>("/get-all");
            return rs;
        }
    }
}