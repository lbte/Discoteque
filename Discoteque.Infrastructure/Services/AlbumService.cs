namespace Discoteque.Infrastructure.Services
{
    using Application;
    using Application.IServices;
    using Domain.Artist.Entities;
    using Domain.Album.Entities;
    using Domain.Dto;
    using Domain.Repositories;
    using System.Net;
    using System.Text.RegularExpressions;

    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a new <see cref="Album"/> entity in the DB
        /// </summary>
        /// <param name="album">A new album entity</param>
        /// <returns>The created album with an assigned Id</returns>
        /// 
        public async Task<EntityMessage<Album>> CreateAlbum(Album newAlbum)
        {
            try
            {
                // TODO DDD
                if (newAlbum.Cost < 0 || newAlbum.YearPublished < 1905 || newAlbum.YearPublished > 2023 || AreForbiddenWordsContained(newAlbum.Name))
                {
                    return BuildResponseClass<Album>.BuildResponse(HttpStatusCode.BadRequest, EntityMessageStatus.BAD_REQUEST_400);
                }

                await _unitOfWork.AlbumRepository.AddAsync(newAlbum);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return BuildResponseClass<Album>.BuildResponse(HttpStatusCode.InternalServerError, EntityMessageStatus.INTERNAL_SERVER_ERROR_500);
            }

            return BuildResponseClass<Album>.BuildResponse(HttpStatusCode.OK, EntityMessageStatus.OK_200, new() { newAlbum });
        }

        /// <summary>
        /// Find all albums
        /// </summary>
        /// <param name="areReferencesLoaded">Returns associated artists per album if true</param>
        /// <returns>A <see cref="List"/> of <see cref="Album"/></returns>
        public async Task<IEnumerable<Album>> GetAlbumsAsync(bool areReferencesLoaded)
        {
            IEnumerable<Album> albums;
            if (areReferencesLoaded)
            {
                albums = await _unitOfWork.AlbumRepository.GetAllAsync(null, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
            }
            else
            {
                albums = await _unitOfWork.AlbumRepository.GetAllAsync();
            }
            return albums;
        }

        /// <summary>
        /// Finds all albums released by <see cref="Artist.Id"/>
        /// </summary>
        /// <param name="artist">The id of the artist</param>
        /// <returns>A <see cref="List"/> of <see cref="Album"/></returns>
        public async Task<IEnumerable<Album>> GetAlbumsByArtist(int artistId)
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync(x => x.ArtistId == artistId, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        }

        public async Task<Album?> GetAlbumByNameAndArtistId(string albumName, int artistId)
        {
            return await _unitOfWork.AlbumRepository.GetEntityAsync(x => string.Equals(x.Name, albumName, StringComparison.OrdinalIgnoreCase) && x.ArtistId == artistId);
        }

        /// <summary>
        /// Finds all albums with the assigned genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>A <see cref="List"/> of <see cref="Album"/></returns>
        public async Task<IEnumerable<Album>> GetAlbumsByGenre(Genres genre)
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync(x => x.Genre.Equals(genre), x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        }

        /// <summary>
        /// Finds all albums published in a year
        /// </summary>
        /// <param name="year"> A gregorian year between 1900 and the current year</param>
        /// <returns>A <see cref="List"/> of <see cref="Album"/></returns>
        public async Task<IEnumerable<Album>> GetAlbumsByYear(int year)
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync(x => x.YearPublished == year, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        }

        /// <summary>
        /// Finds all albums released from initialYear to maxYear
        /// </summary>
        /// <param name="initialYear">The initial year. Minimum value is 1900</param>
        /// <param name="maxYear">The maximun year. Maximum value is 2023</param>
        /// <returns>A <see cref="List"/> of <see cref="Album"/></returns>
        public async Task<IEnumerable<Album>> GetAlbumsByYearRange(int initialYear, int maxYear)
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync(x => x.YearPublished >= initialYear && x.YearPublished <= maxYear, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        }

        /// <summary>
        /// Finds an album by its id in the DB
        /// </summary>
        /// <param name="id">The unique id of the album</param>
        /// <returns>An <see cref="Album"/></returns>
        public async Task<Album> GetById(int id)
        {
            return await _unitOfWork.AlbumRepository.FindAsync(id);
        }

        /// <summary>
        /// Updates the <see cref="Album"/> entity in the DB
        /// </summary>
        /// <param name="album">The album entity to update</param>
        /// <returns>The new album with updated fields when successful</returns>
        public async Task<Album> UpdateAlbum(Album album)
        {
            await _unitOfWork.AlbumRepository.Update(album);
            await _unitOfWork.SaveAsync();

            return album;
        }

        private static bool AreForbiddenWordsContained(string name)
        {
            var forbiddenWords = new List<string>() { "Revolución", "Poder", "Amor", "Guerra" };
            return forbiddenWords.Any(forbiddenWord => Regex.IsMatch(name, Regex.Escape(forbiddenWord), RegexOptions.IgnoreCase));
        }
    }
}
