using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.ValidationConstants;

namespace GameZone.Data.Models
{
    [Comment("Game genre")]
    public class Genre
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Game genre name")]
        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}