using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public class ClaimService
    {
        public Guid UserId { get; set; }

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Guid.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Sid)?.Value);
            return;
        }
    }
}
