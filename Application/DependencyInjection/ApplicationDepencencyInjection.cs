
using Application.Books.Commands.CreateBook;
using Application.MappingProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ApplicationDepencencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationDepencencyInjection).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookmappingProfile>();
                cfg.AddProfile<AuthormappingProfile>();
            });
            services.AddSingleton(config.CreateMapper());

            return services;
        }
    }
}
