namespace Discoteque.Application.AlbumUseCase.Interfaces
{
    using Discoteque.Domain.Album.Dtos;
    public interface ICreateAlbum
    {
        Task ExecuteAsync(AlbumDto albumDto);
    }
}
