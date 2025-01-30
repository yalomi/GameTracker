using Application.IExternalApiServices;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Core.Entities;

namespace Application.Services;

public class GenreService : IGenreService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly Lazy<IRawgService> _rawgService;
    private readonly IMapper _mapper;
    public GenreService(
        IRepositoryManager repositoryManager, IMapper mapper, IRawgService rawgService)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _rawgService = new Lazy<IRawgService>(rawgService);
    }
    public async Task<List<Genre>> GetAll()
    {
        var genres = await _repositoryManager.GenreRepository.GetAllGenres();
        //Mapping
        return genres;
    }

    public async Task<Genre> GetById(Guid id)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreById(id);
        //Mapping
        return genre;
    }
    public async Task CreateOne(int id)
    {
        var rawgGenre = await _rawgService.Value.FetchGenreAsync(id);
        var genre = _mapper.Map<Genre>(rawgGenre);
        await _repositoryManager.GenreRepository.CreateGenre(genre);
        await _repositoryManager.SaveAsync();
    }

    public async Task CreateMany()
    {
        var rawgGenres = await _rawgService.Value.FetchGenresAsync();
        var genres = _mapper.Map<List<Genre>>(rawgGenres);
        
        foreach (var genre in genres)
        {
            await _repositoryManager.GenreRepository.CreateGenre(genre);
        }
        await _repositoryManager.SaveAsync();
    }
}