namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using Application.AlbumUseCase.Interfaces;
    using Application.IServices;
    using Discoteque.Application.Shared.Exceptions;
    using Domain.Album.Dtos;
    using Domain.Album.Entities;
    using Microsoft.Extensions.Logging;

    public class UpdateAlbum : IUpdateAlbum
    {
        private readonly IAlbumService _albumService;
        private readonly ILogger<UpdateAlbum> _logger;

        public UpdateAlbum(IAlbumService albumService, ILogger<UpdateAlbum> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }
        public async Task<Album?> ExecuteAsync(AlbumDto albumDto)
        {
            var album = await _albumService.GetAlbumByNameAndArtistId(albumDto.Name, albumDto.ArtistId);
            if (album is null)
            {
                var exceptionMessage = $"The album you're trying to update was not found.";
                _logger.LogError(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }
            album.Name = albumDto.Name;
            album.Year = albumDto.Year;
            album.Genre = albumDto.Genre;
            album.Cost = albumDto.Cost;

            return await _albumService.UpdateAlbum(album);
        }
    }
}
