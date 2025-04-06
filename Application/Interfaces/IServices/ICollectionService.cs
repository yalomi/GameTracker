using Application.Dtos.GetDtos;
using Application.Dtos.PostDtos;

namespace Application.Interfaces.IServices;

public interface ICollectionService
{
    public Task<List<GetGameDto>> GetAll(Guid userId);
    Task AddGameToCollection(PostGameDto gameDto, Guid userId);
}