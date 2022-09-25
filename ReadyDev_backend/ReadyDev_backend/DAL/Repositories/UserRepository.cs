using Microsoft.EntityFrameworkCore;
using ReadyDev_backend.DAL.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        got_databaseContext _context;

        public UserRepository(got_databaseContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

    }
}
