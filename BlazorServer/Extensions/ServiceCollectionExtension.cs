namespace BlazorServer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BlazorContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnectString"));
            });
            service.AddTransient(typeof(IGennericReponsitory<>), typeof(GennericReponsitory<>));
            service.AddTransient<IStudentService, StudentService>();
            service.AddTransient<ISubjectService, SubjectService>();
            service.AddAutoMapper(typeof(PorfileMapping));
            return service;
        }
    }
}