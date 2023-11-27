namespace Discoteque.Application.IServices
{
    using Domain.Song.Entities;
    using Domain.Shared;

    public interface ISongService
    {
        Task<IEnumerable<Song>> GetSongsAsync(bool areReferencesLoaded);
        Task<IEnumerable<Song>> GetSongsByAlbum(int albumId);
        Task<Song> GetById(int id);
        Task<IEnumerable<Song>> GetSongsByYear(int year);
        Task<EntityMessage<Song>> CreateSong(Song song);
        Task<EntityMessage<Song>> CreateSongsInBatch(List<Song> songs);
        Task<Song> UpdateSong(Song song);
    }
}
