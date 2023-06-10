using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.BLL
{
    public interface ISongRepository
    {
        void Add(Song song);
        void Delete(int songId);
        List<Song> GetAll();
        Song GetById(int id);
        void Update(Song song);
    }
}