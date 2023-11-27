namespace Discoteque.API.Controllers
{
    using Application.AlbumUseCase.Interfaces;
    using Application.IServices;
    using Domain.Album.Dtos;
    using Domain.Album.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ICreateAlbum _createAlbum;
        private readonly IGetAlbum _getAlbum;
        private readonly IUpdateAlbum _updateAlbum;

        public AlbumController(ICreateAlbum createAlbum, IGetAlbum getAlbum, IUpdateAlbum updateAlbum, IAlbumService albumService)
        {
            _createAlbum = createAlbum;
            _getAlbum = getAlbum;
            _updateAlbum = updateAlbum;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums(bool areReferencesLoaded = false)
        {
            var albums = await _getAlbum.AllAsync(areReferencesLoaded);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found to show");
        }

        [HttpGet("id={id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _getAlbum.ByIdAsync(id);
            return album != null ? Ok(album) : StatusCode(StatusCodes.Status404NotFound, $"There was no album found with the Id number {id}");
        }

        [HttpGet("year={year}")]
        public async Task<IActionResult> GetAlbumsByYear(int year)
        {
            var albums = await _getAlbum.ByYearAsync(year); 
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found in this year");
        }

        [HttpGet("initialYear={initialYear}&finalYear={maxYear}")]
        public async Task<IActionResult> GetAlbumsByYearRange(int initialYear, int maxYear)
        {
            var albums = await _getAlbum.ByYearRangeAsync(initialYear, maxYear);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found in this year range");
        }

        [HttpGet("genre={genre}")]
        public async Task<IActionResult> GetAlbumsByGenre(Genres genre)
        {
            var albums = await _getAlbum.ByGenreAsync(genre);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, $"There were no albums found with the genre {genre}");
        }

        [HttpGet("artistId={artistId}")]
        public async Task<IActionResult> GetAlbumsByArtist(int artistId)
        {
            var albums = await _getAlbum.ByArtistAsync(artistId);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, $"There were no albums found from the artist {artistId}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(AlbumDto album)
        {
            await _createAlbum.ExecuteAsync(album);
            return Ok("Album created successfully");
        }

        [HttpPatch]
        public async Task<ActionResult<Album>> UpdateAlbum(AlbumDto album)
        {
            var updatedAlbum = await _updateAlbum.ExecuteAsync(album);
            return Ok(updatedAlbum);
        }
    }
}
