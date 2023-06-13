using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using song_lyrics_finder.BLL;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.APP.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepository;

        public SongController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpPost]
        public ActionResult AddSong(CreateUserSong createUserSong)
        {
            Song tempSong = new Song()
            {
                SongApiId = createUserSong.SongApiId
            };

            User tempUser = new User()
            {
                Nickname = createUserSong.Nickname
            };

            _songRepository.Add(tempSong);

            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAll();
            var currentUserId = 0;
            foreach (User user in users )
            {
                if(user.Nickname == tempUser.Nickname)
                {
                    currentUserId = user.UserId;
                }
            }

            List<Song> songs = _songRepository.GetAll();
            var currentSongId = 0;
            foreach (Song song in songs)
            {
                if (song.SongApiId== tempSong.SongApiId)
                {
                    currentSongId = song.SongId;
                }
            }

            UserSongRepository userSongRepository = new UserSongRepository();

            UserSong userSong = new UserSong();

            userSong.UserId = currentUserId;
            userSong.SongId = currentSongId;

            userSongRepository.Add(userSong);

            return Ok(createUserSong);
        }

        [HttpDelete("{songId}")]
        public ActionResult DeleteSong(int songId)
        {
            _songRepository.Delete(songId);
            return Ok();
        }
    }
}
