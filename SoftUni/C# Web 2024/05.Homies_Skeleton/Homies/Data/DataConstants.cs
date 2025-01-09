namespace Homies.Data
{
    public static class DataConstants
    {
        public const int EventNameMinimumLength = 5;
        public const int EventNameMaximumLength = 20;

        public const int EventDescriptionMinimumLength = 15;
        public const int EventDescriptionMaximumLength = 150;

        public const string EventCreatedOnFormat = "yyyy.MM.dd H:mm";

        public const int TypeNameMaxLength = 15;
        public const int TypeNameMinLength = 5;

        public const string RequireErrorMessage = "The field {0} is required";

        public const string StringLengthErrorMessage = "The field {0} mest be between {1} and {2}!";
    }
}
