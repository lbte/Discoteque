namespace Discoteque.Application.AlbumUseCase.UseCases
{
    using Application.IServices;
    using Domain.Album.Entities;
    using Interfaces;
    using System.Threading.Tasks;

    public class GetAlbum : IGetAlbum
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        public GetAlbum(IAlbumService albumService, IArtistService artistService)
        {
            _albumService = albumService;
            _artistService = artistService;
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
                return null; //TODO
            }

            return await _albumService.GetAlbumsByArtist(artistId);
        }

        public async Task<IEnumerable<Album>> ByGenreAsync(Genres genre)
        {
            if (!System.Enum.IsDefined(typeof(Genres), genre)) 
            { 
                return null; //TODO
            }
            return await _albumService.GetAlbumsByGenre(genre);
        }

        public async Task<Album> ByIdAsync(int id)
        {
            var album = await _albumService.GetById(id);
            if (album is null)
            {
                return null; //TODO
            }
            return album;
        }

        public async Task<IEnumerable<Album>> ByYearAsync(int year)
        {
            if (year < 1903 || year > DateTime.Now.Year) 
            {
                return null;
            }
            return await _albumService.GetAlbumsByYear(year);
        }

        public async Task<IEnumerable<Album>> ByYearRangeAsync(int initialYear, int maxYear)
        {
            if (initialYear < 1903 || maxYear > DateTime.Now.Year)
            {
                return null;
            }
            return await _albumService.GetAlbumsByYearRange(initialYear, maxYear);
        }
    }
}
