using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository repository = new UserRepository();

        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUser(int id)
        {
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.UserName, name, StringComparison.OrdinalIgnoreCase));
        }
        // Not the final implementation!
        //public User PostProduct(User item)
        //{
        //    item = repository.Add(item);
        //    return item;
        //}
        public HttpResponseMessage PostProduct(User item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.UserID });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutProduct(int id, User user)
        {
            user.UserID = id;
            if (!repository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduct(int id)
        {
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
