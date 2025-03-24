using Application;
using Application.IExternalApiServices;
using Application.IRepositories;
using Application.IServices;
using Application.Mappers;
using Application.Services;
using Infrastructure;
using Infrastructure.ExternalApi;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<GameContext, GameContext>(); //Delete this
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRawgService, RawgService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddAutoMapper(
    typeof(GenresMappingProfile), 
    typeof(GamesMappingProfile), 
    typeof(UsersMappingProfile));

builder.Services.AddHttpClient();
builder.Services.AddDbContext<TrackerContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();