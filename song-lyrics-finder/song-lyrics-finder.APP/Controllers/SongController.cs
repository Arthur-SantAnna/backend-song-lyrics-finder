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


        [HttpGet]
        public ActionResult GetSongs(string nickname)
        {
            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAll();
            int? userId = 0;
            foreach (User user in users)
            {
                if (user.Nickname == nickname)
                {
                    userId = user.UserId;
                }
            }

            UserSongRepository userSongRepository = new UserSongRepository();
            List<UserSong> userSongs = userSongRepository.GetAll();
            List<int?> songIds = new List<int?>();
            foreach (UserSong userSong in userSongs)
            {
                if (userSong.UserId == userId)
                {
                    songIds.Add(userSong.SongId);
                }
            }

            List<int> songApiIds = new List<int>();
            foreach (int? songId in songIds)
            {
                songApiIds.Add(_songRepository.GetById(songId.Value).SongApiId);
            }

            return Ok(songApiIds);
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

            List<Song> songs = _songRepository.GetAll();

            foreach (Song song in songs)
            {
                if (song.SongApiId == tempSong.SongApiId)
                {
                    return StatusCode(409);
                }
            }

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
