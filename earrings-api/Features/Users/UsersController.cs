using EarringsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using EarringsApi.Features.Users.Models;

namespace EarringsApi.Features.Users
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersRepository usersRepository;
        public UsersController()
        {
            usersRepository = new UsersRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] UserFilter filter)
        {
            filter.BringPassword = false;

            List<UserDto> notes = await usersRepository.GetUsers(filter);

            return Ok(notes);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginExecution>> Login([FromBody] LoginSession loginSession)
        {
            LoginExecution loginExecution = await usersRepository.Login(loginSession);

            return Ok(loginExecution);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<Execution>> SignUp([FromBody] SignUpSession signUpSession)
        {
            Execution execution = await usersRepository.SignUp(signUpSession);

            return execution;
        }

    }
}
