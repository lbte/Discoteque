using Discoteque.Domain.Models;

namespace Discoteque.Domain
{
    public interface IUnitOfWork
    {
        IRepository<int, Artist> ArtistRepository { get; }
        IRepository<int, Album> AlbumRepository { get; }
        IRepository<int, Song> SongRepository { get; }
        IRepository<int, Tour> TourRepository { get; }

        Task SaveAsync();
    }
}
