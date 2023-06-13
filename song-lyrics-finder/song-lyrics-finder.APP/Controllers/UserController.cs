using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using song_lyrics_finder.BLL;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.APP.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult AddUser(CreateUser createUser)
        {
            var tempUser = new User()
            {
                Name = createUser.Name,
                Email = createUser.Email,
                Nickname = createUser.Nickname,
                Password = createUser.Password
            };

            List<User> users = _userRepository.GetAll();

            foreach (User user in users)
            {
                if (user.Nickname == tempUser.Nickname)
                {
                    return StatusCode(409);
                }
            }

            _userRepository.Add(tempUser);

            return Ok(createUser);
        }
    }
}
