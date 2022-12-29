using entities;
using data_layer;
using Microsoft.AspNetCore.Mvc;

namespace logic_layer
{
    public class logicProduct : IlogicProduct
    {

        private readonly IdataProduct _Idata;
        public logicProduct(IdataProduct Idata)
        {
            _Idata = Idata;

        }
        public async Task<List<Product>> getProducts(int[]? CategoryId,  string? name,
         int? minPrice, int? maxPrice,int? start, int? end,string? orderBy = "price", string? dir = "ASC")
        {

            List<Product> products = await _Idata.getData(CategoryId,  name, minPrice, maxPrice,  start, end, orderBy ,dir);
            if(products!=null)
                return products;
            return null;


        }

    }
}