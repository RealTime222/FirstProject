using entities;

namespace logic_layer
{
    public interface IlogicCategory
    {
        Task<List<Category>> getCategories();
    }
}