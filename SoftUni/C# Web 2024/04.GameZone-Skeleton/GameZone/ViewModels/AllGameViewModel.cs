using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.ValidationConstants;

namespace GameZone.ViewModels
{
    public class AllGameViewModel
    { 
        public int Id { get; set; }

        [StringLength(GameTitleMaxTitleLength, MinimumLength = GameTitleMinTitleLength)]
        public string Title { get; set; } = null!;

        [Comment("Game description")]
        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string ReleasedOn { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}
