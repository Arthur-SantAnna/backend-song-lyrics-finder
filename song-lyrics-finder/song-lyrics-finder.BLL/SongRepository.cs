using song_lyrics_finder.DAL.DBContext;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.BLL
{
    public class SongRepository : ISongRepository
    {
        private readonly LyricfinderDBContext _dbContext;

        public SongRepository(LyricfinderDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public void Add(Song song)
        {
            _dbContext.Add(song);
            _dbContext.SaveChanges();
        }

        public Song GetById(int id)
        {

            var songs = _dbContext.Songs.Single(p => p.SongId == id);
            return songs;
        }

        public List<Song> GetAll()
        {
            var songs = _dbContext.Songs.ToList();
            return songs;
        }

        public void Update(Song song)
        {
            var songs = _dbContext.Songs.Single(p => p.SongId == song.SongId);
            songs.SongId = song.SongId;
            songs.SongApiId = song.SongApiId;
            _dbContext.SaveChanges();

        }

        public void Delete(int songId)
        {
            var songs = _dbContext.Songs.Single(p => p.SongId == songId);
            _dbContext.Remove(songs);
            _dbContext.SaveChanges();
        }
    }
}
