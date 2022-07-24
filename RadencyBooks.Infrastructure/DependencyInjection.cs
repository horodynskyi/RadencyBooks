using Microsoft.Extensions.DependencyInjection;
using RadencyBooks.Application.Interfaces;

namespace RadencyBooks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        return service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}