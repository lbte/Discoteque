namespace Discoteque.Application.IServices
{
    using Domain.Shared;
    using Domain.Album.Entities;
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbumsAsync(bool areReferencesLoaded);
        Task<IEnumerable<Album>> GetAlbumsByYear(int year);
        Task<IEnumerable<Album>> GetAlbumsByYearRange(int initialYear, int maxYear);
        Task<IEnumerable<Album>> GetAlbumsByGenre(Genres genre);
        Task<IEnumerable<Album>> GetAlbumsByArtist(int artistId);
        Task<Album?> GetAlbumByNameAndArtistId(string albumName, int artistId);
        Task<Album> GetById(int id);
        Task<EntityMessage<Album>> CreateAlbum(Album album);
        Task<Album> UpdateAlbum(Album album);
    }
}
