namespace Discoteque.Application.IServices
{
    using Domain.Shared;
    using Domain.Artist.Entities;
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetById(int id);
        Task<EntityMessage<Artist>> CreateArtist(Artist artist);
        Task<Artist> UpdateArtist(Artist artist);
    }
}
