using Application.Dtos.GetDtos;
using Application.Dtos.PostDtos;

namespace Application.Interfaces.IServices;

public interface ICollectionService
{
    Task<List<GetGameDto>> GetAll(Guid userId);
    Task<GetGameDto> GetById(Guid gameId, Guid userId);
    Task<GetGameDto> AddGameToCollection(PostGameDto gameDto, Guid userId);
}