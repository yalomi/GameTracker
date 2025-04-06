using Application;
using Application.IExternalApiServices;
using Application.Interfaces;
using Application.Interfaces.IManagers;
using Application.IRepositories;
using Application.Mappers;
using Application.Services;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.ExternalApi;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddControllers();
builder.Services.AddSwagger();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRawgService, RawgService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddAutoMapper(
    typeof(GenresMappingProfile), 
    typeof(GamesMappingProfile), 
    typeof(UsersMappingProfile));

builder.Services.AddHttpClient();
builder.Services.AddDbContext<GameTrackerContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IJwtProvider, JwtProvider>(); //Singleton or Scoped

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();