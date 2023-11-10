namespace Discoteque.API.Controllers
{
    using Application.IServices;
    using Domain.Artist.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtistsAsync()
        {
            var artists = await _artistService.GetArtistsAsync();
            return artists.Any() ? Ok(artists) : StatusCode(StatusCodes.Status404NotFound, "There were no artists found to show");
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtistAsync(Artist artist)
        {
            var newArtist = await _artistService.CreateArtist(artist);
            return newArtist.StatusCode == HttpStatusCode.OK ? Ok(newArtist) : StatusCode((int)newArtist.StatusCode, newArtist);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateArtistAsync(Artist artist)
        {
            var updatedArtist = await _artistService.UpdateArtist(artist);
            return updatedArtist != null ? Ok(updatedArtist) : StatusCode(StatusCodes.Status404NotFound, "The artist was not updated"); ;
        }
    }
}

