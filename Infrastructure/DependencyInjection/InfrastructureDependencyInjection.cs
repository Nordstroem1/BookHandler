using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
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

            services.AddSingleton<FakeDatabase>();
            return services;
        }
    }
}
