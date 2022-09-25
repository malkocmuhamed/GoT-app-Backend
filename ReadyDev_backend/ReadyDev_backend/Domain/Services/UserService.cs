using ReadyDev_backend.DAL.Interfaces;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public Task CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

    }
}
