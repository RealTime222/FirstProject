using data_layer;
using entities;

namespace FirstProject
{
    public class logicRating : IlogicRating
    {
        private readonly IdataRating _Idata;
        public logicRating(IdataRating Idata)
        {
            _Idata = Idata;

        }

        public async Task<bool> addData(Rating u)
        {
            await _Idata.AddData(u);
            return true;
        }
    }
}
