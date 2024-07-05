using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.Results;
using BlazorAuthAPI.Core.User;
using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.Entities;
using BlazorAuthAPI.Core.User.QueryCommand;
using BlazorAuthAPI.Core.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUserService userService, AppDbContext context, ICurrentUser currentUser) : ControllerBase
    {
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<LoginResult>> Create([FromBody] AddNewUserCommand userRequest)
        {
            var body = await userService.CreateAsync(userRequest);
            var loginResult = new LoginResult(body);
            return Ok(loginResult);
        }

        [Authorize]
        [HttpDelete("{id:Guid}", Name = "DeleteUserById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!currentUser.IsAuthenticated || !currentUser.IsAdmin)
                return Unauthorized();

            await userService.DeleteAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet(Name = "FindAllUsers")]
        public async Task<ActionResult<List<User>>> Get([FromQuery] UserQueryCommand? queryCommand)
        {
            if (!currentUser.IsAuthenticated || !currentUser.IsAdmin)
                return Unauthorized();

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

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            await userService.ChangePasswordAsync(currentUser.UserId, command);

            return NoContent();
        }
    }
}
