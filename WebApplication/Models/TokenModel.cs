using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class TokenModel
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public bool IsValid { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

    }
}
