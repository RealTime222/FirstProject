using entities;

namespace FirstProject
{
    public interface IlogicRating
    {
        Task<bool> addData(Rating u);
    }
}