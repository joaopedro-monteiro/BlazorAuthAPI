using BlazorAuthAPI.Core.User.Dtos;
using BlazorAuthAPI.Core.User.Entities;
using BlazorAuthAPI.Core.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuthAPI.Api.Users.Controller
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<User>> Create(UserRequest userRequest)
        {
            var body = await userService.Create(userRequest);

            return Ok(body);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteUserById")]
        public IActionResult Delete(Guid id)
        {
            userService.Delete(id);
            return NoContent();
        }

        [HttpGet(Name = "FindAllUsers")]
        public async Task<ActionResult> FindAll()
        {
            var users = await userService.FindAll();
            return Ok(users);
        }
    }
}
