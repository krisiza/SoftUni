
namespace GameZone.ViewModels
{
    public class GameFormViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string ReleasedOn { get; set; } = null!;

        public int GenreId { get; set; }

        public List<GenreViewModel> Genres { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public string PublisherId { get; set;} = null!;
    }
}
