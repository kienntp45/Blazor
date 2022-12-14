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

        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<BlazorContext>();
            DbInitializer.Initialize(context);
            return app;
        }
    }
}