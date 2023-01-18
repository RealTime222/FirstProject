using entities;

namespace data_layer
{
    public interface IdataRating
    {
        List<Rating> Rating { get; set; }

        Task<Rating> AddData(Rating rating);
    }
}