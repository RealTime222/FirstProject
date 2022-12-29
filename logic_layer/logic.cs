using data_layer;
using entities;
using Microsoft.EntityFrameworkCore;

namespace logic_layer
{
    public class logic : Ilogic
    {
        private readonly Idata _Idata;
        public logic(Idata Idata)
        {
            _Idata = Idata;
            
        }
        public async Task<user> getUser(int password, string email)
        {

            List<user> users =await _Idata.getData();
           
            for (int i = 0; i < users.Count(); i++)
            {
                if (users.ElementAt(i).Email == email && users.ElementAt(i).Password == password)
                {
                    Console.WriteLine(users.ElementAt(i).Email);
                    Console.WriteLine(users.ElementAt(i).FirstName);
                    return users.ElementAt(i);
                }
                    
            }
            return null;
        }

        public async Task<bool> addUser(user u)
        {

            //DbSet<User> users = _Idata.getData();
            //users.Add(u);
            await _Idata.AddData(u);
            return true;
        }

        public async Task<bool> updateUser(user newUser ,int id)
        {


            user user = await _Idata.UpdateData(newUser, id);

            if (user!=null)
            {
                return true;
            }
            return false;

           
            }
    }
}