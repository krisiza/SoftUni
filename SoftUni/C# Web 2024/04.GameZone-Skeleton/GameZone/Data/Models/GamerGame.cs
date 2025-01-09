using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    [Comment("Game-games")]
    public class GamerGame
    {
        [Comment("Game id")]
        [Required]
        public int GameId { get; set; }

        [Comment("Game")]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Comment("Gamer id")]
        [Required]
        public string GamerId { get; set; } = null!;

        [Comment("Gamer")]
        [ForeignKey(nameof (GamerId))]
        public IdentityUser Gamer { get; set; } = null !;
    }
}