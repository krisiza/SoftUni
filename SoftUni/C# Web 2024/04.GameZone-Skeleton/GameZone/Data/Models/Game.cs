using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.ValidationConstants;

namespace GameZone.Data.Models
{
    [Comment("All games")]
    public class Game
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Game title")]
        [Required]
        [MaxLength(GameTitleMaxTitleLength)]
        public string Title { get; set; } = null!;

        [Comment("Game description")]
        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Game image url")]
        public string? ImageUrl { get; set; }

        [Comment("Game Publisher id")]
        [Required]
        public string PublischerId { get; set; } = null!;

        [Comment("Game Publischer")]
        [Required]
        [ForeignKey(nameof(PublischerId))]
        public IdentityUser Publischer { get; set; } = null!;

        [Comment("Game released date")]
        [Required]
        public DateTime ReleasedOn { get; set; }

        [Comment("Game genre id")]
        [Required]
        public int GenreId { get; set; }

        [Comment("Game genre")]
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public IEnumerable<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
    }
}
