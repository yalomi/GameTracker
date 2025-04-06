namespace Core.Exceptions;

public class GameNotFoundException : NotFoundException
{
    public GameNotFoundException(Guid id) 
        : base($"Game with id: {id} does not exist in the database.")
    {
    }
}