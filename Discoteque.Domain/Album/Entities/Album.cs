﻿namespace Discoteque.Domain.Album.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Discoteque.Domain.Models;

    public class Album : BaseEntity<int>
    {
        /// <summary>
        /// Name of the album
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Year the album was published
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The <see cref="Genres"/> the album belongs to
        /// </summary>
        public GenreEnum Genre { get; set; } = GenreEnum.Unkown;

        /// <summary>
        /// The cost of the album
        /// </summary>
        public double Cost { get; set; } = 50_000;

        /// <summary>
        /// The <see cref="Artist"/> id this album belongs to
        /// </summary>
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        /// <summary>
        /// The <see cref="Artist"/> entity this album is referring to
        /// </summary>
        public virtual Artist? Artist { get; set; }
    }
}