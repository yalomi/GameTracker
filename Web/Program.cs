using Application.IExternalApiServices;
using Application.IRepositories;
using Application.IServices;
using Application.Mappers;
using Application.Services;
using Core;
using Infrastructure;
using Infrastructure.ExternalApi;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//builder.Services.AddScoped<GameContext, GameContext>(); //Delete this
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRawgService, RawgService>();

builder.Services.AddAutoMapper(
    typeof(GenresMappingProfile), 
    typeof(GamesMappingProfile), 
    typeof(UsersMappingProfile));

builder.Services.AddHttpClient();
builder.Services.AddDbContext<GameContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapControllers();

app.Run();