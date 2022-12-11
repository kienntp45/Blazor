#nullable disable

namespace BlazorServer.Data.Entities
{
    public class Subjects
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<Marks> Marks { get; set; }
    }
}
