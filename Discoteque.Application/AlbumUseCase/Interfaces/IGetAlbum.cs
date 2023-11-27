namespace Discoteque.Application.AlbumUseCase.Interfaces
{
    using Discoteque.Domain.Album.Entities;

    public interface IGetAlbum
    {
        Task<IEnumerable<Album>> AllAsync(bool areReferencesLoaded);
        Task<IEnumerable<Album>> ByArtistAsync(int artistId);
        Task<IEnumerable<Album>> ByGenreAsync(Genres genre);
        Task<IEnumerable<Album>> ByYearAsync(int  year);
        Task<IEnumerable<Album>> ByYearRangeAsync(int initialYear, int maxYear);
        Task<Album> ByIdAsync(int id);
    }
}
