using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    //We need to store a collection of products. 
    //It's a good idea to separate the collection from our service implementation. 
    //That way, we can change the backing store without rewriting the service class. 
    interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int userID);
        User Add(User item);
        void Remove(int userID);
        bool Update(User item);
    }
}
