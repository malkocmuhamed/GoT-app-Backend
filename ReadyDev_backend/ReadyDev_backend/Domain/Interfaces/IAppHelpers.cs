using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Interfaces
{
    public interface IAppHelpers
    {
        public int getUserIdClaim(HttpContext httpContext);
    }
}
