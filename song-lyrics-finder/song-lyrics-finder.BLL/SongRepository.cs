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
    internal class SongRepository
    {
        public void Add(Song song)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                dbContext.Add(song);
                dbContext.SaveChanges();
            }
        }

        public Song GetById(int id)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var songs = dbContext.Songs.Single(p => p.SongId == id);
                return songs;
            }
        }

        public List<Song> GetAll()
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var songs = dbContext.Songs.ToList();
                return songs;
            }
        }

        public void Update(Song song)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var songs = dbContext.Songs.Single(p => p.SongId == song.SongId);
                songs.SongId = song.SongId;
                songs.SongApiId = song.SongApiId;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Song song)
        {
            using (var dbContext = new LyricfinderDBContext())
            {
                var songs = dbContext.Songs.Single(p => p.SongId == song.SongId);
                dbContext.Remove(songs);
                dbContext.SaveChanges();
            }
        }
    }
}
