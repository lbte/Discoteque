﻿using Discoteque.Domain.Models;

namespace Discoteque.Domain.Song.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Discoteque.Domain.Album.Entities;

    public class Song : BaseEntity<int>
    {
        /// <summary>
        /// Name of the Song
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Duration of the song
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// The <see cref="Album"/> id this Song belongs to
        /// </summary>
        /// <value></value>
        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        /// <summary>
        /// The <see cref="Album"/> Entity this song is refering to
        /// </summary> <summary>
        public virtual Album? Album { get; set; }
    }
}