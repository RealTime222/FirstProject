using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using entities;
using data_layer;

namespace data_layer
{
    public class dataProduct : IdataProduct
    {
        public List<Product> products { get; set; }

        WebApiProjectContext _WebApiProjectContext;
        public dataProduct(WebApiProjectContext webApiProjectContext)
        {
            _WebApiProjectContext = webApiProjectContext;

        }
        public async Task<List<Product>> getData(int[]? CategoryId, string? name,
         int? minPrice, int? maxPrice, int? start, int? end, string? orderBy = "price", string? dir = "ASC")

        {
            
                var query =  _WebApiProjectContext.Products.Where(product => (name == null ? (true) : (product.ProductName.Contains(name)))
                 && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                  && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                 && (CategoryId.Length == 0) ? (true) : (CategoryId.Contains(product.CategoryId))
                 ).OrderBy(product => orderBy);
                Console.WriteLine(query);

                List<Product> products = await query.ToListAsync();
                
                return products;

           
            //products = await _WebApiProjectContext.Products.ToListAsync<Product>();
            //return products;
        }
    }
}