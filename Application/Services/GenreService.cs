﻿using Application.IRepositories;
using Application.IServices;
using Core.Entities;
using ExternalApiService;

namespace Application.Services;

public class GenreService : IGenreService
{
    private readonly IRepositoryManager _repositoryManager;
    public GenreService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public IEnumerable<Genre> GetAll()
    {
        var genres = _repositoryManager.GenreRepository.GetAllGenres();
        //Mapping
        return genres;
    }
    // public async Task CreateGenre(int id)
    // {
    //     var genre = await _rawgService.FetchGenreAsync(id);
    //     
    //     _context.Genres.Add(genre);
    //     await _context.SaveChangesAsync();
    // }
}