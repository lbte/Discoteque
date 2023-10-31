namespace Discoteque.Application.AlbumUseCase.Interfaces
{
    using Discoteque.Domain.Album.Dtos;
    using Domain.Album.Entities;
    public interface IUpdateAlbum
    {
        Task<Album> ExecuteAsync(AlbumDto albumDto);
    }
}
