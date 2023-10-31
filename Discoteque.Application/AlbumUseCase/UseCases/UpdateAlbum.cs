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
        public async Task<Album> ExecuteAsync(AlbumDto albumDto)
        {
            //return await _albumService.UpdateAlbum(albumDto);
            throw new NotImplementedException();
        }
    }
}
