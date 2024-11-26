using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Data.UnitOfWork;
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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<FakeDatabase>();

            return services;
        }
    }
}
