using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.Shared.Extensions;

public static class StringExtensions
{
    public static bool HasOnlyNumbers(this string value)
    {
        return !string.IsNullOrEmpty(value) && value.All(v => v is >= '0' and <= '9');
    }

    public static string FirstLetterToLower(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        return value.Length == 1 ? value.ToLower() : $"{char.ToLower(value[0])}{value[1..]}";
    }
}

