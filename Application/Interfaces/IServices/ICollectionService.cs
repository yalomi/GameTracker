using Application.Dtos.GetDtos;
using Application.Dtos.PostDtos;
using Application.Dtos.PutDtos;

namespace Application.Interfaces.IServices;

public interface ICollectionService
{
    Task<List<GetGameDto>> GetAll(Guid userId);
    Task<GetGameDto> GetById(Guid gameId, Guid userId);
    Task<GetGameDto> AddUserGame(PostGameDto gameDto, Guid userId);
    Task UpdateUserGame(PutGameDto gameDto, Guid gameId, Guid userId);
}