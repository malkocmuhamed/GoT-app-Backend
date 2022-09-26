using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.DAL.Interfaces
{
    public interface IUserRepository
    {
        //public IEnumerable<Song> GetAllSongs();

        public IEnumerable<User> GetAllUsers();

        public User GetUser(User user);

        public Task<User> GetUserById(int id);

        public Task CreateUser(User user);

        //public Task<Song> GetSongById(int id);

        //public Task EditSong(Song song);

        //public Task DeleteSong(Song song);
    }
}
