using ExternalApiService;
using GameTracker.Domain;
using GameTracker.Repository;
using GameTracker.Repository.Contracts;
using GameTracker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<GameContext, GameContext>();
builder.Services.AddScoped<GamesRepository, GamesRepository>();
builder.Services.AddScoped<GenreService, GenreService>();
builder.Services.AddScoped<RawgService, RawgService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHttpClient();
builder.Services.AddDbContext<GameContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapControllers();

app.Run();