using Newtonsoft.Json;
using Quik.Framework.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Quik.Framework.Models
{
    public class UserCookieHelper
    {
        public static LoginUserDto CookieParse(IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                var cookie = claims.Claims.FirstOrDefault(x => x.Type == "quickUser");
                if (cookie != null && cookie.Value != null)
                {
                    var ucookie = JsonConvert.DeserializeObject<LoginUserDto>(cookie.Value);
                    return ucookie;
                }

                return null;
            }
            return null;
            //throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}
