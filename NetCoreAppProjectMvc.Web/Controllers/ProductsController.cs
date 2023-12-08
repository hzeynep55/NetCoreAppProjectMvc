using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreAppProjectMvc.Web.Models;
using NetCoreAppProjectMvc.Web.Repository;
using NetCoreAppProjectMvc.Web.ViewModels;

namespace NetCoreAppProjectMvc.Web.Controllers
{
	public class ProductsController : Controller
	{
		private AppDbContext _context;
		private readonly ProductRepository _productRepository;

		private readonly IMapper _mapper;
        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _productRepository = new ProductRepository();
            _mapper = mapper;
        }
        public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(_mapper.Map<List<ProductViewModel>>(products));
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
			ViewBag.Expire = new Dictionary<string, int>()
			{{ "1 Ay", 1},{"3 Ay",3},{"6 Ay",6 },{"12 Ay",12} };
			

			ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
             new() {Data="Beyaz", Value="Beyaz"},
             new() {Data="Kahverengi", Value="Kahverengi"},
             new() {Data="Kırmızı", Value="Kırmızı"},
             new() {Data="Mavi", Value="Mavi"},
             new() {Data="Mor", Value="Mor"},
             new() {Data="Sarı", Value="Sarı"},
             new() {Data="Siyah", Value="Siyah"}


            },"Value","Data");

            return View();
        }

		[HttpPost]
        public IActionResult Add(Product product)
        {
	
			_context.Products.Add(product);
			_context.SaveChanges();

            TempData["status"] = "Ürün başarı ile eklendi.";
            return RedirectToAction("Index");
        }

		[HttpGet]
        public IActionResult Update(int id)
		{
			var product = _context.Products.Find(id);

			ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {{ "1 Ay", 1},{"3 Ay",3},{"6 Ay",6 },{"12 Ay",12} };


            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
             new() {Data="Beyaz", Value="Beyaz"},
             new() {Data="Kahverengi", Value="Kahverengi"},
             new() {Data="Kırmızı", Value="Kırmızı"},
             new() {Data="Mavi", Value="Mavi"},
             new() {Data="Mor", Value="Mor"},
             new() {Data="Sarı", Value="Sarı"},
             new() {Data="Siyah", Value="Siyah"}


            }, "Value", "Data", product.Color);
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
