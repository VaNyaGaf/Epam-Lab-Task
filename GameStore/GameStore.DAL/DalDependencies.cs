using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.DAL
{
    public static class DalDependencies
    {
        public static void RegisterDalDependecies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GameStoreContext>(optioins => optioins.UseSqlServer(connectionString));
        }
    }
}
