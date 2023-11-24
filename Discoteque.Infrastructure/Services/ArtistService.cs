﻿namespace Discoteque.Infrastructure.Services
{
    using Application.IServices;
    using Application;
    using System.Net;
    using Discoteque.Domain.Repositories;
    using Discoteque.Domain.Artist.Entities;
    using Discoteque.Domain.Shared;

    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a new <see cref="Artist"/> entity in the DB
        /// </summary>
        /// <param name="artist">A new artist entity</param>
        /// <returns>The created artist with an assigned id</returns>
        public async Task<EntityMessage<Artist>> CreateArtist(Artist artist)
        {
            try
            {
                if (artist.Name.Length > 100)
                {
                    return BuildResponseClass<Artist>.BuildResponse(HttpStatusCode.BadRequest, EntityMessageStatus.BAD_REQUEST_400);
                }

                await _unitOfWork.ArtistRepository.AddAsync(artist);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return BuildResponseClass<Artist>.BuildResponse(HttpStatusCode.InternalServerError, EntityMessageStatus.INTERNAL_SERVER_ERROR_500);
            }
            return BuildResponseClass<Artist>.BuildResponse(HttpStatusCode.OK, EntityMessageStatus.OK_200, new() { artist });
        }

        /// <summary>
        /// Finds all artists in the DB
        /// </summary>
        /// <returns> A <see cref="List"/> of <see cref="Artist"/></returns>
        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            return await _unitOfWork.ArtistRepository.GetAllAsync();
        }

        /// <summary>
        /// Finds an artist by its id in the DB 
        /// </summary>
        /// <param name="id">The unique id of the artist</param>
        /// <returns>An <see cref="Artist"/></returns>
        public async Task<Artist> GetById(int id)
        {
            return await _unitOfWork.ArtistRepository.FindAsync(id);
        }

        /// <summary>
        /// Updates the <see cref="Artist"/> entity in the DB
        /// </summary>
        /// <param name="artist">The artist entity to update</param>
        /// <returns>The new artist with updated fields when successful</returns>
        public async Task<Artist> UpdateArtist(Artist artist)
        {
            await _unitOfWork.ArtistRepository.Update(artist);
            await _unitOfWork.SaveAsync();
            return artist;
        }
    }
}
