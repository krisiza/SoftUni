using ForumApp.Core.Models;

namespace ForumApp.Contracts
{
    public interface IPostService
    {
        Task AddAsync(PostModel model);
        Task DeletePostAsync(int id);
        Task EditAsync(PostModel model);
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task<PostModel?> GetByIdAsync(int id);
    }
}
