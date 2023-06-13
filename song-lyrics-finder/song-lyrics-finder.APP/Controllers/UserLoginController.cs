using Microsoft.AspNetCore.Mvc;
using song_lyrics_finder.BLL;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.APP.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserLoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult AuthenticateUser(AuthenticateUser authenticateUser)
        {
            var tempUser = new User()
            {
                Nickname = authenticateUser.Nickname,
                Password = authenticateUser.Password
            };

            List<User> users = _userRepository.GetAll();

            foreach (User user in users)
            {
                if (user.Nickname == tempUser.Nickname && user.Password == tempUser.Password)
                {
                    return Ok(authenticateUser);
                }
            }

            return StatusCode(401);
        }
    }
}
