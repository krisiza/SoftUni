using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.ValidationConstants;

namespace ForumApp.Core.Models
{
    /// <summary>
    /// Post data transfer model
    /// </summary>
    public class PostModel
    {
        /// <summary>
        /// Post identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post title
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Post content
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;
    }
}
