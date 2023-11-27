namespace Discoteque.Domain.Repositories
{
    using Album.Entities;
    using Artist.Entities;
    using Song.Entities;
    using Tour.Entities;
    public interface IUnitOfWork
    {
        IRepository<int, Artist> ArtistRepository { get; }
        IRepository<int, Album> AlbumRepository { get; }
        IRepository<int, Song> SongRepository { get; }
        IRepository<int, Tour> TourRepository { get; }

        Task SaveAsync();
    }
}
