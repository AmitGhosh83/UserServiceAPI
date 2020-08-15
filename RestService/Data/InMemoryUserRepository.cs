using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestService.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _userList;
        
        public InMemoryUserRepository()
        {
            _userList = new List<User>
            {
                new User
                {
                    Id= Guid.NewGuid().ToString(),
                    Email="amit@gmail.com",
                    CreatedDate=DateTime.UtcNow,
                     Password= Salt.GenerateHash("1234", Salt.CreateSalt(5))
                },
                new User
                {
                    Id= Guid.NewGuid().ToString(),
                    Email="dave@gmail.com",
                    CreatedDate=DateTime.UtcNow.AddDays(-1),
                     Password= Salt.GenerateHash("1234", Salt.CreateSalt(5))
                },
                new User
                {
                    Id= Guid.NewGuid().ToString(),
                    Email="Joey@gmail.com",
                    CreatedDate=DateTime.UtcNow.AddDays(-2),
                     Password= Salt.GenerateHash("1234", Salt.CreateSalt(5))
                }

            };
        }
        public User Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.UtcNow;
            user.Password = Salt.GenerateHash(user.Password, Salt.CreateSalt(5));
            _userList.Add(user);
            return user;
        }

        public User Delete(string id)
        {
            var user = _userList.Where(x => x.Id == id).FirstOrDefault();
            if(user!=null)
            {
                _userList.Remove(user);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList.OrderBy(x => x.CreatedDate).ToList();
        }

        public User GetUserById(string id)
        {
            var user = _userList.FirstOrDefault(x => x.Id == id);
            if(user!=null)
            {
                return user;
            }
            return null;
        }

        public User Update(string id, User updatedUser)
        {
            var user = _userList.FirstOrDefault(x => x.Id == id);
            user.Email = updatedUser.Email;
            user.Password = Salt.GenerateHash(user.Password, Salt.CreateSalt(5));
            return user;
        }
    }
}
