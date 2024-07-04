using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.Shared
{
    public static class EnumHelper
    {
        public static IEnumerable<TEnum> GetValues<TEnum>()
            where TEnum : Enum
        {
            return Enum
                .GetValues(typeof(TEnum))
                .Cast<TEnum>();
        }
    }
}
