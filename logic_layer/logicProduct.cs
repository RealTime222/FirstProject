using entities;
using data_layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace logic_layer
{
    public class logicProduct : IlogicProduct
    {
        WebApiProjectContext _context;
        private readonly IdataProduct _Idata;
        public logicProduct(IdataProduct Idata, WebApiProjectContext context)
        {
            _Idata = Idata;
            _context = context;

        }
        public async Task<List<Product>> getProducts(int[]? CategoryId,  string? name,
         int? minPrice, int? maxPrice,int? start, int? end,string? orderBy = "price", string? dir = "ASC")
        {

            List<Product> products = await _Idata.getData(CategoryId,  name, minPrice, maxPrice,  start, end, orderBy ,dir);
            if(products!=null)
                return products;
            return null;


        }
        public Product[] GetProductsByIDs(int[]? ProductIds)
        {
            {
                var qurey = _context.Products.Where(product => ProductIds.Contains(product.ProductId));
                Console.WriteLine(qurey);
                List<Product> products = qurey.ToList();
                return products.ToArray();
            }
        }

    }
}