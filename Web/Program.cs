using Application;
using Application.IExternalApiServices;
using Application.Interfaces;
using Application.IRepositories;
using Application.IServices;
using Application.Mappers;
using Application.Services;
using Infrastructure;
using Infrastructure.ExternalApi;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

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

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();