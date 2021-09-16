using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Services
{
    public class UserService
    {
        WeatherContext _context;
        public UserService(WeatherContext context)
        {
            _context = context;
        }
       //public DbHandler(IHttpContextAccessor httpContextAccessor)
       // {
       //     httpContextAccessor.HttpContext.User.Claims
       // }


        public async Task DeleteUser(Guid userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception e) { }
            return;
        }

        public async Task<UserModel> GetUser(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public async Task<UserModel> GetUserWithRolebyEmail(string userEmail)
        {
            return await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<UserModel> GetUserWithRoles(Guid userId)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }
        public async Task<UserModel> GetUserWithWeathers(Guid userId)
        {
            return await _context.Users.Include(u => u.Weathers).FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public async Task<List<UserModel>> GetUsersList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<UserModel>> GetAdminUsersList(Guid userId)
        {
            return await _context.Users.Include(u => u.Weathers).Where(u => !u.Id.Equals(userId)).ToListAsync();
        }

        public async Task<UserModel> GetFullUser(Guid userId)
        {
            return await _context.Users.Include(u => u.Role).Include(u => u.Weathers).FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public async Task<List<RoleModel>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<UserModel> GetUserByEmail(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async void SaveUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<RoleModel> GetRoleUser()
        {
            return await _context.Roles.FirstOrDefaultAsync(r =>r.Name == Constants.User);
            //_context.Roles.Where(r => r.Name == Constants.User).Select(i => new { i.Id }).FirstOrDefaultAsync()
        }

        public async Task<bool> IsAnyEmail(string userEmail)
        {
            return await _context.Users.AnyAsync(i => i.Email == userEmail);
        }

        public async Task UpdateUser(UserModel model)
        {
            await _context.SaveChangesAsync();
            return;
        }

    }
}
