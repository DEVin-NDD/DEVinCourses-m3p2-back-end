
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;


namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UsersController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
                
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            [FromBody] UserDTO changedUser,
            [FromRoute] int id
        )
        {
            _userService.Update(changedUser, id);

            return NoContent();
        }
    
        [HttpPost]
        public IActionResult Post(
            [FromBody] UserDTO newUser
        )
        {
            _userService.InsertUser(newUser);

            return Created("registration", newUser.Id);
        }

   
        [HttpGet]
        [Route("{token}")]
        public IActionResult GetUser([FromRoute] string token)

        { 
            return Ok(_userService.GetUser(token));
        }


        [HttpPost]
        [Route("reset")]
        public IActionResult Reset([FromBody] string emailReset)
        {
            var reset = _userService.Reset(emailReset);

            return Ok(reset);
        }

        [HttpPost]
        [Route("token")]
        public IActionResult VerifyToken([FromBody] string emailReset, string password)
        {
            var reset = _userService.VerifyToken(emailReset,password);

            return Ok(reset);
        }
    }
}