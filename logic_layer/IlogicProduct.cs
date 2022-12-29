using entities;

namespace logic_layer
{
    public interface IlogicProduct
    {
        Task<List<Product>> getProducts(int[]? CategoryId, string? name,
         int? minPrice, int? maxPrice, int? start, int? end, string? orderBy = "price", string? dir = "ASC");
    }
}