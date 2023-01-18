using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_layer
{
    public class dataRating : IdataRating
    {
        public List<Rating> Rating { get; set; }

        public WebApiProjectContext _WebApiProjectContext;
        public dataRating(WebApiProjectContext webApiProjectContext)
        {
            _WebApiProjectContext = webApiProjectContext;

        }
        public async Task<Rating> AddData(Rating rating)
        {

            await _WebApiProjectContext.Rating.AddAsync(rating);
            await _WebApiProjectContext.SaveChangesAsync();
            return rating;
        }
    }
}
