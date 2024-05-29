﻿using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationContext.SongNameMaxLength)]
        public string Name { get; set; } = null!;

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album? Album { get; set; }

        public int WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public Writer Writer { get; set; } = null!;

        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
