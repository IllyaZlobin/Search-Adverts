using berloga.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace berloga.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}