namespace Core.Exceptions;

public sealed class GenreNotFountException : NotFoundException
{
    public GenreNotFountException(Guid genreId) 
        : base($"Genre with id: {genreId} does not exist in the database.")
    {
    }
}