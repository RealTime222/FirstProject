using entities;

namespace data_layer
{
    public interface IdataProduct
    {
        List<Product> products { get; set; }

        Task<List<Product>> getData(int[]? CategoryId, string? name,
          int? minPrice, int? maxPrice, int? start, int? end, string? orderBy = "price", string? dir = "ASC");
    }
}