using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Repositories;

public class AdminPasswordRepository : IAdminPasswordRepository
{
    public string Password { get; private set; }

    public AdminPasswordRepository(string password)
    {
        Password = password;
    }
}