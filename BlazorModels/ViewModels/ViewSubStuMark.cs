namespace BlazorServer.ViewModels;

public class ViewSubStuMark
{
    public Marks    Mark    { get; set; }
    public Subjects Subject { get; set; }
    public Students Student { get; set; }

    public ViewSubStuMark()
    {
        Mark    = new Marks();
        Subject = new Subjects();
        Student = new Students();
    }
}