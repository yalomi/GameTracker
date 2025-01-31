namespace Application.IServices;

public interface IGameService
{
    Task CreateOne(int id);
    Task CreateMany(int quantity);
}