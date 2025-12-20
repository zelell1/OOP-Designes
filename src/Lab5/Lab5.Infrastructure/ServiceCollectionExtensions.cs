using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection collection, string password)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<IAdminPasswordRepository>(new AdminPasswordRepository(password));
        collection.AddSingleton<IBankAccountRepository, BankAccountRepository>();
        collection.AddSingleton<IOperationsHistoryRepository, OperationHistoryRepository>();
        collection.AddSingleton<ISessionsRepository, SessionRepository>();

        return collection;
    }
}