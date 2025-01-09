using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Product;
using System.Text;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("My-Products")]
        public IActionResult All(string? keyword)
        {
            if(keyword == null) 
                return View("My-Products", _products);

            var products = _products
                .Where(p => p.Name
                                .ToLower()
                                .Contains(keyword.ToLower()));

            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null) 
                return BadRequest();

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(_products, options);
        }

        public IActionResult AllAsText()
        {
            var text = string.Empty;

            foreach (var item in _products)
            {
                text += $"Product {item.Id}: {item.Name} - {item.Price} lv.{Environment.NewLine}";
            }

            return Content(text);
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in _products)
            {
                stringBuilder.AppendLine($"Product {item.Id}: {item.Name} - {item.Price} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString().TrimEnd()), "text/plain");
        }

        private IEnumerable<ProductViewModel> _products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Bread",
                    Price = 1.50
                }
            };
    }
}
