namespace ForumApp.Data
{
    /// <summary>
    /// Validation Constants
    /// </summary>
    public class ValidationConstants
    {
        /// <summary>
        /// Maximal Post Title length
        /// </summary>
        public const int PostTitleMaxLength = 100;

        /// <summary>
        /// Minimal Post Title length
        /// </summary>
        public const int PostTitleMinLength = 10;

        /// <summary>
        /// Maximal Post Content length
        /// </summary>     
        public const int PostContentMaxLength = 1500;

        /// <summary>
        /// Minimal Post Content length
        /// </summary>
        public const int PostContentMinLength = 30;

        /// <summary>
        /// Require Error message text
        /// </summary>
        public const string RequireErrorMessage = "The {0} field is required";

        public const string StringLengthErrorMessage = "The {0} field must be between {2} and {1} characters long.";
    }
}
