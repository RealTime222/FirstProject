using entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace data_layer
{
    public interface Idata
    {
        Task<List<user>> getData();

         Task<user> AddData(user u);

        Task<user> UpdateData(user u,int p);
    }
}