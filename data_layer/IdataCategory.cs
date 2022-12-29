using entities;

namespace data_layer
{
     public interface IdataCategory
    {
        List<Category> categories { get; set; }

        Task<List<Category>> getData();
    }
}