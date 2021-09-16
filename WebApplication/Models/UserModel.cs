using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid? RoleId { get; set; }
        public RoleModel Role { get; set; }

        public StatusType Status { get; set; }

        public List<WeatherModel> Weathers { get; set; }
        public List<TokenModel> Tokens { get; set; }
        public UserModel()
        {
            Weathers = new List<WeatherModel>();
            Tokens = new List<TokenModel>();
        }
    }

    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; }
        public RoleModel()
        {
            Users = new List<UserModel>();
        }
    }

    public enum StatusType
    {
        Uncomfirmed,
        Confirmed
    }

}
