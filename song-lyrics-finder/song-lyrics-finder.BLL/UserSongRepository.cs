using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using song_lyrics_finder.DAL;
using song_lyrics_finder.MODEL;
using song_lyrics_finder.DAL.DBContext;

namespace song_lyrics_finder.BLL
{
    internal class UserSongRepository
    {
        public void Add(UserSong userSong)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                dbContext.Add(userSong);
                dbContext.SaveChanges();
            }
        }

        public UserSong GetById(int id)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var userSongs = dbContext.UserSongs.Single(p => p.UserSongId == id);
                return userSongs;
            }
        }

        public List<UserSong> GetAll()
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var userSongs = dbContext.UserSongs.ToList();
                return userSongs;
            }
        }

        public void Update(UserSong userSong)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var userSongs = dbContext.UserSongs.Single(p => p.UserSongId == userSong.UserSongId);
                userSongs.UserSongId = userSong.UserSongId;
                userSongs.UserId = userSong.UserId;
                userSongs.SongId = userSong.SongId;
                dbContext.SaveChanges();
            }
        }

        public void Delete(UserSong userSong)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var userSongs = dbContext.UserSongs.Single(p => p.UserSongId == userSong.UserSongId);
                dbContext.Remove(userSongs);
                dbContext.SaveChanges();
            }
        }
    }
}
