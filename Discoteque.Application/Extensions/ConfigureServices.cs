namespace Discoteque.Application.Extensions
{
    using AlbumUseCase.Interfaces;
    using AlbumUseCase.UseCases;
    using Microsoft.Extensions.DependencyInjection;
    public static class ConfigureServices
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services.AddScoped<ICreateAlbum, CreateAlbum>()
            .AddScoped<IGetAlbum, GetAlbum>()
            .AddScoped<IUpdateAlbum, UpdateAlbum>();
    }
}