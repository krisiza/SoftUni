using DeskMarket.Contracts;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeskMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ProductAllViewModel>> GetProducts(string currentId)
        => await context.Products
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductAllViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    SellerId = p.SellerId,
                    IsSeller = p.SellerId == currentId,
                    HasBought = context.ProductsClients.Any(pc => pc.ProductId == p.Id && pc.ClientId == currentId)
                })
                .ToListAsync();

        public async Task AddProduct(ProductAddViewModel model, DateTime date, string sellerId)
        {
            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CategoryId = model.CategoryId,
                AddedOn = date,
                SellerId = sellerId,
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product?> FindProduct(int id)
        => await context.Products
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task SaveProductClient(string currentId, int productId)
        {
            var productClient = new ProductClient()
            {
                ClientId = currentId,
                ProductId = productId
            };

            if (!context.ProductsClients.Any(pc => pc.ProductId == productId && pc.ClientId == currentId))
            {
                await context.ProductsClients.AddAsync(productClient);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<ProductCartViewModel>> FindProductsInCart(string currentId)
            => await context.ProductsClients
                .Where(pc => pc.Product.IsDeleted == false && pc.ClientId == currentId)
                .Select(pc => new ProductCartViewModel()
                {
                    Id = pc.Product.Id,
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price,
                    ImageUrl = pc.Product.ImageUrl,
                })
                .ToListAsync();

        public async Task<bool> RemoveProductFromCart(string currentId, int productId)
        {
            var productClient = await context.ProductsClients.
                Where(pc => pc.Product.Id == productId && pc.ClientId == currentId)
                .FirstOrDefaultAsync();

            if (productClient == null)
                return false;

            context.ProductsClients.Remove(productClient);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveChanges(ProductEditViewModel model, DateTime date)
        {
            Product? product = await FindProduct(model.Id);

            if (product == null) return false;

            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = date;
            product.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductDetailsViewModel?> CreateProductDetailsViewModel(string currentId, int productId)
            => await context.Products
               .Where(p => p.IsDeleted == false)
               .Select(p => new ProductDetailsViewModel()
               {
                   Id = p.Id,
                   ProductName = p.ProductName,
                   Price = p.Price,
                   ImageUrl = p.ImageUrl,
                   Description = p.Description,
                   CategoryId = p.CategoryId,
                   CategoryName = p.Category.Name,
                   AddedOn = p.AddedOn.ToString(ValidationConstants.DataFormat),
                   SellerId = p.SellerId,
                   Seller = p.Seller.UserName,
                   HasBought = context.ProductsClients.Any(pc => pc.ProductId == p.Id && pc.ClientId == currentId)

               })
               .FirstOrDefaultAsync(p => p.Id == productId);


        public async Task<Product?> FindProductAndIncludeSeller(int id)
            => await context.Products
             .Include(p => p.Seller)
             .Where(p => p.IsDeleted == false)
             .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await context.Products
             .Where(p => p.IsDeleted == false)
             .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return false;

            product.IsDeleted = true;
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<CategoryViewModel>> GetCategories()
            => await context.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
    }
}

