namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using AlbumUseCase.Interfaces;
    using IServices;
    using Shared.Exceptions;
    using Domain.Album.Dtos;
    using Domain.Album.Entities;
    using Serilog;

    public class UpdateAlbum : IUpdateAlbum
    {
        private readonly IAlbumService _albumService;

        public UpdateAlbum(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<Album?> ExecuteAsync(AlbumDto albumDto)
        {
            var album = await _albumService.GetAlbumByNameAndArtistId(albumDto.Name, albumDto.ArtistId);
            if (album is null)
            {
                var exceptionMessage = $"The album you're trying to update was not found.";
                Log.Error(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }
            album.Name = albumDto.Name;
            album.YearPublished = albumDto.YearPublished;
            album.Genre = albumDto.Genre;
            album.Cost = albumDto.Cost;

            return await _albumService.UpdateAlbum(album);
        }
    }
}
