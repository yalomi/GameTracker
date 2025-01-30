﻿using Core.Entities;

namespace Application.IServices;

public interface IGenreService
{
    Task<List<Genre>> GetAll();
    Task<Genre> GetById(Guid id);
}