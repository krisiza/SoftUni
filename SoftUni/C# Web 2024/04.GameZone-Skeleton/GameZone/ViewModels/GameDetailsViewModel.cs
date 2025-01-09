namespace GameZone.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string ReleasedOn { get; set; } = null!;

        public int GenreId { get; set; }

        public string Genre { get; set; } = null!;

        public string Publisher { get; set; } = null!;

    }
}
