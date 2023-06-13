using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using song_lyrics_finder.DAL;
using song_lyrics_finder.DAL.DBContext;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.BLL
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                dbContext.Add(user);
                dbContext.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var users = dbContext.Users.Single(p => p.UserId == id);
                return users;
            }
        }

        public List<User> GetAll()
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var users = dbContext.Users.ToList();
                return users;
            }
        }

        public void Update(User user)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var users = dbContext.Users.Single(p => p.UserId == user.UserId);
                users.UserId = user.UserId;
                users.Name = user.Name;
                users.Email = user.Email;
                users.Nickname = user.Nickname;
                users.Password = user.Password;
                dbContext.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var users = dbContext.Users.Single(p => p.UserId == user.UserId);
                dbContext.Remove(users);
                dbContext.SaveChanges();
            }
        }
    }
}
