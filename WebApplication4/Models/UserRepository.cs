using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> user = new List<User>();
        private int _nextId = 1;

        public UserRepository()
        {
            Add(new User { UserName = "Adesh Shah",
                           UserEmail = "aadishah74@outlook.com",
                           UserAddress = "1785 Baseline Road",
                           UserPhoneNumber = "+16476674651",
                           UserCompanyName = "Algonquin College",
                           UserCompanyAddress = "Baseline Road"
            });
           
        }
        public IEnumerable<User> GetAll()
        {
            return user;
        }
        public User Get(int userID)
        {
            return user.Find(p => p.UserID == userID);
        }
        public User Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.UserID = _nextId++;
            user.Add(item);
            return item;
        }
        public void Remove(int userID)
        {
            user.RemoveAll(p => p.UserID == userID);
        }
        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = user.FindIndex(p => p.UserID == item.UserID);
            if (index == -1)
            {
                return false;
            }
            user.RemoveAt(index);
            user.Add(item);
            return true;
        }
    }
}



//public string UserName { get; set; }
//public string UserEmail { get; set; }
//public string UserAddress { get; set; }
//public string UserPhoneNumber { get; set; }
//public string UserCompanyName { get; set; }
//public string UserCompanyAddress { get; set; }