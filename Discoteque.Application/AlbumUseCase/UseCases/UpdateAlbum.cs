namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using Application.AlbumUseCase.Interfaces;
    using Application.IServices;
    using Domain.Album.Dtos;
    using Domain.Album.Entities;
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
                return null; //TODO
            }
            album.Name = albumDto.Name;
            album.Year = albumDto.Year;
            album.Genre = albumDto.Genre;
            album.Cost = albumDto.Cost;

            return await _albumService.UpdateAlbum(album);
        }
    }
}
