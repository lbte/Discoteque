namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using Discoteque.Domain.Artist.Entities;
    using Domain.Album.Entities;
    using Domain.Album.Exceptions;
    using Interfaces;
    using IServices;
    using Microsoft.Extensions.Logging;
    using Shared.Exceptions;
    using System.Threading.Tasks;

    public class GetAlbum : IGetAlbum
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly ILogger<GetAlbum> _logger;
        public GetAlbum(IAlbumService albumService, IArtistService artistService, ILogger<GetAlbum> logger)
        {
            _albumService = albumService;
            _artistService = artistService;
            _logger = logger;
        }
        public async Task<IEnumerable<Album>> AllAsync(bool areReferencesLoaded)
        {
            return await _albumService.GetAlbumsAsync(areReferencesLoaded);
        }

        public async Task<IEnumerable<Album>> ByArtistAsync(int artistId)
        {
            var artist = await _artistService.GetById(artistId);
            if (artist is null) 
            {
                var exceptionMessage = $"Artist with id {artistId} was not found.";
                _logger.LogError(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }

            return await _albumService.GetAlbumsByArtist(artistId);
        }

        public async Task<IEnumerable<Album>> ByGenreAsync(Genres genre)
        {
            if (!System.Enum.IsDefined(typeof(Genres), genre)) 
            {
                var exceptionMessage = $"Album with genre {genre} was not found.";
                _logger.LogError(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }
            return await _albumService.GetAlbumsByGenre(genre);
        }

        public async Task<Album> ByIdAsync(int id)
        {
            var album = await _albumService.GetById(id);
            if (album is null)
            {
                var exceptionMessage = $"Album with id {id} was not found.";
                _logger.LogError(exceptionMessage);
                throw new NotFoundException(exceptionMessage);
            }
            return album;
        }

        public async Task<IEnumerable<Album>> ByYearAsync(int year)
        {
            var minValidYear = 1903;
            var maxValidYear = DateTime.Now.Year;
            if (year < minValidYear || year > maxValidYear) 
            {
                _logger.LogError($"Year not defined in range: [{minValidYear}, {maxValidYear}]");
                throw new InvalidYearException(minValidYear, maxValidYear);
            }
            return await _albumService.GetAlbumsByYear(year);
        }

        public async Task<IEnumerable<Album>> ByYearRangeAsync(int initialYear, int maxYear)
        {
            var minValidYear = 1903;
            var maxValidYear = DateTime.Now.Year;
            if (initialYear < minValidYear || maxYear > maxValidYear)
            {
                _logger.LogError($"Year range provided ({initialYear}, {maxYear}) not defined in range: [{minValidYear}, {maxValidYear}]");
                throw new InvalidYearException(minValidYear, maxValidYear);
            }
            return await _albumService.GetAlbumsByYearRange(initialYear, maxYear);
        }
    }
}
