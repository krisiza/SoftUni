namespace GameZone.Data
{
    public static class ValidationConstants
    {
        // Game Title
        public const int GameTitleMaxTitleLength = 50;
        public const int GameTitleMinTitleLength = 2;

        //Game Description
        public const int GameDescriptionMaxLength = 500;
        public const int GameDescriptionMinLength = 10;

        //Game RelasedOn
        public const string DateTimeFormat = "yyyy-MM-dd";

        //Genre
        public const int GenreNameMaxLength = 25;
        public const int GenreNameMinLength = 3;
    }
}
