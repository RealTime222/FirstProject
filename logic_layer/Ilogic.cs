using entities;

namespace logic_layer
{
    public interface Ilogic
    {
        Task<bool> addUser(user u);
        Task<user>  getUser(int password, string email);
        Task<bool> updateUser(user u,int p);
    }
}