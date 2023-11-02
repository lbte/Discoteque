﻿namespace Discoteque.Domain.Repositories
{
    using Discoteque.Domain.Album.Entities;
    using Discoteque.Domain.Artist.Entities;
    using Discoteque.Domain.Song.Entities;
    using Discoteque.Domain.Tour.Entities;
    using Models;
    public interface IUnitOfWork
    {
        IRepository<int, Artist> ArtistRepository { get; }
        IRepository<int, Album> AlbumRepository { get; }
        IRepository<int, Song> SongRepository { get; }
        IRepository<int, Tour> TourRepository { get; }

        Task SaveAsync();
    }
}
