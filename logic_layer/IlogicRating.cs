using entities;

namespace logic_layer
{
    public interface IlogicRating
    {
        Task<bool> addData(Rating u);
    }
}