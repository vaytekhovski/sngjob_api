using System;
using Microsoft.AspNetCore.Mvc;
using SNGJOB.Services;
using Microsoft.AspNetCore.Authorization;
using SNGJOB.Models.UserModels;

namespace SNGJOB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private LoginManager LoginManager;
        private UserManager UserManager;

        public AccountController(LoginManager loginManager, UserManager userManager)
        {
            LoginManager = loginManager;
            UserManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult auth([FromBody]User user)
        {
            User Login = user;
            IActionResult response = Unauthorized();

            var User = LoginManager.AuthenticateUser(Login);

            if(User != null)
            {
                var token = LoginManager.GetJSONWebToken(User);
                response = Ok(new { id = User.id, token = token });
            }
            else
            {
                response = NotFound(new { response = "Incorrect user name or password" });
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult create([FromBody]User user)
        {
            User Login = user;
            IActionResult response = Unauthorized();

            var User = LoginManager.CreateUser(Login);
            if (User != null)
            {
                var token = LoginManager.GetJSONWebToken(User);
                response = Ok(new { id = User.id, token = token });
            }
            else
            {
                response = BadRequest(new { response = "User with same Email address is exist" });
            }
            return response;
        }

        [HttpPost("{UserId}/edit")]
        public IActionResult changeUserData(Guid UserId, [FromBody]UserDetail userData)
        {

            IActionResult response = Unauthorized();
            var responseStatus = UserManager.ChangeUserData(UserId, userData);

            switch (responseStatus)
            {
                case "404":
                    response = NotFound();
                    break;
                case "200":
                    response = Ok(new { response = $"User data for User {UserId} changed " });
                    break;

                default:
                    break;
            }

            return response;
        }
        [AllowAnonymous]

        [HttpPost("{email}/recoverpassword")]
        public IActionResult recoverPassword(string email)
        {
            return Ok(new { recover_token = LoginManager.RecoverPassword(email) });
        }
        [AllowAnonymous]
        [HttpGet("{email}/recoverpassword")]
        public IActionResult RecoverToken(string email)
        {
            return Ok(new { recover_token = LoginManager.GetRecoverToken(email) });
        }
        [AllowAnonymous]
        [HttpPost("{email}/verifyemail")]
        public IActionResult verifyEmail(string email)
        {
            return Ok(new { verify_token = LoginManager.EmailConfirm(email) });
        }
        [AllowAnonymous]
        [HttpGet("{email}/verifyemail")]
        public IActionResult verifyToken(string email)
        {
            return Ok(new { recover_token = LoginManager.GetVerifyToken(email) });
        }


    }
}