using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Repositories;
namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<MySqlDatabase>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<FakeDatabase>();

            return services;
        }
    }
}
