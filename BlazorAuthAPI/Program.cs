using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.DependencyInjection;
using BlazorAuthAPI.Core.User.Entities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterDatabase();
builder.Services.RegisterMappers();
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BlazorAuthAPI",
        Description = "API para cadastro e login de usu�rios",
        Contact = new OpenApiContact
        {
            Name = "Jo�o Pedro Monteiro",
            Url = new Uri("https://www.linkedin.com/in/joaopedro-monteiro/"),
            Email = "joaopedrobdmgbr@gmail.com"
        }
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Existing configuration code

    SeedDatabase(app);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

void SeedDatabase(IApplicationBuilder app)
{
    using var serviceScope = app.ApplicationServices.CreateScope();
    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

    context?.Users.AddRange(
        new User { Name = "Admin", Email = "admin@example.com", Password = "admin123", Cpf = "679.448.630-07", Role = "Admin" },
        new User { Name = "User", Email = "user@example.com", Password = "user123", Cpf = "583.404.300-33", Role = "User" }
    );

    context?.SaveChanges();
}

app.Run();
