namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using AlbumUseCase.Interfaces;
    using IServices;
    using Domain.Album.Dtos;
    using Domain.Album.Entities;
    using Shared.Exceptions;
    //using Microsoft.Extensions.Logging;
    using Serilog;

    public class CreateAlbum : ICreateAlbum
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        //private readonly ILogger<CreateAlbum> _logger;
        public CreateAlbum(IAlbumService albumService, IArtistService artistService)//, ILogger<CreateAlbum> logger)
        {
            _albumService = albumService;
            _artistService = artistService;
            //_logger = logger;
        }

        public async Task ExecuteAsync(AlbumDto albumDto)
        {
            Log.Information("Entering Create Album");
            var artistId = albumDto.ArtistId;
            var artist = await _artistService.GetById(artistId);
            if (artist is null)
            {
                var exceptionMessage = $"Artist with id {artistId} was not found.";
                Log.Error(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }

            var album = await _albumService.GetAlbumByNameAndArtistId(albumDto.Name, artist.Id);
            if (album is not null)
            {
                var exceptionMessage = "The album that you are trying to create already exists.";
                Log.Error(exceptionMessage);
                throw new AlreadyExistsException(exceptionMessage);
            }
            var newAlbum = new Album()
            {
                Name = albumDto.Name,
                ArtistId = artistId,
                Cost = albumDto.Cost,
                Genre = albumDto.Genre,
                Year = albumDto.Year
            };

             await _albumService.CreateAlbum(newAlbum);
        }
    }
}
