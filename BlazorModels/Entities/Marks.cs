#nullable disable

namespace BlazorModel.Data.Entities
{
    public class Marks
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }
        public Students Student { get; set; }
        public Subjects Subject { get; set; }
    }
}