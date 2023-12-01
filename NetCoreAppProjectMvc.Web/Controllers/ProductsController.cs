using Microsoft.AspNetCore.Mvc;
using NetCoreAppProjectMvc.Web.Models;
using NetCoreAppProjectMvc.Web.Repository;

namespace NetCoreAppProjectMvc.Web.Controllers
{
	public class ProductsController : Controller
	{
		private AppDbContext _context;
		private readonly ProductRepository _productRepository;
		public ProductsController(AppDbContext context)
		{
			_context=context;
			_productRepository = new ProductRepository();

			
		}
		public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}

		public IActionResult Remove(int id)
		{
			var product=_context.Products.Find(id);
			_context.Products.Remove(product);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Expire = new List<string>() {"1 Ay","2 Ay","6 Ay","12 Ay" };
			return View();
		}

		[HttpPost]
        public IActionResult Add(Product product)
        {
			//1.yöntem
			//var name = HttpContext.Request.Form["Name"].ToString();
			//var price= decimal.Parse(HttpContext.Request.Form["Price"].ToString());
			//var stock= int.Parse(HttpContext.Request.Form["Stock"].ToString());
			//var color= HttpContext.Request.Form["Color"].ToString();

			//2.Yöntem
			/*Product product = new Product()
			//{
			//	Name = Name,
			//    Price=Price,
				Stock=Stock,
				Color=Color
			};*/

			_context.Products.Add(product);
			_context.SaveChanges();

            TempData["status"] = "Ürün başarı ile eklendi.";
            return RedirectToAction("Index");
        }

		[HttpGet]
        public IActionResult Update(int id)
		{
			var product = _context.Products.Find(id);
			return View(product);
        }

		[HttpPost]
		public IActionResult Update(Product product, int productId)
		{
			product.Id=productId;
			_context.Products.Update(product);
			_context.SaveChanges();

			TempData["status"] = "Ürün başarı ile güncellendi.";
            return RedirectToAction("Index");
        }
	}
}
