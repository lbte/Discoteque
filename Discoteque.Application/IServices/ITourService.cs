﻿using Discoteque.Domain.Dto;
using Discoteque.Domain.Models;

namespace Discoteque.Application.IServices
{
    public interface ITourService
    {
        /// <summary>
        /// Find all tours in the DB
        /// </summary>
        /// <param name="areReferencesLoaded">Returns associated artists per tour if true</param>
        /// <returns>A <see cref="List"/> of <see cref="Tour"/></returns>
        Task<IEnumerable<Tour>> GetToursAsync(bool areReferencesLoaded);

        /// <summary>
        /// Find a tour by its id in the DB
        /// </summary>
        /// <param name="id">The unique id of the tour</param>
        /// <returns>A <see cref="Tour"/></returns>
        Task<Tour> GetTourById(int id);

        /// <summary>
        /// Finds all tours from an <see cref="Artist"/>
        /// </summary>
        /// <param name="artistId">The id from the Artist associated</param>
        /// <returns>A <see cref="List"/> of <see cref="Tour"/></returns>
        Task<IEnumerable<Tour>> GetToursByArtist(int artistId);

        /// <summary>
        /// Finds all tours from a specific year
        /// </summary>
        /// <param name="year">A gregorian year between 1900 and the current year (2023)</param>
        /// <returns>A <see cref="List"/> of <see cref="Tour"/></returns>
        Task<IEnumerable<Tour>> GetToursByYear(int year);

        /// <summary>
        /// Finds all tours from a specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>A <see cref="List"/> of <see cref="Tour"/></returns>
        Task<IEnumerable<Tour>> GetToursByCity(string city);

        /// <summary>
        /// Creates a new <see cref="Tour"/> entity in the DB
        /// </summary>
        /// <param name="tour">A new tour entity</param>
        /// <returns>The created tour with an assigned id</returns>
        Task<EntityMessage<Tour>> CreateTour(Tour tour);

        /// <summary>
        /// Updates the <see cref="Tour"/> entity in the DB
        /// </summary>
        /// <param name="tour">The tour entity to update</param>
        /// <returns>The new tour with updated fields when successful</returns>
        Task<Tour> UpdateTour(Tour tour);
    }
}
