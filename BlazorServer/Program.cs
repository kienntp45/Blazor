var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDI(builder.Configuration);
builder.Services.AddScoped<DbInitializer>();

var cross = "myCross";

builder.Services.AddCors(option =>
    option.AddPolicy(name: cross,
    policy =>
        policy.WithOrigins("*").WithMethods("GET", "PUT", "POST", "DELETE").AllowAnyMethod().AllowAnyHeader()
));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(cross);
app.UseItToSeedSqlServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
