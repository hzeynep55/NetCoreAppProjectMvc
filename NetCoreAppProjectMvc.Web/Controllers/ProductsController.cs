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

		public IActionResult Add()
		{
			return View();
		}

		public IActionResult Update(int id)
		{
			return View();
		}
	}
}
