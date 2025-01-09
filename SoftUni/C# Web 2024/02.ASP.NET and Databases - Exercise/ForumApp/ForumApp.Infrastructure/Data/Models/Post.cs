using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.ValidationConstants;

namespace ForumApp.Data.Models
{
    [Comment("Posts table")]
    public class Post
    {
        [Key]
        [Comment("Post identifier")]
        public int Id { get; init; }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        [Comment("Post title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PostContentMaxLength)]
        [Comment("Post content")]
        public string Content { get; set; } = null!;
    }
}
