using Discoteque.Application.IServices;
using Discoteque.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Discoteque.Infrastructure.Extensions;
using Discoteque.Domain.Album.Entities;
using Discoteque.Domain.Artist.Entities;
using Discoteque.Domain.Song.Entities;
using Discoteque.Domain.Tour.Entities;
using Discoteque.API.Middlewares.Exceptions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DiscotequeContext>(
    opt => { opt.UseInMemoryDatabase("Discoteque"); }
);

// dependency injection
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

// HealthCheck for confirmation that the app can communicate with a DB configured with EFCore DbContext
builder.Services.AddHealthChecks()
    .AddDbContextCheck<DiscotequeContext>();

var app = builder.Build();
PopulateDb(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();

#region  DB Population
/// <summary>
/// Populate the Database with some data.
/// </summary>
/// <param name="app"></param>
async void PopulateDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var artistService = scope.ServiceProvider.GetRequiredService<IArtistService>();
        var albumService = scope.ServiceProvider.GetRequiredService<IAlbumService>();
        var songService = scope.ServiceProvider.GetRequiredService<ISongService>();
        var tourService = scope.ServiceProvider.GetRequiredService<ITourService>();

        // Artists
        await artistService.CreateArtist(new Artist
        {
            Id = 1,
            Name = "Karol G",
            Label = "Universal Music Latin",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 2,
            Name = "Juanes",
            Label = "Universal Music Group",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 3,
            Name = "Shakira",
            Label = "Sony Music",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 4,
            Name = "Joe Arroyo",
            Label = "AVAYA",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 5,
            Name = "Carlos Vives",
            Label = "EMI/Virgin",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 6,
            Name = "Silvestre Dangond",
            Label = "SONY Music",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 7,
            Name = "Fonseca",
            Label = "SONY BMG",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 8,
            Name = "Maluma",
            Label = "RCA",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 9,
            Name = "Andr�s Cepeda",
            Label = "SONY BMG",
            IsOnTour = true
        });
        await artistService.CreateArtist(new Artist
        {
            Id = 10,
            Name = "J Balvin",
            Label = "SONY BMG",
            IsOnTour = true
        });

        // Albums
        #region Karol G
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2017,
            Name = "Unstopabble",
            ArtistId = 1,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2019,
            Name = "Ocean",
            ArtistId = 1,
            Genre = Genres.Urban
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2021,
            Name = "KG0516",
            ArtistId = 1,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2023,
            Name = "Ma�ana ser� bonito",
            ArtistId = 1,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Juanes
        // Juanes
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2000,
            Name = "Fijate Bien",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2002,
            Name = "Un d�a normal",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2004,
            Name = "Mi sangre",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2007,
            Name = "La vida... es un ratico",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2010,
            Name = "P.A.R.C.E",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2014,
            Name = "Loco de amor",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2017,
            Name = "Mis planes son amarte",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2019,
            Name = "M�s futuro que pasado",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2021,
            Name = "Origen",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2023,
            Name = "Vida cotidiana",
            ArtistId = 2,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Shakira
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1991,
            Name = "Magia",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1993,
            Name = "Peligro",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1995,
            Name = "Pies Descalzos",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1998,
            Name = "�D�nde est�n los ladrones",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2001,
            Name = "Servicio de lavanderia",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2005,
            Name = "Fijaci�n oral vol 1",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2009,
            Name = "Loba / She Wolf",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2010,
            Name = "Sale el sol",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2014,
            Name = "Shakira",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2015,
            Name = "El Dorado",
            ArtistId = 3,
            Genre = Genres.Rock,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Joe Arroyo
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1990,
            Name = "La guerra de los callados",
            ArtistId = 4,
            Genre = Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1992,
            Name = "La voz",
            ArtistId = 4,
            Genre = Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1976,
            Name = "El b�rbaro",
            ArtistId = 4,
            Genre = Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1975,
            Name = "El grande",
            ArtistId = 4,
            Genre = Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1979,
            Name = "El teso",
            ArtistId = 4,
            Genre = Genres.Salsa,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Carlos Vives
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1993,
            Name = "Cl�sicos de la Provincia",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1995,
            Name = "la Tierra del olvido",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1997,
            Name = "Tengo fe",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1999,
            Name = "El amor de la tierra",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2001,
            Name = "Dejame entrar",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2009,
            Name = "Cl�sicos de la provincia",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2020,
            Name = "Cumbiana",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2022,
            Name = "Cumbiana II",
            ArtistId = 5,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Silvestre Dangond
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2002,
            Name = "Tanto para ti",
            ArtistId = 6,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2003,
            Name = "Lo mejor para los dos",
            ArtistId = 6,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2006,
            Name = "el original",
            ArtistId = 6,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2010,
            Name = "Cantinero",
            ArtistId = 6,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Fonseca
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2002,
            Name = "Fonseca",
            ArtistId = 7,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2005,
            Name = "Coraz�n",
            ArtistId = 7,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2008,
            Name = "Gratitud",
            ArtistId = 7,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2011,
            Name = "Ilusi�n",
            ArtistId = 7,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Maluma
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2012,
            Name = "Magia",
            ArtistId = 8,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2015,
            Name = "Pretty Boy, Dirty Boy",
            ArtistId = 8,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2018,
            Name = "F.A.M.E.",
            ArtistId = 8,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2019,
            Name = "11:11",
            ArtistId = 8,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2020,
            Name = "Papi Juancho",
            ArtistId = 8,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2023,
            Name = "Don Juan",
            ArtistId = 8,
            Genre = Genres.Vallenato,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region Andr�s Cepeda
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 1999,
            Name = "Se morir",
            ArtistId = 9,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2001,
            Name = "El carpintero",
            ArtistId = 9,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2003,
            Name = "Canci�n rota",
            ArtistId = 9,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2005,
            Name = "Para amarte mejor",
            ArtistId = 9,
            Genre = Genres.Pop,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        #region J Balvin
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2013,
            Name = "la familia",
            ArtistId = 10,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2016,
            Name = "Energ�a",
            ArtistId = 10,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2018,
            Name = "Vibras",
            ArtistId = 10,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2020,
            Name = "Colores",
            ArtistId = 10,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        await albumService.CreateAlbum(new Album
        {
            YearPublished = 2021,
            Name = "Jose",
            ArtistId = 10,
            Genre = Genres.Urban,
            Cost = new Random().Next(1, 9) * 10_000
        });
        #endregion

        // Songs
        #region Songs
        await songService.CreateSong(new Song
        {
            Name = "Mientras me curo del cora",
            Length = 164,
            AlbumId = 4
        });
        await songService.CreateSong(new Song
        {
            Name = "Ma�ana ser� bonito",
            Length = 210,
            AlbumId = 4
        });
        await songService.CreateSong(new Song
        {
            Name = "A Dios le pido",
            Length = 206,
            AlbumId = 4
        });
        await songService.CreateSong(new Song
        {
            Name = "Mala gente",
            Length = 198,
            AlbumId = 4
        });
        #endregion

        // Tours
        #region Tour
        await tourService.CreateTour(new Tour
        {
            Name = "Mientras me curo del cora",
            City = "Medellin",
            TourDate = new DateTime(2023, 07, 31),
            IsSoldOut = true,
            ArtistId = 1
        });
        await tourService.CreateTour(new Tour
        {
            Name = "Juanes & Morat",
            City = "Medellin",
            TourDate = new DateTime(2023, 04, 21),
            IsSoldOut = true,
            ArtistId = 2
        });
        #endregion
    }
}
#endregion