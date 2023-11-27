using Discoteque.Domain.Album.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discoteque.Infrastructure.EntityFramework.DbContexts.ModelBuilders
{
    public static class AlbumModelBuilder
    {
        public static void Configure(this EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album").HasKey(k => k.Id);
            builder.Property(p => p.Name).HasConversion<string>(p => p, p => new(p));
            builder.Property(p => p.YearPublished).HasConversion<int>(p => p, p => new(p));
            builder.Property(p => p.Genre).HasConversion<int>();
            builder.Property(p => p.Cost).HasConversion<double>(p => p, p => new(p));
            builder.Property(p => p.ArtistId).HasConversion<int>();
        }
    }
}
