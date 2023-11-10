namespace Discoteque.Infrastructure.Extensions
{
    using Application.IServices;
    using Application.Extensions;
    using Domain.Repositories;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IArtistService, ArtistService>()
                    .AddScoped<IAlbumService, AlbumService>()
                    .AddScoped<ISongService, SongService>()
                    .AddScoped<ITourService, TourService>();

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddUseCases();
    }
}