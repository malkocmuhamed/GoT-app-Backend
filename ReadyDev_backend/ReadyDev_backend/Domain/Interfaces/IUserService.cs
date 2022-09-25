using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();

        public Task<User> GetUserById(int id);

        public Task CreateUser(User user);
    }
}
