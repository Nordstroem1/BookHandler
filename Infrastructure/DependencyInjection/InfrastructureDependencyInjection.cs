using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Infrastructure.Databases;
namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            var assembly = typeof(InfrastructureDependencyInjection).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));
            services.AddSingleton<FakeDatabase>();
            return services;
        }
    }
}
