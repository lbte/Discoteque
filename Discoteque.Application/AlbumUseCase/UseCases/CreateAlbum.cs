namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using Discoteque.Application.AlbumUseCase.Interfaces;
    using Discoteque.Application.IServices;
    using Discoteque.Domain.Album.Dtos;
    using Discoteque.Domain.Album.Entities;

    public class CreateAlbum : ICreateAlbum
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        public CreateAlbum(IAlbumService albumService, IArtistService artistService)
        {
            _albumService = albumService;
            _artistService = artistService;
        }

        public async Task ExecuteAsync(AlbumDto albumDto)
        {
            var artistId = albumDto.ArtistId;
            var artist = await _artistService.GetById(artistId);
            if (artist is null)
            {
                return; //TODO
            }

            var album = _albumService.GetAlbumByNameAndArtistId(albumDto.Name, artistId);
            if (album is not null)
            {
                return; //TODO
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
