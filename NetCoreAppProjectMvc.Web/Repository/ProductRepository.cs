using NetCoreAppProjectMvc.Web.Models;

namespace NetCoreAppProjectMvc.Web.Repository
{
	public class ProductRepository
	{
		private static List<Product> _products=new List<Product>()
		{
            new() { Id = 1, Name = "Kalem 1", Price = 124, Stock = 100 },
            new () { Id = 2, Name = "Kalem 2", Price = 96, Stock = 120 },
			new () { Id = 3, Name = "Kalem 3", Price = 100, Stock = 108 }
		};

		public List<Product> GetAll()=>_products;
		
		public void Add(Product newProduct)=>_products.Add(newProduct);

		public void Remove(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if(product == null)
			{
				throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır.");
			}
			_products.Remove(product);
		}

		public void Update(Product updateProduct)
		{
			var product = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
			if (product == null)
			{
				throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
			}
			product.Name=updateProduct.Name;
			product.Price=updateProduct.Price;
			product.Stock=updateProduct.Stock;

			var index=_products.FindIndex(x=>x.Id==updateProduct.Id);
			_products[index]= product;  // güncelleme
		}

		
	}
}
