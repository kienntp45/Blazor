#nullable disable

namespace BlazorServer.Data.Entities
{
    public class Students
    {
        public int      ID {     get; set; }
        public string   Name     { get; set; }
        public string   Account  { get; set; }
        public string   Password { get; set; }
        public DateTime DOB      { get; set; }
        public int      Gender   { get; set; }
        public bool     Status   { get; set; }

        public ICollection<Marks> Marks { get; set; }
    }
}
