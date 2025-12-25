using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.UserRegisterCommads;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommadHandler _createUserRegisterCommadHandler;
        public RegistersController(CreateUserRegisterCommadHandler createUserRegisterCommadHandler)
        {
            _createUserRegisterCommadHandler = createUserRegisterCommadHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserResgister(CreateUserRegisterCommad command)
        {
            await _createUserRegisterCommadHandler.Handle(command);
            return Ok("User registered successfully.");
        }
    }
}
