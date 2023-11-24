namespace Discoteque.Application.IServices
{
    using Discoteque.Domain.Shared;
    using Domain.Artist.Entities;
    using Domain.Dto;
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetById(int id);
        Task<EntityMessage<Artist>> CreateArtist(Artist artist);
        Task<Artist> UpdateArtist(Artist artist);
    }
}
