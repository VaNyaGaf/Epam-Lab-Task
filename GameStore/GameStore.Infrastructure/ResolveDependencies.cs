using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;
using GameStore.Infrastructure.Authorization;
using GameStore.Infrastructure.Repositories;
using GameStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Infrastructure
{
    public static class ResolveDependencies
    {
        public static void RegisterDependecies(this IServiceCollection servcies, string connectionString, string authConnectonString)
        {
            servcies.AddDbContext<GameStoreContext>(options => options.UseSqlServer(connectionString));
            servcies.AddDbContext<AuthDbContext>(options => options.UseSqlServer(authConnectonString));

            servcies.AddTransient<ICommentRepository, CommentRepository>();
            servcies.AddTransient<IGameRepository, GameRepository>();
            servcies.AddTransient<IGenreRepository, GenreRepository>();
            servcies.AddTransient<IPlatformTypeRepository, PlatformTypeRepository>();
            servcies.AddTransient<IPublisherRepository, PublisherRepository>();

            servcies.AddTransient<IGameService, GameService>();
            servcies.AddTransient<IGenreService, GenreService>();
            servcies.AddTransient<IPublisherService, PublisherService>();
            servcies.AddTransient<ICommentService, CommentService>();
        }
    }
}
