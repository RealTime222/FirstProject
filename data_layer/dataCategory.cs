using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_layer
{
   public class dataCategory : IdataCategory
    {
        public List<Category> categories { get; set; }

        WebApiProjectContext _WebApiProjectContext;
        public dataCategory(WebApiProjectContext webApiProjectContext)
        {
            _WebApiProjectContext = webApiProjectContext;

        }
        public async Task<List<Category>> getData()

        {
            categories = await _WebApiProjectContext.Categories.Include(p=>p.Products).ToListAsync<Category>();
               
            return categories;
        }
    }
}
