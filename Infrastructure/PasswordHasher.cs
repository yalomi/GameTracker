using Application;

namespace Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool Verify(string password, string hashed)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashed);
    }
}