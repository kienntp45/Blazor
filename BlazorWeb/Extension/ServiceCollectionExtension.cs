namespace BlazorWeb.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IStudentService, StudentService>();
            service.AddBlazorStrap();
            return service;
        }
    }
}
