namespace BlazorModel.ViewModels;

public class ViewStudentMark
{
    public Students Student { get; set; }
    public Marks    Mark { get; set; }

    public ViewStudentMark()
    {
        Student = new Students();
        Mark = new Marks();
    }
}