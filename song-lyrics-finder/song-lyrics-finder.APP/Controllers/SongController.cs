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
        public ActionResult AddSong(CreateSong createSong)
        {
            var song = new Song()
            {
                SongApiId = createSong.SongApiId
            };
           
            _songRepository.Add(song);
            return Ok(createSong);
        }

        [HttpDelete("{songId}")]
        public ActionResult DeleteSong(int songId)
        {
            _songRepository.Delete(songId);
            return Ok();
        }
    }
}
