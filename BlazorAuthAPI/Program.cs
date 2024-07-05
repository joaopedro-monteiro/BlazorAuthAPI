using BlazorAuthAPI.Auth;
using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.DependencyInjection;
using BlazorAuthAPI.Core.Shared.Jwt;
using BlazorAuthAPI.Core.User;
using BlazorAuthAPI.Core.User.Entities;
using Duett.Api.Middlewares.Error;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var assemblies = typeof(AppDbContext).Assembly;

// Add services to the container.
builder.Services.RegisterDatabase();
builder.Services.RegisterServices();
builder.Services.RegisterAutoMapper(assemblies);
builder.Services.RegisterFluentValidation(assemblies);
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BlazorAuthAPI",
        Description = "API para cadastro e login de usuários",
        Contact = new OpenApiContact
        {
            Name = "João Pedro Monteiro",
            Url = new Uri("https://www.linkedin.com/in/joaopedro-monteiro/"),
            Email = "joaopedrobdmgbr@gmail.com"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = JwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = JwtOptions.Audience,

            ValidateLifetime = true,

            IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddHttpContextAccessor();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
