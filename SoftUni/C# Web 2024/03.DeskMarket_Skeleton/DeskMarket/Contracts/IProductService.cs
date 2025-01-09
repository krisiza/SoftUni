using DeskMarket.Data.Models;
using DeskMarket.Models;

namespace DeskMarket.Contracts
{
    public interface IProductService
    {
        Task<ICollection<ProductAllViewModel>> GetProducts(string currentId);
        Task AddProduct(ProductAddViewModel model, DateTime date, string sellerId);
        Task<Product?> FindProduct(int id);
        Task SaveProductClient(string currentId, int productId);
        Task<ICollection<ProductCartViewModel>> FindProductsInCart(string currentId);
        Task<bool> RemoveProductFromCart(string currentId, int productId);
        Task<bool> SaveChanges(ProductEditViewModel model, DateTime date);
        Task<ProductDetailsViewModel?> CreateProductDetailsViewModel(string currentId, int productId);
        Task<Product?> FindProductAndIncludeSeller(int id);
        Task<bool> DeleteProduct(int id);
        Task<ICollection<CategoryViewModel>> GetCategories();
    }
}
