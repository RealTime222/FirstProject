
using entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace data_layer
{
    public class data : Idata
    {
        public List<user> users { get; set; }
        WebApiProjectContext _WebApiProjectContext;
        public data(WebApiProjectContext webApiProjectContext)
        {
            _WebApiProjectContext= webApiProjectContext;
           


        }

        //public data()
        //{
        //}

        public async Task<List<user>> getData()

        {
          users = await _WebApiProjectContext.Users.Include(p=>p.Orders).ToListAsync<user>();
            return users; 
        }

        public async Task<user> AddData(user user)
        {
            
            await _WebApiProjectContext.Users.AddAsync(user);
            await _WebApiProjectContext.SaveChangesAsync();
           return user;
            
        }

        
        public async Task<user> UpdateData(user new_user,int id)
        {
            //List<user> users = await getData();
            //user oldUser = new user();
            //for (int i = 0; i < users.Count(); i++)
            //{
            //    if (users.ElementAt(i).UserId == id)
            //    {
            //        oldUser = users.ElementAt(i);
            //        break;
            //    }
            //}




            //_WebApiProjectContext.Users.Update(new_user);
            //_WebApiProjectContext.Users.Remove(oldUser);

            //await _WebApiProjectContext.SaveChangesAsync();
            //return new_user;

            var user = await _WebApiProjectContext.Users.FindAsync(id);
            if (user == null) 
                return null;
            _WebApiProjectContext.Entry(user).CurrentValues.SetValues(new_user);
            _WebApiProjectContext.SaveChanges();
            return user;
        }
       
    }
}