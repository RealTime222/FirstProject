using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_layer
{
    public class dataRating
    {
        public List<Rating> Rating { get; set; }

        public WebApiProjectContext _WebApiProjectContext;
        public dataRating(WebApiProjectContext webApiProjectContext)
        {
            _WebApiProjectContext = webApiProjectContext;



        }
    }
}
