using Application.MappingProfiles;
using Domain.Interfaces;
using Infrastructure.Data.Caching;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ApplicationDepencencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationDepencencyInjection).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));
            services.AddScoped<TokenHelper>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddMemoryCache();
            services.AddScoped<ICacheMemoryService, MemoryCacheService>();
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("DefaultCache",
                    new CacheProfile()
                    {
                        Duration = 60,
                        Location = ResponseCacheLocation.Any,
                    });
            });
            services.AddMemoryCache();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<BookmappingProfile>();
                config.AddProfile<AuthormappingProfile>();
            }, assembly);

            return services;
        }
    }
}
