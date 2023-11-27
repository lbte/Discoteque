namespace Discoteque.Application.IServices
{
    using Domain.Tour.Entities;
    using Domain.Shared;

    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetToursAsync(bool areReferencesLoaded);
        Task<Tour> GetTourById(int id);
        Task<IEnumerable<Tour>> GetToursByArtist(int artistId);
        Task<IEnumerable<Tour>> GetToursByYear(int year);
        Task<IEnumerable<Tour>> GetToursByCity(string city);
        Task<EntityMessage<Tour>> CreateTour(Tour tour);
        Task<Tour> UpdateTour(Tour tour);
    }
}
