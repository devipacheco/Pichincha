using Management.Domain.Interfaces;
using Management.Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Management.Domain.Models;

namespace Management.Infraestructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IMovementRepository, MovementRepository>();

            return services;
        }
    }
}
