using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        User Add(User user);
        User Update(string id, User updatedUser);
        User Delete(string id);

       

    }
}
