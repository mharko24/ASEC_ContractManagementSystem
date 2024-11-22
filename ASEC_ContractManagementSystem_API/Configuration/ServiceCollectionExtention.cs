using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Interfaces.Common;
using ASEC_ContractManagementSystem_API.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ASEC_ContractManagementSystem_API.Configuration
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGetAssignProjectRepository), typeof(GetAssignProjectRepository));
            services.AddTransient(typeof(IPaginatedRepository<>), typeof(PaginatedRepository<>));
            return services;
        }
        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connection);
            });

            return services;
        }
    }
}
