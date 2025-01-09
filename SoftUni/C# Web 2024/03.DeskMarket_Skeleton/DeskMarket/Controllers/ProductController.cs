using DeskMarket.Contracts;
using DeskMarket.Models;
using DeskMarket.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace DeskMarket.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController( IProductService productService)
        {
            this.productService = productService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var currentId = GetUserId();
            return View(await productService.GetProducts(currentId));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductAddViewModel
            {
                Categories = await productService.GetCategories(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetCategories();
                return View(model);
            }

            DateTime date;

            if (!DateTime.TryParseExact(
                    model.AddedOn,
                    ValidationConstants.DataFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                ModelState.AddModelError(nameof(model.AddedOn), $"Invalid date! Format must be {ValidationConstants.DataFormat}");
                model.Categories = await productService.GetCategories();
                return View(model);
            }

            await productService.AddProduct(model, date, GetUserId());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await productService.FindProduct(id);

            if (product == null)
                return NotFound();

            await productService.SaveProductClient(GetUserId(), product.Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cart()
            => View(await productService.FindProductsInCart(GetUserId()));

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            bool itemIsRemoved =await productService.RemoveProductFromCart(GetUserId(), id);
            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.FindProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                AddedOn = product.AddedOn.ToString(ValidationConstants.DataFormat),
                CategoryId = product.CategoryId,
                Categories = await productService.GetCategories(),
                SellerId = product.SellerId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetCategories();
                return View(model);
            }

            DateTime date = DateTime.Now;

            if (!DateTime.TryParseExact(
                    model.AddedOn,
                    ValidationConstants.DataFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                ModelState.AddModelError(nameof(model.AddedOn), $"Invalid date! Format must be {ValidationConstants.DataFormat}");
                model.Categories = await productService.GetCategories();
                return View(model);
            }

            bool productIsEdited = await productService.SaveChanges(model, date);

            if (!productIsEdited)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => View(await productService.CreateProductDetailsViewModel(GetUserId(), id));
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await productService.FindProductAndIncludeSeller(id);

            if (product == null)
                return NotFound();
     
            var model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Seller = product.Seller.UserName,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDetailsViewModel model)
        {
            bool isDeleted = await productService.DeleteProduct(model.Id);
            if (!isDeleted)
                return NotFound();
            
            return RedirectToAction("Index");
        }


        private string GetUserId()
            => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }
}
