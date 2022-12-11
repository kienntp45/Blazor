namespace BlazorServer.Mapping
{
    public class PorfileMapping : Profile
    {
        public PorfileMapping()
        {
            CreateMap<ViewStu, Students>().ReverseMap();
            CreateMap<ViewSub, Subjects>().ReverseMap();
        }
    }
}