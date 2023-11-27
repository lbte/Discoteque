namespace Discoteque.Infrastructure.EntityFramework.DbContexts
{
    using ModelBuilders;
    using Domain.Album.Entities;
    using Domain.Artist.Entities;
    using Domain.Song.Entities;
    using Domain.Tour.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DiscotequeContext : DbContext
    {
        public DiscotequeContext(DbContextOptions<DiscotequeContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                return;
            }

            builder.Entity<Album>().Configure();
            builder.Entity<Artist>().ToTable("Artist").HasKey(k => k.Id);
            builder.Entity<Song>().ToTable("Song").HasKey(k => k.Id);
            builder.Entity<Tour>().ToTable("Tour").HasKey(k => k.Id);
            base.OnModelCreating(builder);
        }
    }
}