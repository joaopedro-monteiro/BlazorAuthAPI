using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.Results;
using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.Entities;
using BlazorAuthAPI.Core.User.QueryCommand;
using BlazorAuthAPI.Core.User.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUserService userService, AppDbContext context) : ControllerBase
    {
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<User>> Create([FromBody]AddNewUserCommand userRequest)
        {
            var body = await userService.CreateAsync(userRequest);

            return Ok(body);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteUserById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(Name = "FindAllUsers")]
        public async Task<ActionResult<List<User>>> Get([FromQuery] UserQueryCommand? queryCommand)
        {
            queryCommand ??= new UserQueryCommand();

            var queryable = queryCommand.ApplyFilter(context.Users);
            var users = await queryable.ToListAsync();

            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login([FromBody] LoginCommand command)
        {
            var result = await userService.LoginAsync(command);

            return Ok(result);
        }

        [HttpPut("{userId:guid}/change-password")]
        public async Task<IActionResult> ChangePassword(Guid userId, [FromBody] ChangePasswordCommand command)
        {
            await userService.ChangePasswordAsync(userId, command);

            return NoContent();
        }
    }
}
