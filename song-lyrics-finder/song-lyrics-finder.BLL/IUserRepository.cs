using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.BLL
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        List<User> GetAll();
        User GetById(int id);
        void Update(User user);
    }
}