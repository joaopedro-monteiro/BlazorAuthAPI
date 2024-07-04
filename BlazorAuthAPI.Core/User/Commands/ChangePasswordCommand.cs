using BlazorAuthAPI.Core.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.User.Commands
{
    public class ChangePasswordCommand
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        //public string? PasswordHashed => string.IsNullOrEmpty(NewPassword) ? null : PasswordHelper.HashPassword(NewPassword);
    }
}
