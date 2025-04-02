using Application.Dtos;
using Application.IExternalApiServices;
using Application.Interfaces.IServices;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;

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
    public async Task<List<GetGenreDto>> GetAll()
    {
        var genres = await _repositoryManager.GenreRepository.GetAllGenres();
        var genresDto = _mapper.Map<List<GetGenreDto>>(genres);
        return genresDto;
    }

    public async Task<GetGenreDto> GetById(Guid id)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreById(id) 
                    ?? throw new GenreNotFountException(id);
        
        var genreDto = _mapper.Map<GetGenreDto>(genre);
        return genreDto;
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

    public async Task DeleteOne(Guid id)
    {
        await _repositoryManager.GenreRepository.DeleteGenre(id);
        await _repositoryManager.SaveAsync();
    }
}