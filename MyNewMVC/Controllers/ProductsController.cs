using Microsoft.AspNetCore.Mvc;
using MyNewMVC.Service;
using MyNewMVC.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyNewMVC.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route ("GetProducts")]
        public IActionResult GetProducts([FromQuery]int page)
        {
            GetRequestToApi getRequestToApi = new GetRequestToApi();
            var pagesWithProducts = getRequestToApi.GetProducts(page);
            if (pagesWithProducts.Page == 1)
            {
                pagesWithProducts.PageMinus2 = 1;
                pagesWithProducts.PageMinus1 = 2;
                pagesWithProducts.Page = 3;
                pagesWithProducts.PagePlus1 = 4;
                pagesWithProducts.PagePlus2 = 5;
            }
            else if (pagesWithProducts.Page == 2)
            {
                pagesWithProducts.PageMinus2 = 1;
                pagesWithProducts.PageMinus1 = 2;
                pagesWithProducts.Page = 3;
                pagesWithProducts.PagePlus1 = 4;
                pagesWithProducts.PagePlus2 = 5;
            }
            else if (pagesWithProducts.TotalPages <= pagesWithProducts.Page 
                || pagesWithProducts.TotalPages -1 == pagesWithProducts.Page 
                || pagesWithProducts.TotalPages - 2 == pagesWithProducts.Page 
                || pagesWithProducts.TotalPages - 3 == pagesWithProducts.Page 
                || pagesWithProducts.TotalPages - 4 == pagesWithProducts.Page)
            {
                pagesWithProducts.PageMinus2 = pagesWithProducts.TotalPages -4;
                pagesWithProducts.PageMinus1 = pagesWithProducts.TotalPages -3;
                pagesWithProducts.Page = pagesWithProducts.TotalPages - 2;
                pagesWithProducts.PagePlus1 = pagesWithProducts.TotalPages - 1;
                pagesWithProducts.PagePlus2 = pagesWithProducts.TotalPages;
            }
            else
            {
                pagesWithProducts.PageMinus2 = pagesWithProducts.Page - 2;
                pagesWithProducts.PageMinus1 = pagesWithProducts.Page - 1;
                pagesWithProducts.PagePlus1 = pagesWithProducts.Page + 1;
                pagesWithProducts.PagePlus2 = pagesWithProducts.Page + 2;
            }
            return View(pagesWithProducts);
        }
        [HttpGet]
        [Route ("GetDescriptions")]
        public IActionResult GetDescriptions ([FromQuery]int id)
        {
            GetRequestToApi getRequestToApi = new GetRequestToApi();
            var product = getRequestToApi.GetProductById(id);
            List<Characteristics> characteristics = new List<Characteristics>();
            characteristics = JsonSerializer.Deserialize<List<Characteristics>>(product.Characteristics);
            ProductForView productForView = new ProductForView()
            {
                IdRozetka = product.IdRozetka,
                Name = product.Name,
                Price = product.Price,
                CharacteristicsList = characteristics
            };
            return View(productForView);
        }
    }
}
