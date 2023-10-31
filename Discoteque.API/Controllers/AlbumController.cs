namespace Discoteque.API.Controllers
{
    using Application.IServices;
    using Discoteque.Domain.Album.Entities;
    using Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums(bool areReferencesLoaded = false)
        {
            var albums = await _albumService.GetAlbumsAsync(areReferencesLoaded);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found to show");
        }

        /// <summary>
        /// Gets album by its unique id
        /// </summary>
        /// <param name="id">The album id</param>
        /// <returns>The album requested</returns>
        /// <response code="200">Returns the requested album</response>
        /// <response code="400">No album was found</response>
        [HttpGet("id={id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _albumService.GetById(id);
            return album != null ? Ok(album) : StatusCode(StatusCodes.Status404NotFound, $"There was no album found with the Id number {id}");
        }

        [HttpGet("year={year}")]
        public async Task<IActionResult> GetAlbumsByYear(int year)
        {
            var albums = await _albumService.GetAlbumsByYear(year);
            //if the albums list is not empty show success, otherwise show message
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found in this year");
        }

        [HttpGet("initialYear={initialYear}&finalYear={maxYear}")]
        public async Task<IActionResult> GetAlbumsByYearRange(int initialYear, int maxYear)
        {
            var albums = await _albumService.GetAlbumsByYearRange(initialYear, maxYear);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were no albums found in this year range");
        }

        [HttpGet("genre={genre}")]
        public async Task<IActionResult> GetAlbumsByGenre(GenreEnum genre)
        {
            var albums = await _albumService.GetAlbumsByGenre(genre);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, $"There were no albums found with the genre {genre}");
        }

        [HttpGet("artistName={artistName}")]
        public async Task<IActionResult> GetAlbumsByArtist(string artistName)
        {
            var albums = await _albumService.GetAlbumsByArtist(artistName);
            return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, $"There were no albums found from the artist {artistName}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            var newAlbum = await _albumService.CreateAlbum(album);
            return newAlbum.StatusCode == HttpStatusCode.OK ? Ok(newAlbum) : StatusCode((int)newAlbum.StatusCode, newAlbum);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            var updatedAlbum = await _albumService.UpdateAlbum(album);
            return updatedAlbum != null ? Ok(updatedAlbum) : StatusCode(StatusCodes.Status404NotFound, "The album was not updated"); ;
        }
    }
}
