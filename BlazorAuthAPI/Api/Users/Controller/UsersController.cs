using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Api.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuthAPI.Api.Users.Controller
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost(Name = "CreateUser")]
        public IActionResult Create([FromForm]UserRequest userRequest)
        {
            var body = userService.Create(userRequest);

            return Created($"/api/users/{body.Id}", body);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteUserById")]
        public IActionResult Delete(Guid id)
        {
            userService.Delete(id);
            return NoContent();
        }

        [HttpGet(Name = "FindAllUsers")]
        public IActionResult FindAll()
        {
            var users = userService.FindAll();
            return Ok(users);
        }
    }
}
