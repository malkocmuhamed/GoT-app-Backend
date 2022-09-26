using Microsoft.AspNetCore.Http;
using ReadyDev_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Services
{
    public class AppHelpers: IAppHelpers
    {
        public int getUserIdClaim(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                return Convert.ToInt32(identity.FindFirst("userId").Value);
            }
            return -1;
        }
    }
}
