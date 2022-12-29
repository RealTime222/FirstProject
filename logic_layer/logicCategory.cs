using data_layer;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace logic_layer
{
    public class logicCategory : IlogicCategory
    {

        private readonly IdataCategory _Idata;
        public logicCategory(IdataCategory Idata)
        {
            _Idata = Idata;

        }
        public async Task<List<Category>> getCategories()
        {

            List<Category> categories =await _Idata.getData();
            return categories;


        }

    }
}
